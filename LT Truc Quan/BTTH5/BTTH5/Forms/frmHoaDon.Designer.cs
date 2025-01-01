namespace BTTH5.Forms
{
    partial class frmHoaDon
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
            this.label1 = new System.Windows.Forms.Label();
            this.gbthongtinchung = new System.Windows.Forms.GroupBox();
            this.btnthemkhach = new System.Windows.Forms.Button();
            this.dtpngayban = new System.Windows.Forms.DateTimePicker();
            this.cbomakhach = new System.Windows.Forms.ComboBox();
            this.txttenkhach = new System.Windows.Forms.TextBox();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.txtsdt = new System.Windows.Forms.TextBox();
            this.txtmanhanvien = new System.Windows.Forms.TextBox();
            this.txttennhanvien = new System.Windows.Forms.TextBox();
            this.txtmahoadon = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbthongtinmathang = new System.Windows.Forms.GroupBox();
            this.lbltongtien = new System.Windows.Forms.Label();
            this.dgvchitiet = new System.Windows.Forms.DataGridView();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbomahang = new System.Windows.Forms.ComboBox();
            this.txtthanhtien = new System.Windows.Forms.TextBox();
            this.txtdongia = new System.Windows.Forms.TextBox();
            this.txttenhang = new System.Windows.Forms.TextBox();
            this.txtgiamgia = new System.Windows.Forms.TextBox();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnin = new System.Windows.Forms.Button();
            this.cboHoaDon = new System.Windows.Forms.ComboBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.gbthongtinchung.SuspendLayout();
            this.gbthongtinmathang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvchitiet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(400, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "HÓA ĐƠN BÁN HÀNG";
            // 
            // gbthongtinchung
            // 
            this.gbthongtinchung.Controls.Add(this.btnthemkhach);
            this.gbthongtinchung.Controls.Add(this.dtpngayban);
            this.gbthongtinchung.Controls.Add(this.cbomakhach);
            this.gbthongtinchung.Controls.Add(this.txttenkhach);
            this.gbthongtinchung.Controls.Add(this.txtdiachi);
            this.gbthongtinchung.Controls.Add(this.txtsdt);
            this.gbthongtinchung.Controls.Add(this.txtmanhanvien);
            this.gbthongtinchung.Controls.Add(this.txttennhanvien);
            this.gbthongtinchung.Controls.Add(this.txtmahoadon);
            this.gbthongtinchung.Controls.Add(this.label9);
            this.gbthongtinchung.Controls.Add(this.label8);
            this.gbthongtinchung.Controls.Add(this.label7);
            this.gbthongtinchung.Controls.Add(this.label6);
            this.gbthongtinchung.Controls.Add(this.label5);
            this.gbthongtinchung.Controls.Add(this.label4);
            this.gbthongtinchung.Controls.Add(this.label3);
            this.gbthongtinchung.Controls.Add(this.label2);
            this.gbthongtinchung.Location = new System.Drawing.Point(12, 92);
            this.gbthongtinchung.Name = "gbthongtinchung";
            this.gbthongtinchung.Size = new System.Drawing.Size(1160, 299);
            this.gbthongtinchung.TabIndex = 1;
            this.gbthongtinchung.TabStop = false;
            this.gbthongtinchung.Text = "Thông tin chung";
            // 
            // btnthemkhach
            // 
            this.btnthemkhach.Location = new System.Drawing.Point(1073, 34);
            this.btnthemkhach.Name = "btnthemkhach";
            this.btnthemkhach.Size = new System.Drawing.Size(81, 24);
            this.btnthemkhach.TabIndex = 10;
            this.btnthemkhach.Text = "...";
            this.btnthemkhach.UseVisualStyleBackColor = true;
            this.btnthemkhach.Click += new System.EventHandler(this.btnthemkhach_Click);
            // 
            // dtpngayban
            // 
            this.dtpngayban.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngayban.Location = new System.Drawing.Point(159, 86);
            this.dtpngayban.Name = "dtpngayban";
            this.dtpngayban.Size = new System.Drawing.Size(283, 22);
            this.dtpngayban.TabIndex = 14;
            // 
            // cbomakhach
            // 
            this.cbomakhach.FormattingEnabled = true;
            this.cbomakhach.Location = new System.Drawing.Point(764, 34);
            this.cbomakhach.Name = "cbomakhach";
            this.cbomakhach.Size = new System.Drawing.Size(283, 24);
            this.cbomakhach.TabIndex = 3;
            this.cbomakhach.SelectedIndexChanged += new System.EventHandler(this.cbomakhach_SelectedIndexChanged);
            // 
            // txttenkhach
            // 
            this.txttenkhach.Location = new System.Drawing.Point(764, 86);
            this.txttenkhach.Name = "txttenkhach";
            this.txttenkhach.Size = new System.Drawing.Size(283, 22);
            this.txttenkhach.TabIndex = 13;
            // 
            // txtdiachi
            // 
            this.txtdiachi.Location = new System.Drawing.Point(764, 189);
            this.txtdiachi.Multiline = true;
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(283, 96);
            this.txtdiachi.TabIndex = 12;
            // 
            // txtsdt
            // 
            this.txtsdt.Location = new System.Drawing.Point(764, 137);
            this.txtsdt.Name = "txtsdt";
            this.txtsdt.Size = new System.Drawing.Size(283, 22);
            this.txtsdt.TabIndex = 11;
            this.txtsdt.TextChanged += new System.EventHandler(this.txtsdt_TextChanged);
            // 
            // txtmanhanvien
            // 
            this.txtmanhanvien.Enabled = false;
            this.txtmanhanvien.Location = new System.Drawing.Point(159, 131);
            this.txtmanhanvien.Name = "txtmanhanvien";
            this.txtmanhanvien.Size = new System.Drawing.Size(283, 22);
            this.txtmanhanvien.TabIndex = 10;
            // 
            // txttennhanvien
            // 
            this.txttennhanvien.Enabled = false;
            this.txttennhanvien.Location = new System.Drawing.Point(159, 186);
            this.txttennhanvien.Name = "txttennhanvien";
            this.txttennhanvien.Size = new System.Drawing.Size(283, 22);
            this.txttennhanvien.TabIndex = 9;
            // 
            // txtmahoadon
            // 
            this.txtmahoadon.Location = new System.Drawing.Point(159, 39);
            this.txtmahoadon.Name = "txtmahoadon";
            this.txtmahoadon.Size = new System.Drawing.Size(283, 22);
            this.txtmahoadon.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(607, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Mã khách";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(607, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tên khách";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(607, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Số điện thoại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(607, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên nhân viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ngày bán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hóa đơn";
            // 
            // gbthongtinmathang
            // 
            this.gbthongtinmathang.Controls.Add(this.lbltongtien);
            this.gbthongtinmathang.Controls.Add(this.dgvchitiet);
            this.gbthongtinmathang.Controls.Add(this.label17);
            this.gbthongtinmathang.Controls.Add(this.label16);
            this.gbthongtinmathang.Controls.Add(this.cbomahang);
            this.gbthongtinmathang.Controls.Add(this.txtthanhtien);
            this.gbthongtinmathang.Controls.Add(this.txtdongia);
            this.gbthongtinmathang.Controls.Add(this.txttenhang);
            this.gbthongtinmathang.Controls.Add(this.txtgiamgia);
            this.gbthongtinmathang.Controls.Add(this.txtsoluong);
            this.gbthongtinmathang.Controls.Add(this.label15);
            this.gbthongtinmathang.Controls.Add(this.label14);
            this.gbthongtinmathang.Controls.Add(this.label13);
            this.gbthongtinmathang.Controls.Add(this.label12);
            this.gbthongtinmathang.Controls.Add(this.label11);
            this.gbthongtinmathang.Controls.Add(this.label10);
            this.gbthongtinmathang.Location = new System.Drawing.Point(12, 415);
            this.gbthongtinmathang.Name = "gbthongtinmathang";
            this.gbthongtinmathang.Size = new System.Drawing.Size(1160, 378);
            this.gbthongtinmathang.TabIndex = 2;
            this.gbthongtinmathang.TabStop = false;
            this.gbthongtinmathang.Text = "Thông tin các mặt hàng";
            // 
            // lbltongtien
            // 
            this.lbltongtien.AutoSize = true;
            this.lbltongtien.ForeColor = System.Drawing.Color.Red;
            this.lbltongtien.Location = new System.Drawing.Point(814, 335);
            this.lbltongtien.Name = "lbltongtien";
            this.lbltongtien.Size = new System.Drawing.Size(0, 16);
            this.lbltongtien.TabIndex = 23;
            // 
            // dgvchitiet
            // 
            this.dgvchitiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvchitiet.Location = new System.Drawing.Point(40, 143);
            this.dgvchitiet.Name = "dgvchitiet";
            this.dgvchitiet.RowHeadersWidth = 51;
            this.dgvchitiet.RowTemplate.Height = 24;
            this.dgvchitiet.Size = new System.Drawing.Size(1061, 174);
            this.dgvchitiet.TabIndex = 22;
            this.dgvchitiet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvchitiet_CellDoubleClick);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1045, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 16);
            this.label17.TabIndex = 21;
            this.label17.Text = "VNĐ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(658, 103);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 16);
            this.label16.TabIndex = 20;
            this.label16.Text = "%";
            // 
            // cbomahang
            // 
            this.cbomahang.FormattingEnabled = true;
            this.cbomahang.Location = new System.Drawing.Point(116, 42);
            this.cbomahang.Name = "cbomahang";
            this.cbomahang.Size = new System.Drawing.Size(158, 24);
            this.cbomahang.TabIndex = 15;
            this.cbomahang.SelectedIndexChanged += new System.EventHandler(this.cboMaHang_SelectedIndexChanged);
            // 
            // txtthanhtien
            // 
            this.txtthanhtien.Enabled = false;
            this.txtthanhtien.Location = new System.Drawing.Point(861, 103);
            this.txtthanhtien.Name = "txtthanhtien";
            this.txtthanhtien.Size = new System.Drawing.Size(158, 22);
            this.txtthanhtien.TabIndex = 19;
            // 
            // txtdongia
            // 
            this.txtdongia.Enabled = false;
            this.txtdongia.Location = new System.Drawing.Point(861, 45);
            this.txtdongia.Name = "txtdongia";
            this.txtdongia.Size = new System.Drawing.Size(219, 22);
            this.txtdongia.TabIndex = 18;
            // 
            // txttenhang
            // 
            this.txttenhang.Enabled = false;
            this.txttenhang.Location = new System.Drawing.Point(481, 45);
            this.txttenhang.Name = "txttenhang";
            this.txttenhang.Size = new System.Drawing.Size(196, 22);
            this.txttenhang.TabIndex = 17;
            // 
            // txtgiamgia
            // 
            this.txtgiamgia.Location = new System.Drawing.Point(481, 97);
            this.txtgiamgia.Name = "txtgiamgia";
            this.txtgiamgia.Size = new System.Drawing.Size(158, 22);
            this.txtgiamgia.TabIndex = 16;
            this.txtgiamgia.TextChanged += new System.EventHandler(this.txtgiamgia_TextChanged);
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(116, 91);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(158, 22);
            this.txtsoluong.TabIndex = 15;
            this.txtsoluong.TextChanged += new System.EventHandler(this.txtsoluong_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(745, 109);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 16);
            this.label15.TabIndex = 8;
            this.label15.Text = "Thành tiền";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(392, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 16);
            this.label14.TabIndex = 7;
            this.label14.Text = "Giảm giá";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(37, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 16);
            this.label13.TabIndex = 6;
            this.label13.Text = "Số lượng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(741, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = "Đơn giá";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(392, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "Tên hàng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "Mã hàng";
            // 
            // btnthem
            // 
            this.btnthem.ForeColor = System.Drawing.Color.Black;
            this.btnthem.Location = new System.Drawing.Point(52, 799);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(150, 36);
            this.btnthem.TabIndex = 3;
            this.btnthem.Text = "Thêm hóa đơn";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnluu
            // 
            this.btnluu.ForeColor = System.Drawing.Color.Black;
            this.btnluu.Location = new System.Drawing.Point(348, 799);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(150, 36);
            this.btnluu.TabIndex = 4;
            this.btnluu.Text = "Lưu hóa đơn";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.ForeColor = System.Drawing.Color.Black;
            this.btnhuy.Location = new System.Drawing.Point(673, 799);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(150, 36);
            this.btnhuy.TabIndex = 5;
            this.btnhuy.Text = "Hủy hóa đơn";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnin
            // 
            this.btnin.ForeColor = System.Drawing.Color.Black;
            this.btnin.Location = new System.Drawing.Point(984, 799);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(150, 36);
            this.btnin.TabIndex = 6;
            this.btnin.Text = "In hóa đơn";
            this.btnin.UseVisualStyleBackColor = true;
            this.btnin.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // cboHoaDon
            // 
            this.cboHoaDon.FormattingEnabled = true;
            this.cboHoaDon.Location = new System.Drawing.Point(98, 46);
            this.cboHoaDon.Name = "cboHoaDon";
            this.cboHoaDon.Size = new System.Drawing.Size(174, 24);
            this.cboHoaDon.TabIndex = 7;
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(294, 46);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(81, 24);
            this.btntimkiem.TabIndex = 8;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(27, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 16);
            this.label18.TabIndex = 9;
            this.label18.Text = "Mã HĐ:";
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 932);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.cboHoaDon);
            this.Controls.Add(this.btnin);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.gbthongtinmathang);
            this.Controls.Add(this.gbthongtinchung);
            this.Controls.Add(this.label1);
            this.Name = "frmHoaDon";
            this.Text = "Hóa Đơn Bán Hàng";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            this.gbthongtinchung.ResumeLayout(false);
            this.gbthongtinchung.PerformLayout();
            this.gbthongtinmathang.ResumeLayout(false);
            this.gbthongtinmathang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvchitiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbthongtinchung;
        private System.Windows.Forms.GroupBox gbthongtinmathang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttenkhach;
        private System.Windows.Forms.TextBox txtdiachi;
        private System.Windows.Forms.TextBox txtsdt;
        private System.Windows.Forms.TextBox txtmanhanvien;
        private System.Windows.Forms.TextBox txttennhanvien;
        private System.Windows.Forms.TextBox txtmahoadon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbomakhach;
        private System.Windows.Forms.DateTimePicker dtpngayban;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbomahang;
        private System.Windows.Forms.TextBox txtthanhtien;
        private System.Windows.Forms.TextBox txtdongia;
        private System.Windows.Forms.TextBox txttenhang;
        private System.Windows.Forms.TextBox txtgiamgia;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvchitiet;
        private System.Windows.Forms.Label lbltongtien;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnin;
        private System.Windows.Forms.ComboBox cboHoaDon;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btnthemkhach;
        private System.Windows.Forms.Label label18;
    }
}