using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DataEncode
{
    public partial class FormStatistics : Form
    {
        private bool isByProductMode = true;// Variable pour suivre le mode actuel (par produit ou par client)
        private bool isMonthMode = true;// Variable pour suivre le mode actuel (par mois ou par ans)
        private void InitializeDataGridView()
        {
            // Assurez-vous que votre DataGridView est configuré pour gérer les colonnes manuellement
            dataGridViewStats.AutoGenerateColumns = false;
            dataGridViewStats.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);

            // Ajoutez les colonnes nécessaires
            dataGridViewStats.Columns.Add("Purchased", "Purchased");
            dataGridViewStats.Columns.Add("Rebilled", "Rebilled");
            dataGridViewStats.Columns.Add("Margin", "Margin");
            dataGridViewStats.Columns.Add("Variation Purchased", "% Variation Purchased");
            dataGridViewStats.Columns.Add("Variation Rebilled", "% Variation Rebilled");
            dataGridViewStats.Columns.Add("Variation Margin", "% Variation Margin");

            // Ici vous pouvez configurer le style de vos colonnes si nécessaire, par exemple :
            foreach (DataGridViewColumn col in dataGridViewStats.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void FormStatistics_Load(object sender, EventArgs e)
        {
            LoadUniqueDates();
            LoadStatPerProduct(); // Call this method to load the dates when form loads
        }

        // Appeler cette méthode dans le constructeur de votre formulaire ou dans la méthode Load
        public FormStatistics()
        {
            InitializeComponent();
            InitializeDataGridView();
            // Ajoutez cette ligne pour initialiser les colonnes
            this.FormClosed += (s, args) => Application.Exit();
        }

        private string GetDatabasePath()
        {
            // Chemin du bureau de l'utilisateur
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Chemin complet du fichier de base de données
            string dbFilePath = Path.Combine(desktopPath, "Database", "DatabaseDataEncode.accdb");

            return dbFilePath;
        }

        private void UpdateStatistics(string productName, string monthYear)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string purchasePriceQuery = "SELECT SUM(SubTotal) FROM MaTable WHERE ProductName = @ProductName AND FORMAT(Date, 'mmmm yyyy') = @MonthYear";
                    using (OleDbCommand command = new OleDbCommand(purchasePriceQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", productName);
                        command.Parameters.AddWithValue("@MonthYear", monthYear);

                        var purchasePriceResult = command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating statistics: " + ex.Message);
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
        private void manageClientDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientData formClientData = new FormClientData();
            this.Hide();
            formClientData.Show();
        }
        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataBase formDatabase = new FormDataBase();
            this.Hide();
            formDatabase.Show();
        }
        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImportData formImportData = new FormImportData();
            this.Hide();
            formImportData.Show();
        }
        private void LoadUniqueDates()
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query;

                    if (isMonthMode)
                    {
                        query = @"
                                SELECT DateText
                                FROM (SELECT DISTINCT FORMAT(Date, 'mmmm yyyy') AS DateText FROM MaTable)
                                ORDER BY CDate(DateText)";
                    }

                    else // Mode année
                    {
                        // Charger les données à partir de la colonne DateYears
                        query = "SELECT DISTINCT DateYears AS DateText FROM MaTable ORDER BY DateYears";
                    }

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            comboBoxDate.Items.Clear();
                            comboBoxDate2.Items.Clear();

                            while (reader.Read())
                            {
                                string dateText = reader["DateText"].ToString();
                                comboBoxDate.Items.Add(dateText);
                                comboBoxDate2.Items.Add(dateText);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading unique dates: " + ex.Message);
            }
        }
        private void comboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxDate.SelectedItem != null)
            {
                string selectedMonthYear = comboBoxDate.SelectedItem.ToString();
            }
        }
        private void comboBoxDate2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDate2.SelectedItem != null)
            {
                string selectedMonthYear = comboBoxDate2.SelectedItem.ToString();

            }
        }
        private void dataGridViewStats_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewStats.Columns[e.ColumnIndex].Name.Contains("Variation"))
            {
                if (e.Value != null && e.Value.ToString() != "")
                {
                    string value = e.Value.ToString().Replace("%", "");
                    if (decimal.TryParse(value, out decimal numericValue))
                    {
                        if (numericValue < 0)
                        {
                            e.CellStyle.ForeColor = Color.Red;
                            e.Value =  e.Value + " ↓ " ; // Flèche rouge descendante pour les valeurs négatives
                        }
                        else if (numericValue > 0)
                        {
                            e.CellStyle.ForeColor = Color.Green;
                            e.Value =  e.Value+ " ↑ " ;
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.Gray;
                            // Pas de flèche pour les valeurs nulles
                        }
                    }
                }
            }
        }

        private void ComboBoxNameProduct_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Gestion des boutons                                                   //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void btnSortProductCustomer_Click(object sender, EventArgs e)
        {
            isByProductMode = !isByProductMode; // Inverser le mode actuel
            ComboBoxNameProduct.Items.Clear();
            if (isByProductMode)
            {


                btnSortProductCustomer.Text = "Sort By Customers";
                if (isMonthMode)
                {
                    LoadStatPerProduct(); // Charger les statistiques par produit
                }
                else
                {
                    LoadStatPerProductYears();
                }

            }
            else
            {

                btnSortProductCustomer.Text = "Sort By Product";
                if (isMonthMode)
                {
                    LoadStatPerCustomer(); // Charger les statistiques par client
                }
                else
                {
                    LoadStatPerCustomerYears();
                }

            }
        }
        private void btnChooseYears_Click(object sender, EventArgs e)
        {
            isMonthMode = !isMonthMode;
            if (isMonthMode)
            {
                btnChooseYears.Text = "Choose Years"; // Mettre à jour le texte du bouton si nécessaire
            }
            else
            {
                btnChooseYears.Text = "Choose Months"; // Mettre à jour le texte du bouton si nécessaire
            }

            LoadUniqueDates(); // Cette méthode doit charger les données en fonction du mode actuel
        }


        private void btConfirm_Click(object sender, EventArgs e)
        {
            
            // Ensure both dates and product are selected
            if (comboBoxDate.SelectedItem == null || comboBoxDate2.SelectedItem == null || ComboBoxNameProduct.SelectedItem == null)
            {
                MessageBox.Show("Please select two dates and a product or a customer to compare.");
                return;
            }
            if (isByProductMode)
            {
                ProductCalcul();
            }
            else { CustomerCalcul(); }
        }
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Gestion / Calculs                                                     //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void ProductCalcul()
        {
            // Get selected values
            string productName = ComboBoxNameProduct.SelectedItem.ToString();
            string firstMonthYear = comboBoxDate.SelectedItem.ToString();
            string secondMonthYear = comboBoxDate2.SelectedItem.ToString();
            decimal firstMonthPurchased;
            decimal firstMonthRebilled;
            decimal firstMonthMargin;
            decimal secondMonthPurchased;
            decimal secondMonthRebilled;
            decimal secondMonthMargin;

            if (isMonthMode)
            {
                // Calculate statistics for both months
                firstMonthPurchased = GetStatisticValue(productName, firstMonthYear, "SubTotal");
                firstMonthRebilled = GetStatisticValue(productName, firstMonthYear, "Profit");
                firstMonthMargin = GetStatisticValue(productName, firstMonthYear, "ProfitNet");

                secondMonthPurchased = GetStatisticValue(productName, secondMonthYear, "SubTotal");
                secondMonthRebilled = GetStatisticValue(productName, secondMonthYear, "Profit");
                secondMonthMargin = GetStatisticValue(productName, secondMonthYear, "ProfitNet");
            }
            else
            {
                firstMonthPurchased = GetStatisticValueYears(productName, firstMonthYear, "SubTotal");
                firstMonthRebilled = GetStatisticValueYears(productName, firstMonthYear, "Profit");
                firstMonthMargin = GetStatisticValueYears(productName, firstMonthYear, "ProfitNet");

                secondMonthPurchased = GetStatisticValueYears(productName, secondMonthYear, "SubTotal");
                secondMonthRebilled = GetStatisticValueYears(productName, secondMonthYear, "Profit");
                secondMonthMargin = GetStatisticValueYears(productName, secondMonthYear, "ProfitNet");
            }



            // Calculate variations
            decimal purchasedVariation = CalculateVariation(firstMonthPurchased, secondMonthPurchased);
            decimal rebilledVariation = CalculateVariation(firstMonthRebilled, secondMonthRebilled);
            decimal marginVariation = CalculateVariation(firstMonthMargin, secondMonthMargin);

            // Populate DataGridView
            dataGridViewStats.Rows.Clear();
            dataGridViewStats.Rows.Add(new object[] {
                firstMonthPurchased.ToString("0.##"),
                firstMonthRebilled.ToString("0.##"),
                firstMonthMargin.ToString("0.##"),
                purchasedVariation.ToString("0.##") + "%",
                rebilledVariation.ToString("0.##") + "%",
                marginVariation.ToString("0.##") + "%"
            });
        }
        private void CustomerCalcul()
        {
            // Récupérer les valeurs sélectionnées
            string customerName = ComboBoxNameProduct.SelectedItem.ToString();
            string firstMonthYear = comboBoxDate.SelectedItem.ToString();
            string secondMonthYear = comboBoxDate2.SelectedItem.ToString();
            decimal firstMonthPurchased;
            decimal firstMonthRebilled;
            decimal firstMonthMargin;
            decimal secondMonthPurchased;
            decimal secondMonthRebilled;
            decimal secondMonthMargin;
            if (isMonthMode)
            {// Calculer les statistiques pour les deux mois
                firstMonthPurchased = GetStatisticValueForCustomer(customerName, firstMonthYear, "SubTotal");
                firstMonthRebilled = GetStatisticValueForCustomer(customerName, firstMonthYear, "Profit");
                firstMonthMargin = GetStatisticValueForCustomer(customerName, firstMonthYear, "ProfitNet");

                secondMonthPurchased = GetStatisticValueForCustomer(customerName, secondMonthYear, "SubTotal");
                secondMonthRebilled = GetStatisticValueForCustomer(customerName, secondMonthYear, "Profit");
                secondMonthMargin = GetStatisticValueForCustomer(customerName, secondMonthYear, "ProfitNet");
            }
            else
            {
                firstMonthPurchased = GetStatisticValueForCustomerYears(customerName, firstMonthYear, "SubTotal");
                firstMonthRebilled = GetStatisticValueForCustomerYears(customerName, firstMonthYear, "Profit");
                firstMonthMargin = GetStatisticValueForCustomerYears(customerName, firstMonthYear, "ProfitNet");

                secondMonthPurchased = GetStatisticValueForCustomerYears(customerName, secondMonthYear, "SubTotal");
                secondMonthRebilled = GetStatisticValueForCustomerYears(customerName, secondMonthYear, "Profit");
                secondMonthMargin = GetStatisticValueForCustomerYears(customerName, secondMonthYear, "ProfitNet");
            }


            // Calculer les variations
            decimal purchasedVariation = CalculateVariation(firstMonthPurchased, secondMonthPurchased);
            decimal rebilledVariation = CalculateVariation(firstMonthRebilled, secondMonthRebilled);
            decimal marginVariation = CalculateVariation(firstMonthMargin, secondMonthMargin);

            // Remplir le DataGridView
            dataGridViewStats.Rows.Clear();
            dataGridViewStats.Rows.Add(new object[] {
                firstMonthPurchased.ToString("0.##"),
                firstMonthRebilled.ToString("0.##"),
                firstMonthMargin.ToString("0.##"),
                purchasedVariation.ToString("0.##") + "%",
                rebilledVariation.ToString("0.##") + "%",
                marginVariation.ToString("0.##") + "%"
            });
        }
        private decimal GetStatisticValue(string productName, string monthYear, string columnName)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";
            decimal value = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Utilisez COALESCE pour sélectionner la première colonne non nulle
                // ou IIF pour vérifier si ProductName est vide ou nul et dans ce cas, utilisez SubscriptionDescription
                string query = $@"
            SELECT SUM({columnName}) 
            FROM MaTable 
            WHERE 
                (ProductName = @ProductName OR SubscriptionDescription = @ProductName) 
                AND FORMAT(Date, 'mmmm yyyy') = @MonthYear";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@MonthYear", monthYear);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        value = Convert.ToDecimal(result);
                    }
                }
            }

            return value;
        }
        private decimal GetStatisticValueForCustomer(string customerName, string monthYear, string columnName)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";
            decimal value = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $@"
            SELECT SUM({columnName}) 
            FROM MaTable 
            WHERE 
                CustomerName = @CustomerName
                AND FORMAT(Date, 'mmmm yyyy') = @MonthYear";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerName", customerName);
                    command.Parameters.AddWithValue("@MonthYear", monthYear);

                    try
                    {
                        connection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            value = Convert.ToDecimal(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving statistics: " + ex.Message);
                    }
                }
            }

            return value;
        }
        private decimal GetStatisticValueYears(string productName, string year, string columnName)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";
            decimal value = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $@"
            SELECT SUM({columnName}) 
            FROM MaTable 
            WHERE 
                (ProductName = @ProductName OR SubscriptionDescription = @ProductName) 
                AND FORMAT(Date, 'yyyy') = @Year";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@Year", year);

                    try
                    {
                        connection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            value = Convert.ToDecimal(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving statistics: " + ex.Message);
                    }
                }
            }

            return value;
        }

        private decimal GetStatisticValueForCustomerYears(string customerName, string year, string columnName)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";
            decimal value = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $@"
            SELECT SUM({columnName}) 
            FROM MaTable 
            WHERE 
                CustomerName = @CustomerName
                AND FORMAT(Date, 'yyyy') = @Year";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerName", customerName);
                    command.Parameters.AddWithValue("@Year", year);

                    try
                    {
                        connection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            value = Convert.ToDecimal(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving statistics: " + ex.Message);
                    }
                }
            }

            return value;
        }
        private decimal CalculateVariation(decimal firstMonthValue, decimal secondMonthValue)
        {
            if (firstMonthValue == 0)
            {
                return secondMonthValue > 0 ? 100 : 0;
            }

            return ((secondMonthValue - firstMonthValue) / firstMonthValue) * 100;
        }

        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Gestion / LOADING                                                     //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        ///
        private void LoadStatPerProduct()
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT IIF(OfferName IS NULL OR OfferName = '', ProductName, OfferName) AS DisplayText FROM MaTable";
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string displayText = reader["DisplayText"].ToString();
                                ComboBoxNameProduct.Items.Add(displayText);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer names: " + ex.Message);
            }

            ComboBoxNameProduct.SelectedIndexChanged += ComboBoxNameProduct_SelectedIndexChanged;
        }
        private void LoadStatPerCustomer()
        {
            ComboBoxNameProduct.Items.Clear(); // Nettoyer les éléments précédents, si nécessaire

            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT DISTINCT CustomerName 
                FROM MaTable"; // Modifier la requête pour obtenir les noms des clients
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string customerName = reader["CustomerName"].ToString();
                                ComboBoxNameProduct.Items.Add(customerName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer names: " + ex.Message);
            }
        }
        private void LoadStatPerProductYears()
        {
            ComboBoxNameProduct.Items.Clear(); // Nettoyer les éléments précédents, si nécessaire

            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT DISTINCT IIF(OfferName IS NULL OR OfferName = '', ProductName, OfferName) AS DisplayText
                FROM MaTable
                WHERE FORMAT(Date, 'yyyy') = @Year"; // Modifier la requête pour obtenir les noms des produits par année

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // Spécifiez l'année pour laquelle vous voulez charger les produits
                        cmd.Parameters.AddWithValue("@Year", "2023"); // Par exemple, remplacez "2023" par l'année désirée

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string displayText = reader["DisplayText"].ToString();
                                ComboBoxNameProduct.Items.Add(displayText);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product names: " + ex.Message);
            }

            ComboBoxNameProduct.SelectedIndexChanged += ComboBoxNameProduct_SelectedIndexChanged;
        }

        private void LoadStatPerCustomerYears()
        {
            ComboBoxNameProduct.Items.Clear(); // Nettoyer les éléments précédents, si nécessaire

            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT DISTINCT CustomerName 
                FROM MaTable
                WHERE FORMAT(Date, 'yyyy') = @Year"; // Modifier la requête pour obtenir les noms des clients par année

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // Spécifiez l'année pour laquelle vous voulez charger les clients
                        cmd.Parameters.AddWithValue("@Year", "2023"); // Par exemple, remplacez "2023" par l'année désirée

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string customerName = reader["CustomerName"].ToString();
                                ComboBoxNameProduct.Items.Add(customerName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer names: " + ex.Message);
            }
        }
        // Méthode pour charger les années uniques à partir de vos données
        private void LoadUniqueYears()
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
            SELECT DISTINCT Year(Date) AS Year
            FROM MaTable
            ORDER BY Year(Date)";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string year = reader["Year"].ToString();
                                comboBoxDate.Items.Add(year);
                                comboBoxDate2.Items.Add(year);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading unique years: " + ex.Message);
            }
        }
    }
}

