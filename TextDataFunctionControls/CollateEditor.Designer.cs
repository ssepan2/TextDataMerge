namespace TextDataFunctionControls
{
    partial class CollateEditor
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
            this.SuspendLayout();
            // 
            // lblComparisons
            // 
            this.lblComparisons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblComparisons.Location = new System.Drawing.Point(129, 173);
            // 
            // cmdRun
            // 
            this.cmdRun.Image = global::TextDataFunctionControls.Properties.TextFunction.Collate;
            this.cmdRun.Text = "Collate";
            // 
            // lstOutputFiles
            // 
            this.lstOutputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOutputFiles.Size = new System.Drawing.Size(421, 108);
            // 
            // chkNot
            // 
            this.chkNot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNot.Location = new System.Drawing.Point(73, 171);
            this.chkNot.Visible = true;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(207, 170);
            this.txtValue.Visible = true;
            // 
            // lblLines
            // 
            this.lblLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLines.Enabled = true;
            this.lblLines.Location = new System.Drawing.Point(9, 173);
            this.lblLines.Visible = true;
            // 
            // ddlComparisons
            // 
            this.ddlComparisons.Visible = true;
            // 
            // CollateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CollateEditor";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
