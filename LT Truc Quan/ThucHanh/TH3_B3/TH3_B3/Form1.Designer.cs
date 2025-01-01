namespace TH3_B3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbodia = new System.Windows.Forms.Label();
            this.lbthumuc = new System.Windows.Forms.Label();
            this.lbtaptin = new System.Windows.Forms.Label();
            this.cbbodia = new System.Windows.Forms.ComboBox();
            this.cbbthumuc = new System.Windows.Forms.ComboBox();
            this.rtbtaptin = new System.Windows.Forms.RichTextBox();
            this.lbnhac = new System.Windows.Forms.ListBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbodia
            // 
            this.lbodia.AutoSize = true;
            this.lbodia.Location = new System.Drawing.Point(29, 29);
            this.lbodia.Name = "lbodia";
            this.lbodia.Size = new System.Drawing.Size(37, 20);
            this.lbodia.TabIndex = 0;
            this.lbodia.Text = "Ổ đĩa";
            this.lbodia.UseCompatibleTextRendering = true;
            // 
            // lbthumuc
            // 
            this.lbthumuc.AutoSize = true;
            this.lbthumuc.Location = new System.Drawing.Point(26, 80);
            this.lbthumuc.Name = "lbthumuc";
            this.lbthumuc.Size = new System.Drawing.Size(58, 16);
            this.lbthumuc.TabIndex = 1;
            this.lbthumuc.Text = "Thư mục";
            // 
            // lbtaptin
            // 
            this.lbtaptin.AutoSize = true;
            this.lbtaptin.Location = new System.Drawing.Point(26, 137);
            this.lbtaptin.Name = "lbtaptin";
            this.lbtaptin.Size = new System.Drawing.Size(48, 16);
            this.lbtaptin.TabIndex = 2;
            this.lbtaptin.Text = "Tập tin";
            // 
            // cbbodia
            // 
            this.cbbodia.FormattingEnabled = true;
            this.cbbodia.Location = new System.Drawing.Point(126, 29);
            this.cbbodia.Name = "cbbodia";
            this.cbbodia.Size = new System.Drawing.Size(235, 24);
            this.cbbodia.TabIndex = 3;
            this.cbbodia.SelectedIndexChanged += new System.EventHandler(this.cbbodia_SelectedIndexChanged);
            // 
            // cbbthumuc
            // 
            this.cbbthumuc.FormattingEnabled = true;
            this.cbbthumuc.Location = new System.Drawing.Point(126, 77);
            this.cbbthumuc.Name = "cbbthumuc";
            this.cbbthumuc.Size = new System.Drawing.Size(235, 24);
            this.cbbthumuc.TabIndex = 4;
            this.cbbthumuc.SelectedIndexChanged += new System.EventHandler(this.cbbthumuc_SelectedIndexChanged);
            // 
            // rtbtaptin
            // 
            this.rtbtaptin.Location = new System.Drawing.Point(541, 44);
            this.rtbtaptin.Name = "rtbtaptin";
            this.rtbtaptin.Size = new System.Drawing.Size(481, 600);
            this.rtbtaptin.TabIndex = 5;
            this.rtbtaptin.Text = "";
            // 
            // lbnhac
            // 
            this.lbnhac.FormattingEnabled = true;
            this.lbnhac.ItemHeight = 16;
            this.lbnhac.Location = new System.Drawing.Point(29, 165);
            this.lbnhac.Name = "lbnhac";
            this.lbnhac.Size = new System.Drawing.Size(332, 116);
            this.lbnhac.TabIndex = 6;
            this.lbnhac.SelectedIndexChanged += new System.EventHandler(this.lbnhac_SelectedIndexChanged);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(29, 309);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(321, 209);
            this.axWindowsMediaPlayer1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 656);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.lbnhac);
            this.Controls.Add(this.rtbtaptin);
            this.Controls.Add(this.cbbthumuc);
            this.Controls.Add(this.cbbodia);
            this.Controls.Add(this.lbtaptin);
            this.Controls.Add(this.lbthumuc);
            this.Controls.Add(this.lbodia);
            this.Name = "Form1";
            this.Text = " Ví dụ ComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbodia;
        private System.Windows.Forms.Label lbthumuc;
        private System.Windows.Forms.Label lbtaptin;
        private System.Windows.Forms.ComboBox cbbodia;
        private System.Windows.Forms.ComboBox cbbthumuc;
        private System.Windows.Forms.RichTextBox rtbtaptin;
        private System.Windows.Forms.ListBox lbnhac;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

