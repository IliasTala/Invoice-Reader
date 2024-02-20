using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataEncode
{
    public partial class FormClientData : Form
    {
        //Déclarations
        private string dataTableName = "MaTable";
        //Déclaration d'un ToolTip pour afficher un texte sur un bouton 
        private ToolTip toolTip = new ToolTip();
        public FormClientData()
        {
            InitializeComponent();
            //Assignation des toolTip à son bouton 
            toolTip.SetToolTip(this.buttonExportClientFinancialOverview, "Export into an Excel file all datas.");
            toolTip.SetToolTip(this.buttonUploadMargeAndCodeFocus, "Update the code focus and the margin in the database.");
            toolTip.SetToolTip(this.btnExportClientData, "Export into an Excel file all datas per client.");
            toolTip.SetToolTip(this.buttonDeleteLastUpdate, "Delete the last upload you did in the database.");

            //Personnalisation des panels
            panel3.Paint += CustomBorderPaintPanel;
            panel1.Paint += CustomBorderPaintPanel;

            this.Load += new System.EventHandler(this.FormClientData_Load);
            this.FormClosed += (s, args) => Application.Exit();

        }

        private void FormClientData_Load(object sender, EventArgs e)
        {
            LoadUniqueMonths();
            LoadCustomerNamesIntoComboBox();
        }
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Système de navigation - MenuToolStrip                                 //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMainMenu homeMenu = new FormMainMenu();
            this.Hide();
            homeMenu.Show();
        }
        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImportData formImportData = new FormImportData();
            this.Hide();
            formImportData.Show();
        }
        private void viewStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStatistics formStatistics = new FormStatistics();
            this.Hide();
            formStatistics.Show();
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataBase formDatabase = new FormDataBase();
            this.Hide();
            formDatabase.Show();
        }
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Système de tri                                                        //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////

        private void LoadCustomerNamesIntoComboBox()
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";


            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT CustomerName FROM MaTable", connection))
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBoxCustomerNames.Items.Add(reader["CustomerName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer names: " + ex.Message);
            }
        }

        private void LoadCustomerDetails(string customerName)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";


            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM MaTable WHERE CustomerName = ?";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        // Utilisez "?" pour les paramètres dans OleDb et ajoutez-les ensuite
                        adapter.SelectCommand.Parameters.Add("@CustomerName", OleDbType.VarChar).Value = customerName;
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);



                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer details: " + ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Système d'export                                                      //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////

        private void ExportClientsToCSV()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string csvDirectory = Path.Combine(desktopPath, "ClientCSVs");

            if (!Directory.Exists(csvDirectory))
            {
                Directory.CreateDirectory(csvDirectory);
            }

            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    using (OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT CustomerId, CustomerName FROM MaTable", connection))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string customerId = reader["CustomerId"].ToString();
                                string customerName = reader["CustomerName"].ToString();
                                string safeCustomerName = string.Join("_", customerName.Split(Path.GetInvalidFileNameChars()));
                                string customerDirectory = Path.Combine(csvDirectory, safeCustomerName);

                                if (!Directory.Exists(customerDirectory))
                                {
                                    Directory.CreateDirectory(customerDirectory);
                                }

                                string detailsQuery = @"
                            SELECT 
                                IIF(ISNULL(ProductName) OR ProductName = '', SubscriptionDescription, ProductName) AS ProductOrSubscription, 
                                Quantity, UnitPrice, SubTotal, Date 
                            FROM 
                                MaTable 
                            WHERE 
                                CustomerId = ? 
                            ORDER BY 
                                Date";

                                using (OleDbCommand detailsCmd = new OleDbCommand(detailsQuery, connection))
                                {
                                    detailsCmd.Parameters.AddWithValue("@CustomerId", customerId);

                                    using (OleDbDataReader detailsReader = detailsCmd.ExecuteReader())
                                    {
                                        Dictionary<string, StreamWriter> monthlyFiles = new Dictionary<string, StreamWriter>();

                                        while (detailsReader.Read())
                                        {
                                            DateTime chargeStartDate = (DateTime)detailsReader["Date"];
                                            string monthYear = chargeStartDate.ToString("yyyy_MM");
                                            string csvPath = Path.Combine(customerDirectory, $"{safeCustomerName}_{monthYear}.csv");

                                            if (!monthlyFiles.ContainsKey(monthYear))
                                            {
                                                monthlyFiles[monthYear] = new StreamWriter(csvPath, false); // Overwrite the existing file
                                                monthlyFiles[monthYear].WriteLine("Product;Quantity;UnitPrice;Total;Date"); // Write the header
                                            }

                                            string productOrSubscription = detailsReader["ProductOrSubscription"].ToString();
                                            string quantity = detailsReader["Quantity"].ToString();
                                            string unitPrice = detailsReader["UnitPrice"].ToString();
                                            string totalAmount = detailsReader["SubTotal"].ToString();

                                            monthlyFiles[monthYear].WriteLine($"{productOrSubscription};{quantity};{unitPrice};{totalAmount};{chargeStartDate:yyyy-MM-dd}");
                                        }

                                        // Close all file streams
                                        foreach (var file in monthlyFiles.Values)
                                        {
                                            file.Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Export Data Clients successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to CSV: {ex.Message}");
            }
        }
        private void ExportDataToCSV()
        {
            // Vérifier si une date est sélectionnée dans le ComboBox
            if (comboBoxDate.SelectedItem == null)
            {
                MessageBox.Show("Please select a month and year before exporting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Arrêter l'exécution si aucune date n'est sélectionnée
            }

            string selectedMonthYear = comboBoxDate.SelectedItem.ToString();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string monthYearFormatted = DateTime.ParseExact(selectedMonthYear, "MMMM yyyy", CultureInfo.CurrentCulture).ToString("yyyy_MM");
            string csvFilePath = Path.Combine(desktopPath, $"ExportedData_{monthYearFormatted}.csv");

            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    using (StreamWriter sw = new StreamWriter(csvFilePath, false))
                    {
                        sw.WriteLine("Customer;Focus;Purchase VAT;Rebilling VAT Excl.;Margin");

                        string query = $@"
                    SELECT 
                        CustomerName,
                        CodeFocus,
                        Marge,
                        SUM(Quantity * UnitPrice) AS PurchaseVAT
                    FROM 
                        MaTable
                    WHERE 
                        FORMAT(Date, 'mmmm yyyy') = ?
                    GROUP BY 
                        CustomerName, CodeFocus, Marge";

                        using (OleDbCommand cmd = new OleDbCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("?", selectedMonthYear);

                            using (OleDbDataReader reader = cmd.ExecuteReader())
                            {
                                bool allClientsHaveData = true;

                                while (reader.Read())
                                {
                                    string customer = reader["CustomerName"].ToString();
                                    string codeFocus = reader["CodeFocus"].ToString();
                                    string margeString = reader["Marge"].ToString();
                                    string purchaseVAT = Convert.ToDouble(reader["PurchaseVAT"]).ToString("0.##");


                                    if (string.IsNullOrEmpty(codeFocus) || string.IsNullOrEmpty(margeString))
                                    {
                                        allClientsHaveData = false;
                                        break;
                                    }

                                    double margeValue = double.TryParse(margeString, out double margeDecimal) ? margeDecimal / 100.0 : 0.0;
                                    double inverseMargin = 1 - margeValue;
                                    double rebillingVatAdjusted;
                                    if (double.TryParse(purchaseVAT, out double purchaseVatValue) && inverseMargin != 0)
                                    {
                                        rebillingVatAdjusted = purchaseVatValue / inverseMargin;
                                    }
                                    else
                                    {
                                        rebillingVatAdjusted = 0.0;
                                    }

                                    string formattedRebillingVatAdjusted = rebillingVatAdjusted.ToString("0.##");


                                    sw.WriteLine($"\"{customer}\";\"{codeFocus}\";{purchaseVAT};{rebillingVatAdjusted:0.##};\"{margeString + "%"}\"");
                                }

                                if (!allClientsHaveData)
                                {
                                    MessageBox.Show("Not all clients have a CodeFocus and Marge. Please update the data before exporting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                    MessageBox.Show("Export Data successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Système d'affichage de la base de donnée                              //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////

        private string GetDatabasePath()
        {
            // Chemin du bureau de l'utilisateur
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Chemin complet du fichier de base de données
            string dbFilePath = Path.Combine(desktopPath, "Database", "DatabaseDataEncode.accdb");

            return dbFilePath;
        }
        private int GetLastUploadedMergeId()
        {
            if (TableExists(dataTableName))
            {
                string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    using (OleDbCommand cmd = new OleDbCommand("SELECT MAX(IdMerge) FROM MaTable;", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            // Aucun enregistrement trouvé
                            return 0; // ou une valeur qui indique qu'aucun enregistrement n'a été trouvé
                        }
                    }
                }
            }
            return 0;
        }

        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Vérification si une table existe                                      //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////

        private bool TableExists(string tableName)
        {

            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Récupérer la liste des tables
                DataTable schema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                // Vérifier si la table existe
                foreach (DataRow row in schema.Rows)
                {
                    string tableNameInDatabase = row["TABLE_NAME"].ToString();
                    if (tableNameInDatabase.Equals(tableName, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

                return false;
            }
        }


        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Suppression de tous les records qui possèdents un id merge e()        //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////

        private void DeleteRecordsByMergeId()
        {
            if (GetLastUploadedMergeId() == 0)
            {
                return;
            }
            else
            {
                string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    using (OleDbCommand cmd = new OleDbCommand($"DELETE FROM MaTable WHERE IdMerge = {GetLastUploadedMergeId()};", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }

        private void UploadMargeAndCodeFocus(string customerName, string codeFocus, string marge)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Construire la requête d'insertion
                    string query = "UPDATE MaTable SET CodeFocus = ?, Marge = ? WHERE CustomerName = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // Ajouter les paramètres avec leurs valeurs
                        cmd.Parameters.AddWithValue("@CodeFocus", codeFocus);
                        cmd.Parameters.AddWithValue("@Marge", marge);
                        cmd.Parameters.AddWithValue("@CustomerName", customerName);

                        // Exécuter la commande
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data upload successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uploading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //                    GESTION DE LA DATE                                //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void comboBoxCustomerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCustomerNames.SelectedItem != null)
            {
                string selectedCustomerName = comboBoxCustomerNames.SelectedItem.ToString();
                LoadCustomerDetails(selectedCustomerName);
            }
        }
        private void comboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDate.SelectedItem != null)
            {
                string selectedMonthYear = comboBoxDate.SelectedItem.ToString();
                LoadProductStatsForMonth(selectedMonthYear);
            }
        }
        private void LoadProductStatsForMonth(string monthYear)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";
            DataTable statsTable = new DataTable();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    IIF(ISNULL(OfferName) OR OfferName = '', ProductName, OfferName) AS Product, 
                    SUM(SubTotal) AS Purchase
                FROM 
                    MaTable
                WHERE 
                    FORMAT(ChargeStartDate, 'mmmm yyyy') = ?
                GROUP BY 
                    IIF(ISNULL(OfferName) OR OfferName = '', ProductName, OfferName)";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", monthYear);

                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                        {
                            adapter.Fill(statsTable);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product stats: " + ex.Message);
            }
        }
        private void LoadUniqueMonths()
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    Format(Date,'mmmm yyyy') AS MonthYear
                FROM 
                    MaTable
                GROUP BY 
                    Format(Date,'mmmm yyyy')
                ORDER BY 
                    MIN(Date)";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string monthYear = reader["MonthYear"].ToString();
                                // Capitalize the first letter of each word
                                monthYear = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(monthYear.ToLower());
                                comboBoxDate.Items.Add(monthYear);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading unique months: " + ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Gestion des boutons                                                   //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void buttonExportClientFinancialOverview_Click(object sender, EventArgs e)
        {
            ExportDataToCSV();
        }

        private void btnExportClientData_Click(object sender, EventArgs e)
        {

            ExportClientsToCSV();
        }

        private void buttonDeleteLastUpdate_Click(object sender, EventArgs e)
        {
            int lastMergeId = GetLastUploadedMergeId();
            if (lastMergeId > 0)
            {
                DeleteRecordsByMergeId();
                MessageBox.Show("The last file upload has been successfully deleted.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is no file upload to delete.", "Delete Not Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void buttonUploadMargeAndCodeFocus_Click(object sender, EventArgs e)
        {
            // Vérifier si un client est sélectionné dans le comboBoxCustomerNames
            if (comboBoxCustomerNames.SelectedItem != null)
            {
                string selectedCustomerName = comboBoxCustomerNames.SelectedItem.ToString();

                // Vérifier si les zones de texte ne sont pas vides
                if (!string.IsNullOrWhiteSpace(textBoxCodeFocus.Text) && !string.IsNullOrWhiteSpace(textBoxMarge.Text))
                {
                    // Récupérer les valeurs des zones de texte
                    string codeFocus = textBoxCodeFocus.Text;
                    string marge = textBoxMarge.Text;

                    // Appeler la méthode pour insérer les données dans la base de données
                    UploadMargeAndCodeFocus(selectedCustomerName, codeFocus, marge);

                    // Rafraîchir les détails du client
                    LoadCustomerDetails(selectedCustomerName);

                    //Rafraichir les profits
                    AddProfitColumnAndUpdateValues();
                    AddProfitNetColumnAndUpdateValues();
                }
                else
                {
                    MessageBox.Show("Please enter values for CodeFocus and Marge.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer from the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void AddProfitColumnAndUpdateValues()
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Vérifier si la colonne 'Profit' existe
                    DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, "MaTable", "Profit" });
                    if (schema.Rows.Count == 0)
                    {
                        // Créer la colonne 'Profit' car elle n'existe pas
                        using (OleDbCommand cmd = new OleDbCommand("ALTER TABLE MaTable ADD COLUMN Profit CURRENCY;", connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Mettre à jour la colonne 'Profit' pour tous les enregistrements
                    string updateQuery = @"
                UPDATE MaTable
                SET Profit = SubTotal / (1 - (IIF(ISNULL(Marge), 0, Marge) / 100.0))
            ";
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, connection))
                    {
                        updateCmd.ExecuteNonQuery();
                    }

                    //   MessageBox.Show("Profit column added and values updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddProfitNetColumnAndUpdateValues()
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Vérifier si la colonne 'ProfitNet' existe
                    DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, "MaTable", "ProfitNet" });
                    if (schema.Rows.Count == 0)
                    {
                        // Créer la colonne 'ProfitNet' car elle n'existe pas
                        using (OleDbCommand cmd = new OleDbCommand("ALTER TABLE MaTable ADD COLUMN ProfitNet CURRENCY;", connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Mettre à jour la colonne 'ProfitNet' pour tous les enregistrements
                    // Assurez-vous que la colonne 'Profit' a été créée et mise à jour avant d'exécuter cette mise à jour
                    string updateQuery = @"
                UPDATE MaTable
                SET ProfitNet = Profit - SubTotal
            ";
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, connection))
                    {
                        updateCmd.ExecuteNonQuery();
                    }

                    //  MessageBox.Show("ProfitNet column added and values updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomBorderPaintPanel(object sender, PaintEventArgs e)
        {
            Panel currentPanel = sender as Panel;
            Color myCustomColor = Color.FromArgb(255, 125, 8);
            if (currentPanel != null && currentPanel.BorderStyle == BorderStyle.FixedSingle)
            {
                int thickness = 2;
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(myCustomColor, thickness))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                              halfThickness,
                                                              currentPanel.ClientSize.Width - thickness,
                                                              currentPanel.ClientSize.Height - thickness));
                }
            }
        }

    }
}
