namespace bt_form_13_9_20224
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
            this.btnAddDs = new System.Windows.Forms.Button();
            this.tbDiem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSoTinChi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxNameSub = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbDanhSach = new System.Windows.Forms.ListBox();
            this.tbTongSoTinChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTongSoDiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDiemTrungBinh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTinh = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddDs);
            this.groupBox1.Controls.Add(this.tbDiem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbSoTinChi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxNameSub);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(53, 43);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(338, 400);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên";
            // 
            // btnAddDs
            // 
            this.btnAddDs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddDs.Location = new System.Drawing.Point(73, 274);
            this.btnAddDs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddDs.Name = "btnAddDs";
            this.btnAddDs.Size = new System.Drawing.Size(162, 32);
            this.btnAddDs.TabIndex = 6;
            this.btnAddDs.Text = "Them vao &DS";
            this.btnAddDs.UseVisualStyleBackColor = false;
            this.btnAddDs.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // tbDiem
            // 
            this.tbDiem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDiem.Location = new System.Drawing.Point(103, 178);
            this.tbDiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDiem.Name = "tbDiem";
            this.tbDiem.Size = new System.Drawing.Size(142, 22);
            this.tbDiem.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Diem";
            // 
            // tbSoTinChi
            // 
            this.tbSoTinChi.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbSoTinChi.Location = new System.Drawing.Point(103, 137);
            this.tbSoTinChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSoTinChi.Name = "tbSoTinChi";
            this.tbSoTinChi.ReadOnly = true;
            this.tbSoTinChi.Size = new System.Drawing.Size(195, 22);
            this.tbSoTinChi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "So tin chi";
            // 
            // comboBoxNameSub
            // 
            this.comboBoxNameSub.FormattingEnabled = true;
            this.comboBoxNameSub.Location = new System.Drawing.Point(27, 90);
            this.comboBoxNameSub.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxNameSub.Name = "comboBoxNameSub";
            this.comboBoxNameSub.Size = new System.Drawing.Size(272, 24);
            this.comboBoxNameSub.TabIndex = 1;
            this.comboBoxNameSub.SelectedIndexChanged += new System.EventHandler(this.comboBoxNameSub_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ten mon hoc";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbDanhSach);
            this.groupBox2.Location = new System.Drawing.Point(391, 43);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(654, 206);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách các môn học";
            // 
            // lbDanhSach
            // 
            this.lbDanhSach.FormattingEnabled = true;
            this.lbDanhSach.ItemHeight = 16;
            this.lbDanhSach.Location = new System.Drawing.Point(22, 30);
            this.lbDanhSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbDanhSach.Name = "lbDanhSach";
            this.lbDanhSach.Size = new System.Drawing.Size(612, 164);
            this.lbDanhSach.TabIndex = 0;
            // 
            // tbTongSoTinChi
            // 
            this.tbTongSoTinChi.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbTongSoTinChi.Location = new System.Drawing.Point(532, 278);
            this.tbTongSoTinChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTongSoTinChi.Name = "tbTongSoTinChi";
            this.tbTongSoTinChi.ReadOnly = true;
            this.tbTongSoTinChi.Size = new System.Drawing.Size(168, 22);
            this.tbTongSoTinChi.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tong so tin chi";
            // 
            // tbTongSoDiem
            // 
            this.tbTongSoDiem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbTongSoDiem.Location = new System.Drawing.Point(858, 281);
            this.tbTongSoDiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTongSoDiem.Name = "tbTongSoDiem";
            this.tbTongSoDiem.ReadOnly = true;
            this.tbTongSoDiem.Size = new System.Drawing.Size(168, 22);
            this.tbTongSoDiem.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(738, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tong so diem";
            // 
            // tbDiemTrungBinh
            // 
            this.tbDiemTrungBinh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDiemTrungBinh.Location = new System.Drawing.Point(568, 351);
            this.tbDiemTrungBinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDiemTrungBinh.Name = "tbDiemTrungBinh";
            this.tbDiemTrungBinh.ReadOnly = true;
            this.tbDiemTrungBinh.Size = new System.Drawing.Size(269, 22);
            this.tbDiemTrungBinh.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(412, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Diem trung binh";
            // 
            // btnTinh
            // 
            this.btnTinh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnTinh.Location = new System.Drawing.Point(505, 410);
            this.btnTinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(146, 42);
            this.btnTinh.TabIndex = 10;
            this.btnTinh.Text = "&Tinh";
            this.btnTinh.UseVisualStyleBackColor = false;
            this.btnTinh.Click += new System.EventHandler(this.buttonTinh_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnThoat.Location = new System.Drawing.Point(819, 410);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(146, 42);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "T&hoat";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 493);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.tbDiemTrungBinh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbTongSoDiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTongSoTinChi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxNameSub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddDs;
        private System.Windows.Forms.TextBox tbDiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSoTinChi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTongSoTinChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTongSoDiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDiemTrungBinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ListBox lbDanhSach;
    }
}

