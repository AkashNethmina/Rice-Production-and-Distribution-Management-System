using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace RiceMgmtApp
{
    public partial class Cultivation : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["RiceMgmtApp.Properties.Settings.RiceProductionDB2ConnectionString"].ConnectionString;

        public Cultivation()
        {
            InitializeComponent();
        }

        private void Cultivation_Load(object sender, EventArgs e)
        {
            LoadCultivationData();
        }

        private void LoadCultivationData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) // Fixed
            {
                string query = "SELECT * FROM Cultivation";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvCultivation.DataSource = table;
            }
        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    using (UserControl ac = new AddEditCultivation())
        //    {
        //        if (ac.ShowDialog() == DialogResult.OK)
        //        {
        //            LoadCultivationData();
        //        }
        //    }
        //}

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    if (dgvCultivation.CurrentRow != null)
        //    {
        //        int id = Convert.ToInt32(dgvCultivation.CurrentRow.Cells["CultivationID"].Value);
        //        using (UserControl ec = new AddEditCultivation(id))
        //        {
        //            if (ec.ShowDialog() == DialogResult.OK)
        //            {
        //                LoadCultivationData();
        //            }
        //        }
        //    }
        //}

       

     

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCultivation.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvCultivation.CurrentRow.Cells["CultivationID"].Value);
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString)) // Fixed
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Cultivation WHERE CultivationID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadCultivationData();
                }
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "Cultivation_Report.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document doc = new Document(PageSize.A4.Rotate());
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    PdfPTable pdfTable = new PdfPTable(dgvCultivation.Columns.Count);
                    pdfTable.WidthPercentage = 100;

                    // Add headers
                    foreach (DataGridViewColumn column in dgvCultivation.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText))
                        {
                            BackgroundColor = BaseColor.LIGHT_GRAY
                        };
                        pdfTable.AddCell(cell);
                    }

                    // Add data rows
                    foreach (DataGridViewRow row in dgvCultivation.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                pdfTable.AddCell(cell.Value?.ToString() ?? "");
                            }
                        }
                    }

                    doc.Add(pdfTable);
                    doc.Close();

                    MessageBox.Show("Exported to PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
