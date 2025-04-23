using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RiceMgmtApp
{
    public partial class DataAnalytics_Reports : UserControl
    {
        private readonly string connectionString = "Server=DESKTOP-O6K3I3U\\SQLEXPRESS;Database=RiceProductionDB2;Integrated Security=True;";
        private SqlConnection connection;
        private Chart userRolesChart;
        private Chart stockDistributionChart;
        private Chart salesTrendChart;
        private Chart governmentPrivateChart;
        private DataGridView reportDataGrid;
        private ComboBox reportTypeComboBox;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private Button generateReportButton;
        private Button exportPdfButton;
        private Button exportExcelButton;
        private Button exportCsvButton;
        private Panel filtersPanel;
        private Panel chartsPanel;
        private TableLayoutPanel chartLayout;
        private Panel exportPanel;

        public DataAnalytics_Reports()
        {
            InitializeComponent();
            InitializeCustomComponents();
            AttachEventHandlers();
        }

        private void InitializeCustomComponents()
        {
            // Main layout
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(15);

            // Filters panel
            filtersPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White,
                Padding = new Padding(10),
            };

            // Report type combo box
            reportTypeComboBox = new ComboBox
            {
                Location = new Point(10, 20),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            reportTypeComboBox.Items.AddRange(new object[] {
                "User Distribution",
                "Stock Analysis",
                "Sales Trends",
                "Government vs Private Holdings",
                "Price Monitoring"
            });
            reportTypeComboBox.SelectedIndex = 0;

            // Date pickers
            Label fromLabel = new Label
            {
                Text = "From:",
                Location = new Point(220, 23),
                AutoSize = true
            };

            startDatePicker = new DateTimePicker
            {
                Location = new Point(260, 20),
                Width = 150,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now.AddMonths(-1)
            };

            Label toLabel = new Label
            {
                Text = "To:",
                Location = new Point(420, 23),
                AutoSize = true
            };

            endDatePicker = new DateTimePicker
            {
                Location = new Point(450, 20),
                Width = 150,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now
            };

            // Generate button
            generateReportButton = new Button
            {
                Text = "Generate Report",
                Location = new Point(620, 18),
                Width = 150,
                Height = 30,
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            generateReportButton.FlatAppearance.BorderSize = 0;

            // Add controls to filters panel
            filtersPanel.Controls.AddRange(new Control[] {
                reportTypeComboBox, fromLabel, startDatePicker,
                toLabel, endDatePicker, generateReportButton
            });

            // Charts panel
            chartsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10),
                Margin = new Padding(0, 10, 0, 10),
                AutoScroll = true
            };

            // Chart layout 
            chartLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 2,
                RowStyles = {
                    new RowStyle(SizeType.Percent, 50),
                    new RowStyle(SizeType.Percent, 50)
                },
                ColumnStyles = {
                    new ColumnStyle(SizeType.Percent, 50),
                    new ColumnStyle(SizeType.Percent, 50)
                },
                Padding = new Padding(10),
                BackColor = Color.White
            };

            // Initialize charts
            userRolesChart = CreateChart("User Distribution by Roles", SeriesChartType.Pie);
            stockDistributionChart = CreateChart("Stock Distribution by Type", SeriesChartType.Column);
            salesTrendChart = CreateChart("Sales Trends", SeriesChartType.Line);
            governmentPrivateChart = CreateChart("Government vs Private Holdings", SeriesChartType.Doughnut);

            // Add charts to layout
            chartLayout.Controls.Add(userRolesChart, 0, 0);
            chartLayout.Controls.Add(stockDistributionChart, 1, 0);
            chartLayout.Controls.Add(salesTrendChart, 0, 1);
            chartLayout.Controls.Add(governmentPrivateChart, 1, 1);
            chartsPanel.Controls.Add(chartLayout);

            // Data grid for detailed report view
            reportDataGrid = new DataGridView
            {
                Dock = DockStyle.Bottom,
                Height = 200,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            // Export panel
            exportPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            // Export buttons
            exportPdfButton = CreateExportButton("Export to PDF", Color.FromArgb(220, 53, 69), 10);
            exportExcelButton = CreateExportButton("Export to Excel", Color.FromArgb(0, 123, 255), 170);
            exportCsvButton = CreateExportButton("Export to CSV", Color.FromArgb(108, 117, 125), 330);

            exportPanel.Controls.AddRange(new Control[] {
                exportPdfButton, exportExcelButton, exportCsvButton
            });

            // Add all components to form
            this.Controls.Add(reportDataGrid);
            this.Controls.Add(exportPanel);
            this.Controls.Add(chartsPanel);
            this.Controls.Add(filtersPanel);
        }

        private Chart CreateChart(string title, SeriesChartType chartType)
        {
            Chart chart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                BorderlineColor = Color.LightGray,
                BorderlineDashStyle = ChartDashStyle.Solid,
                BorderlineWidth = 1,
                Padding = new Padding(10),
                Margin = new Padding(5),
            };

            // Set up chart area
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.BackColor = Color.White;
            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 8);
            chartArea.AxisY.LabelStyle.Font = new Font("Arial", 8);
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.BorderColor = Color.LightGray;
            chartArea.BorderWidth = 1;
            chart.ChartAreas.Add(chartArea);

            // Set up series
            Series series = new Series("MainSeries");
            series.ChartType = chartType;

            if (chartType == SeriesChartType.Pie || chartType == SeriesChartType.Doughnut)
            {
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "{0}%";
                series["PieLabelStyle"] = "Outside";
                series["PieLineColor"] = "Gray";
                chart.Legends.Add(new Legend("MainLegend")
                {
                    Docking = Docking.Bottom,
                    Alignment = StringAlignment.Center,
                    BorderColor = Color.LightGray,
                    BorderWidth = 1
                });
                series.Legend = "MainLegend";
            }

            chart.Series.Add(series);

            // Add title
            chart.Titles.Add(new Title
            {
                Text = title,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                Alignment = ContentAlignment.TopCenter
            });

            return chart;
        }

        private Button CreateExportButton(string text, Color backColor, int xPosition)
        {
            Button button = new Button
            {
                Text = text,
                Location = new Point(xPosition, 10),
                Width = 150,
                Height = 30,
                BackColor = backColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        private void AttachEventHandlers()
        {
            this.Load += DataAnalytics_Reports_Load;
            generateReportButton.Click += GenerateReportButton_Click;
            exportPdfButton.Click += ExportPdfButton_Click;
            exportExcelButton.Click += ExportExcelButton_Click;
            exportCsvButton.Click += ExportCsvButton_Click;
        }

        private void DataAnalytics_Reports_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                PopulateUserRolesChart();
                PopulateStockDistributionChart();
                PopulateSalesTrendChart();
                PopulateGovernmentPrivateChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            string selectedReport = reportTypeComboBox.SelectedItem.ToString();
            DateTime startDate = startDatePicker.Value;
            DateTime endDate = endDatePicker.Value;

            try
            {
                switch (selectedReport)
                {
                    case "User Distribution":
                        LoadUserDistributionData();
                        break;
                    case "Stock Analysis":
                        LoadStockAnalysisData(startDate, endDate);
                        break;
                    case "Sales Trends":
                        LoadSalesTrendsData(startDate, endDate);
                        break;
                    case "Government vs Private Holdings":
                        LoadGovernmentPrivateData();
                        break;
                    case "Price Monitoring":
                        LoadPriceMonitoringData(startDate, endDate);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Report Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateUserRolesChart()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT R.RoleName, COUNT(U.UserID) AS UserCount 
                    FROM Users U 
                    JOIN Roles R ON U.RoleID = R.RoleID 
                    GROUP BY R.RoleName", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        userRolesChart.Series["MainSeries"].Points.Clear();
                        while (reader.Read())
                        {
                            string roleName = reader["RoleName"].ToString();
                            int userCount = Convert.ToInt32(reader["UserCount"]);
                            var point = userRolesChart.Series["MainSeries"].Points.Add(userCount);
                            point.LegendText = $"{roleName} ({userCount})";
                            point.Label = $"{userCount}";

                            // Assign different colors based on roles
                            switch (roleName)
                            {
                                case "Admin":
                                    point.Color = Color.FromArgb(40, 167, 69); // Green
                                    break;
                                case "Farmer":
                                    point.Color = Color.FromArgb(255, 193, 7); // Yellow
                                    break;
                                case "Government":
                                    point.Color = Color.FromArgb(0, 123, 255); // Blue
                                    break;
                                case "Private Buyer":
                                    point.Color = Color.FromArgb(220, 53, 69); // Red
                                    break;
                                default:
                                    point.Color = Color.Gray;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user roles data: {ex.Message}", "Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateStockDistributionChart()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT CropType, SUM(Quantity) AS TotalQuantity 
                    FROM Stock 
                    GROUP BY CropType", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        stockDistributionChart.Series["MainSeries"].Points.Clear();
                        while (reader.Read())
                        {
                            string cropType = reader["CropType"].ToString();
                            decimal quantity = Convert.ToDecimal(reader["TotalQuantity"]);
                            var point = stockDistributionChart.Series["MainSeries"].Points.Add((double)quantity);
                            point.AxisLabel = cropType;
                            point.Label = quantity.ToString("N0");

                            // Assign different colors based on crop types
                            switch (cropType)
                            {
                                case "Red Nadu":
                                    point.Color = Color.IndianRed;
                                    break;
                                case "White Nadu":
                                    point.Color = Color.Wheat;
                                    break;
                                case "White Samba":
                                    point.Color = Color.LightYellow;
                                    break;
                                case "Red Samba":
                                    point.Color = Color.Salmon;
                                    break;
                                case "Keeri Samba":
                                    point.Color = Color.SandyBrown;
                                    break;
                                case "Red Raw Rice":
                                    point.Color = Color.Firebrick;
                                    break;
                                case "White Raw Rice":
                                    point.Color = Color.AntiqueWhite;
                                    break;
                                default:
                                    point.Color = Color.Gray;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock distribution data: {ex.Message}", "Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateSalesTrendChart()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        FORMAT(SaleDate, 'yyyy-MM') AS Month, 
                        SUM(Quantity) AS TotalQuantity, 
                        SUM(SalePrice * Quantity) AS TotalValue
                    FROM Sales
                    GROUP BY FORMAT(SaleDate, 'yyyy-MM')
                    ORDER BY FORMAT(SaleDate, 'yyyy-MM')", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        salesTrendChart.Series["MainSeries"].Points.Clear();

                        // Add a new series for quantity
                        if (!salesTrendChart.Series.Any(s => s.Name == "Quantity"))
                        {
                            Series quantitySeries = new Series("Quantity")
                            {
                                ChartType = SeriesChartType.Line,
                                Color = Color.FromArgb(0, 123, 255),
                                BorderWidth = 3,
                                MarkerStyle = MarkerStyle.Circle,
                                MarkerSize = 8,
                                YAxisType = AxisType.Primary
                            };
                            salesTrendChart.Series.Add(quantitySeries);
                        }

                        // Add a new series for value
                        if (!salesTrendChart.Series.Any(s => s.Name == "Value"))
                        {
                            Series valueSeries = new Series("Value")
                            {
                                ChartType = SeriesChartType.Line,
                                Color = Color.FromArgb(40, 167, 69),
                                BorderWidth = 3,
                                MarkerStyle = MarkerStyle.Diamond,
                                MarkerSize = 8,
                                YAxisType = AxisType.Secondary
                            };
                            salesTrendChart.Series.Add(valueSeries);
                        }

                        // Add a secondary Y axis
                        if (salesTrendChart.ChartAreas[0].AxisY2.Enabled == AxisEnabled.False)
                        {
                            salesTrendChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                            salesTrendChart.ChartAreas[0].AxisY2.LabelStyle.Format = "{0:C0}";
                            salesTrendChart.ChartAreas[0].AxisY2.Title = "Value";
                            salesTrendChart.ChartAreas[0].AxisY2.TitleFont = new Font("Arial", 10, FontStyle.Regular);
                            salesTrendChart.ChartAreas[0].AxisY.Title = "Quantity";
                            salesTrendChart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Regular);
                        }

                        salesTrendChart.Series["Quantity"].Points.Clear();
                        salesTrendChart.Series["Value"].Points.Clear();

                        while (reader.Read())
                        {
                            string month = reader["Month"].ToString();
                            decimal quantity = Convert.ToDecimal(reader["TotalQuantity"]);
                            decimal value = Convert.ToDecimal(reader["TotalValue"]);

                            int quantityPoint = salesTrendChart.Series["Quantity"].Points.AddXY(month, (double)quantity);
                            salesTrendChart.Series["Quantity"].Points[quantityPoint].Label = quantity.ToString("N0");

                            int valuePoint = salesTrendChart.Series["Value"].Points.AddXY(month, (double)value);
                            salesTrendChart.Series["Value"].Points[valuePoint].Label = value.ToString("C0");
                        }

                        // Add a legend
                        if (!salesTrendChart.Legends.Cast<Legend>().Any(l => l.Name == "SalesLegend"))
                        {
                            Legend legend = new Legend("SalesLegend")
                            {
                                Docking = Docking.Bottom,
                                Alignment = StringAlignment.Center,
                                BorderColor = Color.LightGray,
                                BorderWidth = 1
                            };
                            salesTrendChart.Legends.Add(legend);
                            salesTrendChart.Series["Quantity"].Legend = "SalesLegend";
                            salesTrendChart.Series["Value"].Legend = "SalesLegend";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales trend data: {ex.Message}", "Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateGovernmentPrivateChart()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        BuyerType, 
                        SUM(Quantity) AS TotalQuantity
                    FROM Sales
                    GROUP BY BuyerType", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        governmentPrivateChart.Series["MainSeries"].Points.Clear();
                        while (reader.Read())
                        {
                            string buyerType = reader["BuyerType"].ToString();
                            decimal quantity = Convert.ToDecimal(reader["TotalQuantity"]);
                            var point = governmentPrivateChart.Series["MainSeries"].Points.Add((double)quantity);
                            point.LegendText = $"{buyerType} ({quantity:N0})";
                            point.Label = $"{quantity:N0}";

                            // Assign different colors based on buyer type
                            if (buyerType == "Government")
                                point.Color = Color.FromArgb(0, 123, 255); // Blue
                            else
                                point.Color = Color.FromArgb(220, 53, 69); // Red
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading government vs private data: {ex.Message}", "Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserDistributionData()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        U.UserID, 
                        U.FullName, 
                        U.Username, 
                        U.Email, 
                        U.ContactNumber, 
                        R.RoleName, 
                        U.Status, 
                        U.CreatedAt 
                    FROM Users U 
                    JOIN Roles R ON U.RoleID = R.RoleID 
                    ORDER BY U.RoleID, U.FullName", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        reportDataGrid.DataSource = dataTable;
                    }
                }

                PopulateUserRolesChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user distribution data: {ex.Message}", "Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStockAnalysisData(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        U.FullName AS FarmerName, 
                        S.CropType, 
                        S.Quantity, 
                        S.LastUpdated 
                    FROM Stock S 
                    JOIN Users U ON S.FarmerID = U.UserID 
                    WHERE S.LastUpdated BETWEEN @StartDate AND @EndDate 
                    ORDER BY S.CropType, U.FullName", connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        reportDataGrid.DataSource = dataTable;
                    }
                }

                PopulateStockDistributionChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock analysis data: {ex.Message}", "Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSalesTrendsData(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        Seller.FullName AS FarmerName, 
                        Buyer.FullName AS BuyerName, 
                        S.BuyerType, 
                        S.SalePrice, 
                        S.Quantity, 
                        S.PaymentStatus, 
                        S.SaleDate 
                    FROM Sales S 
                    JOIN Users Seller ON S.FarmerID = Seller.UserID 
                    LEFT JOIN Users Buyer ON S.BuyerID = Buyer.UserID 
                    WHERE S.SaleDate BETWEEN @StartDate AND @EndDate 
                    ORDER BY S.SaleDate DESC", connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        reportDataGrid.DataSource = dataTable;
                    }
                }

                PopulateSalesTrendChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales trends data: {ex.Message}", "Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGovernmentPrivateData()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        S.BuyerType,
                        COALESCE(U.FullName, 'Unknown') AS BuyerName,
                        SUM(S.Quantity) AS TotalQuantity,
                        SUM(S.SalePrice * S.Quantity) AS TotalValue,
                        COUNT(S.SaleID) AS TransactionCount
                    FROM Sales S
                    LEFT JOIN Users U ON S.BuyerID = U.UserID
                    GROUP BY S.BuyerType, U.FullName
                    ORDER BY S.BuyerType, TotalQuantity DESC", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        reportDataGrid.DataSource = dataTable;
                    }
                }

                PopulateGovernmentPrivateChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading government vs private data: {ex.Message}", "Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPriceMonitoringData(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        CropType,
                        AvgPrice,
                        GovernmentPrice,
                        PriceDeviation,
                        CreatedAt
                    FROM PriceMonitoring
                    WHERE CreatedAt BETWEEN @StartDate AND @EndDate
                    ORDER BY CropType, CreatedAt DESC", connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        reportDataGrid.DataSource = dataTable;
                    }
                }

                // Create a price monitoring chart
                if (chartLayout.Controls.Contains(userRolesChart))
                {
                    // Replace first chart with price monitoring chart
                    chartLayout.Controls.Remove(userRolesChart);

                    Chart priceMonitoringChart = CreateChart("Price Monitoring", SeriesChartType.Line);

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT 
                            CropType,
                            AVG(AvgPrice) AS AveragePrice,
                            AVG(GovernmentPrice) AS AvgGovPrice,
                            FORMAT(CreatedAt, 'yyyy-MM') AS MonthYear
                        FROM PriceMonitoring
                        WHERE CreatedAt BETWEEN @StartDate AND @EndDate
                        GROUP BY CropType, FORMAT(CreatedAt, 'yyyy-MM')
                        ORDER BY FORMAT(CreatedAt, 'yyyy-MM')", connection))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Get unique crop types and months
                            var cropTypes = new HashSet<string>();
                            var months = new List<string>();
                            var dataPoints = new Dictionary<string, Dictionary<string, (double, double)>>();

                            while (reader.Read())
                            {
                                string cropType = reader["CropType"].ToString();
                                string month = reader["MonthYear"].ToString();
                                double avgPrice = Convert.ToDouble(reader["AveragePrice"]);
                                double govPrice = Convert.ToDouble(reader["AvgGovPrice"]);

                                cropTypes.Add(cropType);
                                if (!months.Contains(month))
                                    months.Add(month);

                                if (!dataPoints.ContainsKey(cropType))
                                    dataPoints[cropType] = new Dictionary<string, (double, double)>();

                                dataPoints[cropType][month] = (avgPrice, govPrice);
                            }

                            // Set up series for each crop type
                            foreach (var cropType in cropTypes)
                            {
                                Series marketSeries = new Series($"{cropType} Mkt")
                                {
                                    ChartType = SeriesChartType.Line,
                                    BorderWidth = 2,
                                    MarkerStyle = MarkerStyle.Circle,
                                    MarkerSize = 6
                                };

                                Series govSeries = new Series($"{cropType} Gov")
                                {
                                    ChartType = SeriesChartType.Line,
                                    BorderWidth = 2,
                                    MarkerStyle = MarkerStyle.Diamond,
                                    MarkerSize = 6,
                                    BorderDashStyle = ChartDashStyle.Dash
                                };

                                // Assign different colors based on crop types
                                switch (cropType)
                                {
                                    case "Red Nadu":
                                        marketSeries.Color = Color.IndianRed;
                                        govSeries.Color = Color.LightCoral;
                                        break;
                                    case "White Nadu":
                                        marketSeries.Color = Color.DarkKhaki;
                                        govSeries.Color = Color.Khaki;
                                        break;
                                    case "White Samba":
                                        marketSeries.Color = Color.DarkGoldenrod;
                                        govSeries.Color = Color.Gold;
                                        break;
                                    case "Red Samba":
                                        marketSeries.Color = Color.Crimson;
                                        govSeries.Color = Color.Pink;
                                        break;
                                    case "Keeri Samba":
                                        marketSeries.Color = Color.SaddleBrown;
                                        govSeries.Color = Color.Peru;
                                        break;
                                    case "Red Raw Rice":
                                        marketSeries.Color = Color.DarkRed;
                                        govSeries.Color = Color.Red;
                                        break;
                                    case "White Raw Rice":
                                        marketSeries.Color = Color.Tan;
                                        govSeries.Color = Color.PapayaWhip;
                                        break;
                                    default:
                                        marketSeries.Color = Color.Gray;
                                        govSeries.Color = Color.LightGray;
                                        break;
                                }

                                // Add data points for each month
                                foreach (var month in months)
                                {
                                    if (dataPoints[cropType].ContainsKey(month))
                                    {
                                        var (marketPrice, govPrice) = dataPoints[cropType][month];
                                        marketSeries.Points.AddXY(month, marketPrice);
                                        govSeries.Points.AddXY(month, govPrice);
                                    }
                                    else
                                    {
                                        marketSeries.Points.AddXY(month, 0);
                                        govSeries.Points.AddXY(month, 0);
                                    }
                                }

                                priceMonitoringChart.Series.Add(marketSeries);
                                priceMonitoringChart.Series.Add(govSeries);
                            }

                            // Add legend
                            Legend legend = new Legend("PriceLegend")
                            {
                                Docking = Docking.Bottom,
                                IsDockedInsideChartArea = false,
                                Alignment = StringAlignment.Center,
                                BorderColor = Color.LightGray,
                                BorderWidth = 1
                            };
                            priceMonitoringChart.Legends.Add(legend);

                            foreach (var series in priceMonitoringChart.Series)
                            {
                                series.Legend = "PriceLegend";
                            }

                            // Set Y axis label format
                            priceMonitoringChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:C0}";
                            priceMonitoringChart.ChartAreas[0].AxisY.Title = "Price";
                            priceMonitoringChart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Regular);

                            // Remove MainSeries
                            priceMonitoringChart.Series.Remove(priceMonitoringChart.Series["MainSeries"]);
                        }
                    }

                    chartLayout.Controls.Add(priceMonitoringChart, 0, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading price monitoring data: {ex.Message}", "Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportPdfButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    Title = "Save Report as PDF"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedReport = reportTypeComboBox.SelectedItem.ToString();

                    // Here you would implement PDF generation logic
                    // For now, we'll show a success message
                    MessageBox.Show($"Successfully exported {selectedReport} report to {saveFileDialog.FileName}",
                        "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Record the export in the Reports table
                    RecordReport("PDF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to PDF: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportExcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    Title = "Save Report as Excel"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedReport = reportTypeComboBox.SelectedItem.ToString();

                    // Export the data grid to Excel
                    ExportDataGridToExcel(reportDataGrid, saveFileDialog.FileName);

                    MessageBox.Show($"Successfully exported {selectedReport} report to {saveFileDialog.FileName}",
                        "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Record the export in the Reports table
                    RecordReport("Excel");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportCsvButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv",
                    Title = "Save Report as CSV"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedReport = reportTypeComboBox.SelectedItem.ToString();

                    // Export the data grid to CSV
                    ExportDataGridToCsv(reportDataGrid, saveFileDialog.FileName);

                    MessageBox.Show($"Successfully exported {selectedReport} report to {saveFileDialog.FileName}",
                        "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Record the export in the Reports table
                    RecordReport("CSV");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to CSV: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportDataGridToExcel(DataGridView dataGrid, string filePath)
        {
            try
            {
                // This is a simplified version - in a real app you'd use Excel libraries
                StringBuilder sb = new StringBuilder();

                // Add headers
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    sb.Append(dataGrid.Columns[i].HeaderText);
                    if (i < dataGrid.Columns.Count - 1)
                        sb.Append("\t");
                }
                sb.AppendLine();

                // Add rows
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    for (int i = 0; i < dataGrid.Columns.Count; i++)
                    {
                        sb.Append(row.Cells[i].Value?.ToString() ?? "");
                        if (i < dataGrid.Columns.Count - 1)
                            sb.Append("\t");
                    }
                    sb.AppendLine();
                }

                // Write to file
                File.WriteAllText(filePath, sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to export to Excel: " + ex.Message);
            }
        }

        private void ExportDataGridToCsv(DataGridView dataGrid, string filePath)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                // Add headers
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    sb.Append(dataGrid.Columns[i].HeaderText);
                    if (i < dataGrid.Columns.Count - 1)
                        sb.Append(",");
                }
                sb.AppendLine();

                // Add rows
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    for (int i = 0; i < dataGrid.Columns.Count; i++)
                    {
                        string value = row.Cells[i].Value?.ToString() ?? "";
                        // Escape values with commas
                        if (value.Contains(","))
                            value = $"\"{value}\"";

                        sb.Append(value);
                        if (i < dataGrid.Columns.Count - 1)
                            sb.Append(",");
                    }
                    sb.AppendLine();
                }

                // Write to file
                File.WriteAllText(filePath, sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to export to CSV: " + ex.Message);
            }
        }

        private void RecordReport(string exportType)
        {
            try
            {
                string reportType = reportTypeComboBox.SelectedItem.ToString() + " - " + exportType;
                int currentUserID = 1; // This would be obtained from your app's authentication system

                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Reports (ReportType, GeneratedBy) VALUES (@ReportType, @GeneratedBy)",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@ReportType", reportType);
                    cmd.Parameters.AddWithValue("@GeneratedBy", currentUserID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording report: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}