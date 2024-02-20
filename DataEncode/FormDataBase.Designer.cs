namespace DataEncode
{
    partial class FormDataBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataBase));
            dataGridViewDatabase = new DataGridView();
            buttonSearch = new Button();
            textBoxSearch = new TextBox();
            pbSearch = new PictureBox();
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            importDataToolStripMenuItem = new ToolStripMenuItem();
            viewStatisticsToolStripMenuItem = new ToolStripMenuItem();
            manageDataToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            comboBoxCustomerNames = new ComboBox();
            btReloadClient = new Button();
            toolTipReload = new ToolTip(components);
            label2 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDatabase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewDatabase
            // 
            dataGridViewDatabase.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewDatabase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDatabase.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewDatabase.BackgroundColor = Color.Black;
            dataGridViewDatabase.BorderStyle = BorderStyle.None;
            dataGridViewDatabase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDatabase.Location = new Point(33, 280);
            dataGridViewDatabase.Name = "dataGridViewDatabase";
            dataGridViewDatabase.RowHeadersWidth = 51;
            dataGridViewDatabase.RowTemplate.Height = 25;
            dataGridViewDatabase.Size = new Size(1359, 449);
            dataGridViewDatabase.TabIndex = 2;
            dataGridViewDatabase.CellFormatting += dataGridViewDatabase_CellFormatting;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.Transparent;
            buttonSearch.FlatAppearance.BorderSize = 2;
            buttonSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 125, 8);
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSearch.ForeColor = Color.White;
            buttonSearch.Location = new Point(604, 80);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(96, 36);
            buttonSearch.TabIndex = 12;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Location = new Point(340, 90);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(243, 23);
            textBoxSearch.TabIndex = 11;
            // 
            // pbSearch
            // 
            pbSearch.Image = (Image)resources.GetObject("pbSearch.Image");
            pbSearch.Location = new Point(312, 91);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(22, 22);
            pbSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSearch.TabIndex = 14;
            pbSearch.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(255, 125, 8);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, importDataToolStripMenuItem, viewStatisticsToolStripMenuItem, manageDataToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1416, 24);
            menuStrip1.TabIndex = 15;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Font = new Font("Mongolian Baiti", 12F, FontStyle.Regular, GraphicsUnit.Point);
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(58, 20);
            homeToolStripMenuItem.Text = "&Home";
            homeToolStripMenuItem.Click += homeToolStripMenuItem_Click;
            // 
            // importDataToolStripMenuItem
            // 
            importDataToolStripMenuItem.Font = new Font("Mongolian Baiti", 12F, FontStyle.Regular, GraphicsUnit.Point);
            importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            importDataToolStripMenuItem.Size = new Size(91, 20);
            importDataToolStripMenuItem.Text = "&Import data";
            importDataToolStripMenuItem.Click += importDataToolStripMenuItem_Click;
            // 
            // viewStatisticsToolStripMenuItem
            // 
            viewStatisticsToolStripMenuItem.Font = new Font("Mongolian Baiti", 12F, FontStyle.Regular, GraphicsUnit.Point);
            viewStatisticsToolStripMenuItem.Name = "viewStatisticsToolStripMenuItem";
            viewStatisticsToolStripMenuItem.Size = new Size(110, 20);
            viewStatisticsToolStripMenuItem.Text = "&View statistics";
            viewStatisticsToolStripMenuItem.Click += viewStatisticsToolStripMenuItem_Click;
            // 
            // manageDataToolStripMenuItem
            // 
            manageDataToolStripMenuItem.Font = new Font("Mongolian Baiti", 12F, FontStyle.Regular, GraphicsUnit.Point);
            manageDataToolStripMenuItem.Name = "manageDataToolStripMenuItem";
            manageDataToolStripMenuItem.Size = new Size(138, 20);
            manageDataToolStripMenuItem.Text = "&Manage client data";
            manageDataToolStripMenuItem.Click += manageDataToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Mongolian Baiti", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(23, 116);
            label1.Name = "label1";
            label1.Size = new Size(135, 16);
            label1.TabIndex = 16;
            label1.Text = "Please select a client";
            // 
            // comboBoxCustomerNames
            // 
            comboBoxCustomerNames.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCustomerNames.FormattingEnabled = true;
            comboBoxCustomerNames.Location = new Point(53, 93);
            comboBoxCustomerNames.Name = "comboBoxCustomerNames";
            comboBoxCustomerNames.Size = new Size(187, 23);
            comboBoxCustomerNames.TabIndex = 17;
            comboBoxCustomerNames.SelectedIndexChanged += comboBoxCustomerNames_SelectedIndexChanged;
            // 
            // btReloadClient
            // 
            btReloadClient.Anchor = AnchorStyles.Top;
            btReloadClient.BackColor = Color.Transparent;
            btReloadClient.FlatAppearance.MouseOverBackColor = Color.DimGray;
            btReloadClient.Location = new Point(845, 54);
            btReloadClient.Name = "btReloadClient";
            btReloadClient.Size = new Size(105, 90);
            btReloadClient.TabIndex = 18;
            btReloadClient.Text = "Reload";
            btReloadClient.UseVisualStyleBackColor = false;
            btReloadClient.Click += btReloadClient_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(255, 125, 8);
            label2.Location = new Point(26, 24);
            label2.Name = "label2";
            label2.Size = new Size(358, 20);
            label2.TabIndex = 19;
            label2.Text = "Please select which data you would like to display.";
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btReloadClient);
            panel1.Controls.Add(buttonSearch);
            panel1.Controls.Add(textBoxSearch);
            panel1.Controls.Add(comboBoxCustomerNames);
            panel1.Controls.Add(pbSearch);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(33, 81);
            panel1.Name = "panel1";
            panel1.Size = new Size(1006, 193);
            panel1.TabIndex = 20;
            // 
            // FormDataBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1416, 775);
            Controls.Add(panel1);
            Controls.Add(dataGridViewDatabase);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormDataBase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database";
            Load += FormDataBase_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDatabase).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewDatabase;
        private Button buttonSearch;
        private TextBox textBoxSearch;
        private PictureBox pbSearch;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem importDataToolStripMenuItem;
        private ToolStripMenuItem viewStatisticsToolStripMenuItem;
        private ToolStripMenuItem manageDataToolStripMenuItem;
        private Label label1;
        private ComboBox comboBoxCustomerNames;
        private Button btReloadClient;
        private ToolTip toolTipReload;
        private Label label2;
        private Panel panel1;
    }
}