using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_IOStream
{
    public partial class Bai05 : Form
    {
        private const int SO_GHE_MOI_PHONG = 15; // 3 hàng (A-C) x 5 ghế

        private readonly string duongDanInput = Path.Combine(AppContext.BaseDirectory, "input5.txt");
        private readonly string duongDanOutput = Path.Combine(AppContext.BaseDirectory, "output5.txt");

        private static readonly JsonSerializerOptions tuyChonJson = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        private List<Phim> dsPhim = new List<Phim>();

        public Bai05()
        {
            InitializeComponent();
        }

        private double GetHeSo(string ghe)
        {
            if (ghe == "A1" || ghe == "A5" || ghe == "C1" || ghe == "C5") return 0.25;
            if (ghe == "B2" || ghe == "B3" || ghe == "B4") return 2.0;
            return 1.0;
        }

        // Nút "Thêm phim": nhập thông tin 1 phim và thêm vào danh sách
        private void btnThemPhim_Click(object sender, EventArgs e)
        {
            string tenPhim = txtTenPhim.Text.Trim();
            if (tenPhim.Length == 0)
            {
                MessageBox.Show("Tên phim không được để trống!");
                txtTenPhim.Focus();
                return;
            }

            if (!double.TryParse(txtGiaChuan.Text.Trim().Replace(',', '.'), NumberStyles.Float,
                                 CultureInfo.InvariantCulture, out double giaChuan) || giaChuan <= 0)
            {
                MessageBox.Show("Giá vé chuẩn phải là số lớn hơn 0!");
                txtGiaChuan.Focus();
                return;
            }

            List<int> phongChieu = new List<int>();
            foreach (string phan in txtPhongChieu.Text.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                if (!int.TryParse(phan, out int phong) || phong <= 0)
                {
                    MessageBox.Show("Phòng chiếu phải là các số nguyên dương, cách nhau bởi dấu phẩy (vd: 1,2,3)!");
                    txtPhongChieu.Focus();
                    return;
                }
                phongChieu.Add(phong);
            }
            if (phongChieu.Count == 0)
            {
                MessageBox.Show("Hãy nhập ít nhất 1 phòng chiếu!");
                txtPhongChieu.Focus();
                return;
            }

            List<string> veDaBan = new List<string>();
            foreach (string phan in txtVeDaBan.Text.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                string ghe = phan.ToUpperInvariant();
                if (!Regex.IsMatch(ghe, "^[A-C][1-5]$"))
                {
                    MessageBox.Show("Ghế \"" + phan + "\" không hợp lệ! Ghế gồm hàng A-C và số 1-5 (vd: A1,B2,C5).");
                    txtVeDaBan.Focus();
                    return;
                }
                if (!veDaBan.Contains(ghe)) veDaBan.Add(ghe);
            }

            if (veDaBan.Count > phongChieu.Count * SO_GHE_MOI_PHONG)
            {
                MessageBox.Show("Số vé đã bán vượt quá tổng số ghế của các phòng chiếu!");
                txtVeDaBan.Focus();
                return;
            }

            dsPhim.Add(new Phim
            {
                TenPhim = tenPhim,
                GiaChuan = giaChuan,
                PhongChieu = phongChieu,
                VeDaBan = veDaBan
            });

            txtTenPhim.Clear(); txtGiaChuan.Clear(); txtPhongChieu.Clear(); txtVeDaBan.Clear();
            txtTenPhim.Focus();
            HienThiDanhSach();
        }

        // Nút "Ghi input5.txt": ghi danh sách phim (JSON) thành file
        private void btnGhiInput_Click(object sender, EventArgs e)
        {
            if (dsPhim.Count == 0)
            {
                MessageBox.Show("Chưa có phim nào. Hãy thêm phim hoặc đọc file trước!");
                return;
            }

            try
            {
                File.WriteAllText(duongDanInput, JsonSerializer.Serialize(dsPhim, tuyChonJson));
                MessageBox.Show("Đã ghi " + dsPhim.Count + " phim vào:\n" + duongDanInput);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message);
            }
        }

        // Nút "ĐỌC FILE": đọc input5.txt (nếu không có thì cho chọn file khác)
        private void btnReadFile_Click(object sender, EventArgs e)
        {
            string duongDan = duongDanInput;
            if (!File.Exists(duongDan))
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt",
                    InitialDirectory = AppContext.BaseDirectory
                };
                if (ofd.ShowDialog() != DialogResult.OK) return;
                duongDan = ofd.FileName;
            }

            try
            {
                string json = File.ReadAllText(duongDan);
                List<Phim>? ds = JsonSerializer.Deserialize<List<Phim>>(json);

                if (ds == null || ds.Count == 0)
                {
                    MessageBox.Show("File không có phim nào!");
                    return;
                }

                dsPhim = ds;
                HienThiDanhSach();
                MessageBox.Show("Đã đọc " + dsPhim.Count + " phim từ file dữ liệu!");
            }
            catch (Exception)
            {
                MessageBox.Show("File không đúng cấu trúc dữ liệu phim!");
            }
        }

        // Nút "GHI THỐNG KÊ": xuất thống kê theo phim ra output5.txt, có ProgressBar
        private async void btnGhiFile_Click(object sender, EventArgs e)
        {
            if (dsPhim.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu phim. Hãy đọc file hoặc thêm phim trước!");
                return;
            }

            var thongKe = dsPhim.Select(p =>
            {
                int tongGhe = p.PhongChieu.Count * SO_GHE_MOI_PHONG;
                int veBan = p.VeDaBan.Count;
                int veTon = tongGhe - veBan;
                double tiLe = tongGhe == 0 ? 0 : (double)veBan / tongGhe * 100;
                double doanhThu = p.VeDaBan.Sum(ghe => p.GiaChuan * GetHeSo(ghe));
                return new { p.TenPhim, veBan, veTon, tiLe, doanhThu };
            }).OrderByDescending(x => x.doanhThu).ToList();

            btnGhiFile.Enabled = false;
            btnReadFile.Enabled = false;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = thongKe.Count;
            progressBar1.Value = 0;

            try
            {
                using (StreamWriter sw = new StreamWriter(duongDanOutput, false))
                {
                    for (int i = 0; i < thongKe.Count; i++)
                    {
                        var item = thongKe[i];
                        sw.WriteLine($"Tên phim: {item.TenPhim}");
                        sw.WriteLine($"Số lượng vé bán ra: {item.veBan}");
                        sw.WriteLine($"Số lượng vé tồn: {item.veTon}");
                        sw.WriteLine($"Tỷ lệ vé bán ra: {item.tiLe:F2}%");
                        sw.WriteLine($"Doanh thu: {item.doanhThu:N0} VNĐ");
                        sw.WriteLine($"Xếp hạng doanh thu: {i + 1}");
                        sw.WriteLine("------------------------------------------");

                        progressBar1.Value = i + 1;
                        await Task.Delay(300); // làm chậm lại để nhìn thấy ProgressBar chạy
                    }
                }

                rtbContent.Text = File.ReadAllText(duongDanOutput);
                MessageBox.Show("Đã xuất file thống kê thành công:\n" + duongDanOutput);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message);
            }
            finally
            {
                btnGhiFile.Enabled = true;
                btnReadFile.Enabled = true;
            }
        }

        private void HienThiDanhSach()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Phim p in dsPhim)
            {
                sb.AppendLine("Tên phim: " + p.TenPhim);
                sb.AppendLine("Giá vé chuẩn: " + p.GiaChuan.ToString("N0"));
                sb.AppendLine("Phòng chiếu: " + string.Join(", ", p.PhongChieu));
                sb.AppendLine("Vé đã bán: " + string.Join(", ", p.VeDaBan));
                sb.AppendLine("------------------------------------------");
            }
            rtbContent.Text = sb.ToString();
        }
    }

    public class Phim
    {
        public string TenPhim { get; set; } = "";
        public double GiaChuan { get; set; }
        public List<int> PhongChieu { get; set; } = new List<int>();
        public List<string> VeDaBan { get; set; } = new List<string>();
    }
}
