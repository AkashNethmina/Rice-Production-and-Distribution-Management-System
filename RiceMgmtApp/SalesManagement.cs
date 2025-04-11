using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class SalesManagement : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";

        public SalesManagement()
        {
            InitializeComponent();
            this.Load += SalesManagement_Load;
        }

        private void SalesManagement_Load(object sender, EventArgs e)
        {
            LoadSalesData();
            LoadFarmerCombo();
            LoadBuyerCombo();

            cmbBuyerType.Items.Clear();
            cmbBuyerType.Items.AddRange(new[] { "Government", "Private" });

            cmbPaymentStatus.Items.Clear();
            cmbPaymentStatus.Items.AddRange(new[] { "Pending", "Completed", "Failed" });

            cmbFarmer.SelectedIndex = -1;
            cmbBuyer.SelectedIndex = -1;
            cmbBuyerType.SelectedIndex = -1;
            cmbPaymentStatus.SelectedIndex = -1;

            StyleSalesGrid();
        }

        private void StyleSalesGrid()
        {
            dataGridViewSales.EnableHeadersVisualStyles = false;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewSales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewSales.DefaultCellStyle.BackColor = Color.White;
            dataGridViewSales.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewSales.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewSales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSales.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dataGridViewSales.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewSales.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewSales.RowTemplate.Height = 28;
            dataGridViewSales.GridColor = Color.LightGray;
            dataGridViewSales.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSales.MultiSelect = false;
            dataGridViewSales.AllowUserToAddRows = false;
            dataGridViewSales.ReadOnly = true;
        }

        private void LoadSalesData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT SaleID, FarmerID, BuyerID, BuyerType, SalePrice, Quantity, PaymentStatus, SaleDate FROM Sales";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewSales.DataSource = dt;
            }
        }

        private void LoadFarmerCombo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, FullName FROM Users WHERE RoleID = 2";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbFarmer.DataSource = dt;
                cmbFarmer.DisplayMember = "FullName";
                cmbFarmer.ValueMember = "UserID";
            }
        }

        private void LoadBuyerCombo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, FullName FROM Users WHERE RoleID = 4";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cmbBuyer.DataSource = dt;
                cmbBuyer.DisplayMember = "FullName";
                cmbBuyer.ValueMember = "UserID";
            }
        }

        private void AddSale()
        {
            if (!ValidateInputs()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Sales (FarmerID, BuyerID, BuyerType, SalePrice, Quantity, PaymentStatus, SaleDate)
                                 VALUES (@FarmerID, @BuyerID, @BuyerType, @SalePrice, @Quantity, @PaymentStatus, @SaleDate)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FarmerID", cmbFarmer.SelectedValue);
                    cmd.Parameters.AddWithValue("@BuyerID", cmbBuyer.SelectedValue ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BuyerType", cmbBuyerType.Text);
                    cmd.Parameters.AddWithValue("@SalePrice", decimal.Parse(txtSalePrice.Text));
                    cmd.Parameters.AddWithValue("@Quantity", decimal.Parse(txtQuantity.Text));
                    cmd.Parameters.AddWithValue("@PaymentStatus", cmbPaymentStatus.Text);
                    cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sale added successfully!");
                }
                LoadSalesData();
                ClearInputs();
            }
        }

        private void UpdateSale(int saleId)
        {
            if (!ValidateInputs()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Sales 
                                 SET FarmerID = @FarmerID, BuyerID = @BuyerID, BuyerType = @BuyerType,
                                     SalePrice = @SalePrice, Quantity = @Quantity, PaymentStatus = @PaymentStatus
                                 WHERE SaleID = @SaleID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SaleID", saleId);
                    cmd.Parameters.AddWithValue("@FarmerID", cmbFarmer.SelectedValue);
                    cmd.Parameters.AddWithValue("@BuyerID", cmbBuyer.SelectedValue ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@BuyerType", cmbBuyerType.Text);
                    cmd.Parameters.AddWithValue("@SalePrice", decimal.Parse(txtSalePrice.Text));
                    cmd.Parameters.AddWithValue("@Quantity", decimal.Parse(txtQuantity.Text));
                    cmd.Parameters.AddWithValue("@PaymentStatus", cmbPaymentStatus.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sale updated successfully!");
                }
                LoadSalesData();
                ClearInputs();
            }
        }

        private void DeleteSale(int saleId)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this sale?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Sales WHERE SaleID = @SaleID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SaleID", saleId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sale deleted successfully!");
                }
                LoadSalesData();
                ClearInputs();
            }
        }

        private void SearchSales(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Sales 
                                 WHERE CAST(SaleID AS NVARCHAR) LIKE @Keyword 
                                 OR PaymentStatus LIKE @Keyword";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewSales.DataSource = dt;
            }
        }

        private bool ValidateInputs()
        {
            if (cmbFarmer.SelectedIndex == -1 || cmbBuyer.SelectedIndex == -1 || cmbBuyerType.SelectedIndex == -1 || cmbPaymentStatus.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtSalePrice.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return false;
            }

            if (!decimal.TryParse(txtSalePrice.Text, out _) || !decimal.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("Sale Price and Quantity must be valid numbers.");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            cmbFarmer.SelectedIndex = -1;
            cmbBuyer.SelectedIndex = -1;
            cmbBuyerType.SelectedIndex = -1;
            cmbPaymentStatus.SelectedIndex = -1;
            txtSalePrice.Clear();
            txtQuantity.Clear();
        }

        // Event handlers
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSale();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count > 0)
            {
                int saleId = Convert.ToInt32(dataGridViewSales.SelectedRows[0].Cells["SaleID"].Value);
                UpdateSale(saleId);
            }
            else
            {
                MessageBox.Show("Please select a sale to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count > 0)
            {
                int saleId = Convert.ToInt32(dataGridViewSales.SelectedRows[0].Cells["SaleID"].Value);
                DeleteSale(saleId);
            }
            else
            {
                MessageBox.Show("Please select a sale to delete.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchSales(txtSearch.Text);
        }

        private void dataGridViewSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewSales.Rows[e.RowIndex].Cells["SaleID"].Value != null)
            {
                DataGridViewRow row = dataGridViewSales.Rows[e.RowIndex];

                cmbFarmer.SelectedValue = row.Cells["FarmerID"].Value;
                cmbBuyer.SelectedValue = row.Cells["BuyerID"].Value;
                cmbBuyerType.Text = row.Cells["BuyerType"].Value?.ToString();
                txtSalePrice.Text = row.Cells["SalePrice"].Value?.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value?.ToString();
                cmbPaymentStatus.Text = row.Cells["PaymentStatus"].Value?.ToString();
            }
        }

        private void txtSalePrice_TextChanged(object sender, EventArgs e)
        {
            // Optional: live validation or calculation can go here
        }
    }
}
