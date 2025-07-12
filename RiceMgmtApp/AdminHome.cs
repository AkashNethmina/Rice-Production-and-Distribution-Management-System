using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Office.Interop.Excel;

namespace RiceMgmtApp
{
    public partial class AdminHome : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private int totalUsers = 0;
        private int adminCount = 0;
        private int farmerCount = 0;
        private int governmentCount = 0;
        private int privateBuyerCount = 0;

        private Dictionary<string, int> roleCounts = new Dictionary<string, int>();

        private Dictionary<string, decimal> stockByType = new Dictionary<string, decimal>();

        private Dictionary<string, decimal> salesByMonth = new Dictionary<string, decimal>();

        public AdminHome()
        {
            InitializeComponent();
            this.Load += AdminHome_Load;
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            LoadUserStatistics();
            SetupSalesChart();
            SetupStockChart();
        }

        private void LoadUserStatistics()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            r.RoleName, 
                            COUNT(u.UserID) as UserCount
                        FROM 
                            Users u
                        JOIN 
                            Roles r ON u.RoleID = r.RoleID
                        GROUP BY 
                            r.RoleName, r.RoleID
                        ORDER BY 
                            r.RoleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string roleName = reader["RoleName"].ToString();
                                int count = Convert.ToInt32(reader["UserCount"]);

                              
                                roleCounts[roleName] = count;

                               
                                switch (roleName)
                                {
                                    case "Admin":
                                        adminCount = count;
                                        break;
                                    case "Farmer":
                                        farmerCount = count;
                                        break;
                                    case "Government":
                                        governmentCount = count;
                                        break;
                                    case "Private Buyer":
                                        privateBuyerCount = count;
                                        break;
                                }

                                totalUsers += count;
                            }
                        }
                    }
                }

              
                UpdateUserStatisticsDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user statistics: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUserStatisticsDisplay()
        {
            lblTotalUsers.Text = totalUsers.ToString();
            lblAdminCount.Text = adminCount.ToString();
            lblFarmerCount.Text = farmerCount.ToString();
            lblGovernmentCount.Text = governmentCount.ToString();
            lblPrivateBuyerCount.Text = privateBuyerCount.ToString();
        }

        private void SetupSalesChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                
                    string query = @"
                        SELECT 
                            FORMAT(SaleDate, 'yyyy-MM') as Month,
                            SUM(SalePrice * Quantity) as TotalSales
                        FROM 
                            Sales
                        GROUP BY 
                            FORMAT(SaleDate, 'yyyy-MM')
                        ORDER BY 
                            Month";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string month = reader["Month"].ToString();
                                decimal totalSales = Convert.ToDecimal(reader["TotalSales"]);

                                salesByMonth[month] = totalSales;
                            }
                        }
                    }
                }

             
                chartSales.Series.Clear();
                chartSales.ChartAreas.Clear();

              
                System.Windows.Forms.DataVisualization.Charting.ChartArea salesChartArea =
                    new System.Windows.Forms.DataVisualization.Charting.ChartArea("SalesChartArea");
                chartSales.ChartAreas.Add(salesChartArea);

             
                System.Windows.Forms.DataVisualization.Charting.Series salesSeries =
                    new System.Windows.Forms.DataVisualization.Charting.Series("Sales");

                foreach (var entry in salesByMonth)
                {
                    salesSeries.Points.AddXY(entry.Key, entry.Value);
                }

                chartSales.Series.Add(salesSeries);
                chartSales.Titles.Add(new Title("Monthly Sales", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

              
                salesChartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
                salesChartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                salesChartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 9);
                salesChartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 9);

              
                salesChartArea.AxisX.LabelStyle.Angle = -45;
                salesChartArea.AxisX.LabelStyle.IsStaggered = false;
                salesChartArea.AxisX.MajorGrid.Enabled = false;

            
                salesSeries.Color = Color.FromArgb(52, 152, 219);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales chart: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupStockChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            CropType,
                            SUM(Quantity) as TotalQuantity
                        FROM 
                            Stock
                        GROUP BY 
                            CropType
                        ORDER BY 
                            TotalQuantity DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string cropType = reader["CropType"].ToString();
                                decimal quantity = Convert.ToDecimal(reader["TotalQuantity"]);

                                stockByType[cropType] = quantity;
                            }
                        }
                    }
                }

                chartStock.Series.Clear();
                chartStock.ChartAreas.Clear();
                chartStock.Legends.Clear();
                chartStock.Titles.Clear();

                System.Windows.Forms.DataVisualization.Charting.ChartArea stockChartArea =
                    new System.Windows.Forms.DataVisualization.Charting.ChartArea("StockChartArea");
                chartStock.ChartAreas.Add(stockChartArea);

                System.Windows.Forms.DataVisualization.Charting.Series stockSeries =
                    new System.Windows.Forms.DataVisualization.Charting.Series("Stock");

                stockSeries.ChartType = SeriesChartType.Pie;

                foreach (var entry in stockByType)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueXY(entry.Key, entry.Value);
                    point.LegendText = entry.Key;
                    point.Label = "#PERCENT{P0}";
                    stockSeries.Points.Add(point);
                }

                chartStock.Series.Add(stockSeries);
                chartStock.Titles.Add(new Title("System-wide Stock by Crop Type", Docking.Top, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Color.Black));

                System.Windows.Forms.DataVisualization.Charting.Legend stockLegend =
                    new System.Windows.Forms.DataVisualization.Charting.Legend("StockLegend");
                chartStock.Legends.Add(stockLegend);
                stockSeries.Legend = "StockLegend";

                stockSeries.Palette = ChartColorPalette.BrightPastel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stock chart: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
          
            totalUsers = 0;
            adminCount = 0;
            farmerCount = 0;
            governmentCount = 0;
            privateBuyerCount = 0;
            roleCounts.Clear();
            stockByType.Clear();
            salesByMonth.Clear();

           
            chartSales.Titles.Clear();
            chartStock.Titles.Clear();

            
            LoadUserStatistics();
            SetupSalesChart();
            SetupStockChart();

            MessageBox.Show("Dashboard data has been refreshed.", "Refresh Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      
        public void RefreshDashboard()
        {
            totalUsers = 0;
            adminCount = 0;
            farmerCount = 0;
            governmentCount = 0;
            privateBuyerCount = 0;
            roleCounts.Clear();
            stockByType.Clear();
            salesByMonth.Clear();

            LoadUserStatistics();
            SetupSalesChart();
            SetupStockChart();
        }
    }
}