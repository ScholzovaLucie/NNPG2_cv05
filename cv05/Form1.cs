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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProgressBar = System.Windows.Forms.ProgressBar;

namespace cv05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeProgressBar();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            splitContainer.Panel1.AutoScroll = true;
            splitContainer.Panel2.AutoScroll = true;
        }

        private void LoadSingleImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AddImagePreview(openFileDialog.FileName);
                this.Text = openFileDialog.FileName;
            }
        }

        private void LoadImagesFromDirectory()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string[] imageFiles = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.*").Where(file => new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" }.Contains(Path.GetExtension(file).ToLower())).ToArray();

                foreach (string file in imageFiles)
                {
                    AddImagePreview(file);
                }
            }
        }

        private void AddImagePreview(string filePath)
        {
            int imageWidth = 75;
            int imageHeight = 75;
            int margin = 10;
            int numImages = splitContainer.Panel1.Controls.Count;

            System.Windows.Forms.Button imageButton = new System.Windows.Forms.Button();
            Image image = Image.FromFile(filePath);
            imageButton.BackgroundImage = image.GetThumbnailImage(imageWidth, imageHeight, null, IntPtr.Zero);
            imageButton.BackgroundImageLayout = ImageLayout.Stretch;
            imageButton.Size = new Size(imageWidth, imageHeight);

            int x = (numImages % (splitContainer.Panel1.Width / (imageWidth + margin))) * (imageWidth + margin);
            int y = (numImages / (splitContainer.Panel1.Width / (imageWidth + margin))) * (imageHeight + margin);

            imageButton.Location = new Point(x, y);
            imageButton.Click += (sender, e) => ShowImageInDetailPanel(image);

            splitContainer.Panel1.Controls.Add(imageButton);
        }

        private void ShowImageInDetailPanel(Image image)
        {
            PictureBox detailPictureBox = new PictureBox();
            detailPictureBox.Image = image;
            detailPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            detailPictureBox.Dock = DockStyle.Fill;

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

        private void originálníPixelováVelikostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetImageSizeMode(PictureBoxSizeMode.AutoSize);
        }

        private void originálníTiskováVelikostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetImageSizeMode(PictureBoxSizeMode.Normal);
        }

        private void roztaženíPřesPlochuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetImageSizeMode(PictureBoxSizeMode.StretchImage);
        }

        private void přispůsobitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (splitContainer.Panel2.Controls.Count > 0 && splitContainer.Panel2.Controls[0] is PictureBox detailPictureBox && detailPictureBox.Image != null)
            {
                Image image = detailPictureBox.Image;
                float originalWidth = image.Width;
                float originalHeight = image.Height;
                float panelWidth = splitContainer.Panel2.Width;
                float panelHeight = splitContainer.Panel2.Height;

                float scaleFactor = Math.Min(panelWidth / originalWidth, panelHeight / originalHeight);

                int newWidth = (int)(originalWidth * scaleFactor);
                int newHeight = (int)(originalHeight * scaleFactor);

                detailPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                detailPictureBox.Size = new Size(newWidth, newHeight);
                detailPictureBox.Location = new Point((int)((panelWidth - newWidth) / 2), (int)((panelHeight - newHeight) / 2));
            }
        }

        private void centrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetImageSizeMode(PictureBoxSizeMode.CenterImage);
        }

        private void levýHorníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetImageSizeMode(PictureBoxSizeMode.Normal);
        }

        private void SetImageSizeMode(PictureBoxSizeMode sizeMode)
        {
            if (splitContainer.Panel2.Controls.Count > 0)
            {
                var detailPictureBox = (PictureBox)splitContainer.Panel2.Controls[0];
                detailPictureBox.SizeMode = sizeMode;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RotateImage(90);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            RotateImage(180);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            RotateImage(270);
        }

        private void RotateImage(int angle)
        {
            if (splitContainer.Panel2.Controls.Count > 0)
            {
                var detailPictureBox = (PictureBox)splitContainer.Panel2.Controls[0];
                Image img = detailPictureBox.Image;
                img.RotateFlip((RotateFlipType)Enum.Parse(typeof(RotateFlipType), $"Rotate{angle}FlipNone"));
                detailPictureBox.Image = img;
            }
        }

        private void informaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if there is a PictureBox with an image in the detail panel
            if (splitContainer.Panel2.Controls.Count > 0 && splitContainer.Panel2.Controls[0] is PictureBox detailPictureBox && detailPictureBox.Image != null)
            {
                DisplayImageInfo(detailPictureBox.Image);
            }
            else
            {
                MessageBox.Show("Žádný obrázek není načten.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayImageInfo(Image image)
        {
            var info = new StringBuilder();
            info.AppendLine($"Šířka v pixelech: {image.Width}");
            info.AppendLine($"Výška v pixelech: {image.Height}");
            info.AppendLine($"Fyzické rozměry: {image.PhysicalDimension}");
            info.AppendLine($"Horizontální rozlišení: {image.HorizontalResolution}");
            info.AppendLine($"Vertikální rozlišení: {image.VerticalResolution}");
            info.AppendLine($"Velikost v cm: {image.Width / image.HorizontalResolution * 2.54} x {image.Height / image.VerticalResolution * 2.54}");
            info.AppendLine($"Barevná hloubka: {Image.GetPixelFormatSize(image.PixelFormat)}bpp");

            MessageBox.Show(info.ToString(), "Image Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private ProgressBar progressBar;

        private void InitializeProgressBar()
        {
            progressBar = new ProgressBar();
            progressBar.Location = new Point(10, 10); // Position on form
            progressBar.Size = new Size(300, 20); // Size
            progressBar.Style = ProgressBarStyle.Marquee; // Style for continuous animation
            progressBar.MarqueeAnimationSpeed = 30; // Animation speed
            progressBar.Visible = false; // Hide progress bar until needed

            this.Controls.Add(progressBar); // Add progress bar to form controls
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (splitContainer.Panel2.Controls.Count > 0 && splitContainer.Panel2.Controls[0] is PictureBox detailPictureBox && detailPictureBox.Image is Bitmap bitmap)
            {
                // Display progress bar before calculation
                progressBar.Visible = true;
                progressBar.Style = ProgressBarStyle.Marquee;

                // Start histogram calculation on a separate thread to avoid freezing UI
                Task.Run(() =>
                {
                    ShowHistogram(bitmap);
                });
            }
        }

        private void ShowHistogram(Bitmap image)
        {
            var (red, green, blue) = CalculateHistogram(image);

            // Create a bitmap for displaying the histogram
            Bitmap histogramBitmap = new Bitmap(256, 300); // Separate for each color
            using (Graphics g = Graphics.FromImage(histogramBitmap))
            {
                // Generate the histogram
                DrawHistogramLines(g, red, green, blue);
            }

            // UI update must be performed on the main thread
            this.Invoke(new Action(() =>
            {
                PictureBox histogramPictureBox = new PictureBox();
                histogramPictureBox.Image = histogramBitmap;
                histogramPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                histogramPictureBox.Dock = DockStyle.Fill;

                Form histogramForm = new Form();
                histogramForm.Text = "Histogram";
                histogramForm.Controls.Add(histogramPictureBox);
                histogramForm.Size = new Size(256, 300);
                histogramForm.Show();

                // Hide progress bar after completion
                progressBar.Visible = false;
            }));
        }

        private void DrawHistogramLines(Graphics g, int[] red, int[] green, int[] blue)
        {
            int histogramHeight = 100; // Height for each component
            for (int i = 0; i < 256; i++)
            {
                g.DrawLine(Pens.Red, i, histogramHeight * 3, i, histogramHeight * 3 - (red[i] * histogramHeight / red.Max()));
                g.DrawLine(Pens.Green, i, histogramHeight * 2, i, histogramHeight * 2 - (green[i] * histogramHeight / green.Max()));
                g.DrawLine(Pens.Blue, i, histogramHeight, i, histogramHeight - (blue[i] * histogramHeight / blue.Max()));
            }
        }

        private (int[] red, int[] green, int[] blue) CalculateHistogram(Bitmap image)
        {
            int[] redHistogram = new int[256];
            int[] greenHistogram = new int[256];
            int[] blueHistogram = new int[256];

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixelColor = image.GetPixel(i, j);
                    redHistogram[pixelColor.R]++;
                    greenHistogram[pixelColor.G]++;
                    blueHistogram[pixelColor.B]++;
                }
            }

            return (redHistogram, greenHistogram, blueHistogram);
        }

       
    }
}
