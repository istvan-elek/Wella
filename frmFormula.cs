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
using GMap.NET.MapProviders;
using NCalc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace wella
{
    public partial class frmFormula : Form
    {
        List<float> tmpList = new List<float>();
        Wells w=new Wells();
        List<List<float>> logList = new List<List<float>>();
        string formula = "";
        Dictionary<string, string> Formulas = new Dictionary<string, string>();
        frmWell _parentForm;


         public frmFormula(frmWell parent, Wells well)
        {
            _parentForm = parent;
            InitializeComponent();
            w = well; 
            loadLogs();
            label2.Text = "Formula examples:  1/a * b * 100     where" + Environment.NewLine + "'a' is the first item in the log list, 'b' is the second, 'c' is the third ..." + Environment.NewLine + "Exponentiation: Pow(a+b, 2.3),   Pow(a,2)*b";
            cmbExistingFormulas.Items.Add("Select an item");
            cmbExistingFormulas.SelectedIndex = 0;
            LoadExistingFormulas();
            // Ha a lista módosul, újra beállítjuk az Enabled állapotot
            lstLogsforCompute.DataSourceChanged += (s, e) => UpdateButtonState();
        }

        private void bttnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void loadLogs()
        {
            lstBoxLogNames.Items.Clear();
            foreach (string item in w.CurveInfo.Keys)
            {
                lstBoxLogNames.Items.Add(item);
            }
            lstBoxLogNames.Items.RemoveAt(0);
        }

        List<float> Run()
        {
            // Eredménylista létrehozása
            List<float> results = EvaluateFormula(logList, formula.Trim());
            return results;
        }

        static List<float> EvaluateFormula(List<List<float>> data, string formula)
        {
            List<float> results = new List<float>();

            int rowCount = data[0].Count; // Feltételezzük, hogy minden oszlop ugyanannyi elemet tartalmaz

            for (int i = 0; i < rowCount; i++)
            {
                Expression exp = new Expression(formula);

                // Dinamikusan változókat állítunk be
                char varName = 'a';
                foreach (var column in data)
                {
                    exp.Parameters[varName.ToString()] = column[i];
                    varName++;
                }

                // Kifejezés kiértékelése
                try
                {
                    object result = exp.Evaluate();
                    results.Add(Convert.ToSingle(result));  // Float-ként tárolás
                }
                catch (Exception err)
                {
                    if (err.HResult == -2146232832)
                    {
                        MessageBox.Show("Improper operator in the formula: " + err.Message, "Error in formula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
            return results;
        }


        private void bttnAddSelectedLogs_Click(object sender, EventArgs e)
        {
            lstLogsforCompute.Items.Clear();
            for (int i = 0; i < lstBoxLogNames.SelectedItems.Count; i++)
            {
                lstLogsforCompute.Items.Add(lstBoxLogNames.SelectedItems[i].ToString());
            }
            UpdateButtonState(); // Gomb frissítése
        }

        private void bttnRun_Click(object sender, EventArgs e)
        {
            tmpList = Run();
            if (!w.CurveInfo.ContainsKey("tmp"))
            {
                w.CurveInfo.Add("tmp", "temporary");
                w.Curves.Add(tmpList);
            }
            else
            {
                w.Curves.RemoveAt(w.Curves.Count-1);
                w.Curves.Add(tmpList);
            }
            bttnSaveResult.Enabled=true;
            bttnSaveFormula.Enabled = true;
            if (chkShowResult.Checked)
            {
                logCharts ChartShowResult = new logCharts(w, "tmp");
                ChartShowResult.Show();
            }
            loadLogs();
        }

        private void bttnAcceptFormula_Click(object sender, EventArgs e)
        {
            if (lstLogsforCompute.Items.Count ==0) { MessageBox.Show("There is no logs for computation"); return; }

            if (tbFormula.Text != string.Empty)
            {
                logList.Clear();
                int index = 0;
                for (int i = 0; i < lstLogsforCompute.Items.Count; i++)
                {
                    index = findIndex(lstLogsforCompute.Items[i].ToString());
                    logList.Add(w.Curves[index]);
                }
                formula = tbFormula.Text.Trim();
                bttnRun.Enabled = true;
            }
            else { MessageBox.Show("Formula is empty"); }
        }

        int findIndex(string name)
        {
            int index = 0;
            foreach (var key in w.CurveInfo.Keys)
            {
                if (key == name)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        private void bttnClearFormula_Click(object sender, EventArgs e)
        {
            tbFormula.Text = string.Empty;
            bttnRun.Enabled=false;
        }


        private void lstBoxLogNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxLogNames.SelectedItems.Count > 0) {bttnAddSelectedLogs.Enabled = true;}
            else { bttnAddSelectedLogs.Enabled = false;}
        }

        private void bttnSaveProcedure_Click(object sender, EventArgs e) // új formula mentése
        {
            string fileName2SaveFormula = Application.StartupPath + @"\Formulas.frml";
            InputBox inBox = new InputBox("Formula name:", "Set up formula name"/*tbFormula.Text.Trim()*/);
            if (inBox.ShowDialog() == DialogResult.OK)
            {
                string desc = inBox.ParameterValue;
                Formulas.Add(desc, tbFormula.Text.Trim());
                using (FileStream fs = new FileStream(fileName2SaveFormula, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(desc + ";" + tbFormula.Text.Trim());
                    }
                }
                cmbExistingFormulas.Items.Add(desc);
            }
        }

        private void LoadExistingFormulas()
        {
            string[] forms = File.ReadAllLines(Application.StartupPath + @"\Formulas.frml");
            foreach (string item in forms)
            {
                Formulas.Add(item.Split(';')[0], item.Split(';')[1]);
                cmbExistingFormulas.Items.Add(item.Split(';')[0]);
            }
        }

        private void cmbExistingFormulas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbExistingFormulas.SelectedItem.ToString() != "Select an item") 
            { cmbExistingFormulas.Items.Remove("Select an item"); }
            if (Formulas.Count > 0)
            {
                tbFormula.Text = Formulas[cmbExistingFormulas.SelectedItem.ToString().Trim()];
            }
        }

        void renameKey(string oldKey, string newKey)
        {
            w.CurveInfo.Add(newKey, newKey);
            w.CurveInfo.Remove(oldKey);
        }

        private void bttnSaveResult_Click(object sender, EventArgs e)  // eredmény log mentése
        {
            InputBox inputFileName = new InputBox("Log name:", "Set up new log name");
            if (inputFileName.ShowDialog() == DialogResult.OK)
            {
                if (!w.CurveInfo.ContainsKey(inputFileName.ParameterValue))
                {
                    renameKey("tmp", inputFileName.ParameterValue);
                    _parentForm.refreshDataGrid();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(inputFileName.ParameterValue + " is an existing log name. Choose an other, please.", "Log name conflict", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void bttnDeleteFormula_Click(object sender, EventArgs e)
        {
            Formulas.Remove(cmbExistingFormulas.SelectedItem.ToString());
            cmbExistingFormulas.Items.RemoveAt(cmbExistingFormulas.SelectedIndex);
            File.Delete(Application.StartupPath + "\\Formulas.frml");
            using (FileStream fs = new FileStream(Application.StartupPath + "\\Formulas.frml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var line in Formulas)
                    {
                        sw.WriteLine(line.Key + ";" + line.Value);
                    }
                }
            }
            tbFormula.Text = "";
        }

        private void frmFormula_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (w.CurveInfo.ContainsKey("tmp"))
            {
                w.CurveInfo.Remove("tmp");
                w.Curves.RemoveAt(w.Curves.Count - 1);
                _parentForm.w = w;
            }
        }

        private void UpdateButtonState()
        {
            bttnAcceptFormula.Enabled = lstLogsforCompute.Items.Count > 0;
            bttnRun.Enabled=false;
        }


    }
}
