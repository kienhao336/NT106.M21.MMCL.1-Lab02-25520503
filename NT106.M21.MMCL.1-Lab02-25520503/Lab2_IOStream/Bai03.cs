using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Lab2_IOStream
{
    public partial class Bai03 : Form
    {
        private readonly string duongDanInput = Path.Combine(AppContext.BaseDirectory, "input3.txt");
        private readonly string duongDanOutput = Path.Combine(AppContext.BaseDirectory, "output3.txt");
        private readonly BoTinhToan boTinhToan = new BoTinhToan();

        public Bai03()
        {
            InitializeComponent();
        }

        // ĐỌC FILE: đọc input3.txt, tính từng dòng và hiển thị "biểu thức = kết quả"
        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(duongDanInput))
            {
                MessageBox.Show("Không tìm thấy file:\n" + duongDanInput);
                return;
            }

            rtbContent.Clear();
            foreach (string dong in File.ReadAllLines(duongDanInput))
            {
                if (string.IsNullOrWhiteSpace(dong)) continue;
                rtbContent.AppendText(dong.Trim() + " = " + TinhMotDong(dong) + "\n");
            }
        }

        // GHI FILE: ghi kết quả đang hiển thị xuống output3.txt
        private void btnTinhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbContent.Text))
            {
                MessageBox.Show("Chưa có kết quả. Hãy bấm ĐỌC FILE trước!");
                return;
            }

            try
            {
                File.WriteAllText(duongDanOutput, rtbContent.Text.Replace("\n", Environment.NewLine));
                MessageBox.Show("Đã ghi xong:\n" + duongDanOutput);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message);
            }
        }

        private string TinhMotDong(string dong)
        {
            try
            {
                decimal ketQua = boTinhToan.TinhGiaTri(dong);
                return ketQua.ToString("0.############", CultureInfo.InvariantCulture);
            }
            catch (DivideByZeroException)
            {
                return "Lỗi: chia cho 0";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
    }
}
