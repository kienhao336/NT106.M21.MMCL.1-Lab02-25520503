using System.Xml.Linq;

namespace Lab2_IOStream
{
    partial class Bai04
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
            label1 = new Label();
            txtName = new TextBox();
            rtbContent = new RichTextBox();
            btnWriteaFile = new Button();
            button3 = new Button();
            ID = new TextBox();
            C3 = new TextBox();
            C2 = new TextBox();
            C1 = new TextBox();
            Phone = new TextBox();
            Average = new TextBox();
            btnAdd = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label2 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            Average1 = new TextBox();
            Phone1 = new TextBox();
            C11 = new TextBox();
            C21 = new TextBox();
            C31 = new TextBox();
            ID1 = new TextBox();
            Name1 = new TextBox();
            label14 = new Label();
            PageNumber = new TextBox();
            btnBack = new Button();
            btnNext = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(167, 64);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 61);
            txtName.Name = "txtName";
            txtName.Size = new Size(148, 27);
            txtName.TabIndex = 2;
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(242, 1);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(318, 456);
            rtbContent.TabIndex = 3;
            rtbContent.Text = "";
            // 
            // btnWriteaFile
            // 
            btnWriteaFile.Location = new Point(8, 1);
            btnWriteaFile.Name = "btnWriteaFile";
            btnWriteaFile.Size = new Size(208, 43);
            btnWriteaFile.TabIndex = 4;
            btnWriteaFile.Text = "Write a File";
            btnWriteaFile.UseVisualStyleBackColor = true;
            btnWriteaFile.Click += btnWriteaFile_Click;
            // 
            // button3
            // 
            button3.Location = new Point(580, 12);
            button3.Name = "button3";
            button3.Size = new Size(208, 43);
            button3.TabIndex = 5;
            button3.Text = "Button to read a File";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ID
            // 
            ID.Location = new Point(12, 114);
            ID.Name = "ID";
            ID.Size = new Size(148, 27);
            ID.TabIndex = 6;
            // 
            // C3
            // 
            C3.Location = new Point(12, 325);
            C3.Name = "C3";
            C3.Size = new Size(148, 27);
            C3.TabIndex = 7;
            // 
            // C2
            // 
            C2.Location = new Point(12, 277);
            C2.Name = "C2";
            C2.Size = new Size(148, 27);
            C2.TabIndex = 8;
            // 
            // C1
            // 
            C1.Location = new Point(12, 224);
            C1.Name = "C1";
            C1.Size = new Size(148, 27);
            C1.TabIndex = 9;
            // 
            // Phone
            // 
            Phone.Location = new Point(12, 171);
            Phone.Name = "Phone";
            Phone.Size = new Size(148, 27);
            Phone.TabIndex = 10;
            // 
            // Average
            // 
            Average.Location = new Point(12, 372);
            Average.Name = "Average";
            Average.Size = new Size(148, 27);
            Average.TabIndex = 11;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(86, 405);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(74, 37);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(167, 120);
            label3.Name = "label3";
            label3.Size = new Size(24, 20);
            label3.TabIndex = 21;
            label3.Text = "ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(167, 178);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 22;
            label4.Text = "Phone";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(167, 234);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 23;
            label5.Text = "Course 1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(167, 284);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 24;
            label6.Text = "Course 2";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(167, 335);
            label7.Name = "label7";
            label7.Size = new Size(66, 20);
            label7.TabIndex = 25;
            label7.Text = "Course 3";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(167, 378);
            label8.Name = "label8";
            label8.Size = new Size(64, 20);
            label8.TabIndex = 26;
            label8.Text = "Average";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(721, 381);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 40;
            label2.Text = "Average";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(721, 338);
            label9.Name = "label9";
            label9.Size = new Size(66, 20);
            label9.TabIndex = 39;
            label9.Text = "Course 3";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(721, 287);
            label10.Name = "label10";
            label10.Size = new Size(66, 20);
            label10.TabIndex = 38;
            label10.Text = "Course 2";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(721, 237);
            label11.Name = "label11";
            label11.Size = new Size(66, 20);
            label11.TabIndex = 37;
            label11.Text = "Course 1";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(721, 181);
            label12.Name = "label12";
            label12.Size = new Size(50, 20);
            label12.TabIndex = 36;
            label12.Text = "Phone";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(721, 123);
            label13.Name = "label13";
            label13.Size = new Size(24, 20);
            label13.TabIndex = 35;
            label13.Text = "ID";
            // 
            // Average1
            // 
            Average1.Location = new Point(566, 375);
            Average1.Name = "Average1";
            Average1.Size = new Size(148, 27);
            Average1.TabIndex = 34;
            // 
            // Phone1
            // 
            Phone1.Location = new Point(566, 174);
            Phone1.Name = "Phone1";
            Phone1.Size = new Size(148, 27);
            Phone1.TabIndex = 33;
            // 
            // C11
            // 
            C11.Location = new Point(566, 227);
            C11.Name = "C11";
            C11.Size = new Size(148, 27);
            C11.TabIndex = 32;
            // 
            // C21
            // 
            C21.Location = new Point(566, 280);
            C21.Name = "C21";
            C21.Size = new Size(148, 27);
            C21.TabIndex = 31;
            // 
            // C31
            // 
            C31.Location = new Point(566, 328);
            C31.Name = "C31";
            C31.Size = new Size(148, 27);
            C31.TabIndex = 30;
            // 
            // ID1
            // 
            ID1.Location = new Point(566, 117);
            ID1.Name = "ID1";
            ID1.Size = new Size(148, 27);
            ID1.TabIndex = 29;
            // 
            // Name1
            // 
            Name1.Location = new Point(566, 64);
            Name1.Name = "Name1";
            Name1.Size = new Size(148, 27);
            Name1.TabIndex = 28;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(721, 67);
            label14.Name = "label14";
            label14.Size = new Size(49, 20);
            label14.TabIndex = 27;
            label14.Text = "Name";
            // 
            // PageNumber
            // 
            PageNumber.Location = new Point(662, 415);
            PageNumber.Name = "PageNumber";
            PageNumber.ReadOnly = true;
            PageNumber.Size = new Size(42, 27);
            PageNumber.TabIndex = 41;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(566, 408);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(74, 37);
            btnBack.TabIndex = 42;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(721, 410);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(74, 37);
            btnNext.TabIndex = 43;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // Bai04
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNext);
            Controls.Add(btnBack);
            Controls.Add(PageNumber);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(Average1);
            Controls.Add(Phone1);
            Controls.Add(C11);
            Controls.Add(C21);
            Controls.Add(C31);
            Controls.Add(ID1);
            Controls.Add(Name1);
            Controls.Add(label14);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnAdd);
            Controls.Add(Average);
            Controls.Add(Phone);
            Controls.Add(C1);
            Controls.Add(C2);
            Controls.Add(C3);
            Controls.Add(ID);
            Controls.Add(button3);
            Controls.Add(btnWriteaFile);
            Controls.Add(rtbContent);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "Bai04";
            Text = "Bai04";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private RichTextBox rtbContent;
        private Button btnWriteaFile;
        private Button button3;
        private TextBox ID;
        private TextBox C3;
        private TextBox C2;
        private TextBox C1;
        private TextBox Phone;
        private TextBox Average;
        private Button btnAdd;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label2;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox Average1;
        private TextBox Phone1;
        private TextBox C11;
        private TextBox C21;
        private TextBox C31;
        private TextBox ID1;
        private TextBox Name1;
        private Label label14;
        private TextBox PageNumber;
        private Button btnBack;
        private Button btnNext;
    }
}