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
        private readonly Color PRIMARY_COLOR = Color.FromArgb(63, 81, 181);
        private readonly Color ACCENT_COLOR = Color.FromArgb(255, 64, 129); 
        private readonly Color LIGHT_COLOR = Color.FromArgb(245, 245, 245);

        public UserManagement()
        {
            InitializeComponent();
            this.Load += UserManagement_Load;
            this.dataGridViewusers.CellClick += dataGridViewusers_CellClick;
            this.Resize += UserManagement_Resize;

          
            InitializeModernButtons();
        }

        private void InitializeModernButtons()
        {
           
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

                   
                    button.MouseEnter += (s, e) => {
                        Button btn = (Button)s;
                        btn.BackColor = Color.FromArgb(83, 101, 201); 
                    };

                    button.MouseLeave += (s, e) => {
                        Button btn = (Button)s;
                        btn.BackColor = PRIMARY_COLOR;
                    };
                }
            }

          

          
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
                  
                    Control parent = this.Parent;
                    if (parent != null)
                    {
                        parent.Controls.Clear();
                        parent.Controls.Add(new UsersAdd());
                    }
                };

                btnAddUser.MouseEnter += (s, e) => {
                    Button btn = (Button)s;
                    btn.BackColor = Color.FromArgb(255, 84, 149);
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
           
            int padding = 10;
            int topBarHeight = 50;

          
          
            Button btnAddUser = (Button)Controls["btnAddUser"];
            Button btnExportPdf = (Button)Controls["btn_exportPdf"];
            Button btnExportExcel = (Button)Controls["btn_exportExcel"];

           
           

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

                    StyleDataGridView(); 
                    AddActionButtons();  
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Error loading users", ex.Message);
                }
            }
        }

        private void StyleDataGridView()
        {
          
            dataGridViewusers.BorderStyle = BorderStyle.None;
            dataGridViewusers.EnableHeadersVisualStyles = false;

           
            dataGridViewusers.ColumnHeadersDefaultCellStyle.BackColor = PRIMARY_COLOR;
            dataGridViewusers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewusers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11);
            dataGridViewusers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewusers.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dataGridViewusers.ColumnHeadersHeight = 40;
            dataGridViewusers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

           
            dataGridViewusers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewusers.GridColor = Color.FromArgb(224, 224, 224); 

            
            dataGridViewusers.RowTemplate.Height = 38;
            dataGridViewusers.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewusers.RowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64); 
            dataGridViewusers.RowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dataGridViewusers.RowsDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);

          
            dataGridViewusers.AlternatingRowsDefaultCellStyle.BackColor = LIGHT_COLOR;

           
            dataGridViewusers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 255); 
            dataGridViewusers.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewusers.BackgroundColor = Color.White;
            dataGridViewusers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

           
            dataGridViewusers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewusers.MultiSelect = false;
            dataGridViewusers.AllowUserToAddRows = false;
            dataGridViewusers.AllowUserToResizeRows = false;
            dataGridViewusers.ReadOnly = true;
            dataGridViewusers.RowHeadersVisible = false;

         
            dataGridViewusers.ScrollBars = ScrollBars.Both;
        }

        private void AddActionButtons()
        {
            
            if (dataGridViewusers.Columns.Contains("EditButton"))
                dataGridViewusers.Columns.Remove("EditButton");

            if (dataGridViewusers.Columns.Contains("DeleteButton"))
                dataGridViewusers.Columns.Remove("DeleteButton");

        
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
                    BackColor = Color.FromArgb(33, 150, 243), 
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
                    BackColor = Color.FromArgb(244, 67, 54), 
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(244, 67, 54),
                    SelectionForeColor = Color.White
                }
            };
            dataGridViewusers.Columns.Add(deleteBtn);


            dataGridViewusers.Columns["EditButton"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewusers.Columns["EditButton"].Width = BUTTON_WIDTH;
            dataGridViewusers.Columns["DeleteButton"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewusers.Columns["DeleteButton"].Width = BUTTON_WIDTH;
        }

        private void dataGridViewusers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.RowIndex >= dataGridViewusers.Rows.Count) return;
            if (e.ColumnIndex >= dataGridViewusers.Columns.Count) return;

         
            if (dataGridViewusers.Rows[e.RowIndex].IsNewRow) return;

         
            var userIdCell = dataGridViewusers.Rows[e.RowIndex].Cells["UserID"];
            if (userIdCell == null || userIdCell.Value == null) return; 

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

                          
                            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
                            Paragraph title = new Paragraph("User Management Report", titleFont);
                            title.Alignment = Element.ALIGN_CENTER;
                            title.SpacingAfter = 20f;
                            pdfDoc.Add(title);

                           
                            iTextSharp.text.Font dateFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC, BaseColor.GRAY);
                            Paragraph datePara = new Paragraph("Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), dateFont);
                            datePara.Alignment = Element.ALIGN_RIGHT;
                            datePara.SpacingAfter = 20f;
                            pdfDoc.Add(datePara);

                         
                            PdfPTable pdfTable = new PdfPTable(dataGridViewusers.Columns.Count - 2); // Exclude buttons
                            pdfTable.WidthPercentage = 100;

                           
                            float[] columnWidths = new float[dataGridViewusers.Columns.Count - 2];
                            int col = 0;
                            for (int i = 0; i < dataGridViewusers.Columns.Count; i++)
                            {
                                if (dataGridViewusers.Columns[i] is DataGridViewButtonColumn) continue;
                                columnWidths[col++] = dataGridViewusers.Columns[i].Width;
                            }
                            pdfTable.SetWidths(columnWidths);

                      
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

                        
                            BaseColor altBgColor = new BaseColor(LIGHT_COLOR.R, LIGHT_COLOR.G, LIGHT_COLOR.B);
                        
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