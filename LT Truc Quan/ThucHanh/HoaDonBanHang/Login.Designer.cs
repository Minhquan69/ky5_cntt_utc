namespace HoaDonBanHang
{
    partial class Login
    {
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
            this.tk = new System.Windows.Forms.TextBox();
            this.mk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ten dang nhap";
            // 
            // tk
            // 
            this.tk.Location = new System.Drawing.Point(308, 87);
            this.tk.Name = "tk";
            this.tk.Size = new System.Drawing.Size(227, 26);
            this.tk.TabIndex = 1;
            // 
            // mk
            // 
            this.mk.Location = new System.Drawing.Point(308, 140);
            this.mk.Name = "mk";
            this.mk.Size = new System.Drawing.Size(227, 26);
            this.mk.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mat khau";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(163, 243);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(124, 56);
            this.login.TabIndex = 4;
            this.login.Text = "Dang nhap";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(371, 243);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(124, 56);
            this.exit.TabIndex = 5;
            this.exit.Text = "Huy bo";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(673, 370);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.login);
            this.Controls.Add(this.mk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tk);
            this.Controls.Add(this.label1);
            this.Name = "FormDangNhap";
            this.Text = "FormDangNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tk;
        private System.Windows.Forms.TextBox mk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button exit;
    }
}