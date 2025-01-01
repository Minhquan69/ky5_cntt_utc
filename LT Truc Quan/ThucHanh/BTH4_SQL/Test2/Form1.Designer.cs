namespace Test2
{
    partial class Frmmain
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
            this.components = new System.ComponentModel.Container();
            this.pntieude = new System.Windows.Forms.Panel();
            this.lbtieude = new System.Windows.Forms.Label();
            this.pnchucnang = new System.Windows.Forms.Panel();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.gbchitiet = new System.Windows.Forms.GroupBox();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.dtpngayhh = new System.Windows.Forms.DateTimePicker();
            this.dtpngaysx = new System.Windows.Forms.DateTimePicker();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.txtdongia = new System.Windows.Forms.TextBox();
            this.txtdonvi = new System.Windows.Forms.TextBox();
            this.lbghichu = new System.Windows.Forms.Label();
            this.lbdonvi = new System.Windows.Forms.Label();
            this.lbdongia = new System.Windows.Forms.Label();
            this.lbngaysx = new System.Windows.Forms.Label();
            this.lbngayhh = new System.Windows.Forms.Label();
            this.txttensp2 = new System.Windows.Forms.TextBox();
            this.txtmsp2 = new System.Windows.Forms.TextBox();
            this.lbtensp2 = new System.Windows.Forms.Label();
            this.lbmsp2 = new System.Windows.Forms.Label();
            this.errChiTiet = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gbtimkiem = new System.Windows.Forms.GroupBox();
            this.txttensp1 = new System.Windows.Forms.TextBox();
            this.txtmsp1 = new System.Windows.Forms.TextBox();
            this.lbtensp1 = new System.Windows.Forms.Label();
            this.lbmsp1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.gbketqua = new System.Windows.Forms.GroupBox();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.pntieude.SuspendLayout();
            this.pnchucnang.SuspendLayout();
            this.gbchitiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errChiTiet)).BeginInit();
            this.gbtimkiem.SuspendLayout();
            this.gbketqua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // pntieude
            // 
            this.pntieude.Controls.Add(this.lbtieude);
            this.pntieude.Dock = System.Windows.Forms.DockStyle.Top;
            this.pntieude.Location = new System.Drawing.Point(0, 0);
            this.pntieude.Name = "pntieude";
            this.pntieude.Size = new System.Drawing.Size(1570, 92);
            this.pntieude.TabIndex = 0;
            // 
            // lbtieude
            // 
            this.lbtieude.AutoSize = true;
            this.lbtieude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtieude.Location = new System.Drawing.Point(549, 35);
            this.lbtieude.Name = "lbtieude";
            this.lbtieude.Size = new System.Drawing.Size(306, 32);
            this.lbtieude.TabIndex = 0;
            this.lbtieude.Text = "QUẢN LÝ SẢN PHẨM";
            this.lbtieude.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnchucnang
            // 
            this.pnchucnang.Controls.Add(this.btnthoat);
            this.pnchucnang.Controls.Add(this.btnxoa);
            this.pnchucnang.Controls.Add(this.btnsua);
            this.pnchucnang.Controls.Add(this.btnthem);
            this.pnchucnang.Controls.Add(this.btntimkiem);
            this.pnchucnang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnchucnang.Location = new System.Drawing.Point(0, 653);
            this.pnchucnang.Name = "pnchucnang";
            this.pnchucnang.Size = new System.Drawing.Size(1570, 100);
            this.pnchucnang.TabIndex = 1;
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(801, 29);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(103, 46);
            this.btnthoat.TabIndex = 22;
            this.btnthoat.Text = "Th&oát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(621, 29);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(103, 46);
            this.btnxoa.TabIndex = 21;
            this.btnxoa.Text = "&Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(429, 29);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(103, 46);
            this.btnsua.TabIndex = 20;
            this.btnsua.Text = "&Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(240, 29);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(103, 46);
            this.btnthem.TabIndex = 19;
            this.btnthem.Text = "T&hêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(59, 29);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(103, 46);
            this.btntimkiem.TabIndex = 18;
            this.btntimkiem.Text = "&Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // gbchitiet
            // 
            this.gbchitiet.Controls.Add(this.btnhuy);
            this.gbchitiet.Controls.Add(this.btnluu);
            this.gbchitiet.Controls.Add(this.dtpngayhh);
            this.gbchitiet.Controls.Add(this.dtpngaysx);
            this.gbchitiet.Controls.Add(this.txtghichu);
            this.gbchitiet.Controls.Add(this.txtdongia);
            this.gbchitiet.Controls.Add(this.txtdonvi);
            this.gbchitiet.Controls.Add(this.lbghichu);
            this.gbchitiet.Controls.Add(this.lbdonvi);
            this.gbchitiet.Controls.Add(this.lbdongia);
            this.gbchitiet.Controls.Add(this.lbngaysx);
            this.gbchitiet.Controls.Add(this.lbngayhh);
            this.gbchitiet.Controls.Add(this.txttensp2);
            this.gbchitiet.Controls.Add(this.txtmsp2);
            this.gbchitiet.Controls.Add(this.lbtensp2);
            this.gbchitiet.Controls.Add(this.lbmsp2);
            this.gbchitiet.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbchitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbchitiet.Location = new System.Drawing.Point(1118, 92);
            this.gbchitiet.Name = "gbchitiet";
            this.gbchitiet.Size = new System.Drawing.Size(452, 561);
            this.gbchitiet.TabIndex = 2;
            this.gbchitiet.TabStop = false;
            this.gbchitiet.Text = "Chi tiết";
            // 
            // btnhuy
            // 
            this.btnhuy.Location = new System.Drawing.Point(216, 435);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(97, 46);
            this.btnhuy.TabIndex = 17;
            this.btnhuy.Text = "&Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(41, 435);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(103, 46);
            this.btnluu.TabIndex = 16;
            this.btnluu.Text = "&Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dtpngayhh
            // 
            this.dtpngayhh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngayhh.Location = new System.Drawing.Point(113, 209);
            this.dtpngayhh.Name = "dtpngayhh";
            this.dtpngayhh.Size = new System.Drawing.Size(200, 24);
            this.dtpngayhh.TabIndex = 15;
            // 
            // dtpngaysx
            // 
            this.dtpngaysx.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngaysx.Location = new System.Drawing.Point(113, 149);
            this.dtpngaysx.Name = "dtpngaysx";
            this.dtpngaysx.Size = new System.Drawing.Size(200, 24);
            this.dtpngaysx.TabIndex = 14;
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(113, 356);
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(200, 24);
            this.txtghichu.TabIndex = 13;
            // 
            // txtdongia
            // 
            this.txtdongia.Location = new System.Drawing.Point(113, 306);
            this.txtdongia.Name = "txtdongia";
            this.txtdongia.Size = new System.Drawing.Size(200, 24);
            this.txtdongia.TabIndex = 12;
            this.txtdongia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdongia_KeyPress);
            // 
            // txtdonvi
            // 
            this.txtdonvi.Location = new System.Drawing.Point(113, 254);
            this.txtdonvi.Name = "txtdonvi";
            this.txtdonvi.Size = new System.Drawing.Size(200, 24);
            this.txtdonvi.TabIndex = 11;
            // 
            // lbghichu
            // 
            this.lbghichu.AutoSize = true;
            this.lbghichu.Location = new System.Drawing.Point(38, 359);
            this.lbghichu.Name = "lbghichu";
            this.lbghichu.Size = new System.Drawing.Size(63, 18);
            this.lbghichu.TabIndex = 10;
            this.lbghichu.Text = "Ghi chú:";
            // 
            // lbdonvi
            // 
            this.lbdonvi.AutoSize = true;
            this.lbdonvi.Location = new System.Drawing.Point(38, 260);
            this.lbdonvi.Name = "lbdonvi";
            this.lbdonvi.Size = new System.Drawing.Size(54, 18);
            this.lbdonvi.TabIndex = 9;
            this.lbdonvi.Text = "Đơn vị:";
            // 
            // lbdongia
            // 
            this.lbdongia.AutoSize = true;
            this.lbdongia.Location = new System.Drawing.Point(36, 312);
            this.lbdongia.Name = "lbdongia";
            this.lbdongia.Size = new System.Drawing.Size(63, 18);
            this.lbdongia.TabIndex = 8;
            this.lbdongia.Text = "Đơn giá:";
            // 
            // lbngaysx
            // 
            this.lbngaysx.AutoSize = true;
            this.lbngaysx.Location = new System.Drawing.Point(38, 155);
            this.lbngaysx.Name = "lbngaysx";
            this.lbngaysx.Size = new System.Drawing.Size(70, 18);
            this.lbngaysx.TabIndex = 7;
            this.lbngaysx.Text = "Ngày SX:";
            // 
            // lbngayhh
            // 
            this.lbngayhh.AutoSize = true;
            this.lbngayhh.Location = new System.Drawing.Point(38, 209);
            this.lbngayhh.Name = "lbngayhh";
            this.lbngayhh.Size = new System.Drawing.Size(72, 18);
            this.lbngayhh.TabIndex = 6;
            this.lbngayhh.Text = "Ngày HH:";
            // 
            // txttensp2
            // 
            this.txttensp2.Location = new System.Drawing.Point(113, 100);
            this.txttensp2.Name = "txttensp2";
            this.txttensp2.Size = new System.Drawing.Size(200, 24);
            this.txttensp2.TabIndex = 5;
            // 
            // txtmsp2
            // 
            this.txtmsp2.Location = new System.Drawing.Point(113, 58);
            this.txtmsp2.Name = "txtmsp2";
            this.txtmsp2.Size = new System.Drawing.Size(200, 24);
            this.txtmsp2.TabIndex = 5;
            // 
            // lbtensp2
            // 
            this.lbtensp2.AutoSize = true;
            this.lbtensp2.Location = new System.Drawing.Point(38, 100);
            this.lbtensp2.Name = "lbtensp2";
            this.lbtensp2.Size = new System.Drawing.Size(61, 18);
            this.lbtensp2.TabIndex = 5;
            this.lbtensp2.Text = "Tên SP:";
            // 
            // lbmsp2
            // 
            this.lbmsp2.AutoSize = true;
            this.lbmsp2.Location = new System.Drawing.Point(38, 61);
            this.lbmsp2.Name = "lbmsp2";
            this.lbmsp2.Size = new System.Drawing.Size(57, 18);
            this.lbmsp2.TabIndex = 5;
            this.lbmsp2.Text = "Mã SP:";
            // 
            // errChiTiet
            // 
            this.errChiTiet.ContainerControl = this;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(1108, 92);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 561);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // gbtimkiem
            // 
            this.gbtimkiem.Controls.Add(this.txttensp1);
            this.gbtimkiem.Controls.Add(this.txtmsp1);
            this.gbtimkiem.Controls.Add(this.lbtensp1);
            this.gbtimkiem.Controls.Add(this.lbmsp1);
            this.gbtimkiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbtimkiem.Location = new System.Drawing.Point(0, 92);
            this.gbtimkiem.Name = "gbtimkiem";
            this.gbtimkiem.Size = new System.Drawing.Size(1108, 94);
            this.gbtimkiem.TabIndex = 6;
            this.gbtimkiem.TabStop = false;
            this.gbtimkiem.Text = "Tìm kiếm";
            // 
            // txttensp1
            // 
            this.txttensp1.Location = new System.Drawing.Point(540, 39);
            this.txttensp1.Name = "txttensp1";
            this.txttensp1.Size = new System.Drawing.Size(200, 24);
            this.txttensp1.TabIndex = 9;
            // 
            // txtmsp1
            // 
            this.txtmsp1.Location = new System.Drawing.Point(131, 39);
            this.txtmsp1.Name = "txtmsp1";
            this.txtmsp1.Size = new System.Drawing.Size(200, 24);
            this.txtmsp1.TabIndex = 8;
            // 
            // lbtensp1
            // 
            this.lbtensp1.AutoSize = true;
            this.lbtensp1.Location = new System.Drawing.Point(444, 42);
            this.lbtensp1.Name = "lbtensp1";
            this.lbtensp1.Size = new System.Drawing.Size(61, 18);
            this.lbtensp1.TabIndex = 7;
            this.lbtensp1.Text = "Tên SP:";
            // 
            // lbmsp1
            // 
            this.lbmsp1.AutoSize = true;
            this.lbmsp1.Location = new System.Drawing.Point(56, 42);
            this.lbmsp1.Name = "lbmsp1";
            this.lbmsp1.Size = new System.Drawing.Size(57, 18);
            this.lbmsp1.TabIndex = 6;
            this.lbmsp1.Text = "Mã SP:";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 186);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1108, 10);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // gbketqua
            // 
            this.gbketqua.Controls.Add(this.dgvKetQua);
            this.gbketqua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbketqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbketqua.Location = new System.Drawing.Point(0, 196);
            this.gbketqua.Name = "gbketqua";
            this.gbketqua.Size = new System.Drawing.Size(1108, 457);
            this.gbketqua.TabIndex = 8;
            this.gbketqua.TabStop = false;
            this.gbketqua.Text = "Kết quả";
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Location = new System.Drawing.Point(3, 20);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersWidth = 51;
            this.dgvKetQua.RowTemplate.Height = 24;
            this.dgvKetQua.Size = new System.Drawing.Size(1102, 434);
            this.dgvKetQua.TabIndex = 0;
            this.dgvKetQua.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQua_CellClick);
            // 
            // Frmmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 753);
            this.Controls.Add(this.gbketqua);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.gbtimkiem);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.gbchitiet);
            this.Controls.Add(this.pnchucnang);
            this.Controls.Add(this.pntieude);
            this.Name = "Frmmain";
            this.Text = "Quản lý sản phẩm";
            this.Load += new System.EventHandler(this.frmMatHang_Load);
            this.pntieude.ResumeLayout(false);
            this.pntieude.PerformLayout();
            this.pnchucnang.ResumeLayout(false);
            this.gbchitiet.ResumeLayout(false);
            this.gbchitiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errChiTiet)).EndInit();
            this.gbtimkiem.ResumeLayout(false);
            this.gbtimkiem.PerformLayout();
            this.gbketqua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pntieude;
        private System.Windows.Forms.Panel pnchucnang;
        private System.Windows.Forms.GroupBox gbchitiet;
        private System.Windows.Forms.Label lbtieude;
        private System.Windows.Forms.Label lbghichu;
        private System.Windows.Forms.Label lbdonvi;
        private System.Windows.Forms.Label lbdongia;
        private System.Windows.Forms.Label lbngaysx;
        private System.Windows.Forms.Label lbngayhh;
        private System.Windows.Forms.TextBox txttensp2;
        private System.Windows.Forms.TextBox txtmsp2;
        private System.Windows.Forms.Label lbtensp2;
        private System.Windows.Forms.Label lbmsp2;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.DateTimePicker dtpngayhh;
        private System.Windows.Forms.DateTimePicker dtpngaysx;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txtdongia;
        private System.Windows.Forms.TextBox txtdonvi;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.ErrorProvider errChiTiet;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox gbketqua;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox gbtimkiem;
        private System.Windows.Forms.TextBox txttensp1;
        private System.Windows.Forms.TextBox txtmsp1;
        private System.Windows.Forms.Label lbtensp1;
        private System.Windows.Forms.Label lbmsp1;
    }
}

