namespace THBuoi1_Baitap2
{
    partial class FormPoint
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
            this.groupBoxPoint1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxPoint2 = new System.Windows.Forms.GroupBox();
            this.tB_PointX1 = new System.Windows.Forms.TextBox();
            this.tB_PointY1 = new System.Windows.Forms.TextBox();
            this.tB_PointX2 = new System.Windows.Forms.TextBox();
            this.tB_PointY2 = new System.Windows.Forms.TextBox();
            this.labelX1 = new System.Windows.Forms.Label();
            this.labelY1 = new System.Windows.Forms.Label();
            this.labelX2 = new System.Windows.Forms.Label();
            this.labelY2 = new System.Windows.Forms.Label();
            this.labelHSG = new System.Windows.Forms.Label();
            this.labelKC = new System.Windows.Forms.Label();
            this.textBoxHSG = new System.Windows.Forms.TextBox();
            this.textBoxKC = new System.Windows.Forms.TextBox();
            this.buttonTT = new System.Windows.Forms.Button();
            this.groupBoxPoint1.SuspendLayout();
            this.groupBoxPoint2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPoint1
            // 
            this.groupBoxPoint1.Controls.Add(this.labelY1);
            this.groupBoxPoint1.Controls.Add(this.labelX1);
            this.groupBoxPoint1.Controls.Add(this.tB_PointY1);
            this.groupBoxPoint1.Controls.Add(this.tB_PointX1);
            this.groupBoxPoint1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPoint1.Location = new System.Drawing.Point(56, 30);
            this.groupBoxPoint1.Name = "groupBoxPoint1";
            this.groupBoxPoint1.Size = new System.Drawing.Size(303, 167);
            this.groupBoxPoint1.TabIndex = 0;
            this.groupBoxPoint1.TabStop = false;
            this.groupBoxPoint1.Text = "Điểm thứ nhất";
            // 
            // groupBoxPoint2
            // 
            this.groupBoxPoint2.Controls.Add(this.labelY2);
            this.groupBoxPoint2.Controls.Add(this.labelX2);
            this.groupBoxPoint2.Controls.Add(this.tB_PointY2);
            this.groupBoxPoint2.Controls.Add(this.tB_PointX2);
            this.groupBoxPoint2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPoint2.Location = new System.Drawing.Point(448, 30);
            this.groupBoxPoint2.Name = "groupBoxPoint2";
            this.groupBoxPoint2.Size = new System.Drawing.Size(303, 167);
            this.groupBoxPoint2.TabIndex = 1;
            this.groupBoxPoint2.TabStop = false;
            this.groupBoxPoint2.Text = "Điểm thứ hai";
            // 
            // tB_PointX1
            // 
            this.tB_PointX1.Location = new System.Drawing.Point(88, 36);
            this.tB_PointX1.Multiline = true;
            this.tB_PointX1.Name = "tB_PointX1";
            this.tB_PointX1.Size = new System.Drawing.Size(193, 50);
            this.tB_PointX1.TabIndex = 0;
            // 
            // tB_PointY1
            // 
            this.tB_PointY1.Location = new System.Drawing.Point(89, 103);
            this.tB_PointY1.Multiline = true;
            this.tB_PointY1.Name = "tB_PointY1";
            this.tB_PointY1.Size = new System.Drawing.Size(191, 52);
            this.tB_PointY1.TabIndex = 1;
            // 
            // tB_PointX2
            // 
            this.tB_PointX2.Location = new System.Drawing.Point(78, 36);
            this.tB_PointX2.Multiline = true;
            this.tB_PointX2.Name = "tB_PointX2";
            this.tB_PointX2.Size = new System.Drawing.Size(193, 50);
            this.tB_PointX2.TabIndex = 1;
            // 
            // tB_PointY2
            // 
            this.tB_PointY2.Location = new System.Drawing.Point(78, 103);
            this.tB_PointY2.Multiline = true;
            this.tB_PointY2.Name = "tB_PointY2";
            this.tB_PointY2.Size = new System.Drawing.Size(193, 50);
            this.tB_PointY2.TabIndex = 2;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.Location = new System.Drawing.Point(39, 55);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(23, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "X";
            // 
            // labelY1
            // 
            this.labelY1.AutoSize = true;
            this.labelY1.Location = new System.Drawing.Point(39, 118);
            this.labelY1.Name = "labelY1";
            this.labelY1.Size = new System.Drawing.Size(24, 23);
            this.labelY1.TabIndex = 3;
            this.labelY1.Text = "Y";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.Location = new System.Drawing.Point(32, 55);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(23, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "X";
            // 
            // labelY2
            // 
            this.labelY2.AutoSize = true;
            this.labelY2.Location = new System.Drawing.Point(32, 118);
            this.labelY2.Name = "labelY2";
            this.labelY2.Size = new System.Drawing.Size(24, 23);
            this.labelY2.TabIndex = 4;
            this.labelY2.Text = "Y";
            // 
            // labelHSG
            // 
            this.labelHSG.AutoSize = true;
            this.labelHSG.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHSG.Location = new System.Drawing.Point(154, 230);
            this.labelHSG.Name = "labelHSG";
            this.labelHSG.Size = new System.Drawing.Size(99, 23);
            this.labelHSG.TabIndex = 2;
            this.labelHSG.Text = "Hệ số góc";
            // 
            // labelKC
            // 
            this.labelKC.AutoSize = true;
            this.labelKC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKC.Location = new System.Drawing.Point(541, 230);
            this.labelKC.Name = "labelKC";
            this.labelKC.Size = new System.Drawing.Size(123, 23);
            this.labelKC.TabIndex = 3;
            this.labelKC.Text = "Khoảng cách";
            // 
            // textBoxHSG
            // 
            this.textBoxHSG.Location = new System.Drawing.Point(58, 259);
            this.textBoxHSG.Multiline = true;
            this.textBoxHSG.Name = "textBoxHSG";
            this.textBoxHSG.ReadOnly = true;
            this.textBoxHSG.Size = new System.Drawing.Size(300, 49);
            this.textBoxHSG.TabIndex = 4;
            // 
            // textBoxKC
            // 
            this.textBoxKC.Location = new System.Drawing.Point(448, 259);
            this.textBoxKC.Multiline = true;
            this.textBoxKC.Name = "textBoxKC";
            this.textBoxKC.ReadOnly = true;
            this.textBoxKC.Size = new System.Drawing.Size(300, 49);
            this.textBoxKC.TabIndex = 5;
            // 
            // buttonTT
            // 
            this.buttonTT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTT.Location = new System.Drawing.Point(331, 349);
            this.buttonTT.Name = "buttonTT";
            this.buttonTT.Size = new System.Drawing.Size(137, 48);
            this.buttonTT.TabIndex = 6;
            this.buttonTT.Text = "Tính toán";
            this.buttonTT.UseVisualStyleBackColor = true;
            this.buttonTT.Click += new System.EventHandler(this.buttonTT_Click);
            // 
            // FormPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonTT);
            this.Controls.Add(this.textBoxKC);
            this.Controls.Add(this.textBoxHSG);
            this.Controls.Add(this.labelKC);
            this.Controls.Add(this.labelHSG);
            this.Controls.Add(this.groupBoxPoint2);
            this.Controls.Add(this.groupBoxPoint1);
            this.Name = "FormPoint";
            this.Text = "Toa do cac diem";
            this.groupBoxPoint1.ResumeLayout(false);
            this.groupBoxPoint1.PerformLayout();
            this.groupBoxPoint2.ResumeLayout(false);
            this.groupBoxPoint2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPoint1;
        private System.Windows.Forms.TextBox tB_PointY1;
        private System.Windows.Forms.TextBox tB_PointX1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBoxPoint2;
        private System.Windows.Forms.TextBox tB_PointY2;
        private System.Windows.Forms.TextBox tB_PointX2;
        private System.Windows.Forms.Label labelY1;
        private System.Windows.Forms.Label labelX1;
        private System.Windows.Forms.Label labelY2;
        private System.Windows.Forms.Label labelX2;
        private System.Windows.Forms.Label labelHSG;
        private System.Windows.Forms.Label labelKC;
        private System.Windows.Forms.TextBox textBoxHSG;
        private System.Windows.Forms.TextBox textBoxKC;
        private System.Windows.Forms.Button buttonTT;
    }
}

