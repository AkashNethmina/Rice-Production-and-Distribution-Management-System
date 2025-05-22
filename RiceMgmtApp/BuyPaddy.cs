using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RiceMgmtApp
{
    public partial class BuyPaddy : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private readonly int currentBuyerId;
        private int selectedStockId = -1;
        private int selectedFarmerId = -1;
        private int selectedSaleId = -1;
        private int userRoleId = -1; // Store the user's role

        public BuyPaddy(int buyerID)
        {
            InitializeComponent();
            this.currentBuyerId = buyerID;
            this.Load += BuyPaddy_Load;
        }

        private void LoadBuyerInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Modified query to accept both Government (3) and Private Buyer (4) roles
                    string query = "SELECT FullName, RoleID FROM Users WHERE UserID = @BuyerID AND RoleID IN (3, 4)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BuyerID", currentBuyerId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fullName = reader["FullName"].ToString();
                            userRoleId = Convert.ToInt32(reader["RoleID"]);

                            // You can uncomment this if you have a label to display buyer name
                            // lblBuyerName.Text = fullName;

                            // Optional: Show role-specific information
                            string roleText = userRoleId == 3 ? "Government Buyer" : "Private Buyer";
                            // lblBuyerRole.Text = roleText; // If you have a role label
                        }
                        else
                        {
                            MessageBox.Show("Error: You do not have buyer privileges (Government or Private).");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading buyer information: {ex.Message}");
            }
        }

        private void StylePurchaseGrid()
        {
            dataGridViewSales.EnableHeadersVisualStyles = false;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewSales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewSales.DefaultCellStyle.BackColor = Color.White;
            dataGridViewSales.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewSales.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
            dataGridViewSales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSales.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewSales.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewSales.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridViewSales.RowTemplate.Height = 28;
            dataGridViewSales.GridColor = Color.LightGray;
            dataGridViewSales.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSales.MultiSelect = false;
            dataGridViewSales.AllowUserToAddRows = false;
            dataGridViewSales.ReadOnly = true;
        }

        private void LoadBuyerPurchasesData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Modified query to show purchases for both Government and Private buyers
                string query = @"
            SELECT s.SaleID, s.FarmerID, f.FullName AS FarmerName, s.BuyerType,
                   s.CropType, s.SalePrice, s.Quantity,
                   (s.SalePrice * s.Quantity) AS TotalAmount,
                   s.PaymentStatus, s.SaleDate
            FROM Sales s
            LEFT JOIN Users f ON s.FarmerID = f.UserID
            WHERE s.BuyerID = @BuyerID AND s.BuyerType IN ('Private', 'Government')
            ORDER BY s.SaleDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BuyerID", currentBuyerId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewSales.DataSource = dt;
                }

                // Rename and format columns for display
                if (dataGridViewSales.Columns["SaleID"] != null)
                    dataGridViewSales.Columns["SaleID"].HeaderText = "Purchase ID";

                if (dataGridViewSales.Columns["FarmerName"] != null)
                    dataGridViewSales.Columns["FarmerName"].HeaderText = "Farmer";

                if (dataGridViewSales.Columns["BuyerType"] != null)
                    dataGridViewSales.Columns["BuyerType"].HeaderText = "Buyer Type";

                if (dataGridViewSales.Columns["CropType"] != null)
                    dataGridViewSales.Columns["CropType"].HeaderText = "Rice Type";

                if (dataGridViewSales.Columns["SalePrice"] != null)
                    dataGridViewSales.Columns["SalePrice"].HeaderText = "Price/kg";

                if (dataGridViewSales.Columns["Quantity"] != null)
                    dataGridViewSales.Columns["Quantity"].HeaderText = "Quantity (kg)";

                if (dataGridViewSales.Columns["TotalAmount"] != null)
                    dataGridViewSales.Columns["TotalAmount"].HeaderText = "Total Amount";

                if (dataGridViewSales.Columns["PaymentStatus"] != null)
                    dataGridViewSales.Columns["PaymentStatus"].HeaderText = "Payment Status";

                if (dataGridViewSales.Columns["SaleDate"] != null)
                    dataGridViewSales.Columns["SaleDate"].HeaderText = "Purchase Date";

                // Hide FarmerID column
                if (dataGridViewSales.Columns["FarmerID"] != null)
                    dataGridViewSales.Columns["FarmerID"].Visible = false;
            }
        }

        private void ClearInputs()
        {
            pnlInvoice.Visible = false;
            rtbInvoicePreview.Clear();
        }

        private void dataGridViewSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewSales.Rows[e.RowIndex].Cells["SaleID"].Value != null)
            {
                selectedSaleId = Convert.ToInt32(dataGridViewSales.Rows[e.RowIndex].Cells["SaleID"].Value);
            }
        }

        private void GenerateInvoicePreview(int saleId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT s.SaleID, s.SaleDate, s.SalePrice, s.Quantity, s.PaymentStatus, s.BuyerType, s.CropType,
                            f.FullName AS FarmerName, f.Email AS FarmerEmail, f.ContactNumber AS FarmerContactNumber, 
                            b.FullName AS BuyerName, b.Email AS BuyerEmail, b.ContactNumber AS BuyerContactNumber
                            FROM Sales s
                            INNER JOIN Users f ON s.FarmerID = f.UserID
                            LEFT JOIN Users b ON s.BuyerID = b.UserID
                            WHERE s.SaleID = @SaleID AND s.BuyerID = @BuyerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SaleID", saleId);
                    cmd.Parameters.AddWithValue("@BuyerID", currentBuyerId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        StringBuilder sb = new StringBuilder();
                        decimal totalAmount = Convert.ToDecimal(reader["SalePrice"]) * Convert.ToDecimal(reader["Quantity"]);
                        string buyerType = reader["BuyerType"].ToString();

                        sb.AppendLine("RICE PRODUCTION SYSTEM");
                        sb.AppendLine("PURCHASE INVOICE");
                        sb.AppendLine("=============================================");
                        sb.AppendLine($"Invoice #: INV-{saleId:D5}");
                        sb.AppendLine($"Date: {Convert.ToDateTime(reader["SaleDate"]):yyyy-MM-dd HH:mm}");
                        sb.AppendLine("=============================================");
                        sb.AppendLine($"\nBUYER INFORMATION ({buyerType.ToUpper()}):");
                        sb.AppendLine($"Name: {reader["BuyerName"]}");
                        if (reader["BuyerContactNumber"] != DBNull.Value) sb.AppendLine($"Contact: {reader["BuyerContactNumber"]}");
                        if (reader["BuyerEmail"] != DBNull.Value) sb.AppendLine($"Email: {reader["BuyerEmail"]}");

                        sb.AppendLine("\nSELLER INFORMATION:");
                        sb.AppendLine($"Name: {reader["FarmerName"]}");
                        if (reader["FarmerContactNumber"] != DBNull.Value) sb.AppendLine($"Contact: {reader["FarmerContactNumber"]}");
                        if (reader["FarmerEmail"] != DBNull.Value) sb.AppendLine($"Email: {reader["FarmerEmail"]}");

                        sb.AppendLine("\n=============================================");
                        sb.AppendLine("TRANSACTION DETAILS:");
                        sb.AppendLine("=============================================");

                        string cropType = reader["CropType"] != DBNull.Value ? reader["CropType"].ToString() : "Rice";
                        sb.AppendLine($"Product: {cropType}");
                        sb.AppendLine($"Price per kg: {Convert.ToDecimal(reader["SalePrice"]):C}");
                        sb.AppendLine($"Quantity: {Convert.ToDecimal(reader["Quantity"]):N2} kg");
                        sb.AppendLine($"Total Amount: {totalAmount:C}");
                        sb.AppendLine($"Payment Status: {reader["PaymentStatus"]}");
                        sb.AppendLine($"Buyer Type: {buyerType}");
                        sb.AppendLine("=============================================");
                        sb.AppendLine("\nThank you for your business!");
                        sb.AppendLine("This is a computer-generated invoice and doesn't require a signature.");
                        rtbInvoicePreview.Text = sb.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invoice data not found or you don't have permission to view this purchase.");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating invoice: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBuyerPurchasesData();
            MessageBox.Show("Data refreshed successfully.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (selectedSaleId == -1 || string.IsNullOrEmpty(rtbInvoicePreview.Text))
            {
                MessageBox.Show("Please generate an invoice first.");
                return;
            }

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Printing functionality would be implemented here.");
                // In a real application, you would implement printing here
                // This would typically use a PrintDocument object
            }
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            if (selectedSaleId == -1 || string.IsNullOrEmpty(rtbInvoicePreview.Text))
            {
                MessageBox.Show("Please generate an invoice first.");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                DefaultExt = "pdf",
                FileName = $"Invoice_{selectedSaleId}_{DateTime.Now:yyyyMMdd}"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileExtension = Path.GetExtension(saveDialog.FileName).ToLower();

                    if (fileExtension == ".pdf")
                    {
                        // Create a PDF using iTextSharp
                        using (FileStream fs = new FileStream(saveDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            Document doc = new Document(PageSize.A4);
                            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                            doc.Open();
                            doc.Add(new Paragraph(rtbInvoicePreview.Text));
                            doc.Close();
                            writer.Close();
                        }
                    }
                    else
                    {
                        // Save as plain text
                        File.WriteAllText(saveDialog.FileName, rtbInvoicePreview.Text);
                    }

                    // Update invoice path in DB
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Invoices SET InvoicePath = @Path WHERE SaleID = @SaleID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Path", saveDialog.FileName);
                            cmd.Parameters.AddWithValue("@SaleID", selectedSaleId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Invoice saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving invoice: {ex.Message}");
                }
            }
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count > 0)
            {
                int saleId = Convert.ToInt32(dataGridViewSales.SelectedRows[0].Cells["SaleID"].Value);
                selectedSaleId = saleId;
                GenerateInvoicePreview(saleId);
                pnlInvoice.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a purchase to generate an invoice.");
            }
        }

        private void BuyPaddy_Load(object sender, EventArgs e)
        {
            // Initialize UI elements
            LoadBuyerInfo();

            // Add purchase history functionality
            dataGridViewSales.CellClick += dataGridViewSales_CellClick;

            // Add invoice-related functionality
            btnGenerateInvoice.Click += btnGenerateInvoice_Click;
            btnSaveInvoice.Click += btnSaveInvoice_Click;
            btnPrintInvoice.Click += btnPrintInvoice_Click;

            // Style data grid views
            StylePurchaseGrid();

            // Load purchase history
            LoadBuyerPurchasesData();

            // Hide invoice panel initially
            pnlInvoice.Visible = false;
        }
    }
}