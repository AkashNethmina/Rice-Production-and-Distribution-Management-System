using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace RiceMgmtApp
{
    public partial class AdminDashboard : Form
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";

        public AdminDashboard(string log)
        {
            InitializeComponent();
            LoadDashboardData();
            CustomizeDashboard();
        }

        private void CustomizeDashboard()
        {
            panelDashboard.Visible = true;
            panelUsers.Visible = false;
            panelFarmers.Visible = false;
            panelSales.Visible = false;
        }

        private void HideSubMenu()
        {
            if (panel2submenu.Visible)
                panel2submenu.Visible = false;
            if (panel3side.Visible)
                panel3side.Visible = false;
        }

        private void ShowSection(Panel panel)
        {
            panelDashboard.Visible = false;
            panelUsers.Visible = false;
            panelFarmers.Visible = false;
            panelSales.Visible = false;

            panel.Visible = true;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    lblTotalUsers.Text = ExecuteScalarQuery(conn, "SELECT COUNT(*) FROM Users");
                    lblTotalFarmers.Text = ExecuteScalarQuery(conn, "SELECT COUNT(*) FROM Users WHERE RoleID = (SELECT RoleID FROM Roles WHERE RoleName = 'Farmer')");
                    lblTotalSales.Text = ExecuteScalarQuery(conn, "SELECT COUNT(*) FROM Sales");
                    lblPendingReports.Text = ExecuteScalarQuery(conn, "SELECT COUNT(*) FROM DamageReports WHERE Status = 'Pending'");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message);
            }
        }

        private string ExecuteScalarQuery(SqlConnection conn, string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                return cmd.ExecuteScalar()?.ToString() ?? "0";
            }
        }

        private void LoadUserManagement()
        {
            panelUsers.Controls.Clear();

            DataGridView dgvUsers = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            panelUsers.Controls.Add(dgvUsers);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(@"
                        SELECT u.UserID, u.Username, u.Email, u.ContactNumber, r.RoleName, u.Status, u.CreatedAt
                        FROM Users u
                        JOIN Roles r ON u.RoleID = r.RoleID", conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvUsers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message);
            }

            // Add control buttons
            Button btnAdd = new Button { Text = "Add User", Dock = DockStyle.Top };
            btnAdd.Click += btn_AddUsers_Click;

            Button btnEdit = new Button { Text = "Edit User", Dock = DockStyle.Top };
            // btnEdit.Click += BtnEdit_Click; // Future implementation

            Button btnSuspend = new Button { Text = "Suspend/Activate", Dock = DockStyle.Top };
            // btnSuspend.Click += BtnSuspend_Click; // Future implementation

            panelUsers.Controls.Add(btnSuspend);
            panelUsers.Controls.Add(btnEdit);
            panelUsers.Controls.Add(btnAdd);
        }

        private void LoadFarmerManagement()
        {
            panelFarmers.Controls.Clear();

            DataGridView dgvFarmers = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            panelFarmers.Controls.Add(dgvFarmers);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(@"
                        SELECT u.UserID, u.Username, u.Email, u.ContactNumber, f.FarmSize, f.Location, u.Status
                        FROM Users u
                        JOIN Farmers f ON u.UserID = f.UserID
                        WHERE u.RoleID = (SELECT RoleID FROM Roles WHERE RoleName = 'Farmer')", conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvFarmers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading farmer data: " + ex.Message);
            }

            // Add control buttons for farmer management if needed
            Button btnAddFarmer = new Button { Text = "Add Farmer", Dock = DockStyle.Top };
            // btnAddFarmer.Click += BtnAddFarmer_Click; // Future implementation

            Button btnEditFarmer = new Button { Text = "Edit Farmer", Dock = DockStyle.Top };
            // btnEditFarmer.Click += BtnEditFarmer_Click; // Future implementation

            panelFarmers.Controls.Add(btnEditFarmer);
            panelFarmers.Controls.Add(btnAddFarmer);
        }

        private void LoadSalesManagement()
        {
            panelSales.Controls.Clear();

            DataGridView dgvSales = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            panelSales.Controls.Add(dgvSales);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(@"
                        SELECT s.SaleID, u.Username AS Farmer, p.ProductName, s.Quantity, s.TotalAmount, s.SaleDate
                        FROM Sales s
                        JOIN Users u ON s.FarmerID = u.UserID
                        JOIN Products p ON s.ProductID = p.ProductID", conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvSales.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message);
            }

            // Add control buttons for sales management
            Button btnAddSale = new Button { Text = "Add Sale", Dock = DockStyle.Top };
            // btnAddSale.Click += BtnAddSale_Click; // Future implementation

            Button btnSalesReport = new Button { Text = "Generate Report", Dock = DockStyle.Top };
            // btnSalesReport.Click += BtnSalesReport_Click; // Future implementation

            panelSales.Controls.Add(btnSalesReport);
            panelSales.Controls.Add(btnAddSale);
        }

        // Navigation Event Handlers
        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            ShowSection(panelDashboard);
            HideSubMenu();
            LoadDashboardData(); // Refresh dashboard data
        }

        private void btn_manUser_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel2submenu);
        }

        private void btn_AllUsers_Click(object sender, EventArgs e)
        {
            LoadUserManagement();
            ShowSection(panelUsers); // Make sure to show the panel after loading data
        }

        private void btn_Farmers_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel3side);
        }

        private void btn_FarmersList_Click(object sender, EventArgs e)
        {
            LoadFarmerManagement();
            ShowSection(panelFarmers); // Make sure to show the panel after loading data
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            LoadSalesManagement();
            ShowSection(panelSales); // Make sure to show the panel after loading data
            HideSubMenu();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            frm_login fl = new frm_login();
            fl.Show();
            this.Hide();
        }

        private void btn_AddUsers_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(); // Assuming this is another form
            addUser.ShowDialog();
            LoadUserManagement(); // Refresh list after adding
            ShowSection(panelUsers); // Ensure panel stays visible
        }

        private void btn_Fields_Click(object sender, EventArgs e)
        {
            // Implement fields management
            MessageBox.Show("Fields management feature coming soon.");
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'riceProductionDB2DataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.riceProductionDB2DataSet.Users);

        }
    }
}
