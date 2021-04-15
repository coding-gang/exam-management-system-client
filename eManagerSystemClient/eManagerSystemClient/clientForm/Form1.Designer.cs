namespace clientForm
{
    partial class Form1
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdKetNoi = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtKetNoi = new System.Windows.Forms.TextBox();
            this.cmdNopBaiThi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDeThi = new System.Windows.Forms.LinkLabel();
            this.lblMaSo = new System.Windows.Forms.Label();
            this.lblThoiGianConLai = new System.Windows.Forms.Label();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.lblMonThi = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdChapNhan = new System.Windows.Forms.Button();
            this.cbDSThi = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdKetNoi);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtKetNoi);
            this.groupBox3.Location = new System.Drawing.Point(16, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(492, 66);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nhập địa chỉ IP Server";
            // 
            // cmdKetNoi
            // 
            this.cmdKetNoi.Location = new System.Drawing.Point(361, 23);
            this.cmdKetNoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdKetNoi.Name = "cmdKetNoi";
            this.cmdKetNoi.Size = new System.Drawing.Size(100, 28);
            this.cmdKetNoi.TabIndex = 8;
            this.cmdKetNoi.Text = "Kết Nối";
            this.cmdKetNoi.UseVisualStyleBackColor = true;
            this.cmdKetNoi.Click += new System.EventHandler(this.cmdKetNoi_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 27);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 17);
            this.label13.TabIndex = 7;
            this.label13.Text = "Server IP:";
            // 
            // txtKetNoi
            // 
            this.txtKetNoi.Location = new System.Drawing.Point(108, 23);
            this.txtKetNoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKetNoi.Name = "txtKetNoi";
            this.txtKetNoi.Size = new System.Drawing.Size(223, 22);
            this.txtKetNoi.TabIndex = 6;
            this.txtKetNoi.Text = "localhost";
            // 
            // cmdNopBaiThi
            // 
            this.cmdNopBaiThi.Location = new System.Drawing.Point(165, 454);
            this.cmdNopBaiThi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdNopBaiThi.Name = "cmdNopBaiThi";
            this.cmdNopBaiThi.Size = new System.Drawing.Size(169, 36);
            this.cmdNopBaiThi.TabIndex = 10;
            this.cmdNopBaiThi.Text = "Nộp Bài Thi";
            this.cmdNopBaiThi.UseVisualStyleBackColor = true;
            this.cmdNopBaiThi.Click += new System.EventHandler(this.cmdNopBaiThi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDeThi);
            this.groupBox2.Controls.Add(this.lblMaSo);
            this.groupBox2.Controls.Add(this.lblThoiGianConLai);
            this.groupBox2.Controls.Add(this.lblThoiGian);
            this.groupBox2.Controls.Add(this.lblMonThi);
            this.groupBox2.Controls.Add(this.lblHoTen);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(16, 223);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(492, 212);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Sinh Viên";
            // 
            // lblDeThi
            // 
            this.lblDeThi.AutoSize = true;
            this.lblDeThi.Location = new System.Drawing.Point(168, 144);
            this.lblDeThi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeThi.Name = "lblDeThi";
            this.lblDeThi.Size = new System.Drawing.Size(0, 17);
            this.lblDeThi.TabIndex = 2;
            this.lblDeThi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDeThi_LinkClicked);
            // 
            // lblMaSo
            // 
            this.lblMaSo.AutoSize = true;
            this.lblMaSo.Location = new System.Drawing.Point(168, 58);
            this.lblMaSo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaSo.Name = "lblMaSo";
            this.lblMaSo.Size = new System.Drawing.Size(0, 17);
            this.lblMaSo.TabIndex = 1;
            // 
            // lblThoiGianConLai
            // 
            this.lblThoiGianConLai.AutoSize = true;
            this.lblThoiGianConLai.Location = new System.Drawing.Point(168, 174);
            this.lblThoiGianConLai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThoiGianConLai.Name = "lblThoiGianConLai";
            this.lblThoiGianConLai.Size = new System.Drawing.Size(56, 17);
            this.lblThoiGianConLai.TabIndex = 1;
            this.lblThoiGianConLai.Text = "35 phút";
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Location = new System.Drawing.Point(168, 114);
            this.lblThoiGian.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(64, 17);
            this.lblThoiGian.TabIndex = 1;
            this.lblThoiGian.Text = "120 phút";
            // 
            // lblMonThi
            // 
            this.lblMonThi.AutoSize = true;
            this.lblMonThi.Location = new System.Drawing.Point(168, 87);
            this.lblMonThi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonThi.Name = "lblMonThi";
            this.lblMonThi.Size = new System.Drawing.Size(0, 17);
            this.lblMonThi.TabIndex = 1;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(168, 31);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(0, 17);
            this.lblHoTen.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "MSSV:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 144);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Đề Thi:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 174);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Thời Gian Còn Lại:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 114);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Thời Gian Làm Bài:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Môn Thi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ Tên Sinh Viên:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdChapNhan);
            this.groupBox1.Controls.Add(this.cbDSThi);
            this.groupBox1.Location = new System.Drawing.Point(16, 103);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(492, 97);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn Tên Sinh Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn Tên  của mình sau đó nhấn vào nút Chấp Nhận";
            // 
            // cmdChapNhan
            // 
            this.cmdChapNhan.Location = new System.Drawing.Point(380, 52);
            this.cmdChapNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdChapNhan.Name = "cmdChapNhan";
            this.cmdChapNhan.Size = new System.Drawing.Size(100, 28);
            this.cmdChapNhan.TabIndex = 1;
            this.cmdChapNhan.Text = "Chấp Nhận";
            this.cmdChapNhan.UseVisualStyleBackColor = true;
            this.cmdChapNhan.Click += new System.EventHandler(this.cmdChapNhan_Click);
            // 
            // cbDSThi
            // 
            this.cbDSThi.FormattingEnabled = true;
            this.cbDSThi.Location = new System.Drawing.Point(15, 54);
            this.cbDSThi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDSThi.Name = "cbDSThi";
            this.cbDSThi.Size = new System.Drawing.Size(344, 24);
            this.cbDSThi.TabIndex = 0;
            this.cbDSThi.SelectedIndexChanged += new System.EventHandler(this.cbDSThi_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 554);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmdNopBaiThi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdKetNoi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtKetNoi;
        private System.Windows.Forms.Button cmdNopBaiThi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel lblDeThi;
        private System.Windows.Forms.Label lblMaSo;
        private System.Windows.Forms.Label lblThoiGianConLai;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label lblMonThi;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdChapNhan;
        private System.Windows.Forms.ComboBox cbDSThi;
    }
}

