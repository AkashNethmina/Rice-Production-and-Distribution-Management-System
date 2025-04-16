using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace RiceMgmtApp
{
    public partial class StockManagement : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";

        public StockManagement()
        {
            InitializeComponent();
            LoadStockData();
        }

        private void StockManagement_Load(object sender, EventArgs e)
        {
            LoadStockData();
        }

        private void LoadStockData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT S.StockID, U.FullName AS FarmerName, S.CropType, S.Quantity, S.LastUpdated
                                 FROM Stock S
                                 INNER JOIN Users U ON S.FarmerID = U.UserID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewStock.DataSource = dt;
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dataGridViewStock.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "StockReport.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
                try
                {
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    Paragraph title = new Paragraph("Stock Report", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20f
                    };
                    doc.Add(title);

                    PdfPTable table = new PdfPTable(dataGridViewStock.Columns.Count);
                    table.WidthPercentage = 100;

                    // Add headers
                    foreach (DataGridViewColumn column in dataGridViewStock.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                        cell.BackgroundColor = new BaseColor(240, 240, 240);
                        table.AddCell(cell);
                    }

                    // Add data rows
                    foreach (DataGridViewRow row in dataGridViewStock.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value?.ToString() ?? "");
                        }
                    }

                    doc.Add(table);
                    MessageBox.Show("PDF exported successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating PDF: " + ex.Message);
                }
                finally
                {
                    doc.Close();
                }
            }
        }

        
    }
}

