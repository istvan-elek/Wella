using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Web.WebView2.WinForms;
using System.IO;

namespace wella
{
    public partial class guide : Form
    {
        public guide()
        {
            InitializeComponent();
            var path = Path.Combine(Application.StartupPath, "wella_users_guide.pdf");
            webView21.Source = new Uri(path);
        }

        //private async void Guide_Load(object? sender, EventArgs e)
        //{
        //    var path = Path.Combine(Application.StartupPath, "wella_users_guide.pdf");
        //    await webView21.EnsureCoreWebView2Async();
        //    webView21.Source = new Uri(path);
        //}
        //public guide()
        //{
        //    InitializeComponent();
        //    //string a = System.IO.File.Exists(Application.StartupPath + @"\wella_users_guide.pdf").ToString();
        //    var uri = new Uri(Application.StartupPath + @"\wella_users_guide.pdf");
        //    this.webBrowser_wella.Navigate(uri);

        //}
    }
}
