using System.Windows.Forms;

namespace DataEncode
{
    public partial class FormMainMenu : Form
    {
        //D�claration d'un ToolTip pour afficher un texte sur un bouton 
        private ToolTip toolTip = new ToolTip();
        public FormMainMenu()
        {
            InitializeComponent();

            //Assignation des toolTip � son bouton 
            toolTip.SetToolTip(this.button_ImportData, "Import data from Excel files.");
            toolTip.SetToolTip(this.button_Stats, "View data statistics.");
            toolTip.SetToolTip(this.button_ManageData, "Manage client data.");
            toolTip.SetToolTip(this.button_Database, "Access the database.");

        }

        //////////////////////////////////////////////////////////////////////////
        //                                                                      // 
        //Syst�me de navigation                                                 //  
        //                                                                      //
        //////////////////////////////////////////////////////////////////////////

        private void button_ImportData_Click(object sender, EventArgs e)
        {
            FormImportData formImportData = new FormImportData();
            //Le code ci - dessous assure que FormImportData s'ouvre exactement � la m�me position �cran que FormHome.
            formImportData.StartPosition = FormStartPosition.CenterScreen;
            formImportData.Location = this.Location;
            this.Hide(); // Cache Form1 (facultatif)
            formImportData.ShowDialog(); // Affiche FormImportData

        }

        private void button_Stats_Click(object sender, EventArgs e)
        {
            FormStatistics formStatistics = new FormStatistics();
            formStatistics.StartPosition = FormStartPosition.CenterScreen;
            formStatistics.Location = this.Location;
            this.Hide();
            formStatistics.ShowDialog();

        }

        private void button_Database_Click(object sender, EventArgs e)
        {
            FormDataBase formDatabase = new FormDataBase();
            formDatabase.StartPosition = FormStartPosition.CenterScreen;
            formDatabase.Location = this.Location;
            this.Hide();
            formDatabase.ShowDialog();

        }

        private void button_ManageData_Click(object sender, EventArgs e)
        {
            FormClientData formClientData = new FormClientData();
            formClientData.StartPosition = FormStartPosition.CenterScreen;
            formClientData.Location = this.Location;
            this.Hide();
            formClientData.ShowDialog();

        }
    }
}

