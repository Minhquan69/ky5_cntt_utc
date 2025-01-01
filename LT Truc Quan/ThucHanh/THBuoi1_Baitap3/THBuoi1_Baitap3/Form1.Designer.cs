namespace THBuoi1_Baitap3
{
    partial class FormBT3
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
            this.label_gptb2 = new System.Windows.Forms.Label();
            this.textBoxNhapA = new System.Windows.Forms.TextBox();
            this.textBoxNhapC = new System.Windows.Forms.TextBox();
            this.textBoxNhapB = new System.Windows.Forms.TextBox();
            this.labelNhapA = new System.Windows.Forms.Label();
            this.labelNhapB = new System.Windows.Forms.Label();
            this.labelNhapC = new System.Windows.Forms.Label();
            this.labelKQ = new System.Windows.Forms.Label();
            this.textBoxKQ = new System.Windows.Forms.TextBox();
            this.buttonGPT = new System.Windows.Forms.Button();
            this.buttonLL = new System.Windows.Forms.Button();
            this.buttonT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_gptb2
            // 
            this.label_gptb2.AutoSize = true;
            this.label_gptb2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_gptb2.ForeColor = System.Drawing.Color.Red;
            this.label_gptb2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_gptb2.Location = new System.Drawing.Point(148, 23);
            this.label_gptb2.Name = "label_gptb2";
            this.label_gptb2.Size = new System.Drawing.Size(329, 25);
            this.label_gptb2.TabIndex = 11;
            this.label_gptb2.Text = "GIẢI PHƯƠNG TRÌNH BẬC 2";
            // 
            // textBoxNhapA
            // 
            this.textBoxNhapA.Location = new System.Drawing.Point(211, 80);
            this.textBoxNhapA.Name = "textBoxNhapA";
            this.textBoxNhapA.Size = new System.Drawing.Size(243, 22);
            this.textBoxNhapA.TabIndex = 0;
            // 
            // textBoxNhapC
            // 
            this.textBoxNhapC.Location = new System.Drawing.Point(211, 214);
            this.textBoxNhapC.Name = "textBoxNhapC";
            this.textBoxNhapC.Size = new System.Drawing.Size(243, 22);
            this.textBoxNhapC.TabIndex = 4;
            // 
            // textBoxNhapB
            // 
            this.textBoxNhapB.Location = new System.Drawing.Point(211, 148);
            this.textBoxNhapB.Name = "textBoxNhapB";
            this.textBoxNhapB.Size = new System.Drawing.Size(243, 22);
            this.textBoxNhapB.TabIndex = 2;
            // 
            // labelNhapA
            // 
            this.labelNhapA.AutoSize = true;
            this.labelNhapA.Location = new System.Drawing.Point(114, 84);
            this.labelNhapA.Name = "labelNhapA";
            this.labelNhapA.Size = new System.Drawing.Size(54, 16);
            this.labelNhapA.TabIndex = 1;
            this.labelNhapA.Text = "Nhập a:";
            // 
            // labelNhapB
            // 
            this.labelNhapB.AutoSize = true;
            this.labelNhapB.Location = new System.Drawing.Point(114, 151);
            this.labelNhapB.Name = "labelNhapB";
            this.labelNhapB.Size = new System.Drawing.Size(54, 16);
            this.labelNhapB.TabIndex = 3;
            this.labelNhapB.Text = "Nhập b:";
            // 
            // labelNhapC
            // 
            this.labelNhapC.AutoSize = true;
            this.labelNhapC.Location = new System.Drawing.Point(114, 217);
            this.labelNhapC.Name = "labelNhapC";
            this.labelNhapC.Size = new System.Drawing.Size(53, 16);
            this.labelNhapC.TabIndex = 5;
            this.labelNhapC.Text = "Nhập c:";
            // 
            // labelKQ
            // 
            this.labelKQ.AutoSize = true;
            this.labelKQ.Location = new System.Drawing.Point(114, 280);
            this.labelKQ.Name = "labelKQ";
            this.labelKQ.Size = new System.Drawing.Size(55, 16);
            this.labelKQ.TabIndex = 7;
            this.labelKQ.Text = "Kết quả:";
            // 
            // textBoxKQ
            // 
            this.textBoxKQ.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxKQ.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxKQ.Location = new System.Drawing.Point(211, 277);
            this.textBoxKQ.Multiline = true;
            this.textBoxKQ.Name = "textBoxKQ";
            this.textBoxKQ.ReadOnly = true;
            this.textBoxKQ.Size = new System.Drawing.Size(242, 46);
            this.textBoxKQ.TabIndex = 6;
            // 
            // buttonGPT
            // 
            this.buttonGPT.Location = new System.Drawing.Point(86, 348);
            this.buttonGPT.Name = "buttonGPT";
            this.buttonGPT.Size = new System.Drawing.Size(125, 45);
            this.buttonGPT.TabIndex = 8;
            this.buttonGPT.Text = "&Giải PT";
            this.buttonGPT.UseVisualStyleBackColor = true;
            this.buttonGPT.Click += new System.EventHandler(this.buttonGPT_Click);
            // 
            // buttonLL
            // 
            this.buttonLL.Location = new System.Drawing.Point(267, 348);
            this.buttonLL.Name = "buttonLL";
            this.buttonLL.Size = new System.Drawing.Size(125, 45);
            this.buttonLL.TabIndex = 9;
            this.buttonLL.Text = "&Làm Lại";
            this.buttonLL.UseVisualStyleBackColor = true;
            this.buttonLL.Click += new System.EventHandler(this.buttonLL_Click);
            // 
            // buttonT
            // 
            this.buttonT.Location = new System.Drawing.Point(432, 348);
            this.buttonT.Name = "buttonT";
            this.buttonT.Size = new System.Drawing.Size(125, 45);
            this.buttonT.TabIndex = 10;
            this.buttonT.Text = "&Thoát";
            this.buttonT.UseVisualStyleBackColor = true;
            this.buttonT.Click += new System.EventHandler(this.buttonT_Click);
            // 
            // FormBT3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 450);
            this.Controls.Add(this.buttonT);
            this.Controls.Add(this.buttonLL);
            this.Controls.Add(this.buttonGPT);
            this.Controls.Add(this.textBoxKQ);
            this.Controls.Add(this.labelKQ);
            this.Controls.Add(this.labelNhapC);
            this.Controls.Add(this.labelNhapB);
            this.Controls.Add(this.labelNhapA);
            this.Controls.Add(this.textBoxNhapB);
            this.Controls.Add(this.textBoxNhapC);
            this.Controls.Add(this.textBoxNhapA);
            this.Controls.Add(this.label_gptb2);
            this.Name = "FormBT3";
            this.Text = "Bài tập 3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_gptb2;
        private System.Windows.Forms.TextBox textBoxNhapA;
        private System.Windows.Forms.TextBox textBoxNhapC;
        private System.Windows.Forms.TextBox textBoxNhapB;
        private System.Windows.Forms.Label labelNhapA;
        private System.Windows.Forms.Label labelNhapB;
        private System.Windows.Forms.Label labelNhapC;
        private System.Windows.Forms.Label labelKQ;
        private System.Windows.Forms.TextBox textBoxKQ;
        private System.Windows.Forms.Button buttonGPT;
        private System.Windows.Forms.Button buttonLL;
        private System.Windows.Forms.Button buttonT;
    }
}

