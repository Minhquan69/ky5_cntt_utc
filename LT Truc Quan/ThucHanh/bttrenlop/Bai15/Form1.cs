using System;
using System.Windows.Forms;

namespace Bai15
{
    public partial class Form2 : Form
    {
        int minutesLeft;
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
    }
}
