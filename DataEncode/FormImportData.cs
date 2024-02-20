using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using CsvHelper.Configuration;
using System.Reflection;

namespace DataEncode
{
    public partial class FormImportData : Form
    {
        //Déclaration d'une table 
        private string dataTableName = "MaTable";
        private int currentMergeId = 0;
        // Déclarations de tableaux de chaînes pour stocker les données CSV.
        private string[] csvData1 = null;
        private string[] csvData2 = null;


        public FormImportData()
        {
            InitializeComponent();
            //Drag and drop 
            dataGridViewImportExcel1.DragDrop += new DragEventHandler(dataGridViewImportExcel1_DragDrop);
            dataGridViewImportExcel2.DragDrop += new DragEventHandler(dataGridViewImportExcel2_DragDrop);
            dataGridViewImportExcel1.DragEnter += new DragEventHandler(dataGridViewImportExcel1_DragEnter);
            dataGridViewImportExcel2.DragEnter += new DragEventHandler(dataGridViewImportExcel2_DragEnter);

            //Personnalisation de la grid 
            dataGridViewImportExcel1.EnableHeadersVisualStyles = false;
            dataGridViewImportExcel1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#003366");
            dataGridViewImportExcel1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewImportExcel2.EnableHeadersVisualStyles = false;
            dataGridViewImportExcel2.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#003366");
            dataGridViewImportExcel2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            dataGridViewImportExcel1.CellFormatting += dataGridViewImportExcel1_CellFormatting;
            dataGridViewImportExcel2.CellFormatting += dataGridViewImportExcel2_CellFormatting;

            // Personnalisation du DateTimePicker

            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "MMMM yyyy";

            //Personnalisation des panels
            panel1.Paint += CustomBorderPaintPanel;
            panel3.Paint += CustomBorderPaintPanel;
            //dataGridViewImportExcel1.Paint += CustomBorderPaint;
            //dataGridViewImportExcel2.Paint += CustomBorderPaint;


            this.FormClosed += (s, args) => Application.Exit();
        }
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Color in the dataGrid                                                 //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void dataGridViewImportExcel1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
        }

        private void dataGridViewImportExcel2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void viewStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStatistics formStats = new FormStatistics();
            this.Hide();
            formStats.Show();
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
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Système de chargement de données                                      //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void LoadCsvData(string filePath, DataGridView dataGridView)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    foreach (string header in csv.Context.Reader.HeaderRecord)
                    {
                        string columnName = header.Trim();
                        dataTable.Columns.Add(columnName, GetColumnType(columnName));
                    }

                    while (csv.Read())
                    {
                        var row = dataTable.NewRow();
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            string columnValue = csv.GetField<string>(column.ColumnName);
                            row[column.ColumnName] = ConvertToType(columnValue, column.DataType);
                        }
                        dataTable.Rows.Add(row);
                    }
                }

                dataGridView.DataSource = dataTable;

                // Afficher les types de données des colonnes
                // DisplayColumnTypes(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du fichier: " + ex.Message);
            }
        }
        //Outil de debugging
        private void DisplayColumnTypes(DataTable dataTable)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn column in dataTable.Columns)
            {
                sb.AppendLine($"Nom de la colonne: {column.ColumnName}, Type de données: {column.DataType}");
            }
            MessageBox.Show(sb.ToString());
        }

        private object ConvertToType(string value, Type type)
        {
            if (string.IsNullOrEmpty(value))
                return DBNull.Value;

            if (type == typeof(int))
                return int.TryParse(value, out int intValue) ? intValue : DBNull.Value;
            if (type == typeof(double))
                return double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleValue) ? doubleValue : DBNull.Value;
            if (type == typeof(DateTime))
            {
                if (type == typeof(DateTime))
                {
                    try
                    {
                        return DateTime.ParseExact(value, "M/d/yyyy", CultureInfo.InvariantCulture);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Erreur de conversion de date : {ex.Message}. Valeur non lisible : {value}");
                        return DBNull.Value;
                    }
                }
            }

            return value;
        }

        private Type GetColumnType(string columnName)
        {
            switch (columnName)
            {
                case "UnitPrice":
                case "Subtotal":
                case "TaxTotal":
                case "Total":
                case "EffectiveUnitPrice":
                case "PCToBCExchangeRate":
                    return typeof(double);

                case "Quantity":
                case "BillableQuantity":
                    return typeof(int);

                case "OrderDate":
                case "ChargeStartDate":
                case "ChargeEndDate":
                case "SubscriptionStartDate":
                case "SubscriptionEndDate":
                    return typeof(DateTime);

                default:
                    return typeof(string);
            }
        }
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Récupération du dernier idMerge                                       //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private int GetNextMergeId()
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
                        return Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        // Aucun enregistrement trouvé, commencez à partir de 1
                        return 1;
                    }
                }
            }
        }
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
        //Système de drag and drop                                              //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void dataGridViewImportExcel1_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && Path.GetExtension(files[0]).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridViewImportExcel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                LoadCsvData(files[0], dataGridViewImportExcel1);
                csvData1 = File.ReadAllLines(files[0]);
                panelElements1.Visible = false;
                labelAddFile1.Visible = false;
            }

        }

        private void dataGridViewImportExcel2_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && Path.GetExtension(files[0]).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridViewImportExcel2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                LoadCsvData(files[0], dataGridViewImportExcel2);
                csvData2 = File.ReadAllLines(files[0])!;
                panelElements2.Visible = false;
                labelAddFile2.Visible = false;

            }
        }

        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Gestion des boutons                                                   //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void button_BrowseExcel1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Fichiers CSV (*.csv)|*.csv|Tous les fichiers (*.*)|*.*",
                FilterIndex = 1
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadCsvData(openFileDialog.FileName, dataGridViewImportExcel1);
                csvData1 = File.ReadAllLines(openFileDialog.FileName);
                panelElements1.Visible = false;
                labelAddFile1.Visible = false;
            }
        }

        private void button_BrowseExcel2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Fichiers CSV (*.csv)|*.csv|Tous les fichiers (*.*)|*.*",
                FilterIndex = 1
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadCsvData(openFileDialog.FileName, dataGridViewImportExcel2);
                csvData2 = File.ReadAllLines(openFileDialog.FileName);
                panelElements2.Visible = false;
                labelAddFile2.Visible = false;
            }
        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            // Check if a date has been selected in the DateTimePicker
            if (dateTimePicker.Value != null && dateTimePicker.Value != DateTime.MinValue)
            {
                // Check if both CSV files have been loaded
                if (csvData1 != null && csvData2 != null)
                {
                    currentMergeId = TableExists(dataTableName) ? GetNextMergeId() : 1;
                    DataTable dataTable1 = (DataTable)dataGridViewImportExcel1.DataSource;
                    DataTable dataTable2 = (DataTable)dataGridViewImportExcel2.DataSource;
                    DataTable mergedData = MergeDataTables(dataTable1, dataTable2);

                    if (mergedData.Rows.Count > 0)
                    {
                        CreateTableInAccess(mergedData);
                        InsertDataIntoAccess(mergedData);
                    }
                    else
                    {
                        MessageBox.Show("No data to insert. The DataTable is empty.");
                    }
                    ResetDataGridUI();
                }
                else
                {
                    MessageBox.Show("Please load both CSV files before proceeding.");
                }
            }
            else
            {
                MessageBox.Show("Please select a date before proceeding.");
            }
        }
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Gestion de la datable                                                 //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private DataTable MergeDataTables(DataTable dataTable1, DataTable dataTable2)
        {
            // Créer un nouveau DataTable pour le résultat
            DataTable mergedDataTable = new DataTable();

            // Ajouter les colonnes de dataTable1
            foreach (DataColumn column in dataTable1.Columns)
            {
                mergedDataTable.Columns.Add(column.ColumnName, column.DataType);
            }

            // Ajouter les colonnes de dataTable2 si elles n'existent pas déjà
            foreach (DataColumn column in dataTable2.Columns)
            {
                if (!mergedDataTable.Columns.Contains(column.ColumnName))
                {
                    mergedDataTable.Columns.Add(column.ColumnName, column.DataType);
                }
            }

            // Ajouter les lignes de dataTable1
            foreach (DataRow row in dataTable1.Rows)
            {
                mergedDataTable.ImportRow(row);
            }

            // Ajouter les lignes de dataTable2
            foreach (DataRow row in dataTable2.Rows)
            {
                DataRow newRow = mergedDataTable.NewRow();

                foreach (DataColumn column in dataTable2.Columns)
                {
                    newRow[column.ColumnName] = row[column.ColumnName];
                }

                mergedDataTable.Rows.Add(newRow);
            }

            return mergedDataTable;
        }
        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Gestion de la base de données                                         //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
        private void InsertDataIntoAccess(DataTable dataTable)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Ajouter la colonne "IdMerge" au DataTable si elle n'existe pas
                if (!dataTable.Columns.Contains("IdMerge"))
                {
                    DataColumn idMergeColumn = new DataColumn("IdMerge", typeof(int));
                    dataTable.Columns.Add(idMergeColumn);
                }

                // Ajouter la colonne "Date" au DataTable si elle n'existe pas
                if (!dataTable.Columns.Contains("Date"))
                {
                    DataColumn dateColumn = new DataColumn("Date", typeof(DateTime));
                    dataTable.Columns.Add(dateColumn);
                }
                // Ajouter la colonne "DateYears" au DataTable si elle n'existe pas
                if (!dataTable.Columns.Contains("DateYears"))
                {
                    DataColumn dateYearColumn = new DataColumn("DateYears", typeof(int));
                    dataTable.Columns.Add(dateYearColumn);
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    // Utilisez currentMergeId comme ID d'ensemble
                    row["IdMerge"] = currentMergeId;

                    // Assigner la date sélectionnée à la colonne "Date"
                    DateTime selectedDate = new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, 1);
                    row["Date"] = selectedDate;

                    row["DateYears"] = selectedDate.Year;

                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = conn;

                        StringBuilder insertCommand = new StringBuilder("INSERT INTO MaTable (");
                        StringBuilder valuesPart = new StringBuilder("VALUES (");

                        foreach (DataColumn column in dataTable.Columns)
                        {
                            insertCommand.Append($"[{column.ColumnName}], ");
                            valuesPart.Append($"@{column.ColumnName}, ");

                            OleDbParameter param = new OleDbParameter($"@{column.ColumnName}", row[column]);

                            // Spécifier le type pour les colonnes de date
                            if (column.DataType == typeof(DateTime))
                            {
                                param.OleDbType = OleDbType.Date;
                            }

                            cmd.Parameters.Add(param);
                        }

                        insertCommand.Length -= 2; // Supprimer la dernière virgule et espace
                        valuesPart.Length -= 2; // Supprimer la dernière virgule et espace

                        insertCommand.Append(") ");
                        valuesPart.Append(")");

                        cmd.CommandText = insertCommand.ToString() + valuesPart.ToString();

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while inserting row: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                conn.Close();
                MessageBox.Show("Data import successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CreateTableInAccess(DataTable dataTable)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDatabasePath()};Persist Security Info=False;";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = conn;

                    // Construction de la requête CREATE TABLE dynamiquement
                    StringBuilder createTableCommand = new StringBuilder("CREATE TABLE MaTable (");

                    // Ajouter les colonnes IdMerge, CodeFocus, Marge, Date, et DateYears
                    createTableCommand.Append("[IdMerge] INTEGER, ");
                    createTableCommand.Append("[CodeFocus] TEXT, ");
                    createTableCommand.Append("[Marge] INTEGER, ");
                    createTableCommand.Append("[Date] DATE, ");
                    createTableCommand.Append("[DateYears] INTEGER, "); // Ajout de la colonne DateYears

                    // Ajouter les autres colonnes du DataTable
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        // S'assurer que la colonne n'est pas déjà incluse
                        if (!new[] { "IdMerge", "CodeFocus", "Marge", "Date", "DateYears" }.Contains(column.ColumnName))
                        {
                            string dataType = ConvertTypeToAccessDataType(column.DataType);
                            createTableCommand.Append($"[{column.ColumnName}] {dataType}, ");
                        }
                    }

                    // Supprimer la dernière virgule et espace
                    createTableCommand.Length -= 2;
                    createTableCommand.Append(")");

                    cmd.CommandText = createTableCommand.ToString();

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your table was created successfully.");
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show("Error creating table : " + ex.Message);
                    }
                }

                conn.Close();
            }
        }
        private int GetCurrentMaxIdMerge(OleDbConnection conn)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT MAX(IdMerge) FROM MaTable", conn))
            {
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    // If there are no records in the table, return 0 as the starting value
                    return 0;
                }
            }
        }

        private string ConvertTypeToAccessDataType(Type type)
        {
            if (type == typeof(int) || type == typeof(long))
                return "INTEGER";
            else if (type == typeof(double) || type == typeof(float) || type == typeof(decimal))
                return "DOUBLE";
            else if (type == typeof(DateTime))
                return "DATETIME";
            else if (type == typeof(bool))
                return "BIT";
            else
                return "TEXT"; // Par défaut
        }

        private string GetDatabasePath()
        {
            // Chemin du bureau de l'utilisateur
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Chemin complet du fichier de base de données
            string dbFilePath = Path.Combine(desktopPath, "Database", "DatabaseDataEncode.accdb");

            return dbFilePath;
        }

        private void ResetDataGridUI()
        {
            // Clear the data sources for both DataGridViews
            dataGridViewImportExcel1.DataSource = null;
            dataGridViewImportExcel2.DataSource = null;

            // Reset the csvData arrays to null
            csvData1 = null;
            csvData2 = null;

            // Make the panels visible again
            panelElements1.Visible = true;
            labelAddFile1.Visible = true;
            panelElements2.Visible = true;
            labelAddFile2.Visible = true;

            // Any other UI reset actions can be added here
        }

        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Design drag and drop                                                  //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////
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
