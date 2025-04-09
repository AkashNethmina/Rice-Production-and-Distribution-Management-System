using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;

using System.IO;

namespace RiceMgmtApp
{
    public partial class Fields: UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["RiceMgmtApp.Properties.Settings.RiceProductionDB2ConnectionString"].ConnectionString;
        public Fields()
        {
            InitializeComponent();
            LoadFields();
        }


        private void LoadFields()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT FieldID, FarmerID, LocationCoordinates, FieldSize, SoilCondition, SeasonType, CreatedAt FROM Fields";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvFields.DataSource = dt;

                // Add Edit/Delete buttons if not already added
                if (dgvFields.Columns["Edit"] == null)
                {
                    DataGridViewImageColumn editColumn = new DataGridViewImageColumn();
                    editColumn.Name = "Edit";
                   // editColumn.Image = Properties.Resources.edit_icon; // Add an edit icon to Resources
                    dgvFields.Columns.Add(editColumn);
                }

                if (dgvFields.Columns["Delete"] == null)
                {
                    DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn();
                    deleteColumn.Name = "Delete";
                  //  deleteColumn.Image = Properties.Resources.delete_icon; // Add a delete icon to Resources
                    dgvFields.Columns.Add(deleteColumn);
                }
            }
        }

        private void dgvFields_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int fieldID = Convert.ToInt32(dgvFields.Rows[e.RowIndex].Cells["FieldID"].Value);

                if (dgvFields.Columns[e.ColumnIndex].Name == "Edit")
                {
                    DialogResult result = MessageBox.Show("Do you want to edit this record?", "Edit Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        EditField(fieldID);
                    }
                }

                if (dgvFields.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DeleteField(fieldID);
                        LoadFields(); // Refresh table
                    }
                }
            }
        }

        private void EditField(int fieldID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Fields WHERE FieldID = @FieldID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FieldID", fieldID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string newLocation = Microsoft.VisualBasic.Interaction.InputBox("Enter new location:", "Edit Field", reader["LocationCoordinates"].ToString());
                    decimal newSize = Convert.ToDecimal(Microsoft.VisualBasic.Interaction.InputBox("Enter new size:", "Edit Field", reader["FieldSize"].ToString()));

                    reader.Close();

                    string updateQuery = "UPDATE Fields SET LocationCoordinates=@Loc, FieldSize=@Size WHERE FieldID=@FieldID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@Loc", newLocation);
                    updateCmd.Parameters.AddWithValue("@Size", newSize);
                    updateCmd.Parameters.AddWithValue("@FieldID", fieldID);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Field updated successfully!");
                    LoadFields();
                }
            }
        }

        private void DeleteField(int fieldID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string deleteQuery = "DELETE FROM Fields WHERE FieldID = @FieldID";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@FieldID", fieldID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Field deleted successfully!");
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (dgvFields.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Fields_Report.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Document doc = new Document(PageSize.A4);
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        PdfPTable pdfTable = new PdfPTable(dgvFields.Columns.Count - 2); // Skip Edit & Delete
                        foreach (DataGridViewColumn column in dgvFields.Columns)
                        {
                            if (column.Name != "Edit" && column.Name != "Delete")
                                pdfTable.AddCell(new Phrase(column.HeaderText));
                        }

                        foreach (DataGridViewRow row in dgvFields.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (dgvFields.Columns[cell.ColumnIndex].Name != "Edit" &&
                                    dgvFields.Columns[cell.ColumnIndex].Name != "Delete")
                                {
                                    pdfTable.AddCell(cell.Value?.ToString());
                                }
                            }
                        }

                        doc.Add(pdfTable);
                        doc.Close();

                        MessageBox.Show("Exported Successfully!", "PDF Export");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data to export!", "Export Failed");
            }
        }
    }
}
