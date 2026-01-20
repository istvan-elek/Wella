using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace wella
{
    public partial class logCharts : Form  
    {
        int numofCharts;
        Chart[] charts;
        ListBox lstLogs = new ListBox();
        Button btnClearAll = new Button();
        Button btnShowLogs = new Button();
        Button btnAddIntervals2Log = new Button();
        ToolStripButton bttnCreateInterval;
        ToolStripButton bttnSaveInterval;
        ToolStripSeparator bttnSeparate;
        ToolStripButton bttnZoomIn;
        ToolStripButton bttnZoomOut;
        Wells well=new Wells();
        Panel panel=new Panel();
        ToolStrip toolStrip1 = new ToolStrip();
        public ImageList imgList;
        private System.ComponentModel.IContainer components;
        public Series pnts;
        Series layer;
        Boolean layering = false;
        frmWell _parentForm;
        string tmpLog = "";      
        int ActiveChart=-1;
        //float xStart, yPixel, xEnd, yPix;

        public logCharts(frmWell parentForm)
        {
            InitializeComponent();
            well = parentForm.w;
            createControlls();
            _parentForm = parentForm;
        }

        public logCharts(Wells w)
        {
            InitializeComponent();
            well = w;
            createControlls();
        }

        public logCharts(Wells w, string oneLog)
        {
            InitializeComponent();
            well = w;
            tmpLog = oneLog;
            createControlls();
        }


 
        void createControlls()
        {
            this.Text = "Log display";
            this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
            this.StartPosition = FormStartPosition.Manual;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Name = "logchart";

            addLogList();

            lstLogs.SelectionMode = SelectionMode.MultiExtended;
            lstLogs.Location = new Point(10, 30);
            lstLogs.Width = 100;

            btnShowLogs.Location = new Point(10, lstLogs.Height + 40);
            btnShowLogs.Size = new Size(120, 80);
            btnShowLogs.Text = "Show logs";
            btnShowLogs.Click += btnShowLogs_click;
            lstLogs.DoubleClick  += btnShowLogs_click;

            btnClearAll.Location = new Point(10, btnShowLogs.Height + btnShowLogs.Location.Y + 10);
            btnClearAll.Text = "Clear log display";
            btnClearAll.Width = btnShowLogs.Width;
            btnClearAll.Click += btnClearAll_click;

            if (well.Intervals.Count > 0)
            {
                btnAddIntervals2Log.Location = new Point(btnClearAll.Location.X, btnClearAll.Location.Y + btnClearAll.Height * 3);
                btnAddIntervals2Log.Size = new Size(120, 50);
                btnAddIntervals2Log.Text = "Add intervals to the selected chart";
                btnAddIntervals2Log.Click += btnAddIntervals2SelectedLog_click;
                btnAddIntervals2Log.Enabled = false;
                this.Controls.Add(btnAddIntervals2Log);
            }

            panel.BackColor = Color.White;
            panel.Location = new Point(lstLogs.Width + 50, 0);
            panel.Size = new Size(this.ClientSize.Width - lstLogs.Width - 50, this.ClientSize.Height);

            if (tmpLog == "tmp")
            {
                lstLogs.SelectedItem = tmpLog;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width / 5;
                panel.Size = new Size(this.ClientSize.Width - lstLogs.Width - 50, this.ClientSize.Height);
            }
            panel.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom);
            panel.AutoScroll = true;

            this.Controls.Add(panel);
            this.Controls.Add(btnClearAll);
            this.Controls.Add(btnShowLogs);
            this.Controls.Add(toolStrip1);
            this.Icon = Icon.FromHandle(((Bitmap)imgList.Images[1]).GetHicon());

            bttnCreateInterval = new ToolStripButton();
            bttnCreateInterval.Enabled = false;
            bttnCreateInterval.Checked = false;
            bttnCreateInterval.ToolTipText = "Switch ON create intervals mode";
            bttnCreateInterval.Click += bttnCreateIntervall_click;
            bttnCreateInterval.Image = imgList.Images[3];
            toolStrip1.Items.Add(bttnCreateInterval);

            bttnSaveInterval = new ToolStripButton();
            bttnSaveInterval.Enabled = false;
            bttnSaveInterval.ToolTipText = "Save interval";
            bttnSaveInterval.Click += bttnSaveIntervall_click;
            bttnSaveInterval.Image = imgList.Images[4];
            toolStrip1.Items.Add(bttnSaveInterval);

            bttnSeparate = new ToolStripSeparator();
            toolStrip1.Items.Add(bttnSeparate);

            bttnZoomIn = new ToolStripButton();
            bttnZoomIn.ToolTipText = "Zoom in";
            bttnZoomIn.Click += bttnZoomIn_Click;
            bttnZoomIn.Image = imgList.Images[5];
            toolStrip1.Items.Add(bttnZoomIn);

            bttnZoomOut = new ToolStripButton();
            bttnZoomOut.ToolTipText = "Zoom out";
            bttnZoomOut.Click += bttnZoomOut_Click;
            bttnZoomOut.Image = imgList.Images[6];
            toolStrip1.Items.Add(bttnZoomOut);
        }

        void bttnZoomIn_Click(object sender, EventArgs e)
        {
            foreach (Chart ch in charts)
            {
                ch.Height = (int)((float)(ch.Height) * 1.2F);
            }
        }

        void bttnZoomOut_Click(object sender, EventArgs e) 
        {
            foreach (Chart ch in charts)
            {
                ch.Height = (int)((float)(ch.Height) / 1.2F); ;
            }
        }


        void bttnCreateIntervall_click(object sender, EventArgs e)
        {


            if (bttnCreateInterval.Checked ) { bttnCreateInterval.ToolTipText = "Switch ON create intervals mode"; }
            else { bttnCreateInterval.ToolTipText = "Switch OFF create intervals mode"; }
            bttnCreateInterval.Checked = !bttnCreateInterval.Checked;
            layering = !layering;
            well.Intervals.Clear();
            if (bttnCreateInterval.Checked) { charts[ActiveChart].Cursor = Cursors.Cross; }
            else { charts[ActiveChart].Cursor = Cursors.Default; }
        }

        void bttnSaveIntervall_click(object sender, EventArgs e)
        {
            int k = 0;
            well.Intervals.Clear();
            LayerPairs nnp1 = new LayerPairs();

            nnp1.depth = well.Curves[0][0];
            nnp1.desc = "Desc_" + nnp1.depth.ToString("F1");
            well.Intervals.Add(nnp1);
            foreach(DataPoint item in charts[ActiveChart].Series[1].Points)
            {
                LayerPairs np= new LayerPairs();
                float roundedDepth = (float)Math.Round((float)item.YValues[0], 1);
                np.depth = roundedDepth;
                np.desc = "Desc_" + np.depth.ToString("F1"); 
                if (k%2==0) well.Intervals.Add(np);
                k++;
            }
            LayerPairs nnp2 = new LayerPairs();
            nnp2.depth = well.Curves[0][well.Curves[0].Count - 1];
            nnp2.desc = "Desc_" + nnp2.depth.ToString("F1");
            well.Intervals.Add(nnp2);
        }

        void btnAddIntervals2SelectedLog_click(object sender, EventArgs e)
        {
            if (ActiveChart > -1)
            {
                if (!charts[ActiveChart].Titles[0].Text.Contains("Intervalls")) charts[ActiveChart].Titles[0].Text = "Intervals,  " + charts[ActiveChart].Titles[0].Text;
                btnAddIntervals2Log.Enabled = false;
                foreach (LayerPairs lp in well.Intervals)
                {
                    string s = lp.toString();
                    AddHorizontalLine(1, double.Parse(s.Split(';')[0], System.Globalization.CultureInfo.InvariantCulture));
                }
            }
            else { MessageBox.Show("Select a chart where you want to display intervals", "Select a chart", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void AddHorizontalLine(double xValue, double yValue)
        {
            Series lineSeries = new Series(yValue.ToString());
            if (charts[ActiveChart].Series.IsUniqueName(lineSeries.Name))
            {
                lineSeries.ChartType = SeriesChartType.Line;
                lineSeries.Color = System.Drawing.Color.Blue;
                lineSeries.BorderDashStyle = ChartDashStyle.Solid;
                lineSeries.BorderWidth = 2;
                lineSeries.Points.AddXY(charts[ActiveChart].ChartAreas[0].AxisX.Minimum, yValue);
                lineSeries.Points.AddXY(charts[ActiveChart].ChartAreas[0].AxisX.Maximum, yValue); // X tengely végéig
                charts[ActiveChart].Series.Add(lineSeries);
            }
        }


        void btnClearAll_click(object sender, EventArgs e)
        {
            lstLogs.ClearSelected();
            panel.Controls.Clear();
            bttnCreateInterval.Enabled=false;
            bttnSaveInterval.Enabled=false;
        }

        void btnShowLogs_click(object sender, EventArgs e)
        {
            numofCharts = lstLogs.SelectedItems.Count;
            bttnCreateInterval.Enabled=false;
            btnAddIntervals2Log.Enabled = false;
            addCharts();
            for (int i = 0; i < numofCharts; i++)
            {
                drawLog(i);
            }
        }

        private void lstLogs_selected_index_changed(object sender, EventArgs e)
        {
            numofCharts = lstLogs.SelectedItems.Count;
            addCharts();
            for (int i = 0; i < numofCharts; i++)
            {
                drawLog(i);
            }

        }
        void addLogList()
        {
            lstLogs.Size = new Size(150, 200);
            lstLogs.Location = new Point(5, 0);
            for (int i = 1; i < well.CurveInfo.Count; i++)
            {
                lstLogs.Items.Add(well.CurveInfo.ElementAt(i).Key);
            }
            lstLogs.SelectedIndex = 0;
            lstLogs.ClearSelected();
            this.Controls.Add(lstLogs);
            //btnAddIntervals2Log.Enabled = false;
        }

        void addCharts()
        {
            this.panel.Controls.Clear();
            charts = new Chart[numofCharts];
            for (int i = 0; i < numofCharts; i++)
            {
                charts[i] = new Chart();
                charts[i].Name = i.ToString();
                charts[i].BackColor = Color.White;
                charts[i].ChartAreas.Add(new ChartArea());
                charts[i].Series.Add(new Series());
                charts[i].Location=new System.Drawing.Point(i*200,0);
                charts[i].Size = new Size(200, this.ClientSize.Height);
                string t = lstLogs.SelectedItems[i].ToString();
                charts[i].Titles.Add(t);
                charts[i].Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                charts[i].MouseClick += ChartMouse_Click;
                charts[i].MouseMove += chart_MouseMove;
                charts[i].Click += selectChart_click;
                this.panel.Controls.Add(charts[i]);
            }
        }

        void selectChart_click(object sender, EventArgs e)
        {
            if (layering) return;
            int n = Int32.Parse(((Chart)sender).Name);
            foreach (Chart chart in charts) { chart.BackColor = Color.White; }
            charts[n].BackColor = Color.MistyRose;
            ActiveChart = n;
            btnAddIntervals2Log.Enabled = true;
            bttnCreateInterval.Enabled = true;
            if (charts[n].Series.IsUniqueName("lay"))
            {
                layer = new Series("lay");
                charts[ActiveChart].Series.Add(layer);
            }
        }


        void drawLog(int k)
        {
            float min, max, depthmin, depthmax;
            charts[k].Series[0].Points.Clear();
            charts[k].ChartAreas[0].AxisX.LineColor = Color.Gray;
            charts[k].ChartAreas[0].AxisY.LineColor = Color.Gray;

            charts[k].ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            charts[k].ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;

            charts[k].ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            charts[k].ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;

            charts[k].ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.LightGray;
            charts[k].ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.LightGray;

            charts[k].ChartAreas[0].AxisX.LineColor = Color.LightGray;
            charts[k].ChartAreas[0].AxisY.LineColor = Color.LightGray;

            charts[k].ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            charts[k].ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            charts[k].ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            charts[k].ChartAreas[0].AxisY.MinorGrid.Enabled = true;

            charts[k].ChartAreas[0].AxisY.MinorGrid.Interval = 10;
            charts[k].ChartAreas[0].AxisX.MinorGrid.Interval = 10;

            charts[k].ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Gray;
            charts[k].ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Gray;

            charts[k].ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular);
            charts[k].ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular);

            charts[k].Series[0].Color = Color.DarkRed;    //Color.DarkGoldenrod;

            int sel = lstLogs.SelectedIndices[k] + 1;
            max = well.Curves[sel].Max();
            min = well.Curves[sel].Min();
            depthmin = well.Curves[0].Min();
            depthmax = well.Curves[0].Max();
            AdjustAxisScale(charts[k].ChartAreas[0].AxisX, min, max);
            AdjustAxisScale(charts[k].ChartAreas[0].AxisY, depthmin, depthmax);
            charts[k].ChartAreas[0].AxisY.IsReversed = true;
            charts[k].ChartAreas[0].AxisX.IsReversed = false;
            charts[k].ChartAreas[0].AxisY.Maximum = depthmax;
            charts[k].ChartAreas[0].AxisY.Minimum = depthmin;
            charts[k].ChartAreas[0].AxisY.Interval = 10;

            for (int i = 0; i < well.Curves[0].Count; i++)
            {
                double x = well.Curves[sel][i];
                double y = well.Curves[0][i];
                charts[k].Series[0].Points.AddXY(x, y);
            }
        }

        private void AdjustAxisScale(Axis axis, double minValue, double maxValue)
        {
            double range = maxValue - minValue;
            double step = Math.Pow(10, Math.Floor(Math.Log10(range))); // Lépték kiválasztása

            double adjustedMin = Math.Floor(minValue / step) * step;
            double adjustedMax = Math.Ceiling(maxValue / step) * step;

            axis.Minimum = adjustedMin;
            axis.Maximum = adjustedMax;
            axis.Interval = step;
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Chart chr = (Chart)sender;
                var result = chr.HitTest(e.X, e.Y, ChartElementType.DataPoint);
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    string val = prop.XValue.ToString("F1");
                    string dep = prop.YValues[0].ToString("F1");
                    this.Text = chr.Titles[0].Text + " --- Depth: " + dep +  ",  Value: " + val;
                }
                else
                { this.Text = "Log display"; }
            }
            catch (Exception)
            {
            }
        }

        string getLayerDescription(float y)
        {
            string dsc = "";
            for (int i = 0; i< well.Intervals.Count-1; i++)
            {
                if ((y> well.Intervals[i].depth) && (y< well.Intervals[i+1].depth))
                {
                    dsc= well.Intervals[i].desc + ";" + well.Intervals[i].depth.ToString("F1");
                }
            }
            return dsc;
        }

        void EnterLayerName(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                TextBox tb=(TextBox)sender;
                for (int i = 0;i< well.Intervals.Count;i++)
                {
                    if (well.Intervals[i].depth == float.Parse(tb.Tag.ToString()))
                    {
                        well.Intervals[i].desc=tb.Text;
                    }
                }
            }
        }



        void ChartMouse_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right))
            {
                charts[ActiveChart].Controls.Clear();
                float yy= ((float)charts[ActiveChart].ChartAreas[0].AxisY.PixelPositionToValue(e.Y));
                string dsc = getLayerDescription(yy);
                TextBox tbLayername = new TextBox();
                tbLayername.KeyDown += new System.Windows.Forms.KeyEventHandler(EnterLayerName);
                tbLayername.Text = dsc.Split(';')[0];
                tbLayername.Tag = dsc.Split(';')[1];
                tbLayername.Location = new Point(e.X+10, e.Y-10);
                charts[ActiveChart].Controls.Add(tbLayername);
                tbLayername.Select();
                tbLayername.Focus();
                return;
            }

            if (bttnCreateInterval.Checked) 
            {
                if (ActiveChart == Int32.Parse(((Chart)sender).Name))
                {
                    //charts[ActiveChart].Series[1].Points.Clear();
                    float x = ((float)charts[ActiveChart].ChartAreas[0].AxisX.PixelPositionToValue(e.X));
                    float y = ((float)charts[ActiveChart].ChartAreas[0].AxisY.PixelPositionToValue(e.Y));

                    charts[ActiveChart].Series[1].Points.AddXY(charts[ActiveChart].ChartAreas[0].AxisX.Minimum, y);
                    charts[ActiveChart].Series[1].Points.AddXY(charts[ActiveChart].ChartAreas[0].AxisX.Maximum, y);
                    charts[ActiveChart].Series[1].Color = Color.Green;
                    charts[ActiveChart].Series[1].ChartType = SeriesChartType.Point;
                    charts[ActiveChart].Series[1].MarkerStyle=MarkerStyle.Diamond;
                    charts[ActiveChart].Series[1].MarkerSize = 10;
                    AddHorizontalLine(x,y);
                    bttnSaveInterval.Enabled = true;
                }
            }
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logCharts));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "wella.png");
            this.imgList.Images.SetKeyName(1, "well16.ico");
            this.imgList.Images.SetKeyName(2, "arrow_rot.png");
            this.imgList.Images.SetKeyName(3, "layers.png");
            this.imgList.Images.SetKeyName(4, "save16.png");
            this.imgList.Images.SetKeyName(5, "plus2.png");
            this.imgList.Images.SetKeyName(6, "minus.png");
            // 
            // logCharts
            // 
            this.ClientSize = new System.Drawing.Size(344, 376);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "logCharts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.logCharts_FormClosed);
            this.Load += new System.EventHandler(this.logCharts_Load);
            this.ResumeLayout(false);

        }


        private void logCharts_FormClosed(object sender, FormClosedEventArgs e)
        {
            ////_parentForm.w = well;
            //_parentForm.dgvWellData.ClearSelection();
            //var fr = _parentForm.ParentForm;
        }

        private void logCharts_Load(object sender, EventArgs e)
        {
            if (tmpLog=="tmp") btnShowLogs.PerformClick();
        }

 

    }
}
