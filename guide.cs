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
    public partial class guide : Form
    {
        public guide()
        {
            InitializeComponent();
            var uri = new Uri(Application.StartupPath + @"\wella_users_guide.pdf");
            this.webBrowser_wella.Navigate(uri);

        }
    }
}
