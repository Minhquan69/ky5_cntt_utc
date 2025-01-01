namespace WindowsFormsApp2
{
    partial class BTT3_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTT3_1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbtaptin = new System.Windows.Forms.RichTextBox();
            this.cbbOdia = new System.Windows.Forms.ComboBox();
            this.cbbThumuc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNhac = new System.Windows.Forms.ListBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ổ đĩa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thư mục";
            // 
            // rtbtaptin
            // 
            this.rtbtaptin.Location = new System.Drawing.Point(402, 27);
            this.rtbtaptin.Name = "rtbtaptin";
            this.rtbtaptin.Size = new System.Drawing.Size(386, 411);
            this.rtbtaptin.TabIndex = 2;
            this.rtbtaptin.Text = "";
            // 
            // cbbOdia
            // 
            this.cbbOdia.FormattingEnabled = true;
            this.cbbOdia.Location = new System.Drawing.Point(120, 27);
            this.cbbOdia.Name = "cbbOdia";
            this.cbbOdia.Size = new System.Drawing.Size(266, 24);
            this.cbbOdia.TabIndex = 3;
            this.cbbOdia.SelectedIndexChanged += new System.EventHandler(this.cbbOdia_SelectedIndexChanged);
            // 
            // cbbThumuc
            // 
            this.cbbThumuc.FormattingEnabled = true;
            this.cbbThumuc.Location = new System.Drawing.Point(120, 70);
            this.cbbThumuc.Name = "cbbThumuc";
            this.cbbThumuc.Size = new System.Drawing.Size(266, 24);
            this.cbbThumuc.TabIndex = 4;
            this.cbbThumuc.SelectedIndexChanged += new System.EventHandler(this.cbbThumuc_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tập tin";
            // 
            // lbNhac
            // 
            this.lbNhac.FormattingEnabled = true;
            this.lbNhac.ItemHeight = 16;
            this.lbNhac.Location = new System.Drawing.Point(12, 132);
            this.lbNhac.Name = "lbNhac";
            this.lbNhac.ScrollAlwaysVisible = true;
            this.lbNhac.Size = new System.Drawing.Size(374, 116);
            this.lbNhac.TabIndex = 6;
            this.lbNhac.SelectedIndexChanged += new System.EventHandler(this.lbNhac_SelectedIndexChanged);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 215);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(277, 132);
            this.axWindowsMediaPlayer1.TabIndex = 7;
            // 
            // BTT3_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.lbNhac);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbThumuc);
            this.Controls.Add(this.cbbOdia);
            this.Controls.Add(this.rtbtaptin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BTT3_1";
            this.Text = "Ví dụ ComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbtaptin;
        private System.Windows.Forms.ComboBox cbbOdia;
        private System.Windows.Forms.ComboBox cbbThumuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbNhac;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}