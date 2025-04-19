namespace RiceMgmtApp
{
    partial class SellPady
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

        // Remove the duplicate InitializeComponent method from the partial class SellPady.Designer.cs
        // The following method already exists in the main SellPady class, so it should not be redefined here.
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SellPady
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SellPady";
            this.Size = new System.Drawing.Size(979, 515);
            this.Load += new System.EventHandler(this.SellPady_Load);
            this.ResumeLayout(false);
        }

        // Ensure proper placement of #region and #endregion
        #region Component Designer generated code
        #endregion
    }
}
