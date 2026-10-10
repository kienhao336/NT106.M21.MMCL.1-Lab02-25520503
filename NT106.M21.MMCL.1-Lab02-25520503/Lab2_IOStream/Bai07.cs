using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab2_IOStream
{
    public partial class Bai07 : Form
    {
        private const string DUMMY = "Loading...";
        private const int SO_KY_TU_TOI_DA = 200000; // chỉ xem trước tối đa ~200 nghìn ký tự

        private static readonly string[] duoiAnh = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
        private static readonly string[] duoiVanBan =
        {
            ".txt", ".cs", ".json", ".xml", ".csv", ".log", ".md", ".html", ".htm", ".css", ".js",
            ".ini", ".config", ".sln", ".csproj", ".resx", ".py", ".java", ".c", ".cpp", ".h", ".sql",
            ".yml", ".yaml", ".bat"
        };

        public Bai07()
        {
            InitializeComponent();
            LoadDrives();
        }

        // Nạp danh sách ổ đĩa, hiển thị dạng "Tên ổ (C:\)" như hình minh họa
        private void LoadDrives()
        {
            treeView1.Nodes.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                string hienThi = drive.Name;
                try
                {
                    if (drive.IsReady && !string.IsNullOrEmpty(drive.VolumeLabel))
                    {
                        hienThi = drive.VolumeLabel + " (" + drive.Name + ")";
                    }
                }
                catch (IOException) { }

                TreeNode node = new TreeNode(hienThi) { Tag = drive.Name };
                node.Nodes.Add(DUMMY); // node giả để hiện dấu +
                treeView1.Nodes.Add(node);
            }
        }

        // Chỉ nạp thư mục con/file khi mở node (nhấp đúp hoặc bấm dấu +)
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode? node = e.Node;
            if (node == null) return;

            if (node.Nodes.Count == 1 && node.Nodes[0].Text == DUMMY && node.Nodes[0].Tag == null)
            {
                LoadChildren(node);
            }
        }

        private void LoadChildren(TreeNode node)
        {
            string? path = node.Tag as string;
            if (string.IsNullOrEmpty(path)) return;

            node.Nodes.Clear();
            try
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    TreeNode sub = new TreeNode(new DirectoryInfo(dir).Name) { Tag = dir };
                    sub.Nodes.Add(DUMMY);
                    node.Nodes.Add(sub);
                }
                foreach (string file in Directory.GetFiles(path))
                {
                    node.Nodes.Add(new TreeNode(Path.GetFileName(file)) { Tag = file });
                }
            }
            catch (UnauthorizedAccessException)
            {
                node.Nodes.Add(new TreeNode("(Không có quyền truy cập)"));
            }
            catch (IOException)
            {
                node.Nodes.Add(new TreeNode("(Không đọc được ổ/thư mục này)"));
            }
        }

        // Bấm chọn 1 file -> hiển thị nội dung (ảnh hoặc văn bản)
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            XoaNoiDung();

            string? path = e.Node?.Tag as string;
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return;

            string duoi = Path.GetExtension(path).ToLowerInvariant();

            if (Array.IndexOf(duoiAnh, duoi) >= 0)
            {
                HienThiAnh(path);
            }
            else if (Array.IndexOf(duoiVanBan, duoi) >= 0)
            {
                HienThiVanBan(path);
            }
            else
            {
                HienThiThongTin(path);
            }
        }

        private void XoaNoiDung()
        {
            Image? cu = pictureBox1.Image;
            pictureBox1.Image = null;
            cu?.Dispose();

            rtbContent.Clear();
            rtbContent.Visible = false;
            pictureBox1.Visible = true;
        }

        private void HienThiAnh(string path)
        {
            try
            {
                // Đọc vào MemoryStream để không bị khóa file ảnh
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(path)))
                using (Image img = Image.FromStream(ms))
                {
                    pictureBox1.Image = new Bitmap(img);
                }
            }
            catch (Exception ex)
            {
                HienThiVanBanTho("Không mở được ảnh: " + ex.Message);
            }
        }

        private void HienThiVanBan(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fs))
                {
                    char[] buffer = new char[SO_KY_TU_TOI_DA];
                    int soKyTu = sr.Read(buffer, 0, buffer.Length);
                    string noiDung = new string(buffer, 0, soKyTu);
                    if (!sr.EndOfStream) noiDung += Environment.NewLine + "... (còn tiếp, chỉ hiển thị phần đầu của file)";
                    HienThiVanBanTho(noiDung);
                }
            }
            catch (Exception ex)
            {
                HienThiVanBanTho("Không đọc được file: " + ex.Message);
            }
        }

        private void HienThiThongTin(string path)
        {
            try
            {
                FileInfo fi = new FileInfo(path);
                HienThiVanBanTho("Không có bản xem trước cho loại file này." + Environment.NewLine + Environment.NewLine +
                                 "Tên file: " + fi.Name + Environment.NewLine +
                                 "Kích thước: " + fi.Length + " bytes" + Environment.NewLine +
                                 "Sửa lần cuối: " + fi.LastWriteTime);
            }
            catch (Exception ex)
            {
                HienThiVanBanTho("Không đọc được thông tin file: " + ex.Message);
            }
        }

        private void HienThiVanBanTho(string noiDung)
        {
            pictureBox1.Visible = false;
            rtbContent.Visible = true;
            rtbContent.Text = noiDung;
        }
    }
}
