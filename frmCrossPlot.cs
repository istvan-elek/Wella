using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace wella
{

    public partial class frmCrossPlot : Form
    {
        Wells well;
        Boolean drawing=false;  // ha rajzol, akkor true, egyéként false
        double x1, y1, x2, y2;
        float x1p, y1p, x2p, y2p, xx2, yy2;
        Point s1;
        Point s2;
        //Boolean mode =  true; // false: egy pont kijelölése rámutatással, true: kijelölés téglalappal. Az lesz kijelölve, ami a téglalapon belül van
        enum status { Point, Line, Poligon};
        status mode = status.Poligon;
        Series pnts1 = new Series();
        Series pnts2 = new Series();
        public frmWell _parentForm;

        public frmCrossPlot(Wells w, frmWell parentForm)
        {
            InitializeComponent();
            well = w;
            addLogList();
            pnts1.Name = "Series2";
            pnts2.Name = "Series2";
            _parentForm = parentForm;
            
        }

        void addLogList()
        {
            lstLogs.Size = new Size(150, 200);
            for (int i = 1; i < well.CurveInfo.Count; i++)
            {
                lstLogs.Items.Add(well.CurveInfo.ElementAt(i).Key);
            }
            lstLogs.SelectedIndex = 0;
            lstLogs.ClearSelected();
        }

        public void bttnClear_Click(object sender, EventArgs e)
        {
            lstLogs.ClearSelected();
            //chart1.Visible = false;
            chart1.Series[1].Points.Clear();
            this.chart1.Series[0].Points.Clear();
            chart1.Invalidate();
            tsbtnPointSelect.Enabled = false; tsbtnRectangleSelect.Enabled = false;
            bttnShowSelectionOnLogs.Enabled = false;

            FormCollection fc = Application.OpenForms;
            if (fc["frmShowCrossPlotSelectionsOnLogChart"] != null)
            {
                fc["frmShowCrossPlotSelectionsOnLogChart"].Close();
            }

        }


        void drawCrossPlot()
        {
            float min1, max1, min2, max2;
            int sel1 = lstLogs.SelectedIndices[0]+1;
            int sel2 = lstLogs.SelectedIndices[1]+1;
            int sel3 = lstLogs.SelectedIndices[0]; //depth
            string t = "Cross-plot of " + lstLogs.SelectedItems[0].ToString() + " - " + lstLogs.SelectedItems[1].ToString();

            chart1.Titles.Clear();
            chart1.Titles.Add(t);

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            chart1.ChartAreas[0].AxisX.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisY.LineColor = Color.Gray;

            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;

            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;

            chart1.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.LightGray;

            chart1.ChartAreas[0].AxisX.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.LineColor = Color.LightGray;

            chart1.ChartAreas[0].AxisX.Title = lstLogs.SelectedItems[0].ToString();
            chart1.ChartAreas[0].AxisY.Title = lstLogs.SelectedItems[1].ToString();

            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Gray;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Gray;

            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular);

            max1 = well.Curves[sel1].Max();
            min1 = well.Curves[sel1].Min();
            min2 = well.Curves[sel2].Min();
            max2 = well.Curves[sel2].Max();

            chart1.ChartAreas[0].AxisY.IsReversed = false;
            chart1.ChartAreas[0].AxisX.IsReversed = false;
            chart1.ChartAreas[0].AxisY.Maximum =  max2;
            chart1.ChartAreas[0].AxisY.Minimum = min2;
            chart1.ChartAreas[0].AxisX.Maximum = (int)(max1 + 1);
            chart1.ChartAreas[0].AxisX.Minimum = (int)(min1 + 0.5D);
            chart1.ChartAreas[0].AxisY.RoundAxisValues();
            chart1.ChartAreas[0].AxisX.RoundAxisValues();

            chart1.Series[0].Color = Color.DarkBlue;

            for (int i = 0; i < well.Curves[0].Count; i++)
            {
                object x = well.Curves[sel1][i];
                object[] y = new object[2];  
                y[0] = well.Curves[sel2][i];
                y[1]=well.Curves[0][i];
                chart1.Series[0].YValuesPerPoint=y.Length;
                chart1.Series[0].Points.AddXY(x, y);
            }
        }

        private void bttnCrossplot_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            drawCrossPlot();
            tsbtnPointSelect.Enabled = true; 
            tsbtnRectangleSelect.Enabled = true;
            tsbtnLineSelect.Enabled = true;
            bttnShowSelectionOnLogs.Enabled = false;
        }

        private void lstLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLogs.SelectedItems.Count ==2) 
            {
                bttnCrossplot.Enabled = true;
                chart1.Series[1].Points.Clear();
                chart1.Series[0].Points.Clear();
                FormCollection fc = Application.OpenForms;
                if (fc["frmShowCrossPlotSelectionsOnLogChart"] != null)
                {
                    fc["frmShowCrossPlotSelectionsOnLogChart"].Close();
                }
            }
            else {bttnCrossplot.Enabled = false;  }
        }
        void DrawBox()
        {
            Graphics gr = chart1.CreateGraphics();
            Pen p = new Pen(Color.DarkGoldenrod);
            gr.DrawLine(p, x1p, y1p, x1p, y2p);
            gr.DrawLine(p, x1p, y1p, x2p, y1p);
            gr.DrawLine(p, x2p, y1p, x2p, y2p);
            gr.DrawLine(p, x2p, y2p, x1p, y2p);
        }

        void DrawLine()
        {
            Graphics gr = chart1.CreateGraphics();
            Pen p = new Pen(Color.Black);
            gr.DrawLine(p, x1p, y1p, x2p, y2p);
        }


        private void bttnShowSelectionOnLogs_Click(object sender, EventArgs e)
        {
            int[] selectedIndeces = new int[lstLogs.SelectedItems.Count];
            for(int i=0; i< lstLogs.SelectedItems.Count;i++)
            {
                selectedIndeces[i]= lstLogs.SelectedIndices[i];
            }

            frmShowCrossPlotSelectionsOnLogChart frm = new frmShowCrossPlotSelectionsOnLogChart(well, selectedIndeces, pnts1, pnts2, this);
            frm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            frm.Show();
            _parentForm.dgvWellData.ClearSelection();
            for (int k=0; k< _parentForm.dgvWellData.Rows.Count-1; k++)
            {
                for (int j = 0; j < pnts1.Points.Count; j++)
                {
                    if (_parentForm.dgvWellData.Rows[k].Cells["Depth"].Value.ToString() == pnts1.Points[j].YValues[0].ToString("#.#"))
                    {
                        _parentForm.dgvWellData.Rows[k].Selected=true;
                    }
                }
            }            
        }

        private void frmCrossPlot_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            if (fc["frmShowCrossPlotSelectionsOnLogChart"] != null)
            {
                fc["frmShowCrossPlotSelectionsOnLogChart"].Close();
            }
            _parentForm.dgvWellData.ClearSelection();
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode==status.Point)  // point select
            {
                chart1.Series[1].Points.Clear();
                chart1.Series[1].MarkerSize = 6;
                pnts1.Points.Clear();
                pnts2.Points.Clear();
                var result = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    float x1 = ((float)prop.XValue);
                    float y1 = ((float)prop.YValues[0]);
                    pnts1.Points.AddXY(x1, (float)prop.YValues[1]);
                    pnts2.Points.AddXY((float)prop.YValues[0], (float)prop.YValues[1]);
                    chart1.Series[1].Points.AddXY(x1, y1);
                    bttnShowSelectionOnLogs.Enabled = true;
                }
            }
            if (mode==status.Poligon)     //else  // mode=true, rectangle select
            {
                x1p = e.X;
                y1p = e.Y;
                x1 = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                y1 = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                drawing = true;
            }
            if (mode == status.Line)
            {
                x1p = e.X;
                y1p = e.Y;
                x1 = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                y1 = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                drawing = true;
            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!drawing) // ide akkor lép, ha nem rajzol
            {
                try
                {
                    var result = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
                    if (result.ChartElementType == ChartElementType.DataPoint)
                    {
                        var prop = result.Object as DataPoint;
                        string X = prop.XValue.ToString("F2");
                        string Y = prop.YValues[0].ToString("F2");
                        string Y2 = prop.YValues[1].ToString("F2");                    
                        this.Text = "Depth: " + Y2.ToString() + "      " + lstLogs.SelectedItems[0].ToString() + ": " + X + " - " + lstLogs.SelectedItems[1].ToString() +": " + Y;
                    }
                    else
                    { this.Text = "Cross-plot of " + lstLogs.SelectedItems[0].ToString() + " - " + lstLogs.SelectedItems[1].ToString(); }
                }
                catch (Exception)
                {
                    //throw;
                }
            }
            else  // ide akkor lép, ha rajzol
            {
                try
                {
                    xx2 = ((float)chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X));
                    x2p = e.X;
                }
                catch (Exception)
                {
                }

                try
                {
                    yy2 = ((float)chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y));
                    y2p=e.Y;
                }
                catch (Exception)
                {
                } 
                chart1.Invalidate();
                if (mode == status.Poligon) DrawBox();
                if (mode == status.Line) DrawLine();
            }
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!drawing) return;  //drawing=false;
            else  // ide akkor lép, ha rajzol
            {
                if (mode == status.Poligon)
                {
                    chart1.Series[1].Points.Clear();
                    if (pnts1.Points != null) { pnts1.Points.Clear(); } else { pnts1 = new Series(); }
                    if (pnts2.Points != null) { pnts2.Points.Clear(); } else { pnts2 = new Series(); }
                    DrawBox();
                    try //ha x kilóg a chart keretéből
                    {
                        x2 = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                        if (x2 < x1)
                        {
                            double xx = x2;
                            x2 = x1;
                            x1 = xx;
                        }
                    }
                    catch (Exception)
                    {
                        x2 = chart1.ChartAreas[0].AxisX.Maximum;
                        if (x2 < x1)
                        {
                            double xx = x2;
                            x2 = x1;
                            x1 = xx;
                        }
                    }


                    try
                    {
                        y2 = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                        if (y2 < y1)
                        {
                            double yy = y2;
                            y2 = y1;
                            y1 = yy;
                        }
                    }
                    catch (Exception)
                    {
                        y2 = chart1.ChartAreas[0].AxisY.Minimum;
                        if (y2 < y1)
                        {
                            double yy = y2;
                            y2 = y1;
                            y1 = yy;
                        }
                    }

                    for (int i = 0; i < chart1.Series[0].Points.Count; i++)
                    {
                        if ((x1 < chart1.Series[0].Points[i].XValue && x2 > chart1.Series[0].Points[i].XValue) && (y1 < chart1.Series[0].Points[i].YValues[0] && y2 > chart1.Series[0].Points[i].YValues[0]))
                        {
                            chart1.Series[1].Points.AddXY(chart1.Series[0].Points[i].XValue, chart1.Series[0].Points[i].YValues[0]);
                            pnts1.Points.AddXY(chart1.Series[0].Points[i].XValue, chart1.Series[0].Points[i].YValues[1]);
                            pnts2.Points.AddXY(chart1.Series[0].Points[i].YValues[0], chart1.Series[0].Points[i].YValues[1]);
                            bttnShowSelectionOnLogs.Enabled = true;
                        }
                    }

                }
                if (mode == status.Line)
                {
                    var result = chart1.HitTest(e.X, e.Y);
                    if (result.Object == null)
                    {
                        chart1.Series[1].Points.Clear();
                        x1 = 0;
                        y1 = 0;
                        return;
                    }
                    double x = result.ChartArea.AxisX.PixelPositionToValue(e.X);
                    double y = result.ChartArea.AxisY.PixelPositionToValue(e.Y);
                    if (x1 == (int)x || y1 == (int)y)
                    {
                        x1 = 0;
                        y1 = 0;
                        return;
                    }
                    chart1.Series[1].MarkerSize = 4;
                    Point endP = new Point((int)x, (int)y);
                    chart1.Series[1].Points.AddXY(x1, y1);
                    chart1.Series[1].Points.AddXY(endP.X, endP.Y);
                    float m = (float)((int)y - x1) / (float)((int)x - x1);
                    float a = (float)y1 - (float)(m * x);
                    drawLongLine(m, a);
                    x1 = 0;
                    y1 = 0;
                }
                drawing = false;
            }
        }

        void drawLongLine(float m, float a)
        {
            s1 = new Point();
            int xmax = 255;
            int ymax = (int)(m * 255 + a);
            s2 = new Point(xmax, ymax);
            if (a > 0)
            {
                s1.X = 0;
                s1.Y = (int)a;
            }
            else
            {
                float c = -a / m;
                s1.X = (int)c;
                s1.Y = 0;
            }
            chart1.Series[1].Points.Clear();
            chart1.Series[1].Points.AddXY(s1.X, s1.Y);
            chart1.Series[1].Points.AddXY(s2.X, s2.Y);
        }

        private void tsbtnRectangleSelect_Click(object sender, EventArgs e)
        {
            mode = status.Poligon; // "rectangle select";
            tsbtnRectangleSelect.Checked = true;
            tsbtnPointSelect.Checked = false;
            tsbtnLineSelect.Checked = false;
            chart1.Series[1].Points.Clear();
        }

        private void tsbtnPointSelect_Click(object sender, EventArgs e)
        {
            mode = status.Point;  // "point select";
            tsbtnPointSelect.Checked = true;
            tsbtnRectangleSelect.Checked = false;
            tsbtnLineSelect.Checked = false;
            chart1.Series[1].Points.Clear();
        }


        private void tsbtnLineSelect_Click(object sender, EventArgs e)
        {
            mode = status.Line;  // "line select";
            tsbtnPointSelect.Checked = false;
            tsbtnLineSelect.Checked = true;
            tsbtnRectangleSelect.Checked = false;
            chart1.Series[1].Points.Clear();
        }

        public void clearAndEnable()
        {
            chart1.Series[1].Points.Clear();
            bttnShowSelectionOnLogs.Enabled = false;
        }

    }
}
