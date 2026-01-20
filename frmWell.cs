using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using GMap.NET.MapProviders;
using GMap;
using System.Security.Cryptography;
using System.Diagnostics.Eventing.Reader;
using Newtonsoft.Json.Linq;

namespace wella
{
    public partial class frmWell : Form
    {
        public Wells w = new Wells();
        string initial_folder;
        string fname="";
        DataTable dtLogs = new DataTable();


        public frmWell()
        {
            InitializeComponent();
            tslabFieldName.Text = "";
            tslabFileName.Text = "";
            tslabRows.Text = "";
            initial_folder = Properties.Settings.Default["initFolder"].ToString();
        }

 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox aboutBox = new frmAboutBox();
            aboutBox.ShowDialog();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lasFileName = ""; 
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory=initial_folder;
            of.Filter = "LAS files|*.las";
            if (of.ShowDialog() == DialogResult.OK)
            {
                w.init();
                tbWellInfo.Text = "";
                lasFileName = of.FileName;
                fname=lasFileName;
                w.parseHeader(lasFileName);
                tbWellInfo.AppendText("Created on: " + w.CreatedOn + Environment.NewLine);
                tbWellInfo.AppendText("LAS format: " + w.Version + Environment.NewLine);
                tbWellInfo.AppendText(Environment.NewLine + "Well information" + Environment.NewLine);
                foreach (KeyValuePair<string, string> item in w.WellInfo)
                {
                    //buttonOnOff(false);
                    tbWellInfo.AppendText(item.Key.ToString() + ", " + item.Value.ToString() + Environment.NewLine);
                    string s = w.WellInfo["WELL"];
                    lblWellName.Text = "Well name: " + s;
                    w.parsLogs(lasFileName);
                    DataTable dtLogs = new DataTable();
                    for (int i = 0; i < w.CurveInfo.Count; i++)
                    {
                        string colname = w.CurveInfo.ElementAt(i).Key;
                        dtLogs.Columns.Add(colname);
                    }
                    dtLogs.NewRow();
                    for (int row = 0; row < w.Curves[0].Count; row++)
                    {
                        dtLogs.Rows.Add();
                        for (int col = 0; col < w.CurveInfo.Count; col++)
                        {
                           dtLogs.Rows[row][col] = w.Curves[col][row];
                        }
                    }
                    bs = new BindingSource();
                    bs.DataSource = dtLogs;
                    dgvWellData.DataSource = bs;
                    bn.BindingSource = bs;

                    tslabRows.Text = "Rows count: " + dtLogs.Rows.Count;
                    dgvWellData.Sort(dgvWellData.Columns[0], ListSortDirection.Ascending);
                    splitContainer1.Visible = true;

                    //displayDataToolStripMenuItem.Enabled = true;
                    propGrid.SelectedObject = w;
                    //mnuSaveToWlaFormat.Enabled = false;
                    saveAsToWlaFormatToolStripMenuItem.Enabled = true;
                    //processingToolStripMenuItem.Enabled = true;
                    tslabFileName.Text = "File name: " + System.IO.Path.GetFileName(fname);
                    tslabFieldName.Text = "";
                    Properties.Settings.Default["initFolder"]=Path.GetDirectoryName(of.FileName);
                    Properties.Settings.Default.Save();
                }
            }
        }
        

        private void showDataAsGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logCharts logDisplay = new logCharts(this);
            logDisplay.Show();
        }

        private void crossPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCrossPlot crossPlot = new frmCrossPlot(w, this);
            crossPlot.Show();
        }

        private void bttnViewProperties_Click(object sender, EventArgs e)
        {
            propGrid.Visible = !propGrid.Visible;
            if (propGrid.Visible) { bttnViewProperties.Text = "Header"; } else { bttnViewProperties.Text = "Properties"; }
             
            
            //propGrid.ExpandAllGridItems();
            propGrid.BringToFront();
        }

        private void mnuSaveToWlaFormat_Click(object sender, EventArgs e)
        {
            w.save2WlaFormat(fname);
            MessageBox.Show("Changes has been saved", "Save changes",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mapWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double lon = Convert.ToDouble(w.WellInfo["LON"], System.Globalization.CultureInfo.InvariantCulture);
            double lat = Convert.ToDouble(w.WellInfo["LAT"], System.Globalization.CultureInfo.InvariantCulture); ;
            frmGmap gmap = new frmGmap(lat, lon, w.WellInfo["WELL"]);
            gmap.Show();
        }


        private static void ExpandGroup(PropertyGrid propertyGrid, string groupName)
        {
            GridItem root = propertyGrid.SelectedGridItem;
            //Get the parent
            while (root.Parent != null)
                root = root.Parent;

            if (root != null)
            {
                foreach (GridItem g in root.GridItems)
                {
                    if (g.GridItemType == GridItemType.Category && g.Label == groupName)
                    {
                        g.Expanded = true;
                        break;
                    }
                }
            }
        }

        private void PpropertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            propGrid.ExpandAllGridItems();
        }

        void buttonOnOff(Boolean sw)
        {
            displayDataToolStripMenuItem.Enabled = sw;
            //propGrid.SelectedObject = w;
            mnuSaveToWlaFormat.Enabled = sw;
            processingToolStripMenuItem.Enabled = sw;
            saveAsToWlaFormatToolStripMenuItem.Enabled = sw;
            tsbtnDisplayLogs.Enabled = sw;
            tsbtnCrossPlot.Enabled = sw;
            tsbtnFormulaEditor.Enabled = sw;
            tsbtnMapWiindow.Enabled = sw;
            tsbtnSaveChanges.Enabled = sw;
            tsExportToLASFilesMenuItem.Enabled = sw;
        }

        private void openWlaFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = initial_folder;
            ofd.Filter = "Wella files|*.wla";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fname = ofd.FileName;
                w = new Wells().openWlaFile(ofd.FileName);
                tbWellInfo.Text = "";
                tbWellInfo.AppendText("Created on: " + w.CreatedOn + Environment.NewLine);
                tbWellInfo.AppendText("LAS format: " + w.Version + Environment.NewLine);
                tbWellInfo.AppendText(Environment.NewLine + "Well information" + Environment.NewLine);
                foreach (KeyValuePair<string, string> item in w.WellInfo)
                {
                    tbWellInfo.AppendText(item.Key.ToString() + ", " + item.Value.ToString() + Environment.NewLine);
                }
                string s = w.WellInfo["WELL"];
                lblWellName.Text = "Well name: " + s;
                dtLogs.Clear();
                dtLogs.Columns.Clear();
                dtLogs = new DataTable();
                for (int i = 0; i < w.CurveInfo.Count; i++)
                {
                    string colname = w.CurveInfo.ElementAt(i).Key;
                    dtLogs.Columns.Add(colname);
                }
                dtLogs.NewRow();
                for (int row = 0; row < w.Curves[0].Count; row++)
                {
                    dtLogs.Rows.Add();
                    for (int col = 0; col < w.CurveInfo.Count; col++)
                    {
                        dtLogs.Rows[row][col] = w.Curves[col][row];
                    }
                }
                bs = new BindingSource();
                bn.BindingSource = bs;
                bs.DataSource = dtLogs;
                dgvWellData.DataSource = bs;
                tslabRows.Text = "   Depth points count: " + dtLogs.Rows.Count;
                dgvWellData.Sort(dgvWellData.Columns[0], ListSortDirection.Ascending);
                splitContainer1.Visible = true;
                buttonOnOff(true);
                propGrid.SelectedObject = w;
                tslabFileName.Text = "File name: " + System.IO.Path.GetFileName(fname);
                w.parseIntervals(fname);
            }
        }

        public void refreshDataGrid()
        {
            dtLogs = new DataTable();
            for (int i = 0; i < w.CurveInfo.Count; i++)
            {
                string colname = w.CurveInfo.ElementAt(i).Key;
                dtLogs.Columns.Add(colname);
            }
            dtLogs.NewRow();
            for (int row = 0; row < w.Curves[0].Count; row++)
            {
                dtLogs.Rows.Add();
                for (int col = 0; col < w.CurveInfo.Count; col++)
                {
                    dtLogs.Rows[row][col] = w.Curves[col][row];
                }
            }
            bs = new BindingSource();
            bs.DataSource = dtLogs;
            dgvWellData.DataSource = bs;
        }

        private void guideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guide webBr = new guide();
            webBr.Show();
        }

        private void mnuFormulaEditor_Click(object sender, EventArgs e)
        {
            frmFormula EditFormula=new frmFormula(this, w);
            EditFormula.ShowDialog();
        }

        private void dgvWellData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult res = MessageBox.Show("Delete '" + dgvWellData.Columns[e.ColumnIndex].Name + "' log?","Delete selected log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes) 
                {
                    string name = dgvWellData.Columns[e.ColumnIndex].Name;
                    dgvWellData.Columns.Remove(name);
                    int k=0;
                    int ind = 0;
                    foreach (var s in w.CurveInfo.Keys)
                    {
                        if (s == name) 
                        { 
                            ind = k;
                            w.Curves.RemoveAt(k);
                        }
                        k++;
                    }
                    w.CurveInfo.Remove(name);
                } 
            }
        }

        private void saveAsToWlaFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = initial_folder;
            saveFileDialog.Filter = "Wella format|*.wla";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fname = saveFileDialog.FileName;
                w.save2WlaFormat(saveFileDialog.FileName);
                tslabFileName.Text = "File name: " + System.IO.Path.GetFileName( fname);
                buttonOnOff(true);
            }
        }


        private void kmeansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClustering frmCluster=new frmClustering(w);
            frmCluster.ShowDialog();
        }

        private void createNewFieldDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox inbox = new InputBox( "Field name:", "Set up field name ");
            inbox.ShowDialog();
            tslabFieldName.Text = "Field name: " + inbox.ParameterValue;
            //SQLiteConnection cnn = new SQLiteConnection();
        }

        private void tsExportToLASFilesMenuItem_Click(object sender, EventArgs e)
        {
            //InputBox LasFileNameIBox = new InputBox("LAS file name:","Set up LAS file name" );
            //LasFileNameIBox.ShowDialog();
            //Export2LasFile(LasFileNameIBox.ParameterValue.ToString());
            Export2LasFile(Path.GetDirectoryName(fname) + "\\export.las");
        }

        void Export2LasFile(string lasFileName)
        {
            using (FileStream fs = new FileStream(lasFileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("#------------------------------------------------------------------------------");
                    sw.WriteLine("#     Created by  :   " + w.CreatedBy.ToString());
                    sw.WriteLine("#     Created on  :   " + w.CreatedOn.ToString());
                    sw.WriteLine("#------------------------------------------------------------------------------");
                    sw.WriteLine("~VERSION INFORMATION");
                    sw.WriteLine("VERS. " + w.Version + " : CWLS Log ASCII Standard - version " + w.Version);
                    sw.WriteLine("WRAP.  NO : One line per depth step");
                    sw.WriteLine("~WELL INFORMATION");
                    sw.WriteLine("# MNEMONIC   .UNIT" + "                                         VALUE :Description");
                    sw.WriteLine("#------------------------------------------------------------------------------");
                    foreach (string item in w.DescWellInfo)
                    {
                        string wellinfoline = item.Trim();
                        sw.WriteLine(wellinfoline);
                    }
                    sw.WriteLine("~CURVE INFORMATION");
                    sw.WriteLine("#MNEMONIC.UNIT               API CODE: CURVE DESCRIPTION");
                    sw.WriteLine("#------------------------------------------------------------------------------");
                    foreach (string item in w.CurveInfo.Keys)
                    {
                        sw.WriteLine(item + "     ." + w.CurveInfo[item]);
                    }
                    string logs = "~A      ";
                    for (int i = 0; i < w.CurveInfo.Count; i++)
                    {
                        logs += w.CurveInfo.ElementAt(i).Key.ToString() + "        ";
                    }

                    sw.WriteLine(logs);

                    int rowCount = w.Curves[0].Count;
                    int colCount = w.Curves.Count;

                    for (int row = 0; row < rowCount; row++)
                    {
                        List<string> valuesInRow = new List<string>();
                        for (int col = 0; col < colCount; col++)
                        {
                            valuesInRow.Add(w.Curves[col][row].ToString("G", System.Globalization.CultureInfo.InvariantCulture));
                        }
                        string s = "      " + string.Join("     ", valuesInRow);
                        sw.WriteLine(s);
                    }
                }
            
            }
        }        
    }
}
