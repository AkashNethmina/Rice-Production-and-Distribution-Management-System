using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Timers;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiceMgmtApp
{
    public partial class Price_Monitoring : UserControl
    {
        private SqlConnection connection;
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int currentUserRoleID;

      
        private const int ROLE_ADMIN = 1;
        private const int ROLE_FARMER = 2;
        private const int ROLE_GOVERNMENT = 3;
        private const int ROLE_PRIVATE_BUYER = 4;

       
        private int selectedPriceID = -1;
        private string selectedCropType = string.Empty;

        public Price_Monitoring(int userRoleID)
        {
            InitializeComponent();
            currentUserRoleID = userRoleID;

           
            connection = new SqlConnection(connectionString);
            
            Load += Price_Monitoring_Load;
        }

        private void Price_Monitoring_Load(object sender, EventArgs e)
        {
            try
            {
              
                LoadCropTypes();

               
                LoadPriceMonitoringData();

               
                ConfigureUIByRole();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing Price Monitoring: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCropTypes()
        {
           
            string[] cropTypes = new string[]
            {
                "Red Nadu",
                "White Nadu",
                "White Samba",
                "Red Samba",
                "Keeri Samba",
                "Red Raw Rice",
                "White Raw Rice"
            };

            comCropType.Items.Clear();
            comCropType.Items.AddRange(cropTypes);

            if (comCropType.Items.Count > 0)
                comCropType.SelectedIndex = 0;

        
            comFilterCrop.Items.Clear();
            comFilterCrop.Items.Add("All");
            comFilterCrop.Items.AddRange(cropTypes);
            comFilterCrop.SelectedIndex = 0; 
        }

        private void LoadPriceMonitoringData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            PriceID, 
                            CropType, 
                            AvgPrice, 
                            GovernmentPrice, 
                            PriceDeviation, 
                            FORMAT(CreatedAt, 'yyyy-MM-dd HH:mm') AS CreatedDate
                        FROM 
                            PriceMonitoring 
                        ORDER BY 
                            CreatedAt DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvPriceMonitoring.DataSource = dt;

                  
                    if (dgvPriceMonitoring.Columns.Contains("PriceID"))
                        dgvPriceMonitoring.Columns["PriceID"].Visible = false;

                   
                    if (dgvPriceMonitoring.Columns.Contains("CropType"))
                        dgvPriceMonitoring.Columns["CropType"].HeaderText = "Crop Type";

                    if (dgvPriceMonitoring.Columns.Contains("AvgPrice"))
                        dgvPriceMonitoring.Columns["AvgPrice"].HeaderText = "Average Price";

                    if (dgvPriceMonitoring.Columns.Contains("GovernmentPrice"))
                        dgvPriceMonitoring.Columns["GovernmentPrice"].HeaderText = "Government Price";

                    if (dgvPriceMonitoring.Columns.Contains("PriceDeviation"))
                        dgvPriceMonitoring.Columns["PriceDeviation"].HeaderText = "Price Deviation";

                    if (dgvPriceMonitoring.Columns.Contains("CreatedDate"))
                        dgvPriceMonitoring.Columns["CreatedDate"].HeaderText = "Created Date";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading price data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comFilterCrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedCrop = comFilterCrop.SelectedItem?.ToString();

               
                if (string.IsNullOrEmpty(selectedCrop) || selectedCrop.ToLower() == "all")
                {
                    LoadPriceMonitoringData();
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT 
                    PriceID, 
                    CropType, 
                    AvgPrice, 
                    GovernmentPrice, 
                    PriceDeviation, 
                    FORMAT(CreatedAt, 'yyyy-MM-dd HH:mm') AS CreatedDate
                FROM 
                    PriceMonitoring 
                WHERE 
                    CropType = @CropType
                ORDER BY 
                    CreatedAt DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CropType", selectedCrop);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvPriceMonitoring.DataSource = dt;

              
                    if (dgvPriceMonitoring.Columns.Contains("PriceID"))
                        dgvPriceMonitoring.Columns["PriceID"].Visible = false;

                    lblStatus.Text = $"Showing price data for {selectedCrop}.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureUIByRole()
        {
           
            bool canEdit = currentUserRoleID == ROLE_ADMIN || currentUserRoleID == ROLE_GOVERNMENT;
            bool isViewOnlyUser = currentUserRoleID == ROLE_FARMER || currentUserRoleID == ROLE_PRIVATE_BUYER;

          
            grpPriceDetails.Visible = !isViewOnlyUser;
            btnAddUpdate.Visible = canEdit;
            btnDelete.Visible = canEdit;
            btnClear.Visible = canEdit;

           
            if (isViewOnlyUser)
            {
                dgvPriceMonitoring.CellClick -= DgvPriceMonitoring_CellClick;

                dgvPriceMonitoring.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPriceMonitoring.ReadOnly = true;
            }
            else
            {
              
                dgvPriceMonitoring.CellClick += DgvPriceMonitoring_CellClick;
                dgvPriceMonitoring.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

         
            if (isViewOnlyUser)
            {
                lblTitle.Text = "Paddy Price Monitoring (View Only)";
            }
            else
            {
                lblTitle.Text = "Paddy Price Monitoring";
            }
        }

        private void DgvPriceMonitoring_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (currentUserRoleID != ROLE_ADMIN && currentUserRoleID != ROLE_GOVERNMENT)
                return;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvPriceMonitoring.Rows[e.RowIndex];

                    selectedPriceID = Convert.ToInt32(row.Cells["PriceID"].Value);
                    selectedCropType = row.Cells["CropType"].Value.ToString();

                
                    comCropType.Text = selectedCropType;

                
                    txtAvgPrice.Text = row.Cells["AvgPrice"].Value.ToString();
                    txtGovtPrice.Text = row.Cells["GovernmentPrice"].Value.ToString();
                    txtPriceDeviation.Text = row.Cells["PriceDeviation"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAddUpdate_Click(object sender, EventArgs e)
        {
          
            if (currentUserRoleID != ROLE_ADMIN && currentUserRoleID != ROLE_GOVERNMENT)
            {
                MessageBox.Show("You do not have permission to modify price data.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (comCropType.SelectedItem == null)
            {
                MessageBox.Show("Please select a crop type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAvgPrice.Text, out decimal avgPrice) || avgPrice <= 0)
            {
                MessageBox.Show("Please enter a valid average price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAvgPrice.Focus();
                return;
            }

            if (!decimal.TryParse(txtGovtPrice.Text, out decimal govtPrice) || govtPrice <= 0)
            {
                MessageBox.Show("Please enter a valid government price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGovtPrice.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd;

                 
                    if (selectedPriceID > 0)
                    {
                       
                        string updateQuery = @"
                            UPDATE PriceMonitoring 
                            SET CropType = @CropType, 
                                AvgPrice = @AvgPrice, 
                                GovernmentPrice = @GovtPrice 
                            WHERE PriceID = @PriceID";

                        cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@PriceID", selectedPriceID);
                    }
                    else
                    {
                      
                        string insertQuery = @"
                            INSERT INTO PriceMonitoring 
                                (CropType, AvgPrice, GovernmentPrice) 
                            VALUES 
                                (@CropType, @AvgPrice, @GovtPrice)";

                        cmd = new SqlCommand(insertQuery, conn);
                    }

                   
                    cmd.Parameters.AddWithValue("@CropType", comCropType.Text);
                    cmd.Parameters.AddWithValue("@AvgPrice", avgPrice);
                    cmd.Parameters.AddWithValue("@GovtPrice", govtPrice);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        lblStatus.Text = selectedPriceID > 0 ?
                            "Price data updated successfully." :
                            "New price data added successfully.";

                     
                        LoadPriceMonitoringData();

                    
                        ClearForm();
                    }
                    else
                    {
                        lblStatus.Text = "Operation failed. No records affected.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error performing operation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
           
            if (currentUserRoleID != ROLE_ADMIN && currentUserRoleID != ROLE_GOVERNMENT)
            {
                MessageBox.Show("You do not have permission to delete price data.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            if (selectedPriceID <= 0)
            {
                MessageBox.Show("Please select a price record to delete.",
                    "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

          
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete the price data for {selectedCropType}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM PriceMonitoring WHERE PriceID = @PriceID";
                        SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@PriceID", selectedPriceID);

                        int affected = cmd.ExecuteNonQuery();

                        if (affected > 0)
                        {
                            lblStatus.Text = "Price data deleted successfully.";

                            LoadPriceMonitoringData();

                     
                            ClearForm();
                        }
                        else
                        {
                            lblStatus.Text = "Delete operation failed. Record may no longer exist.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadPriceMonitoringData();
            lblStatus.Text = "Price data refreshed.";
        }

        private void ClearForm()
        {
            selectedPriceID = -1;
            selectedCropType = string.Empty;

            if (comCropType.Items.Count > 0)
                comCropType.SelectedIndex = 0;

            txtAvgPrice.Text = string.Empty;
            txtGovtPrice.Text = string.Empty;
            txtPriceDeviation.Text = string.Empty;

            lblStatus.Text = "Form cleared.";
        }

       
    }
}