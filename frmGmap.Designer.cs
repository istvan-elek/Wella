namespace wella
{
    partial class frmGmap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGmap));
            this.gmapWindow = new GMap.NET.WindowsForms.GMapControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelSelectMapProvider = new System.Windows.Forms.ToolStripLabel();
            this.cmbMapProviders = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gmapWindow
            // 
            this.gmapWindow.Bearing = 0F;
            this.gmapWindow.CanDragMap = true;
            this.gmapWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmapWindow.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmapWindow.GrayScaleMode = false;
            this.gmapWindow.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmapWindow.LevelsKeepInMemory = 5;
            this.gmapWindow.Location = new System.Drawing.Point(0, 25);
            this.gmapWindow.MarkersEnabled = true;
            this.gmapWindow.MaxZoom = 2;
            this.gmapWindow.MinZoom = 2;
            this.gmapWindow.MouseWheelZoomEnabled = true;
            this.gmapWindow.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmapWindow.Name = "gmapWindow";
            this.gmapWindow.NegativeMode = false;
            this.gmapWindow.PolygonsEnabled = true;
            this.gmapWindow.RetryLoadTile = 0;
            this.gmapWindow.RoutesEnabled = true;
            this.gmapWindow.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmapWindow.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmapWindow.ShowTileGridLines = false;
            this.gmapWindow.Size = new System.Drawing.Size(800, 425);
            this.gmapWindow.TabIndex = 0;
            this.gmapWindow.Zoom = 0D;
            this.gmapWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gmapWindow_MouseMove);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelSelectMapProvider,
            this.cmbMapProviders,
            this.toolStripSeparator1,
            this.btnZoomIn,
            this.btnZoomOut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelSelectMapProvider
            // 
            this.toolStripLabelSelectMapProvider.Name = "toolStripLabelSelectMapProvider";
            this.toolStripLabelSelectMapProvider.Size = new System.Drawing.Size(115, 22);
            this.toolStripLabelSelectMapProvider.Text = "Select map provider:";
            // 
            // cmbMapProviders
            // 
            this.cmbMapProviders.Name = "cmbMapProviders";
            this.cmbMapProviders.Size = new System.Drawing.Size(150, 25);
            this.cmbMapProviders.SelectedIndexChanged += new System.EventHandler(this.cmbMapProviders_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(23, 22);
            this.btnZoomIn.Text = "Zoom in";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(23, 22);
            this.btnZoomOut.Text = "Zoom out";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // frmGmap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gmapWindow);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGmap";
            this.Text = "Map window";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmapWindow;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSelectMapProvider;
        private System.Windows.Forms.ToolStripComboBox cmbMapProviders;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnZoomIn;
        private System.Windows.Forms.ToolStripButton btnZoomOut;
    }
}