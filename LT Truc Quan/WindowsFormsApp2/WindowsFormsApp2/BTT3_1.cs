using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class BTT3_1 : Form
    {
        public BTT3_1()
        {
            InitializeComponent();
            LoadODia();
        }
        private void LoadODia()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo d in drives)
            {
                cbbOdia.Items.Add(d.Name);
            }
        }

        private void cbbOdia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbThumuc.Items.Clear();
            string selectedDrive = cbbOdia.SelectedItem.ToString();
            LoadThuMuc(selectedDrive);
        }
        private void LoadThuMuc(string drive)
        {
            DirectoryInfo directory = new DirectoryInfo(drive);
            DirectoryInfo[] directories = directory.GetDirectories("*.*");

            cbbThumuc.Items.Clear();
            lbNhac.Items.Clear();

            foreach (DirectoryInfo d in directories)
            {
                cbbThumuc.Items.Add(d.FullName);
            }
        }

        private void cbbThumuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFolder = cbbThumuc.SelectedItem.ToString();

            if (Directory.Exists(selectedFolder))
            {
                lbNhac.Items.Clear();

                DirectoryInfo directory = new DirectoryInfo(selectedFolder);
                FileInfo[] files = directory.GetFiles("*.*");

                foreach (FileInfo file in files)
                {
                    lbNhac.Items.Add(file.FullName);
                }
            }

        }

        private void lbNhac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbNhac.SelectedItem == null) return;

            string selectedFile = lbNhac.SelectedItem.ToString();

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
