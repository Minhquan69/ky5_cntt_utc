namespace WindowsFormsApp2
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
            this.lstDanhSach = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.cboThumuc = new System.Windows.Forms.ComboBox();
            this.clbMonAn = new System.Windows.Forms.CheckedListBox();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDanhSach
            // 
            this.lstDanhSach.FormattingEnabled = true;
            this.lstDanhSach.ItemHeight = 16;
            this.lstDanhSach.Location = new System.Drawing.Point(52, 29);
            this.lstDanhSach.Name = "lstDanhSach";
            this.lstDanhSach.Size = new System.Drawing.Size(701, 100);
            this.lstDanhSach.TabIndex = 0;
            this.lstDanhSach.SelectedIndexChanged += new System.EventHandler(this.lstDanhSach_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(395, 467);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cboThumuc
            // 
            this.cboThumuc.FormattingEnabled = true;
            this.cboThumuc.Location = new System.Drawing.Point(52, 176);
            this.cboThumuc.Name = "cboThumuc";
            this.cboThumuc.Size = new System.Drawing.Size(701, 24);
            this.cboThumuc.TabIndex = 2;
            // 
            // clbMonAn
            // 
            this.clbMonAn.FormattingEnabled = true;
            this.clbMonAn.Location = new System.Drawing.Point(52, 223);
            this.clbMonAn.Name = "clbMonAn";
            this.clbMonAn.Size = new System.Drawing.Size(701, 174);
            this.clbMonAn.TabIndex = 3;
            this.clbMonAn.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbMonAn_ItemCheck);
            this.clbMonAn.SelectedIndexChanged += new System.EventHandler(this.clbMonAn_SelectedIndexChanged);
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.Location = new System.Drawing.Point(361, 508);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(134, 41);
            this.btnHoanThanh.TabIndex = 4;
            this.btnHoanThanh.Text = "Hoàn Thành";
            this.btnHoanThanh.UseVisualStyleBackColor = true;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 632);
            this.Controls.Add(this.btnHoanThanh);
            this.Controls.Add(this.clbMonAn);
            this.Controls.Add(this.cboThumuc);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lstDanhSach);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDanhSach;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cboThumuc;
        private System.Windows.Forms.CheckedListBox clbMonAn;
        private System.Windows.Forms.Button btnHoanThanh;
    }
}