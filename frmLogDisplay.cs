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
using System.Windows.Forms.VisualStyles;
using wella;

namespace wella
{
    public partial class frmLogDisplay : Form
    {
        float min, max, depthmin, depthmax;

        Wells wells;
        //Chart[] chrt;

        private void bttnShowSelected_Click(object sender, EventArgs e)
        {
            //for (int i = 1; i < lstLogs.Items.Count; i++)
            //{
                drawLog();
                //chart1.ChartAreas.Add(i.ToString());
                //chart1.ChartAreas[i].AlignmentStyle = AreaAlignmentStyles.Position;
                //chart1.ChartAreas[i].AlignmentOrientation = AreaAlignmentOrientations.Vertical;
                //chart1.Series.Add(i.ToString());
            //}

        }

        public frmLogDisplay(Wells w)
        {
            InitializeComponent();
            wells = w;
            fillLogList();
        }

        private void lstLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            bttnShowSelected.Enabled = true;
        }

        void drawLog()
        {
            int k = 0;
            int selCount=lstLogs.SelectedIndices.Count;
            chart1.Series[k].Points.Clear();
            chart1.ChartAreas[k].AxisX.LineColor = Color.Gray;
            chart1.ChartAreas[k].AxisY.LineColor = Color.Gray;

            chart1.ChartAreas[k].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chart1.ChartAreas[k].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;

            chart1.ChartAreas[k].AxisX.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[k].AxisY.MajorGrid.LineColor = Color.Gray;

            chart1.ChartAreas[k].AxisX.MajorTickMark.LineColor = Color. LightGray;
            chart1.ChartAreas[k].AxisY.MajorTickMark.LineColor = Color.LightGray;

            chart1.ChartAreas[k].AxisX.LineColor = Color.LightGray;
            chart1.ChartAreas[k].AxisY.LineColor = Color.LightGray;

            chart1.ChartAreas[k].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[k].AxisY.MinorGrid.LineColor = Color.LightGray;

            chart1.ChartAreas[k].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[k].AxisY.MinorGrid.Enabled = true;

            chart1.ChartAreas[k].AxisY.MinorGrid.Interval = 10;
            chart1.ChartAreas[k].AxisX.MinorGrid.Interval = 10;

            chart1.ChartAreas[k].AxisX.LabelStyle.ForeColor = Color.Gray;
            chart1.ChartAreas[k].AxisY.LabelStyle.ForeColor = Color.Gray;

            chart1.ChartAreas[k].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular);
            chart1.ChartAreas[k].AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular);

            chart1.Series[k].Color = Color.DarkGreen;

            int sel = lstLogs.SelectedIndex+1;            
            chart1.Titles[0].Text = lstLogs.SelectedItem.ToString();
            max = wells.Curves[sel].Max();
            min = wells.Curves[sel].Min();
            depthmin = wells.Curves[0].Min();
            depthmax = wells.Curves[0].Max();
            chart1.ChartAreas[k].AxisY.RoundAxisValues();
            chart1.ChartAreas[k].AxisX.RoundAxisValues();
            chart1.ChartAreas[k].AxisY.IsReversed = true;
            chart1.ChartAreas[k].AxisY.Maximum = depthmax;
            chart1.ChartAreas[k].AxisY.Minimum = depthmin;
            chart1.ChartAreas[k].AxisX.Maximum = (int)(max+1);
            chart1.ChartAreas[k].AxisX.Minimum = (int)(min+0.5D);

            for (int i = 0; i < wells.Curves[0].Count; i++)
            {
                double x = wells.Curves[sel][i];
                double y = wells.Curves[0][i];
                chart1.Series[k].Points.AddXY(x, y);
            }

        }

        void fillLogList() 
        {
            lstLogs.Items.Clear();
            foreach(string s in wells.CurveInfo.Keys)
            {
                lstLogs.Items.Add(s);
            }
            lstLogs.Items.RemoveAt(0);
        }


        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var result = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    string val=prop.XValue.ToString("F1");
                    string dep = prop.YValues[0].ToString("F1");
                    this.Text = "Depth: " + dep + " --- " + chart1.Titles[0].Text + ": " + val; 
                }
                else
                { this.Text = "Log display"; }
            }
            catch (Exception)
            {
            }
        }
        
    }
}
