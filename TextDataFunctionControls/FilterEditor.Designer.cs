namespace TextDataFunctionControls
{
    partial class FilterEditor
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
            this.lblComparisons.Visible = true;
            // 
            // cmdRun
            // 
            this.cmdRun.Image = global::TextDataFunctionControls.Properties.TextFunction.Filter;
            this.cmdRun.Text = "Filter";
            // 
            // chkNot
            // 
            this.chkNot.Visible = true;
            // 
            // txtValue
            // 
            this.txtValue.Visible = true;
            // 
            // lblLines
            // 
            this.lblLines.Enabled = true;
            this.lblLines.Visible = true;
            // 
            // FilterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FilterEditor";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
