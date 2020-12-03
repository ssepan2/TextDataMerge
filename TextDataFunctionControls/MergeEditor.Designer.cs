namespace TextDataFunctionControls
{
    partial class MergeEditor
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
            this.cmdRun.Image = global::TextDataFunctionControls.Properties.TextFunction.Merge;
            this.cmdRun.Text = "Merge";
            // 
            // lblOutputFiles
            // 
            this.lblOutputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutputFiles.Location = new System.Drawing.Point(7, 131);
            // 
            // lstOutputFiles
            // 
            this.lstOutputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOutputFiles.Location = new System.Drawing.Point(9, 147);
            // 
            // lstInputFiles
            // 
            this.lstInputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInputFiles.Size = new System.Drawing.Size(421, 108);
            // 
            // cmdOutputFilesDelete
            // 
            this.cmdOutputFilesDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOutputFilesDelete.Location = new System.Drawing.Point(467, 147);
            // 
            // cmdOutputFilesAdd
            // 
            this.cmdOutputFilesAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOutputFilesAdd.Location = new System.Drawing.Point(436, 147);
            // 
            // chkNot
            // 
            this.chkNot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNot.Location = new System.Drawing.Point(73, 171);
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(207, 170);
            // 
            // lblLines
            // 
            this.lblLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLines.Location = new System.Drawing.Point(9, 173);
            // 
            // MergeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MergeEditor";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
