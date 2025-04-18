using System.Windows.Forms;

namespace RiceMgmtApp
{
    partial class Price_Monitoring
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewPrices;
        private ComboBox cmbRegion;
        private NumericUpDown numThreshold;
        private Button btnRefresh;
        private Button btnSetPrice;
        private Panel pnlAlerts;


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

            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Dispose();
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
            // Price_Monitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Price_Monitoring";
            this.Size = new System.Drawing.Size(831, 458);
            this.Load += new System.EventHandler(this.Price_Monitoring_Load);
            this.ResumeLayout(false);

        }
        #endregion


    }
}
