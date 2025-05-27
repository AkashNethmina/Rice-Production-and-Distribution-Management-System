using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using iTextSharp.text;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.IO;

namespace RiceMgmtApp
{
    public partial class AuthLogs : UserControl
    {
        private readonly string _connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentUserRoleID;

        public AuthLogs(int userRoleID)
        {
            InitializeComponent();
            currentUserRoleID = userRoleID;
        }

        private void AuthLogs_Load(object sender, EventArgs e)
        {
            try
            {
                if (currentUserRoleID != 1) // 1 = Admin
                {
                    ShowAccessDenied();
                    return;
                }

                dtpFromDate.Value = DateTime.Now.AddDays(-30);
                dtpToDate.Value = DateTime.Now;
                cmbFilterStatus.SelectedIndex = 0;

                LoadAuthLogs();
                LoadStatistics();

             
                dgvAuthLogs.SizeChanged += DgvAuthLogs_SizeChanged;

                
                pnlGrid.SizeChanged += (s, ev) => ConfigureResponsiveColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading authentication logs: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAccessDenied()
        {
            this.Controls.Clear();

            Label lblAccessDenied = new Label
            {
                Text = "Access Denied\n\nOnly administrators can view authentication logs.",
                Font = new System.Drawing.Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            this.Controls.Add(lblAccessDenied);
        }

        private void DgvAuthLogs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvAuthLogs.Columns[e.ColumnIndex].Name == "Status")
                {
                    if (e.Value?.ToString() == "Success")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(34, 197, 94); 
                        e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
                        e.CellStyle.BackColor = Color.FromArgb(240, 253, 244); 
                    }
                    else if (e.Value?.ToString() == "Failure")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68); 
                        e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
                        e.CellStyle.BackColor = Color.FromArgb(254, 242, 242); 
                    }
                }
                else if (dgvAuthLogs.Columns[e.ColumnIndex].Name == "LoginTime")
                {
                    // Format login time consistently
                    if (e.Value is DateTime dateTime)
                    {
                        e.Value = dateTime.ToString("MMM dd, yyyy HH:mm");
                        e.FormattingApplied = true;
                    }
                }
                else if (dgvAuthLogs.Columns[e.ColumnIndex].Name == "RoleName")
                {
                    // Style role names
                    if (e.Value?.ToString() == "Admin")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(147, 51, 234); 
                        e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Cell formatting error: {ex.Message}");
            }
        }

        private void DgvAuthLogs_SizeChanged(object sender, EventArgs e)
        {
            ConfigureResponsiveColumns();
        }

        private void LoadAuthLogs()
        {
            try
            {
                string query = @"
            SELECT 
                al.LogID,
                u.Username,
                u.FullName,
                r.RoleName,
                al.LoginTime,
                al.Status
            FROM AuthLogs al
            LEFT JOIN Users u ON al.UserID = u.UserID
            LEFT JOIN Roles r ON u.RoleID = r.RoleID
            ORDER BY al.LoginTime DESC";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvAuthLogs.DataSource = dataTable;

                 
                    ConfigureDataGridViewStyle();
                    ConfigureResponsiveColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading authentication logs: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ConfigureDataGridViewStyle()
        {
            try
            {
                // Basic DataGridView styling (already configured in designer, but ensuring consistency)
                dgvAuthLogs.EnableHeadersVisualStyles = false;
                dgvAuthLogs.AllowUserToAddRows = false;
                dgvAuthLogs.AllowUserToDeleteRows = false;
                dgvAuthLogs.ReadOnly = true;
                dgvAuthLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvAuthLogs.MultiSelect = false;
                dgvAuthLogs.RowHeadersVisible = false;
                dgvAuthLogs.BorderStyle = BorderStyle.None;
                dgvAuthLogs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvAuthLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgvAuthLogs.BackgroundColor = Color.White;
                dgvAuthLogs.GridColor = Color.FromArgb(229, 231, 235);

                // Row styling
                dgvAuthLogs.RowTemplate.Height = 40;
                dgvAuthLogs.ColumnHeadersHeight = 45;
                dgvAuthLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                // Header style
                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(249, 250, 251),
                    ForeColor = Color.FromArgb(55, 65, 81),
                    Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    SelectionBackColor = Color.FromArgb(249, 250, 251),
                    SelectionForeColor = Color.FromArgb(55, 65, 81),
                    WrapMode = DataGridViewTriState.False,
                    Padding = new Padding(12, 8, 12, 8)
                };
                dgvAuthLogs.ColumnHeadersDefaultCellStyle = headerStyle;

                // Default cell style
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(55, 65, 81),
                    Font = new System.Drawing.Font("Segoe UI", 9F),
                    SelectionBackColor = Color.FromArgb(239, 246, 255),
                    SelectionForeColor = Color.FromArgb(55, 65, 81),
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    WrapMode = DataGridViewTriState.False,
                    Padding = new Padding(12, 6, 12, 6)
                };
                dgvAuthLogs.DefaultCellStyle = cellStyle;

                // Alternating row style for better readability
                DataGridViewCellStyle alternatingStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(248, 250, 252),
                    ForeColor = Color.FromArgb(55, 65, 81),
                    Font = new System.Drawing.Font("Segoe UI", 9F),
                    SelectionBackColor = Color.FromArgb(239, 246, 255),
                    SelectionForeColor = Color.FromArgb(55, 65, 81),
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    WrapMode = DataGridViewTriState.False,
                    Padding = new Padding(12, 6, 12, 6)
                };
                dgvAuthLogs.AlternatingRowsDefaultCellStyle = alternatingStyle;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error configuring DataGridView style: {ex.Message}",
                    "Styling Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void LoadFilteredAuthLogs()
        {
            try
            {
                string query = @"
            SELECT 
                al.LogID,
                u.Username,
                u.FullName,
                r.RoleName,
                al.LoginTime,
                al.Status
            FROM AuthLogs al
            LEFT JOIN Users u ON al.UserID = u.UserID
            LEFT JOIN Roles r ON u.RoleID = r.RoleID
            WHERE al.LoginTime >= @FromDate AND al.LoginTime <= @ToDate";

                if (cmbFilterStatus.SelectedItem.ToString() != "All")
                {
                    query += " AND al.Status = @Status";
                }

                query += " ORDER BY al.LoginTime DESC";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                    command.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date.AddDays(1).AddSeconds(-1));

                    if (cmbFilterStatus.SelectedItem.ToString() != "All")
                    {
                        command.Parameters.AddWithValue("@Status", cmbFilterStatus.SelectedItem.ToString());
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvAuthLogs.DataSource = dataTable;

                   
                    ConfigureDataGridViewStyle();
                    ConfigureResponsiveColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering authentication logs: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigureResponsiveColumns()
        {
            try
            {
                if (dgvAuthLogs.DataSource == null) return;

              
                foreach (DataGridViewColumn column in dgvAuthLogs.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                }

                int totalWidth = dgvAuthLogs.ClientSize.Width;

                var columnConfigs = new Dictionary<string, ColumnConfig>
        {
            { "LogID", new ColumnConfig { MinWidth = 70, MaxWidth = 90, Weight = 1, HeaderText = "ID", Alignment = DataGridViewContentAlignment.MiddleCenter } },
            { "Username", new ColumnConfig { MinWidth = 110, MaxWidth = 160, Weight = 2, HeaderText = "Username", Alignment = DataGridViewContentAlignment.MiddleLeft } },
            { "FullName", new ColumnConfig { MinWidth = 130, MaxWidth = 210, Weight = 3, HeaderText = "Full Name", Alignment = DataGridViewContentAlignment.MiddleLeft } },
            { "RoleName", new ColumnConfig { MinWidth = 90, MaxWidth = 130, Weight = 2, HeaderText = "Role", Alignment = DataGridViewContentAlignment.MiddleCenter } },
            { "LoginTime", new ColumnConfig { MinWidth = 140, MaxWidth = 210, Weight = 3, HeaderText = "Login Time", Alignment = DataGridViewContentAlignment.MiddleCenter } },
            { "Status", new ColumnConfig { MinWidth = 90, MaxWidth = 120, Weight = 1, HeaderText = "Status", Alignment = DataGridViewContentAlignment.MiddleCenter } }
        };

              
                int totalWeight = columnConfigs.Values.Sum(c => c.Weight);

              
                int minRequiredWidth = columnConfigs.Values.Sum(c => c.MinWidth);

           
                foreach (DataGridViewColumn column in dgvAuthLogs.Columns)
                {
                    if (columnConfigs.ContainsKey(column.Name))
                    {
                        var config = columnConfigs[column.Name];
                        column.HeaderText = config.HeaderText;
                        column.DefaultCellStyle.Alignment = config.Alignment;
                        column.HeaderCell.Style.Alignment = config.Alignment;

                       
                        if (totalWidth > minRequiredWidth)
                        {
                           
                            int availableWidth = totalWidth - minRequiredWidth;
                            int additionalWidth = (int)((double)availableWidth * config.Weight / totalWeight);
                            int calculatedWidth = config.MinWidth + additionalWidth;

                          
                            column.Width = Math.Min(calculatedWidth, config.MaxWidth);
                        }
                        else
                        {
                           
                            column.Width = config.MinWidth;
                        }

                        column.MinimumWidth = config.MinWidth;
                        column.Resizable = DataGridViewTriState.True;
                    }
                }

              
                if (dgvAuthLogs.Columns.Contains("LoginTime"))
                {
                    dgvAuthLogs.Columns["LoginTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }

             
                if (totalWidth < 600 && dgvAuthLogs.Columns.Contains("LogID"))
                {
                    dgvAuthLogs.Columns["LogID"].Visible = false;
                }

              
                if (totalWidth < 500 && dgvAuthLogs.Columns.Contains("RoleName"))
                {
                    dgvAuthLogs.Columns["RoleName"].Visible = false;
                }

              
                if (totalWidth < 400 && dgvAuthLogs.Columns.Contains("FullName"))
                {
                    dgvAuthLogs.Columns["FullName"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error configuring responsive columns: {ex.Message}",
                    "Column Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private class ColumnConfig
        {
            public int MinWidth { get; set; }
            public int MaxWidth { get; set; }
            public int Weight { get; set; }
            public string HeaderText { get; set; }
            public DataGridViewContentAlignment Alignment { get; set; }
        }
        private void LoadStatistics()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                   
                    SqlCommand totalCmd = new SqlCommand("SELECT COUNT(*) FROM AuthLogs", connection);
                    int totalLogs = Convert.ToInt32(totalCmd.ExecuteScalar());

                   
                    SqlCommand successCmd = new SqlCommand("SELECT COUNT(*) FROM AuthLogs WHERE Status = 'Success'", connection);
                    int successfulLogins = Convert.ToInt32(successCmd.ExecuteScalar());

                 
                    SqlCommand failedCmd = new SqlCommand("SELECT COUNT(*) FROM AuthLogs WHERE Status = 'Failure'", connection);
                    int failedLogins = Convert.ToInt32(failedCmd.ExecuteScalar());

               
                    lblTotalLogs.Text = $"Total Logs: {totalLogs}";
                    lblSuccessfulLogins.Text = $"Successful: {successfulLogins}";
                    lblFailedLogins.Text = $"Failed: {failedLogins}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            LoadFilteredAuthLogs();
            LoadStatistics();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAuthLogs();
            LoadStatistics();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Export Authentication Logs",
                    FileName = $"AuthLogs_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToPDF(saveFileDialog.FileName);
                    MessageBox.Show("Authentication logs exported successfully!",
                        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}",
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToPDF(string filePath)
        {
            Document document = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

              
                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                Paragraph title = new Paragraph("Authentication Logs Report", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20;
                document.Add(title);

             
                iTextSharp.text.Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                Paragraph dateInfo = new Paragraph($"Report Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", normalFont);
                dateInfo.Alignment = Element.ALIGN_RIGHT;
                dateInfo.SpacingAfter = 20;
                document.Add(dateInfo);

              
                iTextSharp.text.Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                Paragraph stats = new Paragraph();
                stats.Add(new Chunk("Statistics Summary\n", boldFont));
                stats.Add(new Chunk($"{lblTotalLogs.Text}\n", normalFont));
                stats.Add(new Chunk($"{lblSuccessfulLogins.Text}\n", normalFont));
                stats.Add(new Chunk($"{lblFailedLogins.Text}\n", normalFont));
                stats.SpacingAfter = 20;
                document.Add(stats);

             
                PdfPTable table = new PdfPTable(6); 
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1f, 2f, 3f, 2f, 3f, 1.5f });

              
                iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                string[] headers = { "Log ID", "Username", "Full Name", "Role", "Login Time", "Status" };

                foreach (string header in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 5;
                    table.AddCell(cell);
                }

              
                iTextSharp.text.Font dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                foreach (DataGridViewRow row in dgvAuthLogs.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            string cellValue = row.Cells[i].Value?.ToString() ?? "";

                            PdfPCell cell = new PdfPCell(new Phrase(cellValue, dataFont));
                            cell.Padding = 4;

                         
                            if (i == 5) 
                            {
                                if (cellValue == "Success")
                                {
                                    cell.BackgroundColor = new BaseColor(220, 255, 220); 
                                }
                                else if (cellValue == "Failure")
                                {
                                    cell.BackgroundColor = new BaseColor(255, 220, 220); 
                                }
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            }
                            else if (i == 0 || i == 4) 
                            {
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            }

                            table.AddCell(cell);
                        }
                    }
                }

                document.Add(table);

             
                Paragraph footer = new Paragraph($"\nGenerated by Rice Management System on {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8));
                footer.Alignment = Element.ALIGN_CENTER;
                footer.SpacingBefore = 20;
                document.Add(footer);
            }
            finally
            {
                document.Close();
            }
        }

        public static void LogAuthenticationAttempt(string connectionString, int? userID, bool isSuccess)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO AuthLogs (UserID, LoginTime, Status) VALUES (@UserID, @LoginTime, @Status)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@UserID", (object)userID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LoginTime", DateTime.Now);
                    command.Parameters.AddWithValue("@Status", isSuccess ? "Success" : "Failure");

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
               
                System.Diagnostics.Debug.WriteLine($"Error logging authentication attempt: {ex.Message}");
            }
        }

       
    }
}