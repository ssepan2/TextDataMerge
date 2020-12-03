namespace TextDataMergeForms
{
    partial class TextDataMergeViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextDataMergeViewer));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBarStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarErrorMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBarActionIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarDirtyMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFileNew = new System.Windows.Forms.ToolStripButton();
            this.tsbFileOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbFileSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.sortTab = new System.Windows.Forms.TabPage();
            this.sortEditor1 = new TextDataFunctionControls.SortEditor();
            this.mergeTab = new System.Windows.Forms.TabPage();
            this.mergeEditor1 = new TextDataFunctionControls.MergeEditor();
            this.filterTab = new System.Windows.Forms.TabPage();
            this.filterEditor1 = new TextDataFunctionControls.FilterEditor();
            this.collateTab = new System.Windows.Forms.TabPage();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.collateEditor1 = new TextDataFunctionControls.CollateEditor();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.sortTab.SuspendLayout();
            this.mergeTab.SuspendLayout();
            this.filterTab.SuspendLayout();
            this.collateTab.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarStatusMessage,
            this.StatusBarErrorMessage,
            this.StatusBarProgressBar,
            this.StatusBarActionIcon,
            this.StatusBarDirtyMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusBarStatusMessage
            // 
            this.StatusBarStatusMessage.ForeColor = System.Drawing.Color.Green;
            this.StatusBarStatusMessage.Name = "StatusBarStatusMessage";
            this.StatusBarStatusMessage.Size = new System.Drawing.Size(0, 17);
            this.StatusBarStatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBarErrorMessage
            // 
            this.StatusBarErrorMessage.AutoToolTip = true;
            this.StatusBarErrorMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StatusBarErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.StatusBarErrorMessage.Name = "StatusBarErrorMessage";
            this.StatusBarErrorMessage.Size = new System.Drawing.Size(1001, 17);
            this.StatusBarErrorMessage.Spring = true;
            this.StatusBarErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBarProgressBar
            // 
            this.StatusBarProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StatusBarProgressBar.Name = "StatusBarProgressBar";
            this.StatusBarProgressBar.Size = new System.Drawing.Size(100, 16);
            this.StatusBarProgressBar.Value = 10;
            this.StatusBarProgressBar.Visible = false;
            // 
            // StatusBarActionIcon
            // 
            this.StatusBarActionIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StatusBarActionIcon.Image = ((System.Drawing.Image)(resources.GetObject("StatusBarActionIcon.Image")));
            this.StatusBarActionIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StatusBarActionIcon.Name = "StatusBarActionIcon";
            this.StatusBarActionIcon.Size = new System.Drawing.Size(16, 17);
            this.StatusBarActionIcon.Visible = false;
            // 
            // StatusBarDirtyMessage
            // 
            this.StatusBarDirtyMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StatusBarDirtyMessage.Image = ((System.Drawing.Image)(resources.GetObject("StatusBarDirtyMessage.Image")));
            this.StatusBarDirtyMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StatusBarDirtyMessage.Name = "StatusBarDirtyMessage";
            this.StatusBarDirtyMessage.Size = new System.Drawing.Size(16, 17);
            this.StatusBarDirtyMessage.ToolTipText = "Dirty";
            this.StatusBarDirtyMessage.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.toolStripSeparator1,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 20);
            this.menuFile.Text = "&File";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Image = ((System.Drawing.Image)(resources.GetObject("menuFileNew.Image")));
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.Size = new System.Drawing.Size(140, 22);
            this.menuFileNew.Text = "&New";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("menuFileOpen.Image")));
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuFileOpen.Size = new System.Drawing.Size(140, 22);
            this.menuFileOpen.Text = "&Open";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("menuFileSave.Image")));
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFileSave.Size = new System.Drawing.Size(140, 22);
            this.menuFileSave.Text = "&Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(140, 22);
            this.menuFileSaveAs.Text = "Save &As...";
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(140, 22);
            this.menuFileExit.Text = "E&xit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditProperties});
            this.menuEdit.Enabled = false;
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(37, 20);
            this.menuEdit.Text = "&Edit";
            this.menuEdit.Visible = false;
            // 
            // menuEditProperties
            // 
            this.menuEditProperties.Enabled = false;
            this.menuEditProperties.Image = ((System.Drawing.Image)(resources.GetObject("menuEditProperties.Image")));
            this.menuEditProperties.ImageTransparentColor = System.Drawing.Color.Black;
            this.menuEditProperties.Name = "menuEditProperties";
            this.menuEditProperties.Size = new System.Drawing.Size(138, 22);
            this.menuEditProperties.Text = "Properties ...";
            this.menuEditProperties.Visible = false;
            this.menuEditProperties.Click += new System.EventHandler(this.menuEditProperties_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(40, 20);
            this.menuHelp.Text = "&Help";
            this.menuHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(225, 22);
            this.menuHelpAbout.Text = "&About TextDataMergeForms ...";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFileNew,
            this.tsbFileOpen,
            this.tsbFileSave,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(632, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbFileNew
            // 
            this.tsbFileNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFileNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbFileNew.Image")));
            this.tsbFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFileNew.Name = "tsbFileNew";
            this.tsbFileNew.Size = new System.Drawing.Size(23, 22);
            this.tsbFileNew.Text = "&New";
            this.tsbFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // tsbFileOpen
            // 
            this.tsbFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbFileOpen.Image")));
            this.tsbFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFileOpen.Name = "tsbFileOpen";
            this.tsbFileOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbFileOpen.Text = "&Open";
            this.tsbFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // tsbFileSave
            // 
            this.tsbFileSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFileSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbFileSave.Image")));
            this.tsbFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFileSave.Name = "tsbFileSave";
            this.tsbFileSave.Size = new System.Drawing.Size(23, 22);
            this.tsbFileSave.Text = "&Save";
            this.tsbFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Open Settings";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "Save Settings";
            // 
            // sortTab
            // 
            this.sortTab.Controls.Add(this.sortEditor1);
            this.sortTab.Location = new System.Drawing.Point(4, 22);
            this.sortTab.Name = "sortTab";
            this.sortTab.Padding = new System.Windows.Forms.Padding(3);
            this.sortTab.Size = new System.Drawing.Size(624, 350);
            this.sortTab.TabIndex = 6;
            this.sortTab.Text = "Sort";
            this.sortTab.UseVisualStyleBackColor = true;
            // 
            // sortEditor1
            // 
            this.sortEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sortEditor1.Location = new System.Drawing.Point(0, 0);
            this.sortEditor1.Name = "sortEditor1";
            this.sortEditor1.Size = new System.Drawing.Size(621, 347);
            this.sortEditor1.TabIndex = 0;
            this.sortEditor1.RunClick += new System.EventHandler(this.sortEditor1_RunClick);
            this.sortEditor1.InputAddClick += new System.EventHandler(this.sortEditor1_InputAddClick);
            this.sortEditor1.InputDeleteClick += new System.EventHandler(this.sortEditor1_InputDeleteClick);
            this.sortEditor1.OutputAddClick += new System.EventHandler(this.sortEditor1_OutputAddClick);
            this.sortEditor1.OutputDeleteClick += new System.EventHandler(this.sortEditor1_OutputDeleteClick);
            this.sortEditor1.InputKeyUp += new System.Windows.Forms.KeyEventHandler(this.sortEditor1_InputKeyUp);
            this.sortEditor1.OutputKeyUp += new System.Windows.Forms.KeyEventHandler(this.sortEditor1_OutputKeyUp);
            // 
            // mergeTab
            // 
            this.mergeTab.Controls.Add(this.mergeEditor1);
            this.mergeTab.Location = new System.Drawing.Point(4, 22);
            this.mergeTab.Name = "mergeTab";
            this.mergeTab.Size = new System.Drawing.Size(624, 350);
            this.mergeTab.TabIndex = 8;
            this.mergeTab.Text = "Merge";
            this.mergeTab.UseVisualStyleBackColor = true;
            // 
            // mergeEditor1
            // 
            this.mergeEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mergeEditor1.Location = new System.Drawing.Point(0, 0);
            this.mergeEditor1.Name = "mergeEditor1";
            this.mergeEditor1.Size = new System.Drawing.Size(621, 347);
            this.mergeEditor1.TabIndex = 0;
            this.mergeEditor1.RunClick += new System.EventHandler(this.mergeEditor1_RunClick);
            this.mergeEditor1.InputAddClick += new System.EventHandler(this.mergeEditor1_InputAddClick);
            this.mergeEditor1.InputDeleteClick += new System.EventHandler(this.mergeEditor1_InputDeleteClick);
            this.mergeEditor1.OutputAddClick += new System.EventHandler(this.mergeEditor1_OutputAddClick);
            this.mergeEditor1.OutputDeleteClick += new System.EventHandler(this.mergeEditor1_OutputDeleteClick);
            this.mergeEditor1.InputKeyUp += new System.Windows.Forms.KeyEventHandler(this.mergeEditor1_InputKeyUp);
            this.mergeEditor1.OutputKeyUp += new System.Windows.Forms.KeyEventHandler(this.mergeEditor1_OutputKeyUp);
            // 
            // filterTab
            // 
            this.filterTab.Controls.Add(this.filterEditor1);
            this.filterTab.Location = new System.Drawing.Point(4, 22);
            this.filterTab.Name = "filterTab";
            this.filterTab.Padding = new System.Windows.Forms.Padding(3);
            this.filterTab.Size = new System.Drawing.Size(624, 350);
            this.filterTab.TabIndex = 5;
            this.filterTab.Text = "Filter";
            this.filterTab.UseVisualStyleBackColor = true;
            // 
            // filterEditor1
            // 
            this.filterEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterEditor1.Location = new System.Drawing.Point(0, 0);
            this.filterEditor1.Name = "filterEditor1";
            this.filterEditor1.Size = new System.Drawing.Size(621, 347);
            this.filterEditor1.TabIndex = 0;
            this.filterEditor1.RunClick += new System.EventHandler(this.filterEditor1_RunClick);
            this.filterEditor1.InputAddClick += new System.EventHandler(this.filterEditor1_InputAddClick);
            this.filterEditor1.InputDeleteClick += new System.EventHandler(this.filterEditor1_InputDeleteClick);
            this.filterEditor1.OutputAddClick += new System.EventHandler(this.filterEditor1_OutputAddClick);
            this.filterEditor1.OutputDeleteClick += new System.EventHandler(this.filterEditor1_OutputDeleteClick);
            this.filterEditor1.InputKeyUp += new System.Windows.Forms.KeyEventHandler(this.filterEditor1_InputKeyUp);
            this.filterEditor1.OutputKeyUp += new System.Windows.Forms.KeyEventHandler(this.filterEditor1_OutputKeyUp);
            this.filterEditor1.OutputSelectedIndexChanged += new System.EventHandler(this.filterEditor1_OutputSelectedIndexChanged);
            // 
            // collateTab
            // 
            this.collateTab.Controls.Add(this.collateEditor1);
            this.collateTab.Location = new System.Drawing.Point(4, 22);
            this.collateTab.Name = "collateTab";
            this.collateTab.Size = new System.Drawing.Size(624, 350);
            this.collateTab.TabIndex = 7;
            this.collateTab.Text = "Collate";
            this.collateTab.UseVisualStyleBackColor = true;
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.collateTab);
            this.TabControl1.Controls.Add(this.filterTab);
            this.TabControl1.Controls.Add(this.mergeTab);
            this.TabControl1.Controls.Add(this.sortTab);
            this.TabControl1.Location = new System.Drawing.Point(0, 52);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(632, 376);
            this.TabControl1.TabIndex = 2;
            // 
            // collateEditor1
            // 
            this.collateEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.collateEditor1.Location = new System.Drawing.Point(0, 0);
            this.collateEditor1.Name = "collateEditor1";
            this.collateEditor1.Size = new System.Drawing.Size(621, 347);
            this.collateEditor1.TabIndex = 0;
            // 
            // TextDataMergeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextDataMergeViewer";
            this.Text = "TextDataMergeForms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TextDataMerge_FormClosing);
            this.Load += new System.EventHandler(this.TextDataMerge_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.sortTab.ResumeLayout(false);
            this.mergeTab.ResumeLayout(false);
            this.filterTab.ResumeLayout(false);
            this.collateTab.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarStatusMessage;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarErrorMessage;
        private System.Windows.Forms.ToolStripProgressBar StatusBarProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarActionIcon;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarDirtyMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbFileNew;
        private System.Windows.Forms.ToolStripButton tsbFileOpen;
        private System.Windows.Forms.ToolStripButton tsbFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem menuEditProperties;
        private System.Windows.Forms.TabPage sortTab;
        private TextDataFunctionControls.SortEditor sortEditor1;
        private System.Windows.Forms.TabPage mergeTab;
        private TextDataFunctionControls.MergeEditor mergeEditor1;
        private System.Windows.Forms.TabPage filterTab;
        private TextDataFunctionControls.FilterEditor filterEditor1;
        private System.Windows.Forms.TabPage collateTab;
        internal System.Windows.Forms.TabControl TabControl1;
        private TextDataFunctionControls.CollateEditor collateEditor1;
    }
}

