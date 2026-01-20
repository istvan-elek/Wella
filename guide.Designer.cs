namespace wella
{
    partial class guide
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowser_wella = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowser_wella
            // 
            this.webBrowser_wella.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_wella.Location = new System.Drawing.Point(0, 0);
            this.webBrowser_wella.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_wella.Name = "webBrowser_wella";
            this.webBrowser_wella.Size = new System.Drawing.Size(928, 688);
            this.webBrowser_wella.TabIndex = 0;
            // 
            // guide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 688);
            this.Controls.Add(this.webBrowser_wella);
            this.Name = "guide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "guide";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser_wella;
    }
}