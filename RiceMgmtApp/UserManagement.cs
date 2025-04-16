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
    public partial class UserManagement : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["RiceMgmtApp.Properties.Settings.RiceProductionDB2ConnectionString"].ConnectionString;

        public UserManagement()
        {
            InitializeComponent();
            this.Load += UserManagement_Load;
            this.dataGridViewusers.CellClick += dataGridViewusers_CellClick;
        }

        private void UserManagement_Load(object sender, EventArgs e)
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
                        INNER JOIN Roles R ON U.RoleID = R.RoleID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewusers.DataSource = dt;

                    StyleDataGridView(); // Apply styles
                    AddActionButtons();  // Add buttons
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading users: " + ex.Message);
                }
            }
        }

        private void StyleDataGridView()
        {
           // // General appearance
           // dataGridViewusers.BorderStyle = BorderStyle.None;
           // dataGridViewusers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
           // dataGridViewusers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
           // dataGridViewusers.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
           // dataGridViewusers.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
           // dataGridViewusers.BackgroundColor = Color.White;

           // // Header style
           // dataGridViewusers.EnableHeadersVisualStyles = false;
           // dataGridViewusers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
           // dataGridViewusers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
           // dataGridViewusers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
           // //dataGridViewusers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

           // // Row style
           //// dataGridViewusers.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
           // dataGridViewusers.RowTemplate.Height = 30;

           // // Column auto-sizing
           // dataGridViewusers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewusers.EnableHeadersVisualStyles = false;
            dataGridViewusers.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridViewusers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewusers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewusers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewusers.DefaultCellStyle.BackColor = Color.White;
            dataGridViewusers.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewusers.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dataGridViewusers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewusers.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dataGridViewusers.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewusers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewusers.RowTemplate.Height = 28;
            dataGridViewusers.GridColor = Color.LightGray;
            dataGridViewusers.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewusers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewusers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewusers.MultiSelect = false;
            dataGridViewusers.AllowUserToAddRows = false;
            dataGridViewusers.ReadOnly = true;
        }

        private void AddActionButtons()
        {
            if (!dataGridViewusers.Columns.Contains("EditButton"))
            {
                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
                {
                    Name = "EditButton",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewusers.Columns.Add(editBtn);

                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn
                {
                    Name = "DeleteButton",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewusers.Columns.Add(deleteBtn);
            }
        }

        private void dataGridViewusers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int userId = Convert.ToInt32(dataGridViewusers.Rows[e.RowIndex].Cells["UserID"].Value);
            string columnName = dataGridViewusers.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "EditButton":
                    LoadEditUserControl(userId);
                    break;

                case "DeleteButton":
                    DialogResult result = MessageBox.Show("Are you sure to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DeleteUser(userId);
                    }
                    break;
            }
        }

        private void LoadEditUserControl(int userId)
        {
            EditUser editUserControl = new EditUser();
            editUserControl.Dock = DockStyle.Fill;
            editUserControl.LoadUserData(userId);

            Control parent = this.Parent;
            if (parent != null)
            {
                parent.Controls.Clear();
                parent.Controls.Add(editUserControl);
            }
        }

        private void DeleteUser(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadUsers();
        }

        private void dataGridViewusers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional handler
        }

        

        private void btn_exportPdf_Click(object sender, EventArgs e)
        {
            if (dataGridViewusers.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Users.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            PdfPTable pdfTable = new PdfPTable(dataGridViewusers.Columns.Count - 2); // Exclude buttons
                            pdfTable.WidthPercentage = 100;

                            // Add headers
                            for (int i = 0; i < dataGridViewusers.Columns.Count; i++)
                            {
                                if (dataGridViewusers.Columns[i] is DataGridViewButtonColumn) continue;

                                PdfPCell cell = new PdfPCell(new Phrase(dataGridViewusers.Columns[i].HeaderText));
                                cell.BackgroundColor = new BaseColor(240, 240, 240);
                                pdfTable.AddCell(cell);
                            }

                            // Add rows
                            foreach (DataGridViewRow row in dataGridViewusers.Rows)
                            {
                                for (int i = 0; i < row.Cells.Count; i++)
                                {
                                    if (dataGridViewusers.Columns[i] is DataGridViewButtonColumn) continue;

                                    pdfTable.AddCell(row.Cells[i].Value?.ToString() ?? "");
                                }
                            }

                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                            stream.Close();
                        }

                        MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting PDF: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            //if (dataGridViewusers.Rows.Count > 0)
            //{
            //    SaveFileDialog sfd = new SaveFileDialog();
            //    sfd.Filter = "Excel Files|*.xlsx";
            //    sfd.FileName = "Users.xlsx";

            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        try
            //        {
            //            // 👉 Set the license context
            //            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //            using (ExcelPackage pck = new ExcelPackage())
            //            {
            //                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Users");

            //                int colIndex = 1;

            //                // Add headers
            //                for (int i = 0; i < dataGridViewusers.Columns.Count; i++)
            //                {
            //                    if (dataGridViewusers.Columns[i] is DataGridViewButtonColumn) continue;

            //                    ws.Cells[1, colIndex].Value = dataGridViewusers.Columns[i].HeaderText;
            //                    ws.Cells[1, colIndex].Style.Font.Bold = true;
            //                    colIndex++;
            //                }

            //                // Add data
            //                int rowIndex = 2;
            //                foreach (DataGridViewRow row in dataGridViewusers.Rows)
            //                {
            //                    colIndex = 1;
            //                    for (int i = 0; i < row.Cells.Count; i++)
            //                    {
            //                        if (dataGridViewusers.Columns[i] is DataGridViewButtonColumn) continue;

            //                        ws.Cells[rowIndex, colIndex].Value = row.Cells[i].Value?.ToString() ?? "";
            //                        colIndex++;
            //                    }
            //                    rowIndex++;
            //                }

            //                FileInfo fi = new FileInfo(sfd.FileName);
            //                pck.SaveAs(fi);
            //            }

            //            MessageBox.Show("Excel exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Error exporting Excel: " + ex.Message);
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No data to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void dataGridViewusers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
