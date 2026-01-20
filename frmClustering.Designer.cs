namespace wella
{
    partial class frmClustering
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
            this.availableLogs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bttnRun = new System.Windows.Forms.Button();
            this.chkDisplayResult = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNumofClusters = new System.Windows.Forms.TextBox();
            this.tbIterationMax = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // availableLogs
            // 
            this.availableLogs.FormattingEnabled = true;
            this.availableLogs.Location = new System.Drawing.Point(12, 25);
            this.availableLogs.Name = "availableLogs";
            this.availableLogs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.availableLogs.Size = new System.Drawing.Size(159, 290);
            this.availableLogs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available logs";
            // 
            // bttnRun
            // 
            this.bttnRun.Location = new System.Drawing.Point(25, 321);
            this.bttnRun.Name = "bttnRun";
            this.bttnRun.Size = new System.Drawing.Size(126, 53);
            this.bttnRun.TabIndex = 5;
            this.bttnRun.Text = "Run clustering on selected logs";
            this.bttnRun.UseVisualStyleBackColor = true;
            this.bttnRun.Click += new System.EventHandler(this.bttnRun_Click);
            // 
            // chkDisplayResult
            // 
            this.chkDisplayResult.AutoSize = true;
            this.chkDisplayResult.Checked = true;
            this.chkDisplayResult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplayResult.Location = new System.Drawing.Point(37, 380);
            this.chkDisplayResult.Name = "chkDisplayResult";
            this.chkDisplayResult.Size = new System.Drawing.Size(88, 17);
            this.chkDisplayResult.TabIndex = 6;
            this.chkDisplayResult.Text = "Display result";
            this.chkDisplayResult.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number of clusters:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Iteration maximum:";
            // 
            // tbNumofClusters
            // 
            this.tbNumofClusters.Location = new System.Drawing.Point(191, 90);
            this.tbNumofClusters.Name = "tbNumofClusters";
            this.tbNumofClusters.Size = new System.Drawing.Size(91, 20);
            this.tbNumofClusters.TabIndex = 9;
            this.tbNumofClusters.Text = "5";
            // 
            // tbIterationMax
            // 
            this.tbIterationMax.Location = new System.Drawing.Point(191, 186);
            this.tbIterationMax.Name = "tbIterationMax";
            this.tbIterationMax.Size = new System.Drawing.Size(91, 20);
            this.tbIterationMax.TabIndex = 10;
            this.tbIterationMax.Text = "100";
            // 
            // frmClustering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 408);
            this.Controls.Add(this.tbIterationMax);
            this.Controls.Add(this.tbNumofClusters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkDisplayResult);
            this.Controls.Add(this.bttnRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.availableLogs);
            this.Name = "frmClustering";
            this.Text = "Clustering";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClustering_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox availableLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttnRun;
        private System.Windows.Forms.CheckBox chkDisplayResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNumofClusters;
        private System.Windows.Forms.TextBox tbIterationMax;
    }
}