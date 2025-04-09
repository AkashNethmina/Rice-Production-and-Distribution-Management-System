using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using OfficeOpenXml;

namespace RiceMgmtApp
{
    public partial class FarmerManagement : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["RiceMgmtApp.Properties.Settings.RiceProductionDB2ConnectionString"].ConnectionString;

        public FarmerManagement()
        {
            InitializeComponent();
            this.Load += FarmerManagement_Load;
            this.dgvFarmerManage.CellClick += dgvFarmerManage_CellClick;
        }

        private void FarmerManagement_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            U.UserID, 
                            U.FullName, 
                            U.Username, 
                            U.Email, 
                            U.ContactNumber, 
                            R.RoleName, 
                            U.Status 
                        FROM Users U
                        INNER JOIN Roles R ON U.RoleID = R.RoleID
                        WHERE R.RoleID = 2";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvFarmerManage.DataSource = dt;

                    StyleDataGridView();
                    AddButtonsToGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading farmers: " + ex.Message);
                }
            }
        }

        private void StyleDataGridView()
        {
            dgvFarmerManage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFarmerManage.RowTemplate.Height = 30;
            dgvFarmerManage.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvFarmerManage.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFarmerManage.EnableHeadersVisualStyles = false;
        }

        private void AddButtonsToGrid()
        {
            if (!dgvFarmerManage.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "🗑",
                    UseColumnTextForButtonValue = true,
                    HeaderText = "Actions"
                };
                dgvFarmerManage.Columns.Add(deleteButton);
            }
        }

        private void dgvFarmerManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvFarmerManage.Columns["Delete"].Index)
            {
                int userId = Convert.ToInt32(dgvFarmerManage.Rows[e.RowIndex].Cells["UserID"].Value);
                string name = dgvFarmerManage.Rows[e.RowIndex].Cells["FullName"].Value.ToString();

                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete farmer '{name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    DeleteUser(userId);
                    LoadUsers();
                }
            }
        }

        private void DeleteUser(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Users WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message);
                }
            }
        }

        // Export to PDF
        private void ExportToPDF(string filePath)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            PdfPTable table = new PdfPTable(dgvFarmerManage.Columns.Count - 1); // Skip Delete column
            foreach (DataGridViewColumn col in dgvFarmerManage.Columns)
            {
                if (col.Name != "Delete")
                    table.AddCell(new Phrase(col.HeaderText));
            }

            foreach (DataGridViewRow row in dgvFarmerManage.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.OwningColumn.Name != "Delete")
                            table.AddCell(cell.Value?.ToString());
                    }
                }
            }

            document.Add(table);
            document.Close();
        }

        // Export to Excel
        private void ExportToExcel(string filePath)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                var sheet = excel.Workbook.Worksheets.Add("Farmers");

                for (int i = 0; i < dgvFarmerManage.Columns.Count; i++)
                {
                    if (dgvFarmerManage.Columns[i].Name != "Delete")
                        sheet.Cells[1, i + 1].Value = dgvFarmerManage.Columns[i].HeaderText;
                }

                for (int i = 0; i < dgvFarmerManage.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvFarmerManage.Columns.Count; j++)
                    {
                        if (dgvFarmerManage.Columns[j].Name != "Delete")
                        {
                            sheet.Cells[i + 2, j + 1].Value = dgvFarmerManage.Rows[i].Cells[j].Value?.ToString();
                        }
                    }
                }

                File.WriteAllBytes(filePath, excel.GetAsByteArray());
            }
        }

        // Call these two methods from your UI buttons
       
       

        private void ExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF File|*.pdf", FileName = "FarmerList.pdf" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToPDF(sfd.FileName);
                MessageBox.Show("PDF exported successfully.");
            }
        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel File|*.xlsx", FileName = "FarmerList.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(sfd.FileName);
                MessageBox.Show("Excel exported successfully.");
            }
        }
    }
}
