using AxWMPLib;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TH3_B3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadODia();
        }

        private void LoadODia()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo d in drives)
            {
                cbbodia.Items.Add(d.Name);
            }
        }

        private void LoadThuMuc(string drive)
        {
            DirectoryInfo directory = new DirectoryInfo(drive);
            DirectoryInfo[] directories = directory.GetDirectories("*.*");

            cbbthumuc.Items.Clear();
            lbnhac.Items.Clear();

            foreach (DirectoryInfo d in directories)
            {
                cbbthumuc.Items.Add(d.FullName);
            }
        }

        private void cbbodia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbthumuc.Items.Clear();
            string selectedDrive = cbbodia.SelectedItem.ToString();
            LoadThuMuc(selectedDrive);
        }

        private void cbbthumuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFolder = cbbthumuc.SelectedItem.ToString();

            if (Directory.Exists(selectedFolder))
            {
                lbnhac.Items.Clear();

                DirectoryInfo directory = new DirectoryInfo(selectedFolder);
                FileInfo[] files = directory.GetFiles("*.*");

                foreach (FileInfo file in files)
                {
                    lbnhac.Items.Add(file.FullName);
                }
            }
        }

        private void lbnhac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbnhac.SelectedItem == null) return;

            string selectedFile = lbnhac.SelectedItem.ToString();

            if (string.Equals(Path.GetExtension(selectedFile), ".txt", StringComparison.OrdinalIgnoreCase))
            {
                using (FileStream fs = new FileStream(selectedFile, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string content = sr.ReadToEnd();
                    rtbtaptin.Text = content;
                }
            }
            else if (string.Equals(Path.GetExtension(selectedFile), ".mp3", StringComparison.OrdinalIgnoreCase))
            {
                axWindowsMediaPlayer1.URL = selectedFile;
                axWindowsMediaPlayer1.Ctlcontrols.play();

                string lyricsFileTxt = Path.ChangeExtension(selectedFile, ".txt");
                string lyricsFileRtf = Path.ChangeExtension(selectedFile, ".rtf");

                if (File.Exists(lyricsFileTxt))
                {
                    rtbtaptin.Text = File.ReadAllText(lyricsFileTxt);
                }
                else if (File.Exists(lyricsFileRtf))
                {
                    rtbtaptin.LoadFile(lyricsFileRtf);
                }
                else
                {
                    rtbtaptin.Clear();
                    rtbtaptin.Text = "Không tìm thấy lời bài hát.";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn file .mp3 hoặc .txt.");
            }
        }
    }
}
