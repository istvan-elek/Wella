namespace wella
{
    partial class frmCrossPlot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrossPlot));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bttnShowSelectionOnLogs = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnPointSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRectangleSelect = new System.Windows.Forms.ToolStripButton();
            this.bttnClear = new System.Windows.Forms.Button();
            this.bttnCrossplot = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstLogs = new System.Windows.Forms.ListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tsbtnLineSelect = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bttnShowSelectionOnLogs);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.bttnClear);
            this.splitContainer1.Panel1.Controls.Add(this.bttnCrossplot);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lstLogs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 472);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.TabIndex = 0;
            // 
            // bttnShowSelectionOnLogs
            // 
            this.bttnShowSelectionOnLogs.Enabled = false;
            this.bttnShowSelectionOnLogs.Location = new System.Drawing.Point(11, 354);
            this.bttnShowSelectionOnLogs.Name = "bttnShowSelectionOnLogs";
            this.bttnShowSelectionOnLogs.Size = new System.Drawing.Size(120, 56);
            this.bttnShowSelectionOnLogs.TabIndex = 5;
            this.bttnShowSelectionOnLogs.Text = "Show selection on log display";
            this.bttnShowSelectionOnLogs.UseVisualStyleBackColor = true;
            this.bttnShowSelectionOnLogs.Click += new System.EventHandler(this.bttnShowSelectionOnLogs_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnPointSelect,
            this.tsbtnLineSelect,
            this.tsbtnRectangleSelect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(137, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnPointSelect
            // 
            this.tsbtnPointSelect.BackColor = System.Drawing.SystemColors.Control;
            this.tsbtnPointSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPointSelect.Enabled = false;
            this.tsbtnPointSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPointSelect.Image")));
            this.tsbtnPointSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPointSelect.Name = "tsbtnPointSelect";
            this.tsbtnPointSelect.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPointSelect.Text = "Select by pointing";
            this.tsbtnPointSelect.Click += new System.EventHandler(this.tsbtnPointSelect_Click);
            // 
            // tsbtnRectangleSelect
            // 
            this.tsbtnRectangleSelect.Checked = true;
            this.tsbtnRectangleSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbtnRectangleSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRectangleSelect.Enabled = false;
            this.tsbtnRectangleSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRectangleSelect.Image")));
            this.tsbtnRectangleSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRectangleSelect.Name = "tsbtnRectangleSelect";
            this.tsbtnRectangleSelect.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRectangleSelect.Text = "Select by rectangle";
            this.tsbtnRectangleSelect.Click += new System.EventHandler(this.tsbtnRectangleSelect_Click);
            // 
            // bttnClear
            // 
            this.bttnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnClear.Location = new System.Drawing.Point(11, 437);
            this.bttnClear.Name = "bttnClear";
            this.bttnClear.Size = new System.Drawing.Size(120, 23);
            this.bttnClear.TabIndex = 3;
            this.bttnClear.Text = "Clear";
            this.bttnClear.UseVisualStyleBackColor = true;
            this.bttnClear.Click += new System.EventHandler(this.bttnClear_Click);
            // 
            // bttnCrossplot
            // 
            this.bttnCrossplot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnCrossplot.Enabled = false;
            this.bttnCrossplot.Location = new System.Drawing.Point(11, 281);
            this.bttnCrossplot.Name = "bttnCrossplot";
            this.bttnCrossplot.Size = new System.Drawing.Size(120, 67);
            this.bttnCrossplot.TabIndex = 2;
            this.bttnCrossplot.Text = "Show cross plot";
            this.bttnCrossplot.UseVisualStyleBackColor = true;
            this.bttnCrossplot.Click += new System.EventHandler(this.bttnCrossplot_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available logs";
            // 
            // lstLogs
            // 
            this.lstLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLogs.FormattingEnabled = true;
            this.lstLogs.Location = new System.Drawing.Point(7, 76);
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstLogs.Size = new System.Drawing.Size(125, 199);
            this.lstLogs.TabIndex = 0;
            this.lstLogs.SelectedIndexChanged += new System.EventHandler(this.lstLogs_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea6.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea6);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series11.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series11.MarkerColor = System.Drawing.Color.DarkBlue;
            series11.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series11.Name = "Series1";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series12.MarkerColor = System.Drawing.Color.Red;
            series12.MarkerSize = 6;
            series12.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series12.Name = "Series2";
            this.chart1.Series.Add(series11);
            this.chart1.Series.Add(series12);
            this.chart1.Size = new System.Drawing.Size(659, 472);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            this.chart1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseUp);
            // 
            // tsbtnLineSelect
            // 
            this.tsbtnLineSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLineSelect.Enabled = false;
            this.tsbtnLineSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLineSelect.Image")));
            this.tsbtnLineSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLineSelect.Name = "tsbtnLineSelect";
            this.tsbtnLineSelect.Size = new System.Drawing.Size(23, 22);
            this.tsbtnLineSelect.Text = "Select by line";
            this.tsbtnLineSelect.ToolTipText = "Select by line";
            this.tsbtnLineSelect.Click += new System.EventHandler(this.tsbtnLineSelect_Click);
            // 
            // frmCrossPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 472);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCrossPlot";
            this.Text = "Cross plot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCrossPlot_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstLogs;
        private System.Windows.Forms.Button bttnClear;
        private System.Windows.Forms.Button bttnCrossplot;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnPointSelect;
        private System.Windows.Forms.ToolStripButton tsbtnRectangleSelect;
        private System.Windows.Forms.Button bttnShowSelectionOnLogs;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripButton tsbtnLineSelect;
    }
}