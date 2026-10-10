using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab2_IOStream
{
    public partial class Bai04 : Form
    {
        private readonly string duongDanInput = Path.Combine(AppContext.BaseDirectory, "input4.txt");
        private readonly string duongDanOutput = Path.Combine(AppContext.BaseDirectory, "output4.txt");

        private static readonly JsonSerializerOptions tuyChonJson = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        private List<SinhVien> dsNhap = new List<SinhVien>();
        private List<SinhVien> dsDoc = new List<SinhVien>();
        private int viTriHienTai = 0;

        public Bai04()
        {
            InitializeComponent();
            Average.ReadOnly = true; // điểm trung bình không nhập tay
        }

        // Nút "Add": kiểm tra dữ liệu rồi thêm vào danh sách sinh viên
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ten = txtName.Text.Trim();
            if (ten.Length == 0)
            {
                MessageBox.Show("Họ và tên không được để trống!");
                txtName.Focus();
                return;
            }
            if (!Regex.IsMatch(ID.Text.Trim(), @"^\d{8}$"))
            {
                MessageBox.Show("Mã số sinh viên phải là số có đúng 8 chữ số!");
                ID.Focus();
                return;
            }
            if (!Regex.IsMatch(Phone.Text.Trim(), @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0!");
                Phone.Focus();
                return;
            }
            if (!TryDocDiem(C1.Text, out float diem1))
            {
                MessageBox.Show("Điểm môn 1 phải là số từ 0 đến 10!");
                C1.Focus();
                return;
            }
            if (!TryDocDiem(C2.Text, out float diem2))
            {
                MessageBox.Show("Điểm môn 2 phải là số từ 0 đến 10!");
                C2.Focus();
                return;
            }
            if (!TryDocDiem(C3.Text, out float diem3))
            {
                MessageBox.Show("Điểm môn 3 phải là số từ 0 đến 10!");
                C3.Focus();
                return;
            }

            SinhVien sv = new SinhVien
            {
                Name = ten,
                ID = int.Parse(ID.Text.Trim()),
                Phone = Phone.Text.Trim(),
                Course1 = diem1,
                Course2 = diem2,
                Course3 = diem3
            };
            dsNhap.Add(sv);

            rtbContent.AppendText($"{sv.Name}\n{sv.ID}\n{sv.Phone}\n{sv.Course1}\n{sv.Course2}\n{sv.Course3}\n\n");

            txtName.Clear(); ID.Clear(); Phone.Clear();
            C1.Clear(); C2.Clear(); C3.Clear(); Average.Clear();
            txtName.Focus();
        }

        // Nút "Write to a File": ghi mảng sinh viên (JSON) xuống input4.txt
        private void btnWriteaFile_Click(object sender, EventArgs e)
        {
            if (dsNhap.Count == 0)
            {
                MessageBox.Show("Chưa có sinh viên nào. Hãy nhập thông tin rồi bấm Add!");
                return;
            }

            try
            {
                File.WriteAllText(duongDanInput, JsonSerializer.Serialize(dsNhap, tuyChonJson));
                MessageBox.Show("Đã lưu " + dsNhap.Count + " sinh viên vào:\n" + duongDanInput);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message);
            }
        }

        // Nút "Button to read a File": đọc input4.txt, tính điểm TB, ghi output4.txt, hiển thị
        private void button3_Click(object sender, EventArgs e)
        {
            if (!File.Exists(duongDanInput))
            {
                MessageBox.Show("Không tìm thấy file:\n" + duongDanInput);
                return;
            }

            try
            {
                string json = File.ReadAllText(duongDanInput);
                List<SinhVien>? ds = JsonSerializer.Deserialize<List<SinhVien>>(json);

                if (ds == null || ds.Count == 0)
                {
                    MessageBox.Show("File input4.txt không có sinh viên nào!");
                    return;
                }

                foreach (SinhVien sv in ds)
                {
                    sv.Average = (sv.Course1 + sv.Course2 + sv.Course3) / 3;
                }
                dsDoc = ds;

                File.WriteAllText(duongDanOutput, JsonSerializer.Serialize(dsDoc, tuyChonJson));

                viTriHienTai = 0;
                HienThiSinhVien(viTriHienTai);
                MessageBox.Show("Đã đọc " + dsDoc.Count + " sinh viên và ghi kết quả vào:\n" + duongDanOutput);
            }
            catch (Exception)
            {
                MessageBox.Show("File input4.txt không đúng cấu trúc dữ liệu sinh viên!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (dsDoc.Count > 0 && viTriHienTai > 0)
            {
                viTriHienTai--;
                HienThiSinhVien(viTriHienTai);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dsDoc.Count > 0 && viTriHienTai < dsDoc.Count - 1)
            {
                viTriHienTai++;
                HienThiSinhVien(viTriHienTai);
            }
        }

        private void HienThiSinhVien(int viTri)
        {
            if (dsDoc.Count == 0) return;

            SinhVien sv = dsDoc[viTri];
            Name1.Text = sv.Name;
            ID1.Text = sv.ID.ToString();
            Phone1.Text = sv.Phone;
            C11.Text = sv.Course1.ToString(CultureInfo.InvariantCulture);
            C21.Text = sv.Course2.ToString(CultureInfo.InvariantCulture);
            C31.Text = sv.Course3.ToString(CultureInfo.InvariantCulture);
            Average1.Text = sv.Average.ToString("0.00", CultureInfo.InvariantCulture);
            PageNumber.Text = (viTri + 1).ToString();
        }

        // Chấp nhận cả "7.5" lẫn "7,5"; điểm phải nằm trong [0, 10]
        private static bool TryDocDiem(string text, out float diem)
        {
            string chuan = text.Trim().Replace(',', '.');
            return float.TryParse(chuan, NumberStyles.Float, CultureInfo.InvariantCulture, out diem)
                   && diem >= 0 && diem <= 10;
        }
    }

    public class SinhVien
    {
        public string Name { get; set; } = "";
        public int ID { get; set; }
        public string Phone { get; set; } = "";
        public float Course1 { get; set; }
        public float Course2 { get; set; }
        public float Course3 { get; set; }
        public float Average { get; set; }
    }
}
