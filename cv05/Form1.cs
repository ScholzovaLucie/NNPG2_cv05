using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cv05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            splitContainer.Panel1.AutoScroll = true;
            splitContainer.Panel2.AutoScroll = true;
        }

        private void LoadSingleImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AddImageToPreview(openFileDialog.FileName);
            }
        }

        private void LoadImagesFromDirectory()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string[] imageFiles = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.bmp;*.jpg;*.jpeg;*.gif;*.png");

                foreach (string file in imageFiles)
                {
                    AddImageToPreview(file);
                }
            }
        }

        private void AddImageToPreview(string filePath)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(filePath);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Width = 75;
            pictureBox.Height = 75;
            pictureBox.Click += PictureBox_Click;
            splitContainer.Panel1.Controls.Add(pictureBox);
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            ShowImageInDetailPanel(pictureBox.Image);
        }

        private void ShowImageInDetailPanel(Image image)
        {
            PictureBox detailPictureBox = new PictureBox();
            detailPictureBox.Image = image;
            detailPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            splitContainer.Panel2.Controls.Clear();
            splitContainer.Panel2.Controls.Add(detailPictureBox);
        }
    
        private void přidejObrázekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSingleImage();
        }

        private void načtiSložkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImagesFromDirectory();
        }

        private void odstraňVšeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer.Panel1.Controls.Clear();
        }

        // Další event handlery pro implementaci zbývajících funkcí dle specifikace


    }
}
