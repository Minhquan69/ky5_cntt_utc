using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FormMenu
{
    public partial class Form2 : Form
    {
        int minutesLeft;
        private Button button1;
        int secondsLeft;

        public Form2()
        {
            InitializeComponent();
        }

        private void Run_Click(object sender, EventArgs e)
        {

            if (int.TryParse(txttime1.Text, out minutesLeft) && int.TryParse(txttime2.Text, out secondsLeft))
            {
                if (secondsLeft >= 60)
                {
                    MessageBox.Show("Giây không thể lớn hơn 59!", "Lỗi nhập liệu");
                    return;
                }

                tm1.Start();
                tm2.Start();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số phút và giây hợp lệ!", "Lỗi nhập liệu");
            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            tm1.Stop();
            tm2.Stop();
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            tm1.Stop();
            tm2.Stop();
            minutesLeft = 0;
            secondsLeft = 0;
            txttime1.Text = "00";
            txttime2.Text = "00";
        }

        private void tm1_Tick(object sender, EventArgs e)
        {
            if (secondsLeft > 0)
            {
                secondsLeft--;
            }
            else if (minutesLeft > 0)
            {
                minutesLeft--;
                secondsLeft = 59;
            }

            UpdateTimeDisplay();

            if (minutesLeft == 0 && secondsLeft == 0)
            {
                tm1.Stop();
                tm2.Stop();
                MessageBox.Show("Hết giờ!");
            }
        }

        private void tm2_Tick(object sender, EventArgs e)
        {
            if (minutesLeft > 0 && secondsLeft == 0)
            {
                minutesLeft--;
            }

            UpdateTimeDisplay();
        }

        private void UpdateTimeDisplay()
        {
            txttime1.Text = minutesLeft.ToString("D2");
            txttime2.Text = secondsLeft.ToString("D2");
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Minute = new System.Windows.Forms.Label();
            this.Second = new System.Windows.Forms.Label();
            this.txttime1 = new System.Windows.Forms.TextBox();
            this.txttime2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tm1 = new System.Windows.Forms.Timer(this.components);
            this.tm2 = new System.Windows.Forms.Timer(this.components);
            this.Run = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.Finish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Minute
            // 
            this.Minute.AutoSize = true;
            this.Minute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Minute.ForeColor = System.Drawing.Color.Red;
            this.Minute.Location = new System.Drawing.Point(203, 119);
            this.Minute.Name = "Minute";
            this.Minute.Size = new System.Drawing.Size(66, 25);
            this.Minute.TabIndex = 0;
            this.Minute.Text = "(Phút)";
            // 
            // Second
            // 
            this.Second.AutoSize = true;
            this.Second.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Second.ForeColor = System.Drawing.Color.Red;
            this.Second.Location = new System.Drawing.Point(463, 119);
            this.Second.Name = "Second";
            this.Second.Size = new System.Drawing.Size(66, 25);
            this.Second.TabIndex = 1;
            this.Second.Text = "(Giây)";
            // 
            // txttime1
            // 
            this.txttime1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txttime1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txttime1.Location = new System.Drawing.Point(208, 162);
            this.txttime1.Multiline = true;
            this.txttime1.Name = "txttime1";
            this.txttime1.Size = new System.Drawing.Size(103, 48);
            this.txttime1.TabIndex = 2;
            // 
            // txttime2
            // 
            this.txttime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txttime2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txttime2.Location = new System.Drawing.Point(468, 162);
            this.txttime2.Multiline = true;
            this.txttime2.Name = "txttime2";
            this.txttime2.Size = new System.Drawing.Size(103, 48);
            this.txttime2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(381, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = ":";
            // 
            // tm1
            // 
            this.tm1.Interval = 1000;
            this.tm1.Tick += new System.EventHandler(this.tm1_Tick);
            // 
            // tm2
            // 
            this.tm2.Interval = 1000;
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(135, 339);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(127, 43);
            this.Run.TabIndex = 5;
            this.Run.Text = "Chạy";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(331, 339);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(127, 43);
            this.Pause.TabIndex = 6;
            this.Pause.Text = "Tạm Dừng";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Finish
            // 
            this.Finish.Location = new System.Drawing.Point(530, 339);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(127, 43);
            this.Finish.TabIndex = 7;
            this.Finish.Text = "Kết Thúc";
            this.Finish.UseVisualStyleBackColor = true;
            this.Finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Finish);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txttime2);
            this.Controls.Add(this.txttime1);
            this.Controls.Add(this.Second);
            this.Controls.Add(this.Minute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form2";
            this.Text = "Chương trình đồng hồ đếm ngược";
            this.ResumeLayout(false);
            this.PerformLayout();



        }

        public Container components { get; private set; }

        private System.Windows.Forms.Label Minute;
        private System.Windows.Forms.Label Second;
        private System.Windows.Forms.TextBox txttime1;
        private System.Windows.Forms.TextBox txttime2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tm1;
        private System.Windows.Forms.Timer tm2;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button Finish;
    }
}
