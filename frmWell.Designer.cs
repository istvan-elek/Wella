namespace wella
{
    partial class frmWell
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWell));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWlaFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveToWlaFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToWlaFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.importFromLASFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.FieldDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openExistingFieldDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewFieldDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDataAsGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormulaEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClustering = new System.Windows.Forms.ToolStripMenuItem();
            this.kmeansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iSODATAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elbowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutWellaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslabFieldName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslabFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslabRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWellName = new System.Windows.Forms.Label();
            this.tbWellInfo = new System.Windows.Forms.TextBox();
            this.dgvWellData = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bttnViewProperties = new System.Windows.Forms.Button();
            this.propGrid = new System.Windows.Forms.PropertyGrid();
            this.bn = new System.Windows.Forms.BindingNavigator(this.components);
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenWla = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSaveChanges = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnDisplayLogs = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCrossPlot = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMapWiindow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnFormulaEditor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnGuide = new System.Windows.Forms.ToolStripButton();
            this.tsExportToLASFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bn)).BeginInit();
            this.bn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.displayDataToolStripMenuItem,
            this.processingToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWlaFileToolStripMenuItem,
            this.mnuSaveToWlaFormat,
            this.saveAsToWlaFormatToolStripMenuItem,
            this.toolStripMenuItem1,
            this.importFromLASFileToolStripMenuItem,
            this.tsExportToLASFilesMenuItem,
            this.toolStripMenuItem2,
            this.FieldDBToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // openWlaFileToolStripMenuItem
            // 
            this.openWlaFileToolStripMenuItem.Name = "openWlaFileToolStripMenuItem";
            this.openWlaFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openWlaFileToolStripMenuItem.Text = "Open wla file";
            this.openWlaFileToolStripMenuItem.Click += new System.EventHandler(this.openWlaFileToolStripMenuItem_Click);
            // 
            // mnuSaveToWlaFormat
            // 
            this.mnuSaveToWlaFormat.Enabled = false;
            this.mnuSaveToWlaFormat.Name = "mnuSaveToWlaFormat";
            this.mnuSaveToWlaFormat.Size = new System.Drawing.Size(180, 22);
            this.mnuSaveToWlaFormat.Text = "Save changes";
            this.mnuSaveToWlaFormat.Click += new System.EventHandler(this.mnuSaveToWlaFormat_Click);
            // 
            // saveAsToWlaFormatToolStripMenuItem
            // 
            this.saveAsToWlaFormatToolStripMenuItem.Enabled = false;
            this.saveAsToWlaFormatToolStripMenuItem.Name = "saveAsToWlaFormatToolStripMenuItem";
            this.saveAsToWlaFormatToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToWlaFormatToolStripMenuItem.Text = "Save changes as ... ";
            this.saveAsToWlaFormatToolStripMenuItem.Click += new System.EventHandler(this.saveAsToWlaFormatToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // importFromLASFileToolStripMenuItem
            // 
            this.importFromLASFileToolStripMenuItem.Name = "importFromLASFileToolStripMenuItem";
            this.importFromLASFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importFromLASFileToolStripMenuItem.Text = "Import LAS files";
            this.importFromLASFileToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // FieldDBToolStripMenuItem
            // 
            this.FieldDBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openExistingFieldDBToolStripMenuItem,
            this.createNewFieldDBToolStripMenuItem});
            this.FieldDBToolStripMenuItem.Name = "FieldDBToolStripMenuItem";
            this.FieldDBToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FieldDBToolStripMenuItem.Text = "Field DB";
            // 
            // openExistingFieldDBToolStripMenuItem
            // 
            this.openExistingFieldDBToolStripMenuItem.Name = "openExistingFieldDBToolStripMenuItem";
            this.openExistingFieldDBToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openExistingFieldDBToolStripMenuItem.Text = "Open existing field DB";
            // 
            // createNewFieldDBToolStripMenuItem
            // 
            this.createNewFieldDBToolStripMenuItem.Name = "createNewFieldDBToolStripMenuItem";
            this.createNewFieldDBToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.createNewFieldDBToolStripMenuItem.Text = "Create new field DB";
            this.createNewFieldDBToolStripMenuItem.Click += new System.EventHandler(this.createNewFieldDBToolStripMenuItem_Click);
            // 
            // displayDataToolStripMenuItem
            // 
            this.displayDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDataAsGraphToolStripMenuItem,
            this.crossPlotToolStripMenuItem,
            this.mapWindowToolStripMenuItem});
            this.displayDataToolStripMenuItem.Enabled = false;
            this.displayDataToolStripMenuItem.Name = "displayDataToolStripMenuItem";
            this.displayDataToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.displayDataToolStripMenuItem.Text = "Display data";
            // 
            // showDataAsGraphToolStripMenuItem
            // 
            this.showDataAsGraphToolStripMenuItem.Name = "showDataAsGraphToolStripMenuItem";
            this.showDataAsGraphToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.showDataAsGraphToolStripMenuItem.Text = "Show data as graphics";
            this.showDataAsGraphToolStripMenuItem.Click += new System.EventHandler(this.showDataAsGraphToolStripMenuItem_Click);
            // 
            // crossPlotToolStripMenuItem
            // 
            this.crossPlotToolStripMenuItem.Name = "crossPlotToolStripMenuItem";
            this.crossPlotToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.crossPlotToolStripMenuItem.Text = "Cross plot";
            this.crossPlotToolStripMenuItem.Click += new System.EventHandler(this.crossPlotToolStripMenuItem_Click);
            // 
            // mapWindowToolStripMenuItem
            // 
            this.mapWindowToolStripMenuItem.Name = "mapWindowToolStripMenuItem";
            this.mapWindowToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.mapWindowToolStripMenuItem.Text = "Map window";
            this.mapWindowToolStripMenuItem.Click += new System.EventHandler(this.mapWindowToolStripMenuItem_Click);
            // 
            // processingToolStripMenuItem
            // 
            this.processingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormulaEditor,
            this.mnuClustering,
            this.batchToolStripMenuItem});
            this.processingToolStripMenuItem.Enabled = false;
            this.processingToolStripMenuItem.Name = "processingToolStripMenuItem";
            this.processingToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.processingToolStripMenuItem.Text = "Processing";
            // 
            // mnuFormulaEditor
            // 
            this.mnuFormulaEditor.Name = "mnuFormulaEditor";
            this.mnuFormulaEditor.Size = new System.Drawing.Size(164, 22);
            this.mnuFormulaEditor.Text = "Formula editor";
            this.mnuFormulaEditor.Click += new System.EventHandler(this.mnuFormulaEditor_Click);
            // 
            // mnuClustering
            // 
            this.mnuClustering.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kmeansToolStripMenuItem,
            this.iSODATAToolStripMenuItem,
            this.elbowToolStripMenuItem});
            this.mnuClustering.Name = "mnuClustering";
            this.mnuClustering.Size = new System.Drawing.Size(164, 22);
            this.mnuClustering.Text = "Clustering";
            // 
            // kmeansToolStripMenuItem
            // 
            this.kmeansToolStripMenuItem.Name = "kmeansToolStripMenuItem";
            this.kmeansToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.kmeansToolStripMenuItem.Text = "K-means";
            this.kmeansToolStripMenuItem.Click += new System.EventHandler(this.kmeansToolStripMenuItem_Click);
            // 
            // iSODATAToolStripMenuItem
            // 
            this.iSODATAToolStripMenuItem.Name = "iSODATAToolStripMenuItem";
            this.iSODATAToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.iSODATAToolStripMenuItem.Text = "ISODATA";
            // 
            // elbowToolStripMenuItem
            // 
            this.elbowToolStripMenuItem.Name = "elbowToolStripMenuItem";
            this.elbowToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.elbowToolStripMenuItem.Text = "Elbow";
            // 
            // batchToolStripMenuItem
            // 
            this.batchToolStripMenuItem.Enabled = false;
            this.batchToolStripMenuItem.Name = "batchToolStripMenuItem";
            this.batchToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.batchToolStripMenuItem.Text = "Batch processing";
            this.batchToolStripMenuItem.ToolTipText = "Batch processing on many logs";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guideToolStripMenuItem,
            this.aboutWellaToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // guideToolStripMenuItem
            // 
            this.guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            this.guideToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.guideToolStripMenuItem.Text = "Guide";
            this.guideToolStripMenuItem.Click += new System.EventHandler(this.guideToolStripMenuItem_Click);
            // 
            // aboutWellaToolStripMenuItem
            // 
            this.aboutWellaToolStripMenuItem.Name = "aboutWellaToolStripMenuItem";
            this.aboutWellaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.aboutWellaToolStripMenuItem.Text = "About wella";
            this.aboutWellaToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslabFieldName,
            this.tslabFileName,
            this.tslabRows});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslabFieldName
            // 
            this.tslabFieldName.Name = "tslabFieldName";
            this.tslabFieldName.Size = new System.Drawing.Size(89, 17);
            this.tslabFieldName.Text = "tslabFieldName";
            // 
            // tslabFileName
            // 
            this.tslabFileName.Name = "tslabFileName";
            this.tslabFileName.Size = new System.Drawing.Size(82, 17);
            this.tslabFileName.Text = "tslabFileName";
            // 
            // tslabRows
            // 
            this.tslabRows.Name = "tslabRows";
            this.tslabRows.Size = new System.Drawing.Size(60, 17);
            this.tslabRows.Text = "tslabRows";
            // 
            // lblWellName
            // 
            this.lblWellName.AutoSize = true;
            this.lblWellName.Location = new System.Drawing.Point(10, 11);
            this.lblWellName.Name = "lblWellName";
            this.lblWellName.Size = new System.Drawing.Size(57, 13);
            this.lblWellName.TabIndex = 2;
            this.lblWellName.Text = "Well name";
            // 
            // tbWellInfo
            // 
            this.tbWellInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWellInfo.Location = new System.Drawing.Point(3, 36);
            this.tbWellInfo.Multiline = true;
            this.tbWellInfo.Name = "tbWellInfo";
            this.tbWellInfo.ReadOnly = true;
            this.tbWellInfo.Size = new System.Drawing.Size(197, 365);
            this.tbWellInfo.TabIndex = 3;
            // 
            // dgvWellData
            // 
            this.dgvWellData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWellData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWellData.Location = new System.Drawing.Point(0, 25);
            this.dgvWellData.Name = "dgvWellData";
            this.dgvWellData.ReadOnly = true;
            this.dgvWellData.Size = new System.Drawing.Size(536, 379);
            this.dgvWellData.TabIndex = 4;
            this.dgvWellData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvWellData_ColumnHeaderMouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(57, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bttnViewProperties);
            this.splitContainer1.Panel1.Controls.Add(this.lblWellName);
            this.splitContainer1.Panel1.Controls.Add(this.propGrid);
            this.splitContainer1.Panel1.Controls.Add(this.tbWellInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvWellData);
            this.splitContainer1.Panel2.Controls.Add(this.bn);
            this.splitContainer1.Size = new System.Drawing.Size(743, 404);
            this.splitContainer1.SplitterDistance = 203;
            this.splitContainer1.TabIndex = 5;
            this.splitContainer1.Visible = false;
            // 
            // bttnViewProperties
            // 
            this.bttnViewProperties.Location = new System.Drawing.Point(136, 6);
            this.bttnViewProperties.Name = "bttnViewProperties";
            this.bttnViewProperties.Size = new System.Drawing.Size(62, 23);
            this.bttnViewProperties.TabIndex = 6;
            this.bttnViewProperties.Text = "Properties";
            this.bttnViewProperties.UseVisualStyleBackColor = true;
            this.bttnViewProperties.Click += new System.EventHandler(this.bttnViewProperties_Click);
            // 
            // propGrid
            // 
            this.propGrid.Location = new System.Drawing.Point(3, 36);
            this.propGrid.Name = "propGrid";
            this.propGrid.Size = new System.Drawing.Size(194, 365);
            this.propGrid.TabIndex = 5;
            this.propGrid.Visible = false;
            this.propGrid.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.PpropertyGrid1_SelectedGridItemChanged);
            // 
            // bn
            // 
            this.bn.AddNewItem = null;
            this.bn.BindingSource = this.bs;
            this.bn.CountItem = this.bindingNavigatorCountItem;
            this.bn.DeleteItem = null;
            this.bn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bn.Location = new System.Drawing.Point(0, 0);
            this.bn.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn.Name = "bn";
            this.bn.PositionItem = this.bindingNavigatorPositionItem;
            this.bn.Size = new System.Drawing.Size(536, 25);
            this.bn.TabIndex = 5;
            this.bn.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "wella.png");
            this.imgList.Images.SetKeyName(1, "well16.ico");
            this.imgList.Images.SetKeyName(2, "arrow_rot.png");
            this.imgList.Images.SetKeyName(3, "layers.png");
            this.imgList.Images.SetKeyName(4, "save16.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenWla,
            this.tsbtnSaveChanges,
            this.toolStripSeparator1,
            this.tsbtnDisplayLogs,
            this.tsbtnCrossPlot,
            this.tsbtnMapWiindow,
            this.toolStripSeparator2,
            this.tsbtnFormulaEditor,
            this.toolStripSeparator3,
            this.tsbtnGuide});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(57, 404);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpenWla
            // 
            this.tsbtnOpenWla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpenWla.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenWla.Image")));
            this.tsbtnOpenWla.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnOpenWla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenWla.Name = "tsbtnOpenWla";
            this.tsbtnOpenWla.Size = new System.Drawing.Size(55, 44);
            this.tsbtnOpenWla.Text = "Open wla file";
            this.tsbtnOpenWla.Click += new System.EventHandler(this.openWlaFileToolStripMenuItem_Click);
            // 
            // tsbtnSaveChanges
            // 
            this.tsbtnSaveChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSaveChanges.Enabled = false;
            this.tsbtnSaveChanges.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaveChanges.Image")));
            this.tsbtnSaveChanges.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveChanges.Name = "tsbtnSaveChanges";
            this.tsbtnSaveChanges.Size = new System.Drawing.Size(55, 44);
            this.tsbtnSaveChanges.Text = "Save changes";
            this.tsbtnSaveChanges.Click += new System.EventHandler(this.mnuSaveToWlaFormat_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(55, 6);
            // 
            // tsbtnDisplayLogs
            // 
            this.tsbtnDisplayLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDisplayLogs.Enabled = false;
            this.tsbtnDisplayLogs.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDisplayLogs.Image")));
            this.tsbtnDisplayLogs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnDisplayLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDisplayLogs.Name = "tsbtnDisplayLogs";
            this.tsbtnDisplayLogs.Size = new System.Drawing.Size(55, 46);
            this.tsbtnDisplayLogs.Text = "Display logs";
            this.tsbtnDisplayLogs.Click += new System.EventHandler(this.showDataAsGraphToolStripMenuItem_Click);
            // 
            // tsbtnCrossPlot
            // 
            this.tsbtnCrossPlot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCrossPlot.Enabled = false;
            this.tsbtnCrossPlot.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCrossPlot.Image")));
            this.tsbtnCrossPlot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnCrossPlot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCrossPlot.Name = "tsbtnCrossPlot";
            this.tsbtnCrossPlot.Size = new System.Drawing.Size(55, 44);
            this.tsbtnCrossPlot.Text = "Cross plot";
            this.tsbtnCrossPlot.Click += new System.EventHandler(this.crossPlotToolStripMenuItem_Click);
            // 
            // tsbtnMapWiindow
            // 
            this.tsbtnMapWiindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMapWiindow.Enabled = false;
            this.tsbtnMapWiindow.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMapWiindow.Image")));
            this.tsbtnMapWiindow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnMapWiindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMapWiindow.Name = "tsbtnMapWiindow";
            this.tsbtnMapWiindow.Size = new System.Drawing.Size(55, 36);
            this.tsbtnMapWiindow.Text = "Map window";
            this.tsbtnMapWiindow.Click += new System.EventHandler(this.mapWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(55, 6);
            // 
            // tsbtnFormulaEditor
            // 
            this.tsbtnFormulaEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFormulaEditor.Enabled = false;
            this.tsbtnFormulaEditor.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFormulaEditor.Image")));
            this.tsbtnFormulaEditor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnFormulaEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFormulaEditor.Name = "tsbtnFormulaEditor";
            this.tsbtnFormulaEditor.Size = new System.Drawing.Size(55, 34);
            this.tsbtnFormulaEditor.Text = "Formula editor";
            this.tsbtnFormulaEditor.Click += new System.EventHandler(this.mnuFormulaEditor_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(55, 6);
            // 
            // tsbtnGuide
            // 
            this.tsbtnGuide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGuide.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuide.Image")));
            this.tsbtnGuide.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnGuide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuide.Name = "tsbtnGuide";
            this.tsbtnGuide.Size = new System.Drawing.Size(55, 44);
            this.tsbtnGuide.Text = "Users\' guide";
            this.tsbtnGuide.Click += new System.EventHandler(this.guideToolStripMenuItem_Click);
            // 
            // tsExportToLASFilesMenuItem
            // 
            this.tsExportToLASFilesMenuItem.Enabled = false;
            this.tsExportToLASFilesMenuItem.Name = "tsExportToLASFilesMenuItem";
            this.tsExportToLASFilesMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tsExportToLASFilesMenuItem.Text = "Export to LAS files";
            this.tsExportToLASFilesMenuItem.Click += new System.EventHandler(this.tsExportToLASFilesMenuItem_Click);
            // 
            // frmWell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmWell";
            this.Text = "Wella";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellData)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bn)).EndInit();
            this.bn.ResumeLayout(false);
            this.bn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromLASFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDataAsGraphToolStripMenuItem;
        private System.Windows.Forms.Label lblWellName;
        private System.Windows.Forms.TextBox tbWellInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem crossPlotToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propGrid;
        private System.Windows.Forms.Button bttnViewProperties;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveToWlaFormat;
        private System.Windows.Forms.ToolStripMenuItem openWlaFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mapWindowToolStripMenuItem;
        public System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStripMenuItem guideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutWellaToolStripMenuItem;
        private System.Windows.Forms.BindingNavigator bn;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        public System.Windows.Forms.DataGridView dgvWellData;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem FieldDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFormulaEditor;
        private System.Windows.Forms.ToolStripMenuItem batchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToWlaFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tslabFieldName;
        private System.Windows.Forms.ToolStripStatusLabel tslabFileName;
        private System.Windows.Forms.ToolStripStatusLabel tslabRows;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ToolStripMenuItem mnuClustering;
        private System.Windows.Forms.ToolStripMenuItem kmeansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iSODATAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elbowToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenWla;
        private System.Windows.Forms.ToolStripButton tsbtnSaveChanges;
        private System.Windows.Forms.ToolStripButton tsbtnDisplayLogs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnCrossPlot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnMapWiindow;
        private System.Windows.Forms.ToolStripButton tsbtnFormulaEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnGuide;
        private System.Windows.Forms.ToolStripMenuItem openExistingFieldDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewFieldDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsExportToLASFilesMenuItem;
    }
}