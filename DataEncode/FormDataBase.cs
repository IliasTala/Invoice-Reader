using DataEncode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataEncode
{
    public partial class FormDataBase : Form
    {
        private ToolTip toolTip = new ToolTip();
        public FormDataBase()
        {
            InitializeComponent();
            //InitializeDatabase();

            //Assignation des toolTip à son bouton 
            toolTip.SetToolTip(this.pbSearch, "Search by product name.");
            toolTipReload.SetToolTip(this.btReloadClient, "Update data for the new insertion");

            //Personnalisation de la grid
            dataGridViewDatabase.EnableHeadersVisualStyles = false;
            dataGridViewDatabase.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#003366");
            dataGridViewDatabase.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            textBoxSearch.KeyDown += new KeyEventHandler(textBoxSearch_KeyDown);

            //Personnalisation du bouton reload
            btReloadClient.Font = new Font("Wingdings 3", 40, FontStyle.Bold);
            btReloadClient.Text = Char.ConvertFromUtf32(81); // Utilisez 80 si vous préférez l'autre icône
            btReloadClient.Width = 60;
            btReloadClient.Height = 60;
            btReloadClient.FlatStyle = FlatStyle.Flat; // Style de bordure plat
            btReloadClient.FlatAppearance.BorderSize = 0;


            // Définir la couleur du texte sur blanc
            btReloadClient.ForeColor = Color.Chocolate;


            this.FormClosed += (s, args) => Application.Exit();
        }
        private void FormDataBase_Load(object sender, EventArgs e)
        {
            LoadCustomerNamesIntoComboBox();
            dataGridViewDatabase.DataSource = null;
        }
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Color in the dataGrid                                                 //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void dataGridViewDatabase_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
            {

            }
            else
            {
                // Colorer les lignes de façon alternative en blanc et orange
                if (e.RowIndex % 2 == 0)
                {
                    e.CellStyle.BackColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = ColorTranslator.FromHtml("#9bc3da");
                }
            }
            // Vérifier si la cellule est dans la colonne 'Date' et que la valeur n'est pas null
            if (dataGridViewDatabase.Columns[e.ColumnIndex].Name == "Date" && e.Value != null && e.Value is DateTime)
            {
                DateTime date = (DateTime)e.Value;
                // Formater la date pour afficher uniquement le mois et l'année en toutes lettres
                e.Value = date.ToString("MMMM yyyy", CultureInfo.CurrentCulture);
                e.FormattingApplied = true;
            }
            // Vérifie si la cellule est dans la colonne 'UnitPrice' ou 'Subtotal' et que la valeur n'est pas null
            if ((dataGridViewDatabase.Columns[e.ColumnIndex].Name == "UnitPrice" ||
                 dataGridViewDatabase.Columns[e.ColumnIndex].Name == "Subtotal") &&
                 e.Value != null)
            {

                e.Value = $"{e.Value} €";
                e.FormattingApplied = true;
            }
            // Vérifie si la cellule est dans la colonne 'Marge' et que la valeur n'est pas null
            else if (dataGridViewDatabase.Columns[e.ColumnIndex].Name == "Marge" && e.Value != null)
            {
                e.Value = $"{e.Value} %";
                e.FormattingApplied = true;
            }
        }
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //ComboBox                                                              //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void LoadCustomerDetails(string customerName)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT (CustomerName) AS Customer , CodeFocus, IIF(OfferName IS NULL OR OfferName = '', ProductName, OfferName) AS Product, Quantity, UnitPrice, Subtotal, Marge, Date FROM MaTable WHERE CustomerName = ?";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.Add("@CustomerName", OleDbType.VarChar).Value = customerName;
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewDatabase.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer details: " + ex.Message);
            }
        }
        private void comboBoxCustomerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCustomerNames.SelectedItem != null)
            {
                string selectedCustomerName = comboBoxCustomerNames.SelectedItem.ToString();
                LoadCustomerDetails(selectedCustomerName);
            }
            else
            {
                // Initialisez dataGridViewDatabase à null si aucun client n'est sélectionné
                dataGridViewDatabase.DataSource = null;
            }
        }

        private void LoadCustomerNamesIntoComboBox()
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";


            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT (CustomerName) AS Customer FROM MaTable", connection))
                    {
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBoxCustomerNames.Items.Add(reader["Customer"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer names: " + ex.Message);
            }
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

        private void manageDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientData formClientData = new FormClientData();
            this.Hide();
            formClientData.Show();
        }
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Système d'affichage de la bdd                                         //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////

        private void InitializeDatabase()
        {
            string databaseFilePath = GetDatabasePath();
            // Try to connect to the database
            try
            {
                using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + databaseFilePath + ";Persist Security Info=False;"))
                {
                    connection.Open();

                    // Get the data from the database and display it in the dataGridViewDatabase control
                    string sql = "SELECT * FROM MaTable";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewDatabase.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }
        private string GetDatabasePath()
        {
            // Chemin du bureau de l'utilisateur
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Chemin complet du fichier de base de données
            string dbFilePath = Path.Combine(desktopPath, "Database", "DatabaseDataEncode.accdb");

            return dbFilePath;
        }

        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Système de recherche                                                  //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearch.Text;
            SearchInDatabase(searchTerm);
        }
        private void SearchInDatabase(string searchTerm)
        {
            // Vérifiez si un nom de client est sélectionné dans le ComboBox
            if (comboBoxCustomerNames.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer from the dropdown list before searching.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedCustomerName = comboBoxCustomerNames.SelectedItem.ToString();
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    (CustomerName) AS Customer, 
                    CodeFocus, 
                    IIF(ISNULL(OfferName) OR OfferName = '', ProductName, OfferName) AS Product, 
                    Quantity, 
                    UnitPrice, 
                    Subtotal, 
                    Marge, 
                    Date
                FROM 
                    MaTable 
                WHERE 
                    (ProductName LIKE ? OR OfferName LIKE ?)
                    AND CustomerName = ?";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.Add("@searchTerm", OleDbType.VarChar).Value = $"%{searchTerm}%";
                        adapter.SelectCommand.Parameters.Add("@searchTerm", OleDbType.VarChar).Value = $"%{searchTerm}%";
                        adapter.SelectCommand.Parameters.Add("@CustomerName", OleDbType.VarChar).Value = selectedCustomerName;
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridViewDatabase.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in search: " + ex.Message);
            }
        }

        // N'oubliez pas de lier cette méthode à un événement, comme un bouton de recherche ou un événement KeyDown.

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Appeler la méthode de recherche lorsque Enter est pressé
                buttonSearch_Click(sender, e);
            }
        }
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Système de RELOAD                                                     //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void btReloadClient_Click(object sender, EventArgs e)
        {
            UpdateClientInfo();
            UpdateProfitAndProfitNet();
            // Rechargez les détails du client après la mise à jour
            if (comboBoxCustomerNames.SelectedItem != null)
            {
                string selectedCustomerName = comboBoxCustomerNames.SelectedItem.ToString();
                LoadCustomerDetails(selectedCustomerName);
            }
            MessageBox.Show("Data has been successfully reloaded.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void UpdateClientInfo()
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Récupérez la liste des clients ayant des valeurs de code Focus et de marge non nulles
                Dictionary<string, (string CodeFocus, string Marge)> existingClientInfo = GetExistingClientInfo();

                // Parcourez chaque client dans la liste
                foreach (var client in existingClientInfo)
                {
                    string customerName = client.Key;
                    string codeFocus = client.Value.CodeFocus;
                    string marge = client.Value.Marge;

                    // Vérifiez si les valeurs de CodeFocus et Marge ne sont pas nulles avant de mettre à jour
                    if (!string.IsNullOrEmpty(codeFocus) && !string.IsNullOrEmpty(marge))
                    {
                        // Mettez à jour les clients ayant le même nom (CustomerName) avec les mêmes valeurs de code Focus et de marge
                        using (OleDbCommand cmd = new OleDbCommand(@"UPDATE MaTable SET CodeFocus = @CodeFocus, Marge = @Marge WHERE CustomerName = @CustomerName", conn))
                        {
                            cmd.Parameters.AddWithValue("@CodeFocus", codeFocus);
                            cmd.Parameters.AddWithValue("@Marge", marge);
                            cmd.Parameters.AddWithValue("@CustomerName", customerName);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                conn.Close();
            }
        }

        private Dictionary<string, (string CodeFocus, string Marge)> GetExistingClientInfo()
        {
            var clientInfo = new Dictionary<string, (string CodeFocus, string Marge)>();
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT CustomerName, CodeFocus, Marge FROM MaTable", conn))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string customerName = reader["CustomerName"].ToString();
                            string codeFocus = reader["CodeFocus"].ToString();
                            string marge = reader["Marge"].ToString();
                            clientInfo[customerName] = (CodeFocus: codeFocus, Marge: marge);
                        }
                    }
                }
            }
            return clientInfo;
        }
        private void UpdateProfitAndProfitNet()
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Mettre à jour les colonnes 'Profit' et 'ProfitNet'
                string updateQuery = @"
            UPDATE MaTable 
            SET 
                Profit = SubTotal / (1 - IIF(ISNULL(Marge), 0, Marge / 100.0)),
                ProfitNet = SubTotal / (1 - IIF(ISNULL(Marge), 0, Marge / 100.0)) - SubTotal
        ";

                using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

