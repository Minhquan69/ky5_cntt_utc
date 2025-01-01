namespace FormMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bàiTậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bài11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bài15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bài25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bàiTậpToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bàiTậpToolStripMenuItem
            // 
            this.bàiTậpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bài11ToolStripMenuItem,
            this.bài15ToolStripMenuItem,
            this.bài25ToolStripMenuItem});
            this.bàiTậpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bàiTậpToolStripMenuItem.Name = "bàiTậpToolStripMenuItem";
            this.bàiTậpToolStripMenuItem.Size = new System.Drawing.Size(85, 27);
            this.bàiTậpToolStripMenuItem.Text = "Bài Tập ";
            // 
            // bài11ToolStripMenuItem
            // 
            this.bài11ToolStripMenuItem.Name = "bài11ToolStripMenuItem";
            this.bài11ToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.bài11ToolStripMenuItem.Text = "Bài 11";
            this.bài11ToolStripMenuItem.Click += new System.EventHandler(this.bài11ToolStripMenuItem_Click);
            // 
            // bài15ToolStripMenuItem
            // 
            this.bài15ToolStripMenuItem.Name = "bài15ToolStripMenuItem";
            this.bài15ToolStripMenuItem.Size = new System.Drawing.Size(140, 28);
            this.bài15ToolStripMenuItem.Text = "Bài 15";
            this.bài15ToolStripMenuItem.Click += new System.EventHandler(this.bài15ToolStripMenuItem_Click);
            // 
            // bài25ToolStripMenuItem
            // 
            this.bài25ToolStripMenuItem.Name = "bài25ToolStripMenuItem";
            this.bài25ToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.bài25ToolStripMenuItem.Text = "Bài 25";
            this.bài25ToolStripMenuItem.Click += new System.EventHandler(this.bài25ToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(61, 27);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bàiTậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bài11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bài15ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bài25ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
    }
}

