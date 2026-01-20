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
    public partial class InputBox : Form
    {
        public string ParameterValue="";

         public InputBox(string FieldName, string FieldValue)
        {
            InitializeComponent();
            lblInputName.Text = FieldName;
            this.Text = FieldValue; 
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            ParameterValue=tbInputName.Text.Trim();
            this.Close();
        }
    }
}
