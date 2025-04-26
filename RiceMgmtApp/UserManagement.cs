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
        private const int BUTTON_WIDTH = 70;
        private readonly Color PRIMARY_COLOR = Color.FromArgb(63, 81, 181); // Material Design primary blue
        private readonly Color ACCENT_COLOR = Color.FromArgb(255, 64, 129); // Material Design pink accent
        private readonly Color LIGHT_COLOR = Color.FromArgb(245, 245, 245); // Light gray for alternating rows

        public UserManagement()
        {
            InitializeComponent();
            this.Load += UserManagement_Load;
            this.dataGridViewusers.CellClick += dataGridViewusers_CellClick;
            this.Resize += UserManagement_Resize;

            // Initialize modern button styles
            InitializeModernButtons();
        }

        private void InitializeModernButtons()
        {
            // Style the export buttons with modern flat look
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.BackColor = PRIMARY_COLOR;
                    button.ForeColor = Color.White;
                    button.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    button.Cursor = Cursors.Hand;
                    button.Padding = new Padding(10, 5, 10, 5);
                    button.Margin = new Padding(10);
                    button.MinimumSize = new Size(120, 35);

                    // Add hover effect
                    button.MouseEnter += (s, e) => {
                        Button btn = (Button)s;
                        btn.BackColor = Color.FromArgb(83, 101, 201); // Slightly lighter on hover
                    };

                    button.MouseLeave += (s, e) => {
                        Button btn = (Button)s;
                        btn.BackColor = PRIMARY_COLOR;
                    };
                }
            }

            // Add a search box if it doesn't exist
            if (!Controls.ContainsKey("txtSearch"))
            {
                TextBox txtSearch = new TextBox
                {
                    Name = "txtSearch",
                    //PlaceholderText = "Search users...",
                    Font = new System.Drawing.Font("Segoe UI", 10),
                    Width = 200,
                    Height = 30,
                    Location = new Point(10, 10)
                };

                txtSearch.TextChanged += (s, e) => {
                    SearchUsers(txtSearch.Text);
                };

                Controls.Add(txtSearch);
            }

            // Add an "Add User" button if it doesn't exist
            if (!Controls.ContainsKey("btnAddUser"))
            {
                Button btnAddUser = new Button
                {
                    Name = "btnAddUser",
                    Text = "Add User",
                    BackColor = ACCENT_COLOR,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new System.Drawing.Font("Segoe UI", 10),
                    Location = new Point(220, 10),
                    Size = new Size(120, 35),
                    Cursor = Cursors.Hand
                };

                btnAddUser.FlatAppearance.BorderSize = 0;

                btnAddUser.Click += (s, e) => {
                    // Navigate to add user form
                    Control parent = this.Parent;
                    if (parent != null)
                    {
                        parent.Controls.Clear();
                        parent.Controls.Add(new UsersAdd()); // You'll need to create AddUser control
                    }
                };

                btnAddUser.MouseEnter += (s, e) => {
                    Button btn = (Button)s;
                    btn.BackColor = Color.FromArgb(255, 84, 149); // Lighter pink on hover
                };

                btnAddUser.MouseLeave += (s, e) => {
                    Button btn = (Button)s;
                    btn.BackColor = ACCENT_COLOR;
                };

                Controls.Add(btnAddUser);
            }
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadUsers();
            ArrangeControls();
        }

        private void UserManagement_Resize(object sender, EventArgs e)
        {
            ArrangeControls();
        }

        private void ArrangeControls()
        {
            // Responsive layout adjustment
            int padding = 10;
            int topBarHeight = 50;

            // Get reference to controls (assuming they exist)
            TextBox txtSearch = (TextBox)Controls["txtSearch"];
            Button btnAddUser = (Button)Controls["btnAddUser"];
            Button btnExportPdf = (Button)Controls["btn_exportPdf"];
            Button btnExportExcel = (Button)Controls["btn_exportExcel"];

            // Adjust search box
            txtSearch.Location = new Point(padding, padding);

            // Position Add User button
            btnAddUser.Location = new Point(txtSearch.Right + padding, padding);

            // Position export buttons to the right
            if (btnExportExcel != null)
            {
                btnExportExcel.Location = new Point(this.Width - btnExportExcel.Width - padding, padding);
            }

            if (btnExportPdf != null && btnExportExcel != null)
            {
                btnExportPdf.Location = new Point(btnExportExcel.Left - btnExportPdf.Width - padding, padding);
            }
            else if (btnExportPdf != null)
            {
                btnExportPdf.Location = new Point(this.Width - btnExportPdf.Width - padding, padding);
            }

            // Position DataGridView
            dataGridViewusers.Location = new Point(padding, topBarHeight + padding);
            dataGridViewusers.Size = new Size(this.Width - (padding * 2), this.Height - topBarHeight - (padding * 2));
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

                    StyleDataGridView(); // Apply modern styles
                    AddActionButtons();  // Add modern action buttons
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Error loading users", ex.Message);
                }
            }
        }

        private void StyleDataGridView()
        {
            // Modern material design style for DataGridView
            dataGridViewusers.BorderStyle = BorderStyle.None;
            dataGridViewusers.EnableHeadersVisualStyles = false;

            // Header style
            dataGridViewusers.ColumnHeadersDefaultCellStyle.BackColor = PRIMARY_COLOR;
            dataGridViewusers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewusers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11);
            dataGridViewusers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewusers.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dataGridViewusers.ColumnHeadersHeight = 40;
            dataGridViewusers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Cell styles
            dataGridViewusers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewusers.GridColor = Color.FromArgb(224, 224, 224); // Light separator color

            // Row styles
            dataGridViewusers.RowTemplate.Height = 38;
            dataGridViewusers.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewusers.RowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64); // Dark gray text
            dataGridViewusers.RowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dataGridViewusers.RowsDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);

            // Alternating row color for better readability
            dataGridViewusers.AlternatingRowsDefaultCellStyle.BackColor = LIGHT_COLOR;

            // Selection style
            dataGridViewusers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 255); // Light blue selection
            dataGridViewusers.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewusers.BackgroundColor = Color.White;
            dataGridViewusers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Other settings
            dataGridViewusers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewusers.MultiSelect = false;
            dataGridViewusers.AllowUserToAddRows = false;
            dataGridViewusers.AllowUserToResizeRows = false;
            dataGridViewusers.ReadOnly = true;
            dataGridViewusers.RowHeadersVisible = false;

            // Make scrollbars overlay the content
            dataGridViewusers.ScrollBars = ScrollBars.Both;
        }

        private void AddActionButtons()
        {
            // Remove existing buttons if any
            if (dataGridViewusers.Columns.Contains("EditButton"))
                dataGridViewusers.Columns.Remove("EditButton");

            if (dataGridViewusers.Columns.Contains("DeleteButton"))
                dataGridViewusers.Columns.Remove("DeleteButton");

            // Add new styled buttons
            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
            {
                Name = "EditButton",
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = BUTTON_WIDTH,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(33, 150, 243), // Material blue
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(33, 150, 243),
                    SelectionForeColor = Color.White
                }
            };
            dataGridViewusers.Columns.Add(editBtn);

            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn
            {
                Name = "DeleteButton",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = BUTTON_WIDTH,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(244, 67, 54), // Material red
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(244, 67, 54),
                    SelectionForeColor = Color.White
                }
            };
            dataGridViewusers.Columns.Add(deleteBtn);

            // Set fixed widths for action columns
            dataGridViewusers.Columns["EditButton"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewusers.Columns["EditButton"].Width = BUTTON_WIDTH;
            dataGridViewusers.Columns["DeleteButton"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewusers.Columns["DeleteButton"].Width = BUTTON_WIDTH;
        }

        private void dataGridViewusers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure the clicked row and column indexes are valid
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.RowIndex >= dataGridViewusers.Rows.Count) return;
            if (e.ColumnIndex >= dataGridViewusers.Columns.Count) return;

            // Also check if it's not a new row (which can happen)
            if (dataGridViewusers.Rows[e.RowIndex].IsNewRow) return;

            // Now safely access
            var userIdCell = dataGridViewusers.Rows[e.RowIndex].Cells["UserID"];
            if (userIdCell == null || userIdCell.Value == null) return; // extra safety

            int userId = Convert.ToInt32(userIdCell.Value);
            string columnName = dataGridViewusers.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "EditButton":
                    LoadEditUserControl(userId);
                    break;

                case "DeleteButton":
                    ConfirmAndDeleteUser(userId);
                    break;
            }
        }


        private void ConfirmAndDeleteUser(int userId)
        {
            // Create custom dialog for confirmation
            Form confirmDialog = new Form
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                Text = "Confirm Delete",
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label message = new Label
            {
                Text = "Are you sure you want to delete this user?",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 350,
                Height = 50,
                Location = new Point(25, 20),
                Font = new System.Drawing.Font("Segoe UI", 10)
            };

            Button yesButton = new Button
            {
                Text = "Yes, Delete",
                BackColor = Color.FromArgb(244, 67, 54), // Red
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 120,
                Height = 35,
                Location = new Point(70, 80),
                DialogResult = DialogResult.Yes
            };
            yesButton.FlatAppearance.BorderSize = 0;

            Button noButton = new Button
            {
                Text = "Cancel",
                BackColor = Color.FromArgb(158, 158, 158), // Gray
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 120,
                Height = 35,
                Location = new Point(210, 80),
                DialogResult = DialogResult.No
            };
            noButton.FlatAppearance.BorderSize = 0;

            confirmDialog.Controls.Add(message);
            confirmDialog.Controls.Add(yesButton);
            confirmDialog.Controls.Add(noButton);

            DialogResult result = confirmDialog.ShowDialog();

            if (result == DialogResult.Yes)
            {
                DeleteUser(userId);
            }
        }

        private void LoadEditUserControl(int userId)
        {
            try
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
            catch (Exception ex)
            {
                ShowErrorMessage("Error loading edit user form", ex.Message);
            }
        }

        private void DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Users WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        ShowSuccessMessage("User deleted successfully.");
                    }
                    else
                    {
                        ShowWarningMessage("No user was deleted. User may no longer exist.");
                    }
                }

                LoadUsers(); // Refresh the grid
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error deleting user", ex.Message);
            }
        }

        private void SearchUsers(string searchText)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
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
                        WHERE U.FullName LIKE @SearchText 
                        OR U.Username LIKE @SearchText 
                        OR U.Email LIKE @SearchText 
                        OR R.RoleName LIKE @SearchText";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewusers.DataSource = dt;

                    // Reapply styles to buttons after data refresh
                    AddActionButtons();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error searching users", ex.Message);
            }
        }

        private void btn_exportPdf_Click(object sender, EventArgs e)
        {
            if (dataGridViewusers.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = "Users_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf",
                    Title = "Export Users to PDF"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 20f, 20f);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            // Replace the problematic line with the following:
                            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
                            Paragraph title = new Paragraph("User Management Report", titleFont);
                            title.Alignment = Element.ALIGN_CENTER;
                            title.SpacingAfter = 20f;
                            pdfDoc.Add(title);

                            // Use fully qualified name for iTextSharp.text.Font to resolve ambiguity
                            iTextSharp.text.Font dateFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC, BaseColor.GRAY);
                            Paragraph datePara = new Paragraph("Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), dateFont);
                            datePara.Alignment = Element.ALIGN_RIGHT;
                            datePara.SpacingAfter = 20f;
                            pdfDoc.Add(datePara);

                            // Create table
                            PdfPTable pdfTable = new PdfPTable(dataGridViewusers.Columns.Count - 2); // Exclude buttons
                            pdfTable.WidthPercentage = 100;

                            // Set column widths
                            float[] columnWidths = new float[dataGridViewusers.Columns.Count - 2];
                            int col = 0;
                            for (int i = 0; i < dataGridViewusers.Columns.Count; i++)
                            {
                                if (dataGridViewusers.Columns[i] is DataGridViewButtonColumn) continue;
                                columnWidths[col++] = dataGridViewusers.Columns[i].Width;
                            }
                            pdfTable.SetWidths(columnWidths);

                            // Add headers with modern style
                            BaseColor headerBgColor = new BaseColor(PRIMARY_COLOR.R, PRIMARY_COLOR.G, PRIMARY_COLOR.B);
                            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.WHITE);

                            for (int i = 0; i < dataGridViewusers.Columns.Count; i++)
                            {
                                if (dataGridViewusers.Columns[i] is DataGridViewButtonColumn) continue;

                                PdfPCell cell = new PdfPCell(new Phrase(dataGridViewusers.Columns[i].HeaderText, headerFont));
                                cell.BackgroundColor = headerBgColor;
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                cell.Padding = 8;
                                pdfTable.AddCell(cell);
                            }

                            // Add rows with alternating colors
                            BaseColor altBgColor = new BaseColor(LIGHT_COLOR.R, LIGHT_COLOR.G, LIGHT_COLOR.B);
                            // Use fully qualified name for iTextSharp.text.Font to resolve ambiguity
                            iTextSharp.text.Font cellFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10);

                            for (int rowIdx = 0; rowIdx < dataGridViewusers.Rows.Count; rowIdx++)
                            {
                                DataGridViewRow row = dataGridViewusers.Rows[rowIdx];

                                for (int i = 0; i < row.Cells.Count; i++)
                                {
                                    if (dataGridViewusers.Columns[i] is DataGridViewButtonColumn) continue;

                                    PdfPCell cell = new PdfPCell(new Phrase(row.Cells[i].Value?.ToString() ?? "", cellFont));
                                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    cell.Padding = 6;

                                    // Alternating row color
                                    if (rowIdx % 2 != 0)
                                    {
                                        cell.BackgroundColor = altBgColor;
                                    }

                                    pdfTable.AddCell(cell);
                                }
                            }

                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                            stream.Close();
                        }

                        ShowSuccessMessage("PDF exported successfully!");

                        // Ask if user wants to open the file
                        if (MessageBox.Show("Would you like to open the PDF file?", "Open File",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(sfd.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Error exporting PDF", ex.Message);
                    }
                }
            }
            else
            {
                ShowWarningMessage("No data to export!");
            }
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewusers.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = "Users_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx",
                    Title = "Export Users to Excel"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Set the license context
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        using (ExcelPackage pck = new ExcelPackage())
                        {
                            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Users");

                            // Create a header style
                            var headerStyle = ws.Workbook.Styles.CreateNamedStyle("HeaderStyle");
                            headerStyle.Style.Font.Bold = true;
                            headerStyle.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            headerStyle.Style.Fill.BackgroundColor.SetColor(PRIMARY_COLOR);
                            headerStyle.Style.Font.Color.SetColor(Color.White);
                            headerStyle.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;

                            // Create alternating row style
                            var altRowStyle = ws.Workbook.Styles.CreateNamedStyle("AltRowStyle");
                            altRowStyle.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            altRowStyle.Style.Fill.BackgroundColor.SetColor(LIGHT_COLOR);

                            int colIndex = 1;

                            // Add headers
                            for (int i = 0; i < dataGridViewusers.Columns.Count; i++)
                            {
                                if (dataGridViewusers.Columns[i] is DataGridViewButtonColumn) continue;

                                ws.Cells[1, colIndex].Value = dataGridViewusers.Columns[i].HeaderText;
                                ws.Cells[1, colIndex].StyleName = "HeaderStyle";
                                colIndex++;
                            }

                            // Auto-filter for all columns
                            ws.Cells[1, 1, 1, colIndex - 1].AutoFilter = true;

                            // Add data
                            int rowIndex = 2;
                            foreach (DataGridViewRow row in dataGridViewusers.Rows)
                            {
                                colIndex = 1;
                                for (int i = 0; i < row.Cells.Count; i++)
                                {
                                    if (dataGridViewusers.Columns[i] is DataGridViewButtonColumn) continue;

                                    ws.Cells[rowIndex, colIndex].Value = row.Cells[i].Value?.ToString() ?? "";

                                    // Apply alternating row style
                                    if (rowIndex % 2 == 0)
                                    {
                                        ws.Cells[rowIndex, colIndex].StyleName = "AltRowStyle";
                                    }

                                    colIndex++;
                                }
                                rowIndex++;
                            }

                            // Auto-fit columns
                            ws.Cells[ws.Dimension.Address].AutoFitColumns();

                            // Add borders
                            var range = ws.Cells[1, 1, rowIndex - 1, colIndex - 1];
                            range.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                            FileInfo fi = new FileInfo(sfd.FileName);
                            pck.SaveAs(fi);
                        }

                        ShowSuccessMessage("Excel exported successfully!");

                        // Ask if user wants to open the file
                        if (MessageBox.Show("Would you like to open the Excel file?", "Open File",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(sfd.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Error exporting Excel", ex.Message);
                    }
                }
            }
            else
            {
                ShowWarningMessage("No data to export!");
            }
        }

        #region Message Helper Methods

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowErrorMessage(string title, string message)
        {
            MessageBox.Show($"{title}: {message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}