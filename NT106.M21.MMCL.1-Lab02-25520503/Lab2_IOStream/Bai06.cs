using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Lab2_IOStream
{
    public partial class Bai06 : Form
    {
        // CSDL SQLite nằm cạnh file .exe; lần chạy đầu tiên sẽ tự tạo bảng + nhập dữ liệu mẫu
        private readonly string duongDanDb = Path.Combine(AppContext.BaseDirectory, "QuanLyMonAn.db");

        private const string CAU_TRUY_VAN_MON_AN =
            @"SELECT m.IDMA, m.TenMonAn, m.HinhAnh, n.HoVaTen
              FROM MonAn m
              INNER JOIN NguoiDung n ON m.IDNCC = n.IDNCC";

        public Bai06()
        {
            InitializeComponent();
            InitListView();

            try
            {
                KhoiTaoCoSoDuLieu();
                LoadDanhSachMonAn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL SQLite: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SqliteConnection MoKetNoi()
        {
            SqliteConnection conn = new SqliteConnection("Data Source=" + duongDanDb);
            conn.Open();
            return conn;
        }

        private void InitListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.Columns.Add("ID", 45);
            listView1.Columns.Add("Tên món ăn", 140);
            listView1.Columns.Add("Người đóng góp", 125);
        }

        // Tạo bảng MonAn, NguoiDung và nhập dữ liệu mẫu nếu CSDL còn trống
        private void KhoiTaoCoSoDuLieu()
        {
            using (SqliteConnection conn = MoKetNoi())
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS NguoiDung (
                              IDNCC    INTEGER PRIMARY KEY,
                              HoVaTen  TEXT NOT NULL,
                              QuyenHan TEXT
                          );
                          CREATE TABLE IF NOT EXISTS MonAn (
                              IDMA     INTEGER PRIMARY KEY,
                              TenMonAn TEXT NOT NULL,
                              HinhAnh  TEXT,
                              IDNCC    INTEGER NOT NULL,
                              FOREIGN KEY (IDNCC) REFERENCES NguoiDung(IDNCC)
                          );";
                    cmd.ExecuteNonQuery();
                }

                long soMonAn;
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM MonAn";
                    soMonAn = (long)cmd.ExecuteScalar()!;
                }
                if (soMonAn > 0) return;

                using (SqliteTransaction tran = conn.BeginTransaction())
                {
                    (int id, string hoTen, string quyen)[] dsNguoiDung =
                    {
                        (1, "Nguyễn Văn A", "Admin"),
                        (2, "Trần Thị B", "User"),
                        (3, "Lê Văn C", "User")
                    };
                    foreach (var nd in dsNguoiDung)
                    {
                        ThemNguoiDung(conn, tran, nd.id, nd.hoTen, nd.quyen);
                    }

                    (int id, string ten, string hinh, int idncc)[] dsMonAn =
                    {
                        (1, "Phở bò", "Images/pho_bo.png", 1),
                        (2, "Bún chả", "Images/bun_cha.png", 2),
                        (3, "Cơm tấm", "Images/com_tam.png", 3),
                        (4, "Bánh mì", "Images/banh_mi.png", 1),
                        (5, "Mì Quảng", "Images/mi_quang.png", 2),
                        (6, "Gỏi cuốn", "Images/goi_cuon.png", 3),
                        (7, "Bún bò Huế", "Images/bun_bo_hue.png", 1),
                        (8, "Hủ tiếu", "Images/hu_tieu.png", 2)
                    };
                    foreach (var mon in dsMonAn)
                    {
                        ThemMonAn(conn, tran, mon.id, mon.ten, mon.hinh, mon.idncc);
                    }

                    tran.Commit();
                }
            }
        }

        private static void ThemNguoiDung(SqliteConnection conn, SqliteTransaction tran, int id, string hoTen, string quyen)
        {
            using (SqliteCommand cmd = conn.CreateCommand())
            {
                cmd.Transaction = tran;
                cmd.CommandText = "INSERT OR IGNORE INTO NguoiDung (IDNCC, HoVaTen, QuyenHan) VALUES ($id, $ten, $quyen)";
                cmd.Parameters.AddWithValue("$id", id);
                cmd.Parameters.AddWithValue("$ten", hoTen);
                cmd.Parameters.AddWithValue("$quyen", quyen);
                cmd.ExecuteNonQuery();
            }
        }

        private static void ThemMonAn(SqliteConnection conn, SqliteTransaction tran, int id, string ten, string hinh, int idncc)
        {
            using (SqliteCommand cmd = conn.CreateCommand())
            {
                cmd.Transaction = tran;
                cmd.CommandText = "INSERT OR IGNORE INTO MonAn (IDMA, TenMonAn, HinhAnh, IDNCC) VALUES ($id, $ten, $hinh, $idncc)";
                cmd.Parameters.AddWithValue("$id", id);
                cmd.Parameters.AddWithValue("$ten", ten);
                cmd.Parameters.AddWithValue("$hinh", hinh);
                cmd.Parameters.AddWithValue("$idncc", idncc);
                cmd.ExecuteNonQuery();
            }
        }

        private static MonAnView DocMonAn(SqliteDataReader reader)
        {
            return new MonAnView
            {
                IDMA = reader.GetInt32(0),
                TenMonAn = reader.GetString(1),
                HinhAnh = reader.IsDBNull(2) ? "" : reader.GetString(2),
                NguoiDongGop = reader.GetString(3)
            };
        }

        // Đọc toàn bộ danh sách món ăn từ CSDL và hiển thị lên ListView
        private void LoadDanhSachMonAn()
        {
            listView1.Items.Clear();

            using (SqliteConnection conn = MoKetNoi())
            using (SqliteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = CAU_TRUY_VAN_MON_AN + " ORDER BY m.IDMA";
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MonAnView mon = DocMonAn(reader);

                        ListViewItem item = new ListViewItem(mon.IDMA.ToString());
                        item.SubItems.Add(mon.TenMonAn);
                        item.SubItems.Add(mon.NguoiDongGop);
                        item.Tag = mon;
                        listView1.Items.Add(item);
                    }
                }
            }
        }

        // Nút Random: truy vấn SQLite chọn ngẫu nhiên 1 món (ORDER BY RANDOM())
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MonAnView? mon = null;
                using (SqliteConnection conn = MoKetNoi())
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = CAU_TRUY_VAN_MON_AN + " ORDER BY RANDOM() LIMIT 1";
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) mon = DocMonAn(reader);
                    }
                }

                if (mon == null)
                {
                    MessageBox.Show("Chưa có dữ liệu món ăn.");
                    return;
                }

                HienThiMonAn(mon);
                ChonDongTrongDanhSach(mon.IDMA);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL SQLite: " + ex.Message);
            }
        }

        // Chọn 1 dòng trong ListView cũng hiện thông tin + hình
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            if (listView1.SelectedItems[0].Tag is MonAnView mon) HienThiMonAn(mon);
        }

        private void ChonDongTrongDanhSach(int idMonAn)
        {
            listView1.SelectedIndexChanged -= listView1_SelectedIndexChanged;
            foreach (ListViewItem item in listView1.Items)
            {
                bool dungMon = item.Tag is MonAnView m && m.IDMA == idMonAn;
                item.Selected = dungMon;
                if (dungMon) item.EnsureVisible();
            }
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        }

        private void HienThiMonAn(MonAnView mon)
        {
            label1.Text = "Món ăn: " + mon.TenMonAn;
            label2.Text = "Người đóng góp: " + mon.NguoiDongGop;

            Image? cu = pictureBox1.Image;
            pictureBox1.Image = null;
            cu?.Dispose();

            string? duongDan = TimFileAnh(mon.HinhAnh);
            if (duongDan == null) return;

            try
            {
                // Đọc qua MemoryStream để không khóa file ảnh
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(duongDan)))
                using (Image img = Image.FromStream(ms))
                {
                    pictureBox1.Image = new Bitmap(img);
                }
            }
            catch (Exception)
            {
                pictureBox1.Image = null;
            }
        }

        // Hỗ trợ cả đường dẫn tuyệt đối lẫn tương đối (so với thư mục chạy chương trình)
        private static string? TimFileAnh(string hinhAnh)
        {
            if (string.IsNullOrWhiteSpace(hinhAnh)) return null;
            if (File.Exists(hinhAnh)) return hinhAnh;

            string theoThuMucChay = Path.Combine(AppContext.BaseDirectory, hinhAnh);
            return File.Exists(theoThuMucChay) ? theoThuMucChay : null;
        }
    }

    public class MonAnView
    {
        public int IDMA { get; set; }
        public string TenMonAn { get; set; } = "";
        public string HinhAnh { get; set; } = "";
        public string NguoiDongGop { get; set; } = "";
    }
}
