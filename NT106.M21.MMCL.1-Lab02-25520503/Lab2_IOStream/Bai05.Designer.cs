namespace Lab2_IOStream
{
    partial class Bai05
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTenPhim = new Label();
            txtTenPhim = new TextBox();
            lblGiaChuan = new Label();
            txtGiaChuan = new TextBox();
            lblPhongChieu = new Label();
            txtPhongChieu = new TextBox();
            lblVeDaBan = new Label();
            txtVeDaBan = new TextBox();
            btnThemPhim = new Button();
            btnGhiInput = new Button();
            btnReadFile = new Button();
            btnGhiFile = new Button();
            progressBar1 = new ProgressBar();
            rtbContent = new RichTextBox();
            SuspendLayout();
            // 
            // lblTenPhim
            // 
            lblTenPhim.AutoSize = true;
            lblTenPhim.Location = new Point(12, 12);
            lblTenPhim.Name = "lblTenPhim";
            lblTenPhim.Size = new Size(67, 20);
            lblTenPhim.TabIndex = 0;
            lblTenPhim.Text = "Tên phim";
            // 
            // txtTenPhim
            // 
            txtTenPhim.Location = new Point(12, 35);
            txtTenPhim.Name = "txtTenPhim";
            txtTenPhim.Size = new Size(300, 27);
            txtTenPhim.TabIndex = 1;
            // 
            // lblGiaChuan
            // 
            lblGiaChuan.AutoSize = true;
            lblGiaChuan.Location = new Point(12, 72);
            lblGiaChuan.Name = "lblGiaChuan";
            lblGiaChuan.Size = new Size(91, 20);
            lblGiaChuan.TabIndex = 2;
            lblGiaChuan.Text = "Giá vé chuẩn";
            // 
            // txtGiaChuan
            // 
            txtGiaChuan.Location = new Point(12, 95);
            txtGiaChuan.Name = "txtGiaChuan";
            txtGiaChuan.Size = new Size(300, 27);
            txtGiaChuan.TabIndex = 3;
            // 
            // lblPhongChieu
            // 
            lblPhongChieu.AutoSize = true;
            lblPhongChieu.Location = new Point(12, 132);
            lblPhongChieu.Name = "lblPhongChieu";
            lblPhongChieu.Size = new Size(171, 20);
            lblPhongChieu.TabIndex = 4;
            lblPhongChieu.Text = "Phòng chiếu (vd: 1,2,3)";
            // 
            // txtPhongChieu
            // 
            txtPhongChieu.Location = new Point(12, 155);
            txtPhongChieu.Name = "txtPhongChieu";
            txtPhongChieu.Size = new Size(300, 27);
            txtPhongChieu.TabIndex = 5;
            // 
            // lblVeDaBan
            // 
            lblVeDaBan.AutoSize = true;
            lblVeDaBan.Location = new Point(12, 192);
            lblVeDaBan.Name = "lblVeDaBan";
            lblVeDaBan.Size = new Size(193, 20);
            lblVeDaBan.TabIndex = 6;
            lblVeDaBan.Text = "Vé đã bán (vd: A1,B2,C5)";
            // 
            // txtVeDaBan
            // 
            txtVeDaBan.Location = new Point(12, 215);
            txtVeDaBan.Name = "txtVeDaBan";
            txtVeDaBan.Size = new Size(300, 27);
            txtVeDaBan.TabIndex = 7;
            // 
            // btnThemPhim
            // 
            btnThemPhim.Location = new Point(12, 255);
            btnThemPhim.Name = "btnThemPhim";
            btnThemPhim.Size = new Size(145, 35);
            btnThemPhim.TabIndex = 8;
            btnThemPhim.Text = "Thêm phim";
            btnThemPhim.UseVisualStyleBackColor = true;
            btnThemPhim.Click += btnThemPhim_Click;
            // 
            // btnGhiInput
            // 
            btnGhiInput.Location = new Point(167, 255);
            btnGhiInput.Name = "btnGhiInput";
            btnGhiInput.Size = new Size(145, 35);
            btnGhiInput.TabIndex = 9;
            btnGhiInput.Text = "Ghi input5.txt";
            btnGhiInput.UseVisualStyleBackColor = true;
            btnGhiInput.Click += btnGhiInput_Click;
            // 
            // btnReadFile
            // 
            btnReadFile.Location = new Point(12, 305);
            btnReadFile.Name = "btnReadFile";
            btnReadFile.Size = new Size(145, 35);
            btnReadFile.TabIndex = 10;
            btnReadFile.Text = "ĐỌC FILE";
            btnReadFile.UseVisualStyleBackColor = true;
            btnReadFile.Click += btnReadFile_Click;
            // 
            // btnGhiFile
            // 
            btnGhiFile.Location = new Point(167, 305);
            btnGhiFile.Name = "btnGhiFile";
            btnGhiFile.Size = new Size(145, 35);
            btnGhiFile.TabIndex = 11;
            btnGhiFile.Text = "GHI THỐNG KÊ";
            btnGhiFile.UseVisualStyleBackColor = true;
            btnGhiFile.Click += btnGhiFile_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 360);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(300, 29);
            progressBar1.TabIndex = 12;
            // 
            // rtbContent
            // 
            rtbContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbContent.Location = new Point(330, 12);
            rtbContent.Name = "rtbContent";
            rtbContent.ReadOnly = true;
            rtbContent.Size = new Size(458, 426);
            rtbContent.TabIndex = 13;
            rtbContent.Text = "";
            // 
            // Bai05
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbContent);
            Controls.Add(progressBar1);
            Controls.Add(btnGhiFile);
            Controls.Add(btnReadFile);
            Controls.Add(btnGhiInput);
            Controls.Add(btnThemPhim);
            Controls.Add(txtVeDaBan);
            Controls.Add(lblVeDaBan);
            Controls.Add(txtPhongChieu);
            Controls.Add(lblPhongChieu);
            Controls.Add(txtGiaChuan);
            Controls.Add(lblGiaChuan);
            Controls.Add(txtTenPhim);
            Controls.Add(lblTenPhim);
            Name = "Bai05";
            Text = "Bai05 - Quản lý phòng vé";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenPhim;
        private TextBox txtTenPhim;
        private Label lblGiaChuan;
        private TextBox txtGiaChuan;
        private Label lblPhongChieu;
        private TextBox txtPhongChieu;
        private Label lblVeDaBan;
        private TextBox txtVeDaBan;
        private Button btnThemPhim;
        private Button btnGhiInput;
        private Button btnReadFile;
        private Button btnGhiFile;
        private ProgressBar progressBar1;
        private RichTextBox rtbContent;
    }
}
