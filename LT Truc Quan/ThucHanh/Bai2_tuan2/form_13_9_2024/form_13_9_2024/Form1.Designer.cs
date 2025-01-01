namespace form_13_9_2024
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnThemDs = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTien = new System.Windows.Forms.TextBox();
            this.cbSoLuong = new System.Windows.Forms.ComboBox();
            this.cbChonDoUong = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGiaDuThuyen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbNuaNgay = new System.Windows.Forms.RadioButton();
            this.rbCaNgay = new System.Windows.Forms.RadioButton();
            this.tbHoTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbDanhSach = new System.Windows.Forms.ListBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThemMoi);
            this.groupBox1.Controls.Add(this.btnThemDs);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbTien);
            this.groupBox1.Controls.Add(this.cbSoLuong);
            this.groupBox1.Controls.Add(this.cbChonDoUong);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbGiaDuThuyen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbNuaNgay);
            this.groupBox1.Controls.Add(this.rbCaNgay);
            this.groupBox1.Controls.Add(this.tbHoTen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(49, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 472);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhap thong tin khach hang dat tour";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(266, 389);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(130, 37);
            this.btnThemMoi.TabIndex = 15;
            this.btnThemMoi.Text = "Them &moi";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnThemDs
            // 
            this.btnThemDs.Location = new System.Drawing.Point(79, 389);
            this.btnThemDs.Name = "btnThemDs";
            this.btnThemDs.Size = new System.Drawing.Size(130, 37);
            this.btnThemDs.TabIndex = 14;
            this.btnThemDs.Text = "Them vao DS";
            this.btnThemDs.UseVisualStyleBackColor = true;
            this.btnThemDs.Click += new System.EventHandler(this.btnThemVaoDS_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(489, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "$";
            // 
            // tbTien
            // 
            this.tbTien.Location = new System.Drawing.Point(356, 319);
            this.tbTien.Multiline = true;
            this.tbTien.Name = "tbTien";
            this.tbTien.ReadOnly = true;
            this.tbTien.Size = new System.Drawing.Size(127, 28);
            this.tbTien.TabIndex = 12;
            // 
            // cbSoLuong
            // 
            this.cbSoLuong.FormattingEnabled = true;
            this.cbSoLuong.Location = new System.Drawing.Point(201, 319);
            this.cbSoLuong.Name = "cbSoLuong";
            this.cbSoLuong.Size = new System.Drawing.Size(121, 28);
            this.cbSoLuong.TabIndex = 11;
            this.cbSoLuong.SelectedIndexChanged += new System.EventHandler(this.handle_value_soluong_changed);
            // 
            // cbChonDoUong
            // 
            this.cbChonDoUong.FormattingEnabled = true;
            this.cbChonDoUong.Location = new System.Drawing.Point(34, 319);
            this.cbChonDoUong.Name = "cbChonDoUong";
            this.cbChonDoUong.Size = new System.Drawing.Size(121, 28);
            this.cbChonDoUong.TabIndex = 10;
            this.cbChonDoUong.SelectedIndexChanged += new System.EventHandler(this.handle_value_douong_changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(399, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tien";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(228, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "So luong";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Chon do uong";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(395, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "$";
            // 
            // tbGiaDuThuyen
            // 
            this.tbGiaDuThuyen.Location = new System.Drawing.Point(172, 213);
            this.tbGiaDuThuyen.Name = "tbGiaDuThuyen";
            this.tbGiaDuThuyen.ReadOnly = true;
            this.tbGiaDuThuyen.Size = new System.Drawing.Size(212, 26);
            this.tbGiaDuThuyen.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Gia du thuyen";
            // 
            // rbNuaNgay
            // 
            this.rbNuaNgay.AutoSize = true;
            this.rbNuaNgay.Location = new System.Drawing.Point(295, 149);
            this.rbNuaNgay.Name = "rbNuaNgay";
            this.rbNuaNgay.Size = new System.Drawing.Size(101, 24);
            this.rbNuaNgay.TabIndex = 3;
            this.rbNuaNgay.TabStop = true;
            this.rbNuaNgay.Text = "Nua ngay";
            this.rbNuaNgay.UseVisualStyleBackColor = true;
            this.rbNuaNgay.CheckedChanged += new System.EventHandler(this.rdoNuaNgay_CheckedChanged);
            // 
            // rbCaNgay
            // 
            this.rbCaNgay.AutoSize = true;
            this.rbCaNgay.Location = new System.Drawing.Point(143, 149);
            this.rbCaNgay.Name = "rbCaNgay";
            this.rbCaNgay.Size = new System.Drawing.Size(92, 24);
            this.rbCaNgay.TabIndex = 2;
            this.rbCaNgay.TabStop = true;
            this.rbCaNgay.Text = "Ca ngay";
            this.rbCaNgay.UseVisualStyleBackColor = true;
            this.rbCaNgay.CheckedChanged += new System.EventHandler(this.rdoCaNgay_CheckedChanged);
            // 
            // tbHoTen
            // 
            this.tbHoTen.Location = new System.Drawing.Point(121, 100);
            this.tbHoTen.Name = "tbHoTen";
            this.tbHoTen.Size = new System.Drawing.Size(309, 26);
            this.tbHoTen.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ho ten";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbDanhSach);
            this.groupBox2.Location = new System.Drawing.Point(607, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 442);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sach khach hang dat tour";
            // 
            // lbDanhSach
            // 
            this.lbDanhSach.FormattingEnabled = true;
            this.lbDanhSach.ItemHeight = 20;
            this.lbDanhSach.Location = new System.Drawing.Point(18, 25);
            this.lbDanhSach.Name = "lbDanhSach";
            this.lbDanhSach.Size = new System.Drawing.Size(558, 404);
            this.lbDanhSach.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(920, 590);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(130, 37);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "T&hoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btn_Thoat_Clicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1250, 663);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNuaNgay;
        private System.Windows.Forms.RadioButton rbCaNgay;
        private System.Windows.Forms.TextBox tbHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbDanhSach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbGiaDuThuyen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTien;
        private System.Windows.Forms.ComboBox cbSoLuong;
        private System.Windows.Forms.ComboBox cbChonDoUong;
        private System.Windows.Forms.Button btnThemDs;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnThoat;
    }
}

