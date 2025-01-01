namespace WindowsFormsApp2
{
    partial class Form5
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
            this.labelBK = new System.Windows.Forms.Label();
            this.labelCV = new System.Windows.Forms.Label();
            this.labelDT = new System.Windows.Forms.Label();
            this.txtBK = new System.Windows.Forms.TextBox();
            this.txtCV = new System.Windows.Forms.TextBox();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.btnTinh = new System.Windows.Forms.Button();
            this.btnLamlai = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(70, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(664, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "TÍNH DIỆN TÍCH VÀ CHU VI HÌNH TRÒN";
            // 
            // labelBK
            // 
            this.labelBK.AutoSize = true;
            this.labelBK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBK.Location = new System.Drawing.Point(72, 119);
            this.labelBK.Name = "labelBK";
            this.labelBK.Size = new System.Drawing.Size(169, 25);
            this.labelBK.TabIndex = 1;
            this.labelBK.Text = "Nhập bán kính (r):";
            // 
            // labelCV
            // 
            this.labelCV.AutoSize = true;
            this.labelCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCV.Location = new System.Drawing.Point(72, 204);
            this.labelCV.Name = "labelCV";
            this.labelCV.Size = new System.Drawing.Size(74, 25);
            this.labelCV.TabIndex = 2;
            this.labelCV.Text = "Chu vi:";
            // 
            // labelDT
            // 
            this.labelDT.AutoSize = true;
            this.labelDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDT.Location = new System.Drawing.Point(72, 269);
            this.labelDT.Name = "labelDT";
            this.labelDT.Size = new System.Drawing.Size(93, 25);
            this.labelDT.TabIndex = 3;
            this.labelDT.Text = "Diện tích:";
            // 
            // txtBK
            // 
            this.txtBK.Location = new System.Drawing.Point(288, 122);
            this.txtBK.Name = "txtBK";
            this.txtBK.Size = new System.Drawing.Size(428, 22);
            this.txtBK.TabIndex = 4;
            // 
            // txtCV
            // 
            this.txtCV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCV.Enabled = false;
            this.txtCV.Location = new System.Drawing.Point(288, 204);
            this.txtCV.Name = "txtCV";
            this.txtCV.Size = new System.Drawing.Size(428, 22);
            this.txtCV.TabIndex = 5;
            // 
            // txtDT
            // 
            this.txtDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDT.Enabled = false;
            this.txtDT.Location = new System.Drawing.Point(288, 273);
            this.txtDT.Name = "txtDT";
            this.txtDT.Size = new System.Drawing.Size(428, 22);
            this.txtDT.TabIndex = 6;
            // 
            // btnTinh
            // 
            this.btnTinh.Location = new System.Drawing.Point(77, 374);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(145, 38);
            this.btnTinh.TabIndex = 7;
            this.btnTinh.Text = "&Tính";
            this.btnTinh.UseVisualStyleBackColor = true;
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // btnLamlai
            // 
            this.btnLamlai.Location = new System.Drawing.Point(328, 374);
            this.btnLamlai.Name = "btnLamlai";
            this.btnLamlai.Size = new System.Drawing.Size(145, 38);
            this.btnLamlai.TabIndex = 8;
            this.btnLamlai.Text = "&Làm lại";
            this.btnLamlai.UseVisualStyleBackColor = true;
            this.btnLamlai.Click += new System.EventHandler(this.btnLamlai_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(571, 374);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(145, 38);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "T&hoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLamlai);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.txtDT);
            this.Controls.Add(this.txtCV);
            this.Controls.Add(this.txtBK);
            this.Controls.Add(this.labelDT);
            this.Controls.Add(this.labelCV);
            this.Controls.Add(this.labelBK);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Bài tập về hình tròn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelBK;
        private System.Windows.Forms.Label labelCV;
        private System.Windows.Forms.Label labelDT;
        private System.Windows.Forms.TextBox txtBK;
        private System.Windows.Forms.TextBox txtCV;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Button btnLamlai;
        private System.Windows.Forms.Button btnThoat;
    }
}