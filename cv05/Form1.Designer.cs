namespace cv05
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.fileMenu = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přidejObrázekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.načtiSložkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odstraňVšeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zobrazeníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.umístěníObrázkuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levýHorníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.velikostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originálníTiskováVelikostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originálníPixelováVelikostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roztaženíPřesPlochuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otočeníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.fileMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer.Location = new System.Drawing.Point(0, 30);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Size = new System.Drawing.Size(800, 420);
            this.splitContainer.SplitterDistance = 266;
            this.splitContainer.TabIndex = 0;
            // 
            // fileMenu
            // 
            this.fileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.zobrazeníToolStripMenuItem});
            this.fileMenu.Location = new System.Drawing.Point(0, 0);
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(800, 24);
            this.fileMenu.TabIndex = 0;
            this.fileMenu.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přidejObrázekToolStripMenuItem,
            this.načtiSložkuToolStripMenuItem,
            this.odstraňVšeToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // přidejObrázekToolStripMenuItem
            // 
            this.přidejObrázekToolStripMenuItem.Name = "přidejObrázekToolStripMenuItem";
            this.přidejObrázekToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.přidejObrázekToolStripMenuItem.Text = "Přidej obrázek";
            this.přidejObrázekToolStripMenuItem.Click += new System.EventHandler(this.přidejObrázekToolStripMenuItem_Click);
            // 
            // načtiSložkuToolStripMenuItem
            // 
            this.načtiSložkuToolStripMenuItem.Name = "načtiSložkuToolStripMenuItem";
            this.načtiSložkuToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.načtiSložkuToolStripMenuItem.Text = "Načti složku";
            this.načtiSložkuToolStripMenuItem.Click += new System.EventHandler(this.načtiSložkuToolStripMenuItem_Click);
            // 
            // odstraňVšeToolStripMenuItem
            // 
            this.odstraňVšeToolStripMenuItem.Name = "odstraňVšeToolStripMenuItem";
            this.odstraňVšeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.odstraňVšeToolStripMenuItem.Text = "Odstraň vše";
            this.odstraňVšeToolStripMenuItem.Click += new System.EventHandler(this.odstraňVšeToolStripMenuItem_Click);
            // 
            // zobrazeníToolStripMenuItem
            // 
            this.zobrazeníToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.umístěníObrázkuToolStripMenuItem,
            this.velikostToolStripMenuItem,
            this.informaceToolStripMenuItem,
            this.otočeníToolStripMenuItem,
            this.histogramToolStripMenuItem});
            this.zobrazeníToolStripMenuItem.Name = "zobrazeníToolStripMenuItem";
            this.zobrazeníToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.zobrazeníToolStripMenuItem.Text = "Zobrazení";
            // 
            // umístěníObrázkuToolStripMenuItem
            // 
            this.umístěníObrázkuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centrToolStripMenuItem,
            this.levýHorníToolStripMenuItem});
            this.umístěníObrázkuToolStripMenuItem.Name = "umístěníObrázkuToolStripMenuItem";
            this.umístěníObrázkuToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.umístěníObrázkuToolStripMenuItem.Text = "Umístění obrázku";
            // 
            // centrToolStripMenuItem
            // 
            this.centrToolStripMenuItem.Name = "centrToolStripMenuItem";
            this.centrToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.centrToolStripMenuItem.Text = "Centr";
            // 
            // levýHorníToolStripMenuItem
            // 
            this.levýHorníToolStripMenuItem.Name = "levýHorníToolStripMenuItem";
            this.levýHorníToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.levýHorníToolStripMenuItem.Text = "Levý horní";
            // 
            // velikostToolStripMenuItem
            // 
            this.velikostToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.originálníTiskováVelikostToolStripMenuItem,
            this.originálníPixelováVelikostToolStripMenuItem,
            this.roztaženíPřesPlochuToolStripMenuItem});
            this.velikostToolStripMenuItem.Name = "velikostToolStripMenuItem";
            this.velikostToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.velikostToolStripMenuItem.Text = "Velikost";
            // 
            // originálníTiskováVelikostToolStripMenuItem
            // 
            this.originálníTiskováVelikostToolStripMenuItem.Name = "originálníTiskováVelikostToolStripMenuItem";
            this.originálníTiskováVelikostToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.originálníTiskováVelikostToolStripMenuItem.Text = "originální tisková velikost";
            // 
            // originálníPixelováVelikostToolStripMenuItem
            // 
            this.originálníPixelováVelikostToolStripMenuItem.Name = "originálníPixelováVelikostToolStripMenuItem";
            this.originálníPixelováVelikostToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.originálníPixelováVelikostToolStripMenuItem.Text = "originální pixelová velikost";
            // 
            // roztaženíPřesPlochuToolStripMenuItem
            // 
            this.roztaženíPřesPlochuToolStripMenuItem.Name = "roztaženíPřesPlochuToolStripMenuItem";
            this.roztaženíPřesPlochuToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.roztaženíPřesPlochuToolStripMenuItem.Text = " roztažení přes plochu";
            // 
            // informaceToolStripMenuItem
            // 
            this.informaceToolStripMenuItem.Name = "informaceToolStripMenuItem";
            this.informaceToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.informaceToolStripMenuItem.Text = "Informace ";
            // 
            // otočeníToolStripMenuItem
            // 
            this.otočeníToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.otočeníToolStripMenuItem.Name = "otočeníToolStripMenuItem";
            this.otočeníToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.otočeníToolStripMenuItem.Text = "Otočení";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem2.Text = "90°";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem3.Text = "180°";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem4.Text = " 270°";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.fileMenu);
            this.MainMenuStrip = this.fileMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.fileMenu.ResumeLayout(false);
            this.fileMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.MenuStrip fileMenu;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přidejObrázekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem načtiSložkuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odstraňVšeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zobrazeníToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem umístěníObrázkuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levýHorníToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem velikostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem originálníTiskováVelikostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem originálníPixelováVelikostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roztaženíPřesPlochuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otočeníToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    }
}

