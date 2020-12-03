namespace TextDataFunctionControls
{
    partial class TextFunctionEditorBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextFunctionEditorBase));
            this.controlPanel = new System.Windows.Forms.Panel();
            this.ddlComparisons = new System.Windows.Forms.ComboBox();
            this.chkAllowDuplicates = new System.Windows.Forms.CheckBox();
            this.chkDescending = new System.Windows.Forms.CheckBox();
            this.lblComparisons = new System.Windows.Forms.Label();
            this.cmdRun = new System.Windows.Forms.Button();
            this.lblOutputFiles = new System.Windows.Forms.Label();
            this.lblInputFiles = new System.Windows.Forms.Label();
            this.lstOutputFiles = new System.Windows.Forms.ListBox();
            this.lstInputFiles = new System.Windows.Forms.ListBox();
            this.cmdOutputFilesDelete = new System.Windows.Forms.Button();
            this.cmdOutputFilesAdd = new System.Windows.Forms.Button();
            this.cmdInputFilesDelete = new System.Windows.Forms.Button();
            this.cmdInputFilesAdd = new System.Windows.Forms.Button();
            this.txtNumberOfColumns = new System.Windows.Forms.TextBox();
            this.txtStartingColumn = new System.Windows.Forms.TextBox();
            this.lblNumberOfColumns = new System.Windows.Forms.Label();
            this.lblStartingColumn = new System.Windows.Forms.Label();
            this.chkNot = new System.Windows.Forms.CheckBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblLines = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.Controls.Add(this.ddlComparisons);
            this.controlPanel.Controls.Add(this.chkAllowDuplicates);
            this.controlPanel.Controls.Add(this.chkDescending);
            this.controlPanel.Controls.Add(this.lblComparisons);
            this.controlPanel.Controls.Add(this.cmdRun);
            this.controlPanel.Controls.Add(this.lblOutputFiles);
            this.controlPanel.Controls.Add(this.lblInputFiles);
            this.controlPanel.Controls.Add(this.lstOutputFiles);
            this.controlPanel.Controls.Add(this.lstInputFiles);
            this.controlPanel.Controls.Add(this.cmdOutputFilesDelete);
            this.controlPanel.Controls.Add(this.cmdOutputFilesAdd);
            this.controlPanel.Controls.Add(this.cmdInputFilesDelete);
            this.controlPanel.Controls.Add(this.cmdInputFilesAdd);
            this.controlPanel.Controls.Add(this.txtNumberOfColumns);
            this.controlPanel.Controls.Add(this.txtStartingColumn);
            this.controlPanel.Controls.Add(this.lblNumberOfColumns);
            this.controlPanel.Controls.Add(this.lblStartingColumn);
            this.controlPanel.Controls.Add(this.chkNot);
            this.controlPanel.Controls.Add(this.txtValue);
            this.controlPanel.Controls.Add(this.lblLines);
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(500, 253);
            this.controlPanel.TabIndex = 0;
            // 
            // ddlComparisons
            // 
            this.ddlComparisons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlComparisons.BackColor = System.Drawing.SystemColors.Window;
            this.ddlComparisons.Cursor = System.Windows.Forms.Cursors.Default;
            this.ddlComparisons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlComparisons.Enabled = false;
            this.ddlComparisons.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlComparisons.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ddlComparisons.Location = new System.Drawing.Point(124, 170);
            this.ddlComparisons.Name = "ddlComparisons";
            this.ddlComparisons.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ddlComparisons.Size = new System.Drawing.Size(72, 22);
            this.ddlComparisons.TabIndex = 76;
            this.toolTip1.SetToolTip(this.ddlComparisons, "Comparison to use. Note: IsMatch is a RegEx match; use with caution.");
            this.ddlComparisons.Visible = false;
            // 
            // chkAllowDuplicates
            // 
            this.chkAllowDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAllowDuplicates.BackColor = System.Drawing.SystemColors.Control;
            this.chkAllowDuplicates.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkAllowDuplicates.Enabled = false;
            this.chkAllowDuplicates.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllowDuplicates.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAllowDuplicates.Location = new System.Drawing.Point(178, 228);
            this.chkAllowDuplicates.Name = "chkAllowDuplicates";
            this.chkAllowDuplicates.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkAllowDuplicates.Size = new System.Drawing.Size(126, 20);
            this.chkAllowDuplicates.TabIndex = 74;
            this.chkAllowDuplicates.Text = "&Allow Duplicates?";
            this.chkAllowDuplicates.UseVisualStyleBackColor = false;
            this.chkAllowDuplicates.Visible = false;
            // 
            // chkDescending
            // 
            this.chkDescending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDescending.BackColor = System.Drawing.SystemColors.Control;
            this.chkDescending.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkDescending.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescending.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkDescending.Location = new System.Drawing.Point(178, 208);
            this.chkDescending.Name = "chkDescending";
            this.chkDescending.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkDescending.Size = new System.Drawing.Size(126, 20);
            this.chkDescending.TabIndex = 73;
            this.chkDescending.Text = "&Descending Order?";
            this.toolTip1.SetToolTip(this.chkDescending, "Use reverse sort order.");
            this.chkDescending.UseVisualStyleBackColor = false;
            // 
            // lblComparisons
            // 
            this.lblComparisons.AutoSize = true;
            this.lblComparisons.Enabled = false;
            this.lblComparisons.Location = new System.Drawing.Point(129, 81);
            this.lblComparisons.Name = "lblComparisons";
            this.lblComparisons.Size = new System.Drawing.Size(13, 13);
            this.lblComparisons.TabIndex = 67;
            this.lblComparisons.Text = "_";
            this.lblComparisons.Visible = false;
            // 
            // cmdRun
            // 
            this.cmdRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRun.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRun.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdRun.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRun.Location = new System.Drawing.Point(436, 180);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdRun.Size = new System.Drawing.Size(58, 64);
            this.cmdRun.TabIndex = 75;
            this.cmdRun.Text = "Run";
            this.cmdRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.cmdRun, "Run");
            this.cmdRun.UseVisualStyleBackColor = false;
            // 
            // lblOutputFiles
            // 
            this.lblOutputFiles.AutoSize = true;
            this.lblOutputFiles.Location = new System.Drawing.Point(7, 39);
            this.lblOutputFiles.Name = "lblOutputFiles";
            this.lblOutputFiles.Size = new System.Drawing.Size(42, 13);
            this.lblOutputFiles.TabIndex = 61;
            this.lblOutputFiles.Text = "&Output:";
            // 
            // lblInputFiles
            // 
            this.lblInputFiles.AutoSize = true;
            this.lblInputFiles.Location = new System.Drawing.Point(9, 4);
            this.lblInputFiles.Name = "lblInputFiles";
            this.lblInputFiles.Size = new System.Drawing.Size(34, 13);
            this.lblInputFiles.TabIndex = 57;
            this.lblInputFiles.Text = "&Input:";
            // 
            // lstOutputFiles
            // 
            this.lstOutputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOutputFiles.FormattingEnabled = true;
            this.lstOutputFiles.Location = new System.Drawing.Point(9, 55);
            this.lstOutputFiles.Name = "lstOutputFiles";
            this.lstOutputFiles.Size = new System.Drawing.Size(421, 17);
            this.lstOutputFiles.TabIndex = 62;
            // 
            // lstInputFiles
            // 
            this.lstInputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInputFiles.FormattingEnabled = true;
            this.lstInputFiles.Location = new System.Drawing.Point(9, 17);
            this.lstInputFiles.Name = "lstInputFiles";
            this.lstInputFiles.Size = new System.Drawing.Size(421, 17);
            this.lstInputFiles.TabIndex = 58;
            // 
            // cmdOutputFilesDelete
            // 
            this.cmdOutputFilesDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOutputFilesDelete.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOutputFilesDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdOutputFilesDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOutputFilesDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdOutputFilesDelete.Image")));
            this.cmdOutputFilesDelete.Location = new System.Drawing.Point(467, 55);
            this.cmdOutputFilesDelete.Name = "cmdOutputFilesDelete";
            this.cmdOutputFilesDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdOutputFilesDelete.Size = new System.Drawing.Size(26, 22);
            this.cmdOutputFilesDelete.TabIndex = 64;
            this.cmdOutputFilesDelete.Text = "X";
            this.toolTip1.SetToolTip(this.cmdOutputFilesDelete, "Delete");
            this.cmdOutputFilesDelete.UseVisualStyleBackColor = false;
            // 
            // cmdOutputFilesAdd
            // 
            this.cmdOutputFilesAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOutputFilesAdd.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOutputFilesAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdOutputFilesAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOutputFilesAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdOutputFilesAdd.Image")));
            this.cmdOutputFilesAdd.Location = new System.Drawing.Point(436, 55);
            this.cmdOutputFilesAdd.Name = "cmdOutputFilesAdd";
            this.cmdOutputFilesAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdOutputFilesAdd.Size = new System.Drawing.Size(26, 22);
            this.cmdOutputFilesAdd.TabIndex = 63;
            this.cmdOutputFilesAdd.Text = "...";
            this.toolTip1.SetToolTip(this.cmdOutputFilesAdd, "Select");
            this.cmdOutputFilesAdd.UseVisualStyleBackColor = false;
            // 
            // cmdInputFilesDelete
            // 
            this.cmdInputFilesDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdInputFilesDelete.BackColor = System.Drawing.SystemColors.Control;
            this.cmdInputFilesDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdInputFilesDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInputFilesDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdInputFilesDelete.Image")));
            this.cmdInputFilesDelete.Location = new System.Drawing.Point(467, 17);
            this.cmdInputFilesDelete.Name = "cmdInputFilesDelete";
            this.cmdInputFilesDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdInputFilesDelete.Size = new System.Drawing.Size(25, 22);
            this.cmdInputFilesDelete.TabIndex = 60;
            this.cmdInputFilesDelete.Text = "X";
            this.toolTip1.SetToolTip(this.cmdInputFilesDelete, "Delete");
            this.cmdInputFilesDelete.UseVisualStyleBackColor = false;
            // 
            // cmdInputFilesAdd
            // 
            this.cmdInputFilesAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdInputFilesAdd.BackColor = System.Drawing.SystemColors.Control;
            this.cmdInputFilesAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdInputFilesAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInputFilesAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdInputFilesAdd.Image")));
            this.cmdInputFilesAdd.Location = new System.Drawing.Point(436, 17);
            this.cmdInputFilesAdd.Name = "cmdInputFilesAdd";
            this.cmdInputFilesAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdInputFilesAdd.Size = new System.Drawing.Size(25, 22);
            this.cmdInputFilesAdd.TabIndex = 59;
            this.cmdInputFilesAdd.Text = "...";
            this.toolTip1.SetToolTip(this.cmdInputFilesAdd, "Select");
            this.cmdInputFilesAdd.UseVisualStyleBackColor = false;
            // 
            // txtNumberOfColumns
            // 
            this.txtNumberOfColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumberOfColumns.Location = new System.Drawing.Point(109, 227);
            this.txtNumberOfColumns.Name = "txtNumberOfColumns";
            this.txtNumberOfColumns.Size = new System.Drawing.Size(47, 20);
            this.txtNumberOfColumns.TabIndex = 72;
            this.toolTip1.SetToolTip(this.txtNumberOfColumns, "One-based length, in columns.");
            // 
            // txtStartingColumn
            // 
            this.txtStartingColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartingColumn.Location = new System.Drawing.Point(109, 207);
            this.txtStartingColumn.Name = "txtStartingColumn";
            this.txtStartingColumn.Size = new System.Drawing.Size(47, 20);
            this.txtStartingColumn.TabIndex = 70;
            this.toolTip1.SetToolTip(this.txtStartingColumn, "Zero-based start index.");
            // 
            // lblNumberOfColumns
            // 
            this.lblNumberOfColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumberOfColumns.BackColor = System.Drawing.SystemColors.Control;
            this.lblNumberOfColumns.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNumberOfColumns.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfColumns.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNumberOfColumns.Location = new System.Drawing.Point(6, 230);
            this.lblNumberOfColumns.Name = "lblNumberOfColumns";
            this.lblNumberOfColumns.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNumberOfColumns.Size = new System.Drawing.Size(108, 14);
            this.lblNumberOfColumns.TabIndex = 71;
            this.lblNumberOfColumns.Text = "Key Column &Length:";
            // 
            // lblStartingColumn
            // 
            this.lblStartingColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStartingColumn.BackColor = System.Drawing.SystemColors.Control;
            this.lblStartingColumn.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblStartingColumn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartingColumn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStartingColumn.Location = new System.Drawing.Point(6, 210);
            this.lblStartingColumn.Name = "lblStartingColumn";
            this.lblStartingColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStartingColumn.Size = new System.Drawing.Size(108, 14);
            this.lblStartingColumn.TabIndex = 69;
            this.lblStartingColumn.Text = "Key Column &Index:";
            // 
            // chkNot
            // 
            this.chkNot.BackColor = System.Drawing.SystemColors.Control;
            this.chkNot.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkNot.Enabled = false;
            this.chkNot.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkNot.Location = new System.Drawing.Point(73, 79);
            this.chkNot.Name = "chkNot";
            this.chkNot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkNot.Size = new System.Drawing.Size(50, 20);
            this.chkNot.TabIndex = 66;
            this.chkNot.Text = "(no&t)";
            this.chkNot.UseVisualStyleBackColor = false;
            this.chkNot.Visible = false;
            // 
            // txtValue
            // 
            this.txtValue.AcceptsReturn = true;
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.BackColor = System.Drawing.SystemColors.Window;
            this.txtValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValue.Enabled = false;
            this.txtValue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtValue.Location = new System.Drawing.Point(207, 78);
            this.txtValue.MaxLength = 0;
            this.txtValue.Name = "txtValue";
            this.txtValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtValue.Size = new System.Drawing.Size(223, 20);
            this.txtValue.TabIndex = 68;
            this.txtValue.Visible = false;
            // 
            // lblLines
            // 
            this.lblLines.BackColor = System.Drawing.SystemColors.Control;
            this.lblLines.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblLines.Enabled = false;
            this.lblLines.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLines.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLines.Location = new System.Drawing.Point(9, 81);
            this.lblLines.Name = "lblLines";
            this.lblLines.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLines.Size = new System.Drawing.Size(58, 20);
            this.lblLines.TabIndex = 65;
            this.lblLines.Text = "where line";
            this.lblLines.Visible = false;
            // 
            // TextFunctionEditorBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlPanel);
            this.Name = "TextFunctionEditorBase";
            this.Size = new System.Drawing.Size(500, 253);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        protected System.Windows.Forms.CheckBox chkAllowDuplicates;
        protected System.Windows.Forms.CheckBox chkDescending;
        protected System.Windows.Forms.Label lblComparisons;
        protected System.Windows.Forms.Button cmdRun;
        protected System.Windows.Forms.Label lblOutputFiles;
        protected System.Windows.Forms.Label lblInputFiles;
        protected System.Windows.Forms.Button cmdOutputFilesDelete;
        protected System.Windows.Forms.Button cmdOutputFilesAdd;
        protected System.Windows.Forms.Button cmdInputFilesDelete;
        protected System.Windows.Forms.Button cmdInputFilesAdd;
        protected System.Windows.Forms.TextBox txtNumberOfColumns;
        protected System.Windows.Forms.TextBox txtStartingColumn;
        protected System.Windows.Forms.Label lblNumberOfColumns;
        protected System.Windows.Forms.Label lblStartingColumn;
        protected System.Windows.Forms.CheckBox chkNot;
        protected System.Windows.Forms.TextBox txtValue;
        protected System.Windows.Forms.Label lblLines;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox ddlComparisons;
        public System.Windows.Forms.ListBox lstOutputFiles;
        public System.Windows.Forms.ListBox lstInputFiles;





    }
}
