using System;
using System.IO;
using System.Windows.Forms;

namespace Lab2_IOStream
{
    public partial class Bai01 : Form
    {
        private readonly string duongDanInput = Path.Combine(AppContext.BaseDirectory, "input1.txt");
        private readonly string duongDanOutput = Path.Combine(AppContext.BaseDirectory, "output1.txt");

        public Bai01()
        {
            InitializeComponent();
        }

        // ĐỌC FILE: đọc toàn bộ input1.txt (ReadToEnd) và đưa vào RichTextBox
        private void btnDocFile_Click(object sender, EventArgs e)
        {
            if (!File.Exists(duongDanInput))
            {
                MessageBox.Show("Không tìm thấy file:\n" + duongDanInput);
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(duongDanInput))
                {
                    rtbContent.Text = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message);
            }
        }

        // GHI FILE: chuyển nội dung sang chữ in hoa rồi ghi xuống output1.txt (StreamWriter)
        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbContent.Text))
            {
                MessageBox.Show("Chưa có nội dung. Hãy bấm ĐỌC FILE trước!");
                return;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(duongDanOutput, false))
                {
                    sw.Write(rtbContent.Text.ToUpperInvariant());
                }
                MessageBox.Show("Đã ghi file thành công:\n" + duongDanOutput);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message);
            }
        }
    }
}
