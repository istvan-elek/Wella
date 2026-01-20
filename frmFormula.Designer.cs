namespace wella
{
    partial class frmFormula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormula));
            this.lstBoxLogNames = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bttnAddSelectedLogs = new System.Windows.Forms.Button();
            this.bttnCloseForm = new System.Windows.Forms.Button();
            this.bttnDeleteFormula = new System.Windows.Forms.Button();
            this.bttnSaveResult = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbExistingFormulas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstLogsforCompute = new System.Windows.Forms.ListBox();
            this.bttnSaveFormula = new System.Windows.Forms.Button();
            this.lblLogListforComputing = new System.Windows.Forms.Label();
            this.chkShowResult = new System.Windows.Forms.CheckBox();
            this.bttnRun = new System.Windows.Forms.Button();
            this.bttnClearFormula = new System.Windows.Forms.Button();
            this.bttnAcceptFormula = new System.Windows.Forms.Button();
            this.tbFormula = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBoxLogNames
            // 
            this.lstBoxLogNames.FormattingEnabled = true;
            this.lstBoxLogNames.Location = new System.Drawing.Point(10, 37);
            this.lstBoxLogNames.Name = "lstBoxLogNames";
            this.lstBoxLogNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBoxLogNames.Size = new System.Drawing.Size(147, 199);
            this.lstBoxLogNames.TabIndex = 0;
            this.lstBoxLogNames.SelectedIndexChanged += new System.EventHandler(this.lstBoxLogNames_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Logs to select for computing";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bttnAddSelectedLogs);
            this.splitContainer1.Panel1.Controls.Add(this.bttnCloseForm);
            this.splitContainer1.Panel1.Controls.Add(this.lstBoxLogNames);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bttnDeleteFormula);
            this.splitContainer1.Panel2.Controls.Add(this.bttnSaveResult);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.cmbExistingFormulas);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.lstLogsforCompute);
            this.splitContainer1.Panel2.Controls.Add(this.bttnSaveFormula);
            this.splitContainer1.Panel2.Controls.Add(this.lblLogListforComputing);
            this.splitContainer1.Panel2.Controls.Add(this.chkShowResult);
            this.splitContainer1.Panel2.Controls.Add(this.bttnRun);
            this.splitContainer1.Panel2.Controls.Add(this.bttnClearFormula);
            this.splitContainer1.Panel2.Controls.Add(this.bttnAcceptFormula);
            this.splitContainer1.Panel2.Controls.Add(this.tbFormula);
            this.splitContainer1.Size = new System.Drawing.Size(646, 343);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 2;
            // 
            // bttnAddSelectedLogs
            // 
            this.bttnAddSelectedLogs.Enabled = false;
            this.bttnAddSelectedLogs.Location = new System.Drawing.Point(12, 242);
            this.bttnAddSelectedLogs.Name = "bttnAddSelectedLogs";
            this.bttnAddSelectedLogs.Size = new System.Drawing.Size(145, 40);
            this.bttnAddSelectedLogs.TabIndex = 4;
            this.bttnAddSelectedLogs.Text = "Add selected logs to the log list for computing";
            this.bttnAddSelectedLogs.UseVisualStyleBackColor = true;
            this.bttnAddSelectedLogs.Click += new System.EventHandler(this.bttnAddSelectedLogs_Click);
            // 
            // bttnCloseForm
            // 
            this.bttnCloseForm.Location = new System.Drawing.Point(20, 286);
            this.bttnCloseForm.Name = "bttnCloseForm";
            this.bttnCloseForm.Size = new System.Drawing.Size(137, 34);
            this.bttnCloseForm.TabIndex = 3;
            this.bttnCloseForm.Text = "Close window";
            this.bttnCloseForm.UseVisualStyleBackColor = true;
            this.bttnCloseForm.Click += new System.EventHandler(this.bttnCloseForm_Click);
            // 
            // bttnDeleteFormula
            // 
            this.bttnDeleteFormula.Location = new System.Drawing.Point(132, 291);
            this.bttnDeleteFormula.Name = "bttnDeleteFormula";
            this.bttnDeleteFormula.Size = new System.Drawing.Size(130, 26);
            this.bttnDeleteFormula.TabIndex = 17;
            this.bttnDeleteFormula.Text = "Delete selected formula";
            this.bttnDeleteFormula.UseVisualStyleBackColor = true;
            this.bttnDeleteFormula.Click += new System.EventHandler(this.bttnDeleteFormula_Click);
            // 
            // bttnSaveResult
            // 
            this.bttnSaveResult.Enabled = false;
            this.bttnSaveResult.Location = new System.Drawing.Point(369, 12);
            this.bttnSaveResult.Name = "bttnSaveResult";
            this.bttnSaveResult.Size = new System.Drawing.Size(86, 73);
            this.bttnSaveResult.TabIndex = 16;
            this.bttnSaveResult.Text = "Save result as a new log";
            this.bttnSaveResult.UseVisualStyleBackColor = true;
            this.bttnSaveResult.Click += new System.EventHandler(this.bttnSaveResult_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Existing formulas ->";
            // 
            // cmbExistingFormulas
            // 
            this.cmbExistingFormulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExistingFormulas.FormattingEnabled = true;
            this.cmbExistingFormulas.Location = new System.Drawing.Point(262, 155);
            this.cmbExistingFormulas.Name = "cmbExistingFormulas";
            this.cmbExistingFormulas.Size = new System.Drawing.Size(193, 21);
            this.cmbExistingFormulas.TabIndex = 14;
            this.cmbExistingFormulas.SelectedIndexChanged += new System.EventHandler(this.cmbExistingFormulas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Formula example:  1/a * b * 100";
            // 
            // lstLogsforCompute
            // 
            this.lstLogsforCompute.FormattingEnabled = true;
            this.lstLogsforCompute.Location = new System.Drawing.Point(16, 37);
            this.lstLogsforCompute.Name = "lstLogsforCompute";
            this.lstLogsforCompute.Size = new System.Drawing.Size(107, 134);
            this.lstLogsforCompute.TabIndex = 11;
            // 
            // bttnSaveFormula
            // 
            this.bttnSaveFormula.Enabled = false;
            this.bttnSaveFormula.Location = new System.Drawing.Point(318, 286);
            this.bttnSaveFormula.Name = "bttnSaveFormula";
            this.bttnSaveFormula.Size = new System.Drawing.Size(130, 31);
            this.bttnSaveFormula.TabIndex = 2;
            this.bttnSaveFormula.Text = "Save new formula";
            this.bttnSaveFormula.UseVisualStyleBackColor = true;
            this.bttnSaveFormula.Click += new System.EventHandler(this.bttnSaveProcedure_Click);
            // 
            // lblLogListforComputing
            // 
            this.lblLogListforComputing.AutoSize = true;
            this.lblLogListforComputing.Location = new System.Drawing.Point(13, 10);
            this.lblLogListforComputing.Name = "lblLogListforComputing";
            this.lblLogListforComputing.Size = new System.Drawing.Size(110, 13);
            this.lblLogListforComputing.TabIndex = 10;
            this.lblLogListforComputing.Text = "Log list for computing:";
            // 
            // chkShowResult
            // 
            this.chkShowResult.AutoSize = true;
            this.chkShowResult.Checked = true;
            this.chkShowResult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowResult.Location = new System.Drawing.Point(132, 57);
            this.chkShowResult.Name = "chkShowResult";
            this.chkShowResult.Size = new System.Drawing.Size(144, 17);
            this.chkShowResult.TabIndex = 3;
            this.chkShowResult.Text = "Show result in log display";
            this.chkShowResult.UseVisualStyleBackColor = true;
            // 
            // bttnRun
            // 
            this.bttnRun.Enabled = false;
            this.bttnRun.Location = new System.Drawing.Point(146, 12);
            this.bttnRun.Name = "bttnRun";
            this.bttnRun.Size = new System.Drawing.Size(130, 39);
            this.bttnRun.TabIndex = 4;
            this.bttnRun.Text = "RUN procedure on selected logs";
            this.bttnRun.UseVisualStyleBackColor = true;
            this.bttnRun.Click += new System.EventHandler(this.bttnRun_Click);
            // 
            // bttnClearFormula
            // 
            this.bttnClearFormula.Location = new System.Drawing.Point(16, 291);
            this.bttnClearFormula.Name = "bttnClearFormula";
            this.bttnClearFormula.Size = new System.Drawing.Size(80, 24);
            this.bttnClearFormula.TabIndex = 7;
            this.bttnClearFormula.Text = "Clear formula";
            this.bttnClearFormula.UseVisualStyleBackColor = true;
            this.bttnClearFormula.Click += new System.EventHandler(this.bttnClearFormula_Click);
            // 
            // bttnAcceptFormula
            // 
            this.bttnAcceptFormula.Enabled = false;
            this.bttnAcceptFormula.Location = new System.Drawing.Point(291, 12);
            this.bttnAcceptFormula.Name = "bttnAcceptFormula";
            this.bttnAcceptFormula.Size = new System.Drawing.Size(62, 39);
            this.bttnAcceptFormula.TabIndex = 6;
            this.bttnAcceptFormula.Text = "Accept formula";
            this.bttnAcceptFormula.UseVisualStyleBackColor = true;
            this.bttnAcceptFormula.Click += new System.EventHandler(this.bttnAcceptFormula_Click);
            // 
            // tbFormula
            // 
            this.tbFormula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFormula.Location = new System.Drawing.Point(14, 195);
            this.tbFormula.Multiline = true;
            this.tbFormula.Name = "tbFormula";
            this.tbFormula.Size = new System.Drawing.Size(441, 67);
            this.tbFormula.TabIndex = 5;
            // 
            // frmFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 343);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFormula";
            this.Text = "Formula editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFormula_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxLogNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bttnRun;
        private System.Windows.Forms.Button bttnCloseForm;
        private System.Windows.Forms.Button bttnSaveFormula;
        private System.Windows.Forms.CheckBox chkShowResult;
        private System.Windows.Forms.TextBox tbFormula;
        private System.Windows.Forms.Button bttnClearFormula;
        private System.Windows.Forms.Button bttnAcceptFormula;
        private System.Windows.Forms.Button bttnAddSelectedLogs;
        private System.Windows.Forms.Label lblLogListforComputing;
        private System.Windows.Forms.ListBox lstLogsforCompute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbExistingFormulas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bttnSaveResult;
        private System.Windows.Forms.Button bttnDeleteFormula;
    }
}