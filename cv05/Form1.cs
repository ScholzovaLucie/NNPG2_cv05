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
                AddImageToPreview(openFileDialog.FileName);
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
                    AddImageToPreview(file);
                }
            }
        }

        private void AddImageToPreview(string filePath)
        {
            const int imageWidth = 75;
            const int imageHeight = 75;
            const int margin = 10;
            int numImages = splitContainer.Panel1.Controls.Count;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(filePath);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Width = imageWidth;
            pictureBox.Height = imageHeight;

            // Vypočítání pozice nového PictureBox
            int x = (numImages % (splitContainer.Panel1.Width / imageWidth)) * (imageWidth + margin);
            int y = (numImages / (splitContainer.Panel1.Width / imageWidth)) * (imageHeight + margin);

            pictureBox.Location = new Point(x, y);
            pictureBox.Click += PictureBox_Click; // Předpokládá, že PictureBox_Click je metoda pro zpracování kliknutí na obrázek

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
            detailPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Obrázek se přizpůsobí, ale zachová poměry stran
            detailPictureBox.Dock = DockStyle.Fill; // Vyplní celý dostupný prostor

            // Obrázek bude scrollovatelný pouze pokud je větší než Panel2
            Panel scrollablePanel = new Panel();
            scrollablePanel.AutoScroll = true;
            scrollablePanel.Dock = DockStyle.Fill; // Vyplní celý Panel2
            scrollablePanel.Controls.Add(detailPictureBox);

            splitContainer.Panel2.Controls.Clear();
            splitContainer.Panel2.Controls.Add(scrollablePanel);
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

        private void centrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetImagePosition(true);
        }

        private void levýHorníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetImagePosition(false);
        }

        private void SetImagePosition(bool centerImage)
        {
            if (splitContainer.Panel2.Controls.Count > 0 &&
                splitContainer.Panel2.Controls[0] is Panel scrollPanel &&
                scrollPanel.Controls.Count > 0 &&
                scrollPanel.Controls[0] is PictureBox pictureBox)
            {
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                if (centerImage)
                {
                    pictureBox.Dock = DockStyle.Fill; // Centrování obrázku v panelu
                }
                else
                {
                    pictureBox.Dock = DockStyle.None; // Necentrování, umístění v levém horním rohu
                    pictureBox.Location = new Point(0, 0); // Pevné umístění v levém horním rohu
                }
            }
        }

        private void SetImageSizeMode(PictureBoxSizeMode sizeMode)
        {
            if (splitContainer.Panel2.Controls.Count > 0 &&
                splitContainer.Panel2.Controls[0] is Panel scrollPanel &&
                scrollPanel.Controls.Count > 0 &&
                scrollPanel.Controls[0] is PictureBox pictureBox)
            {
                pictureBox.SizeMode = sizeMode;

                if (sizeMode == PictureBoxSizeMode.AutoSize)
                {
                    scrollPanel.AutoScrollMinSize = new Size(pictureBox.Image.Width, pictureBox.Image.Height);
                }
                else
                {
                    scrollPanel.AutoScrollMinSize = Size.Empty;
                }

                scrollPanel.AutoScroll = true;
            }
        }

        private void AdjustScrollBars(PictureBox pictureBox)
        {
            // Získáme rozdíl mezi velikostí obrázku a panelu
            Size sizeDifference = new Size(
                Math.Max(0, pictureBox.Image.Width - splitContainer.Panel2.ClientSize.Width),
                Math.Max(0, pictureBox.Image.Height - splitContainer.Panel2.ClientSize.Height));

            // Nastavíme minimální velikost PictureBox, aby byly scrollbary správně nastaveny
            pictureBox.MinimumSize = new Size(sizeDifference.Width, sizeDifference.Height);
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
                var pictureBox = (PictureBox)splitContainer.Panel2.Controls[0].Controls[0];
                Image img = pictureBox.Image;
                img.RotateFlip((RotateFlipType)Enum.Parse(typeof(RotateFlipType), $"Rotate{angle}FlipNone"));
                pictureBox.Image = img;
            }
        }

        private void informaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Zkontrolujte, zda v detailním panelu existuje PictureBox s obrázkem
            if (splitContainer.Panel2.Controls.Count > 0 && splitContainer.Panel2.Controls[0].Controls[0] is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)splitContainer.Panel2.Controls[0].Controls[0];
                if (pictureBox.Image != null)
                {
                    // Zobrazte informace o obrázku
                    DisplayImageInfo(pictureBox.Image);
                }
                else
                {
                    MessageBox.Show("Žádný obrázek není načten.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            progressBar.Location = new Point(10, 10); // Pozice na formuláři
            progressBar.Size = new Size(300, 20); // Velikost
            progressBar.Style = ProgressBarStyle.Marquee; // Styl pro neustálou animaci
            progressBar.MarqueeAnimationSpeed = 30; // Rychlost animace
            progressBar.Visible = false; // Skrytí progress baru dokud není potřeba

            this.Controls.Add(progressBar); // Přidání progress baru do kolekce ovládacích prvků formuláře
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (splitContainer.Panel2.Controls.Count > 0 && splitContainer.Panel2.Controls[0].Controls[0] is PictureBox pictureBox)
            {
                if (pictureBox.Image is Bitmap bitmap)
                {
                    // Zobrazit progress bar před výpočtem
                    progressBar.Visible = true;
                    progressBar.Style = ProgressBarStyle.Marquee;

                    // Spuštění výpočtu histogramu na samostatném vlákně, aby UI nezamrzlo
                    Task.Run(() =>
                    {
                        ShowHistogram(bitmap);
                    });
                }
            }
        }

        private void ShowHistogram(Bitmap image)
        {
            var (red, green, blue) = CalculateHistogram(image);

            // Vytvoření bitmapy pro zobrazení histogramu
            Bitmap histogramBitmap = new Bitmap(256, 300); // Pro každou barvu zvlášť
            using (Graphics g = Graphics.FromImage(histogramBitmap))
            {
                // Vygenerování histogramu
                DrawHistogramLines(g, red, green, blue);
            }

            // Aktualizace UI musí být provedena na hlavním vlákně
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

                // Skrýt progress bar po dokončení
                progressBar.Visible = false;
            }));
        }

        private void DrawHistogramLines(Graphics g, int[] red, int[] green, int[] blue)
        {
            int histogramHeight = 100; // Výška pro každou složku
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


        private void Panel1_Resize(object sender, EventArgs e)
        {
            RearrangeImages();
        }

        private void RearrangeImages()
        {
            const int imageWidth = 75;
            const int imageHeight = 75;
            const int margin = 10;

            int numColumns = splitContainer.Panel1.Width / (imageWidth + margin);
            numColumns = Math.Max(1, numColumns); 

            for (int i = 0; i < splitContainer.Panel1.Controls.Count; i++)
            {
                var control = splitContainer.Panel1.Controls[i];
                if (control is PictureBox)
                {
                    int x = (i % numColumns) * (imageWidth + margin);
                    int y = (i / numColumns) * (imageHeight + margin);
                    control.Location = new Point(x, y);
                }
            }
        }
    }
}
