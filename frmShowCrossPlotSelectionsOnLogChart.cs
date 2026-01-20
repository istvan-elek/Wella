using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace wella
{
    public partial class frmShowCrossPlotSelectionsOnLogChart : Form
    {
        Wells well;

        private frmCrossPlot _parentForm;

        public frmShowCrossPlotSelectionsOnLogChart(Wells w, int[] k, Series ser1, Series ser2, frmCrossPlot parentForm) 
        {
            _parentForm = parentForm;
            well = w;
            InitializeComponent();
            chart1.Series[1] = ser1;
            chart1.Series[1].MarkerColor=Color.Red;
            chart1.Series[1].MarkerSize = 3;
            chart1.Series[1].ChartType = SeriesChartType.Point;
            chart1.Series[0].Color = Color.Blue;
            drawLog(chart1, k[0]);

            chart2.Series[1] = ser2;
            chart2.Series[1].MarkerColor = Color.Red;
            chart2.Series[1].MarkerSize= 3;
            chart2.Series[1].ChartType=SeriesChartType.Point;
            drawLog(chart2, k[1]);
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

        void drawLog(Chart ch, int logn)
        {
            float min, max, depthmin, depthmax;

            string t = well.CurveInfo.ElementAt(logn + 1).ToString().Trim('[').Trim(']').Trim(' ').Trim(',');
            ch.Titles.Add(t);

            ch.Series[0].Points.Clear();

            ch.ChartAreas[0].AxisX.LineColor = Color.Gray;
            ch.ChartAreas[0].AxisY.LineColor = Color.Gray;

            ch.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            ch.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;

            ch.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            ch.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;

            ch.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.LightGray;
            ch.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.LightGray;

            ch.ChartAreas[0].AxisX.LineColor = Color.LightGray;
            ch.ChartAreas[0].AxisY.LineColor = Color.LightGray;

            ch.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            ch.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            ch.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            ch.ChartAreas[0].AxisY.MinorGrid.Enabled = true;

            ch.ChartAreas[0].AxisY.MinorGrid.Interval = 10;
            ch.ChartAreas[0].AxisX.MinorGrid.Interval = 10;

            ch.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Gray;
            ch.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Gray;

            ch.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular);
            ch.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular);

            int sel = logn + 1; 
            max = well.Curves[sel].Max();
            min = well.Curves[sel].Min();
            depthmin = well.Curves[0].Min();
            depthmax = well.Curves[0].Max();

            AdjustAxisScale(ch.ChartAreas[0].AxisX, min, max);
            AdjustAxisScale(ch.ChartAreas[0].AxisY, depthmin, depthmax);

            ch.ChartAreas[0].AxisY.IsReversed = true;
            ch.ChartAreas[0].AxisX.IsReversed = false;
            ch.ChartAreas[0].AxisY.Maximum = depthmax;
            ch.ChartAreas[0].AxisY.Minimum = depthmin;
            ch.ChartAreas[0].AxisY.Interval = 10;

            for (int i = 0; i < well.Curves[0].Count; i++)
            {
                double x = well.Curves[sel][i];
                double y = well.Curves[0][i];
                ch.Series[0].Points.AddXY(x, y);
            }
            ch.Invalidate();
        }


        private void frmShowCrossPlotSelectionsOnLogChart_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parentForm.clearAndEnable();
            _parentForm._parentForm.dgvWellData.ClearSelection();
        }


    }    
}
