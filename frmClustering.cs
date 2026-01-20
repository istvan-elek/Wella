using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wella
{
    public partial class frmClustering : Form
    {
        List<float> tmpList = new List<float>();
        List<List<float>> logsForClustering = new List<List<float>>();
        //int maxStep = 50;
        //int clusterCount = 5;
        //KMeans kmean;
        Wells wells = new Wells();
        public frmClustering(Wells w)
        {
            InitializeComponent();
            wells = w;
            loadAvailableLogs();

        }

        void loadAvailableLogs()
        {
            availableLogs.Items.Clear();
            foreach (string item in wells.CurveInfo.Keys)
            {
                availableLogs.Items.Add(item);
            }
            availableLogs.Items.RemoveAt(0);
        }


        private void bttnRun_Click(object sender, EventArgs e)
        {
            if (availableLogs.SelectedItems.Count == 0) 
            { MessageBox.Show("You have not selected any items from the list of available logs. Choose at least two logs.","Missing  items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; 
            }

            int maxStep = int.Parse(tbIterationMax.Text.Trim());
            int clusterCount = int.Parse(tbNumofClusters.Text.Trim());
            loadSelectedLogs();
            KMeans kmean = new KMeans(clusterCount, maxStep);
            int[] clusters = kmean.Cluster(logsForClustering);
            logCharts lgChart = new logCharts(wells);
            int[] intArray = clusters;
            float[] floatArray = new float[intArray.Length];
            for (int i = 0; i < intArray.Length; i++)
            {
                floatArray[i] = intArray[i];
            }
            tmpList = new List<float>(floatArray);

            if (!wells.CurveInfo.ContainsKey("tmp"))
            {
                wells.CurveInfo.Add("tmp", "temporary");
                wells.Curves.Add(tmpList);
            }
            else
            {
                wells.Curves.RemoveAt(wells.Curves.Count - 1);
                wells.Curves.Add(tmpList);
            }
            if (chkDisplayResult.Checked)
            {
                logCharts ChartShowResult = new logCharts(wells, "tmp");
                ChartShowResult.Show();
            }
        }


        void loadSelectedLogs()
        {
            for (int i=0; i< availableLogs.Items.Count; i++)
            {
                if (availableLogs.GetSelected(i)) 
                { 
                    logsForClustering.Add(wells.Curves[i+1]); 
                }
            }
        }

        private void frmClustering_FormClosed(object sender, FormClosedEventArgs e)
        {
            wells.Curves.RemoveAt(wells.CurveInfo.Count - 1);
            wells.CurveInfo.Remove("tmp");
        }
    }
}
