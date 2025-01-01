namespace WindowsFormsApp2
{
    partial class frmSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanPham));
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.lbuser = new System.Windows.Forms.Label();
            this.lbtieude = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lbghichu = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvHang = new System.Windows.Forms.DataGridView();
            this.cboChatLieu = new System.Windows.Forms.ComboBox();
            this.txtDonGiaBan = new System.Windows.Forms.TextBox();
            this.txtDonGiaNhap = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.TxtTen = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.piBImage = new System.Windows.Forms.PictureBox();
            this.btnAnh = new System.Windows.Forms.Button();
            this.lbdgb = new System.Windows.Forms.Label();
            this.lbdgn = new System.Windows.Forms.Label();
            this.lbsl = new System.Windows.Forms.Label();
            this.lbchatlieu = new System.Windows.Forms.Label();
            this.lbtenhang = new System.Windows.Forms.Label();
            this.lbmahang = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piBImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHuy.BackgroundImage")));
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHuy.Location = new System.Drawing.Point(747, 732);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(158, 48);
            this.btnHuy.TabIndex = 71;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnluu
            // 
            this.btnluu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnluu.BackgroundImage")));
            this.btnluu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnluu.Location = new System.Drawing.Point(217, 732);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(158, 48);
            this.btnluu.TabIndex = 70;
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.lbuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbuser.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbuser.Location = new System.Drawing.Point(798, 9);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(0, 18);
            this.lbuser.TabIndex = 69;
            // 
            // lbtieude
            // 
            this.lbtieude.AutoSize = true;
            this.lbtieude.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lbtieude.ForeColor = System.Drawing.Color.Red;
            this.lbtieude.Location = new System.Drawing.Point(337, 9);
            this.lbtieude.Name = "lbtieude";
            this.lbtieude.Size = new System.Drawing.Size(402, 39);
            this.lbtieude.TabIndex = 68;
            this.lbtieude.Text = " DANH MỤC HÀNG HÓA";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(747, 337);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(327, 106);
            this.txtGhiChu.TabIndex = 67;
            // 
            // lbghichu
            // 
            this.lbghichu.AutoSize = true;
            this.lbghichu.Location = new System.Drawing.Point(631, 340);
            this.lbghichu.Name = "lbghichu";
            this.lbghichu.Size = new System.Drawing.Size(56, 16);
            this.lbghichu.TabIndex = 66;
            this.lbghichu.Text = "Ghi Chú:";
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.BackgroundImage")));
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThoat.Location = new System.Drawing.Point(927, 732);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(158, 48);
            this.btnThoat.TabIndex = 65;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.BackgroundImage")));
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.Location = new System.Drawing.Point(572, 732);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(158, 48);
            this.btnXoa.TabIndex = 64;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSua.BackgroundImage")));
            this.btnSua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSua.Location = new System.Drawing.Point(408, 732);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(158, 48);
            this.btnSua.TabIndex = 63;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThem.BackgroundImage")));
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.Location = new System.Drawing.Point(25, 732);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(164, 48);
            this.btnThem.TabIndex = 62;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvHang
            // 
            this.dgvHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHang.Location = new System.Drawing.Point(35, 449);
            this.dgvHang.Name = "dgvHang";
            this.dgvHang.RowHeadersWidth = 51;
            this.dgvHang.RowTemplate.Height = 24;
            this.dgvHang.Size = new System.Drawing.Size(1039, 259);
            this.dgvHang.TabIndex = 61;
            this.dgvHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHang_CellClick);
            this.dgvHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHang_CellContentClick);
            // 
            // cboChatLieu
            // 
            this.cboChatLieu.FormattingEnabled = true;
            this.cboChatLieu.Location = new System.Drawing.Point(166, 241);
            this.cboChatLieu.Name = "cboChatLieu";
            this.cboChatLieu.Size = new System.Drawing.Size(349, 24);
            this.cboChatLieu.TabIndex = 60;
            this.cboChatLieu.SelectedIndexChanged += new System.EventHandler(this.cboChatLieu_SelectedIndexChanged);
            // 
            // txtDonGiaBan
            // 
            this.txtDonGiaBan.Location = new System.Drawing.Point(166, 404);
            this.txtDonGiaBan.Name = "txtDonGiaBan";
            this.txtDonGiaBan.Size = new System.Drawing.Size(349, 22);
            this.txtDonGiaBan.TabIndex = 59;
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Location = new System.Drawing.Point(166, 348);
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(349, 22);
            this.txtDonGiaNhap.TabIndex = 58;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(166, 291);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(349, 22);
            this.txtSoLuong.TabIndex = 57;
            // 
            // TxtTen
            // 
            this.TxtTen.Location = new System.Drawing.Point(166, 185);
            this.TxtTen.Name = "TxtTen";
            this.TxtTen.Size = new System.Drawing.Size(349, 22);
            this.TxtTen.TabIndex = 56;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(166, 123);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(349, 22);
            this.txtMa.TabIndex = 55;
            // 
            // piBImage
            // 
            this.piBImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.piBImage.Location = new System.Drawing.Point(747, 95);
            this.piBImage.Name = "piBImage";
            this.piBImage.Size = new System.Drawing.Size(260, 218);
            this.piBImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.piBImage.TabIndex = 54;
            this.piBImage.TabStop = false;
            // 
            // btnAnh
            // 
            this.btnAnh.Location = new System.Drawing.Point(634, 95);
            this.btnAnh.Name = "btnAnh";
            this.btnAnh.Size = new System.Drawing.Size(96, 38);
            this.btnAnh.TabIndex = 53;
            this.btnAnh.Text = "Ảnh";
            this.btnAnh.UseVisualStyleBackColor = true;
            this.btnAnh.Click += new System.EventHandler(this.btnAnh_Click);
            // 
            // lbdgb
            // 
            this.lbdgb.AutoSize = true;
            this.lbdgb.Location = new System.Drawing.Point(32, 407);
            this.lbdgb.Name = "lbdgb";
            this.lbdgb.Size = new System.Drawing.Size(79, 16);
            this.lbdgb.TabIndex = 52;
            this.lbdgb.Text = "Đơn giá bán";
            // 
            // lbdgn
            // 
            this.lbdgn.AutoSize = true;
            this.lbdgn.Location = new System.Drawing.Point(32, 351);
            this.lbdgn.Name = "lbdgn";
            this.lbdgn.Size = new System.Drawing.Size(86, 16);
            this.lbdgn.TabIndex = 51;
            this.lbdgn.Text = "Đơn giá nhập";
            // 
            // lbsl
            // 
            this.lbsl.AutoSize = true;
            this.lbsl.Location = new System.Drawing.Point(32, 297);
            this.lbsl.Name = "lbsl";
            this.lbsl.Size = new System.Drawing.Size(60, 16);
            this.lbsl.TabIndex = 50;
            this.lbsl.Text = "Số lượng";
            // 
            // lbchatlieu
            // 
            this.lbchatlieu.AutoSize = true;
            this.lbchatlieu.Location = new System.Drawing.Point(34, 244);
            this.lbchatlieu.Name = "lbchatlieu";
            this.lbchatlieu.Size = new System.Drawing.Size(58, 16);
            this.lbchatlieu.TabIndex = 49;
            this.lbchatlieu.Text = "Chất liệu";
            // 
            // lbtenhang
            // 
            this.lbtenhang.AutoSize = true;
            this.lbtenhang.Location = new System.Drawing.Point(34, 191);
            this.lbtenhang.Name = "lbtenhang";
            this.lbtenhang.Size = new System.Drawing.Size(67, 16);
            this.lbtenhang.TabIndex = 48;
            this.lbtenhang.Text = "Tên hàng:";
            // 
            // lbmahang
            // 
            this.lbmahang.AutoSize = true;
            this.lbmahang.Location = new System.Drawing.Point(42, 126);
            this.lbmahang.Name = "lbmahang";
            this.lbmahang.Size = new System.Drawing.Size(59, 16);
            this.lbmahang.TabIndex = 47;
            this.lbmahang.Text = "Mã hàng";
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1113, 792);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.lbuser);
            this.Controls.Add(this.lbtieude);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lbghichu);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvHang);
            this.Controls.Add(this.cboChatLieu);
            this.Controls.Add(this.txtDonGiaBan);
            this.Controls.Add(this.txtDonGiaNhap);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.TxtTen);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.piBImage);
            this.Controls.Add(this.btnAnh);
            this.Controls.Add(this.lbdgb);
            this.Controls.Add(this.lbdgn);
            this.Controls.Add(this.lbsl);
            this.Controls.Add(this.lbchatlieu);
            this.Controls.Add(this.lbtenhang);
            this.Controls.Add(this.lbmahang);
            this.Name = "frmSanPham";
            this.Text = "frmSanPham";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piBImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Label lbuser;
        private System.Windows.Forms.Label lbtieude;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lbghichu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvHang;
        private System.Windows.Forms.ComboBox cboChatLieu;
        private System.Windows.Forms.TextBox txtDonGiaBan;
        private System.Windows.Forms.TextBox txtDonGiaNhap;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox TxtTen;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.PictureBox piBImage;
        private System.Windows.Forms.Button btnAnh;
        private System.Windows.Forms.Label lbdgb;
        private System.Windows.Forms.Label lbdgn;
        private System.Windows.Forms.Label lbsl;
        private System.Windows.Forms.Label lbchatlieu;
        private System.Windows.Forms.Label lbtenhang;
        private System.Windows.Forms.Label lbmahang;
    }
}