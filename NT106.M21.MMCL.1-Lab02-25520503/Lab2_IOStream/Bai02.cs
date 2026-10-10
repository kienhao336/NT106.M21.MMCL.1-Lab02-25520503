using System;
using System.IO;
using System.Windows.Forms;

namespace Lab2_IOStream
{
    public partial class Bai02 : Form
    {
        public Bai02()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                InitialDirectory = AppContext.BaseDirectory
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();

                    rtbContent.Text = content;
                    Filename.Text = ofd.SafeFileName;
                    Size.Text = fs.Length + " bytes";
                    URL.Text = fs.Name;
                    Linecount.Text = DemSoDong(content).ToString();
                    Wordscount.Text = DemSoTu(content).ToString();
                    Charactercount.Text = content.Length.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không đọc được file: " + ex.Message);
            }
        }

        private static int DemSoDong(string content)
        {
            int soDong = 0;
            using (StringReader reader = new StringReader(content))
            {
                while (reader.ReadLine() != null)
                {
                    soDong++;
                }
            }
            return soDong;
        }

        private static int DemSoTu(string content)
        {
            char[] kyTuTach = { ' ', '\r', '\n', '\t' };
            return content.Split(kyTuTach, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
