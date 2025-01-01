namespace FormMenu
{
    partial class Form3
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSec = new System.Windows.Forms.RadioButton();
            this.rdoTheTinDung = new System.Windows.Forms.RadioButton();
            this.rdoTienMat = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoDienThoai = new System.Windows.Forms.RadioButton();
            this.rdoFax = new System.Windows.Forms.RadioButton();
            this.rdoEmail = new System.Windows.Forms.RadioButton();
            this.btndy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(514, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Danh sách các mặt hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(514, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hàng đặt mua";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(82, 41);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(188, 20);
            this.txtHoTen.TabIndex = 4;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(575, 52);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(172, 20);
            this.txtDienThoai.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(40, 133);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(230, 186);
            this.listBox1.TabIndex = 6;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(517, 133);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(230, 186);
            this.listBox2.TabIndex = 7;
            this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSec);
            this.groupBox1.Controls.Add(this.rdoTheTinDung);
            this.groupBox1.Controls.Add(this.rdoTienMat);
            this.groupBox1.Location = new System.Drawing.Point(40, 338);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phương thức thanh toán";
            // 
            // rdoSec
            // 
            this.rdoSec.AutoSize = true;
            this.rdoSec.Location = new System.Drawing.Point(19, 42);
            this.rdoSec.Name = "rdoSec";
            this.rdoSec.Size = new System.Drawing.Size(44, 17);
            this.rdoSec.TabIndex = 11;
            this.rdoSec.TabStop = true;
            this.rdoSec.Text = "Sec";
            this.rdoSec.UseVisualStyleBackColor = true;
            // 
            // rdoTheTinDung
            // 
            this.rdoTheTinDung.AutoSize = true;
            this.rdoTheTinDung.Location = new System.Drawing.Point(19, 65);
            this.rdoTheTinDung.Name = "rdoTheTinDung";
            this.rdoTheTinDung.Size = new System.Drawing.Size(87, 17);
            this.rdoTheTinDung.TabIndex = 12;
            this.rdoTheTinDung.TabStop = true;
            this.rdoTheTinDung.Text = "Thẻ tín dụng";
            this.rdoTheTinDung.UseVisualStyleBackColor = true;
            // 
            // rdoTienMat
            // 
            this.rdoTienMat.AutoSize = true;
            this.rdoTienMat.Location = new System.Drawing.Point(19, 19);
            this.rdoTienMat.Name = "rdoTienMat";
            this.rdoTienMat.Size = new System.Drawing.Size(66, 17);
            this.rdoTienMat.TabIndex = 10;
            this.rdoTienMat.TabStop = true;
            this.rdoTienMat.Text = "Tiền mặt";
            this.rdoTienMat.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoDienThoai);
            this.groupBox2.Controls.Add(this.rdoFax);
            this.groupBox2.Controls.Add(this.rdoEmail);
            this.groupBox2.Location = new System.Drawing.Point(517, 338);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hình thức liên lạc";
            // 
            // rdoDienThoai
            // 
            this.rdoDienThoai.AutoSize = true;
            this.rdoDienThoai.Location = new System.Drawing.Point(21, 19);
            this.rdoDienThoai.Name = "rdoDienThoai";
            this.rdoDienThoai.Size = new System.Drawing.Size(73, 17);
            this.rdoDienThoai.TabIndex = 13;
            this.rdoDienThoai.TabStop = true;
            this.rdoDienThoai.Text = "Điện thoại";
            this.rdoDienThoai.UseVisualStyleBackColor = true;
            // 
            // rdoFax
            // 
            this.rdoFax.AutoSize = true;
            this.rdoFax.Location = new System.Drawing.Point(21, 42);
            this.rdoFax.Name = "rdoFax";
            this.rdoFax.Size = new System.Drawing.Size(42, 17);
            this.rdoFax.TabIndex = 14;
            this.rdoFax.TabStop = true;
            this.rdoFax.Text = "Fax";
            this.rdoFax.UseVisualStyleBackColor = true;
            // 
            // rdoEmail
            // 
            this.rdoEmail.AutoSize = true;
            this.rdoEmail.Location = new System.Drawing.Point(21, 65);
            this.rdoEmail.Name = "rdoEmail";
            this.rdoEmail.Size = new System.Drawing.Size(50, 17);
            this.rdoEmail.TabIndex = 15;
            this.rdoEmail.TabStop = true;
            this.rdoEmail.Text = "Email";
            this.rdoEmail.UseVisualStyleBackColor = true;
            // 
            // btndy
            // 
            this.btndy.Location = new System.Drawing.Point(293, 380);
            this.btndy.Name = "btndy";
            this.btndy.Size = new System.Drawing.Size(75, 23);
            this.btndy.TabIndex = 10;
            this.btndy.Text = "Đồng ý";
            this.btndy.UseVisualStyleBackColor = true;
            this.btndy.Click += new System.EventHandler(this.btndy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(404, 380);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btndy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoSec;
        private System.Windows.Forms.RadioButton rdoTheTinDung;
        private System.Windows.Forms.RadioButton rdoTienMat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoDienThoai;
        private System.Windows.Forms.RadioButton rdoFax;
        private System.Windows.Forms.RadioButton rdoEmail;
        private System.Windows.Forms.Button btndy;
        private System.Windows.Forms.Button btnThoat;
    }
}

