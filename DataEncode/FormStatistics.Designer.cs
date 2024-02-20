namespace DataEncode
{
    partial class FormStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatistics));
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            importDataToolStripMenuItem = new ToolStripMenuItem();
            manageClientDataToolStripMenuItem = new ToolStripMenuItem();
            databaseToolStripMenuItem = new ToolStripMenuItem();
            dataGridViewStats = new DataGridView();
            btnSortProductCustomer = new Button();
            ComboBoxNameProduct = new ComboBox();
            lbSelection = new Label();
            comboBoxDate = new ComboBox();
            label1 = new Label();
            comboBoxDate2 = new ComboBox();
            btConfirm = new Button();
            panel1 = new Panel();
            btnChooseYears = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStats).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(255, 125, 8);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, importDataToolStripMenuItem, manageClientDataToolStripMenuItem, databaseToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1416, 24);
            menuStrip1.TabIndex = 7;
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
            // manageClientDataToolStripMenuItem
            // 
            manageClientDataToolStripMenuItem.Font = new Font("Mongolian Baiti", 12F, FontStyle.Regular, GraphicsUnit.Point);
            manageClientDataToolStripMenuItem.Name = "manageClientDataToolStripMenuItem";
            manageClientDataToolStripMenuItem.Size = new Size(138, 20);
            manageClientDataToolStripMenuItem.Text = "&Manage client data";
            manageClientDataToolStripMenuItem.Click += manageClientDataToolStripMenuItem_Click;
            // 
            // databaseToolStripMenuItem
            // 
            databaseToolStripMenuItem.Font = new Font("Mongolian Baiti", 12F, FontStyle.Regular, GraphicsUnit.Point);
            databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            databaseToolStripMenuItem.Size = new Size(77, 20);
            databaseToolStripMenuItem.Text = "&Database";
            databaseToolStripMenuItem.Click += databaseToolStripMenuItem_Click;
            // 
            // dataGridViewStats
            // 
            dataGridViewStats.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStats.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewStats.BackgroundColor = Color.Black;
            dataGridViewStats.BorderStyle = BorderStyle.None;
            dataGridViewStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStats.Location = new Point(21, 407);
            dataGridViewStats.Name = "dataGridViewStats";
            dataGridViewStats.RowHeadersWidth = 51;
            dataGridViewStats.RowTemplate.Height = 25;
            dataGridViewStats.Size = new Size(1350, 64);
            dataGridViewStats.TabIndex = 17;
            dataGridViewStats.CellFormatting += dataGridViewStats_CellFormatting;
            // 
            // btnSortProductCustomer
            // 
            btnSortProductCustomer.FlatAppearance.BorderColor = Color.FromArgb(255, 125, 8);
            btnSortProductCustomer.FlatAppearance.MouseOverBackColor = Color.White;
            btnSortProductCustomer.FlatStyle = FlatStyle.Flat;
            btnSortProductCustomer.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSortProductCustomer.ForeColor = Color.FromArgb(255, 125, 8);
            btnSortProductCustomer.Location = new Point(20, 11);
            btnSortProductCustomer.Margin = new Padding(3, 2, 3, 2);
            btnSortProductCustomer.Name = "btnSortProductCustomer";
            btnSortProductCustomer.Size = new Size(175, 37);
            btnSortProductCustomer.TabIndex = 24;
            btnSortProductCustomer.Text = "Sort By Customer";
            btnSortProductCustomer.UseVisualStyleBackColor = false;
            btnSortProductCustomer.Click += btnSortProductCustomer_Click;
            // 
            // ComboBoxNameProduct
            // 
            ComboBoxNameProduct.BackColor = Color.FromArgb(75, 173, 223);
            ComboBoxNameProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxNameProduct.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ComboBoxNameProduct.FormattingEnabled = true;
            ComboBoxNameProduct.Location = new Point(20, 91);
            ComboBoxNameProduct.Name = "ComboBoxNameProduct";
            ComboBoxNameProduct.Size = new Size(257, 29);
            ComboBoxNameProduct.TabIndex = 25;
            // 
            // lbSelection
            // 
            lbSelection.AutoSize = true;
            lbSelection.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbSelection.ForeColor = Color.FromArgb(255, 125, 8);
            lbSelection.Location = new Point(350, 95);
            lbSelection.Name = "lbSelection";
            lbSelection.Size = new Size(119, 20);
            lbSelection.TabIndex = 26;
            lbSelection.Text = "Current Period :";
            // 
            // comboBoxDate
            // 
            comboBoxDate.BackColor = Color.FromArgb(75, 173, 223);
            comboBoxDate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDate.Font = new Font("Segoe UI", 12F, FontStyle.Underline, GraphicsUnit.Point);
            comboBoxDate.FormattingEnabled = true;
            comboBoxDate.Location = new Point(484, 91);
            comboBoxDate.Name = "comboBoxDate";
            comboBoxDate.Size = new Size(206, 29);
            comboBoxDate.TabIndex = 27;
            comboBoxDate.SelectedIndexChanged += comboBoxDate_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 125, 8);
            label1.Location = new Point(706, 95);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 28;
            label1.Text = "Previous Period :";
            // 
            // comboBoxDate2
            // 
            comboBoxDate2.BackColor = Color.FromArgb(75, 173, 223);
            comboBoxDate2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDate2.Font = new Font("Segoe UI", 12F, FontStyle.Underline, GraphicsUnit.Point);
            comboBoxDate2.FormattingEnabled = true;
            comboBoxDate2.Location = new Point(838, 91);
            comboBoxDate2.Name = "comboBoxDate2";
            comboBoxDate2.Size = new Size(205, 29);
            comboBoxDate2.TabIndex = 29;
            // 
            // btConfirm
            // 
            btConfirm.FlatAppearance.BorderColor = Color.White;
            btConfirm.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 125, 8);
            btConfirm.FlatStyle = FlatStyle.Flat;
            btConfirm.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btConfirm.ForeColor = Color.White;
            btConfirm.Location = new Point(1105, 85);
            btConfirm.Name = "btConfirm";
            btConfirm.Size = new Size(124, 39);
            btConfirm.TabIndex = 30;
            btConfirm.Text = "Confirm";
            btConfirm.UseVisualStyleBackColor = true;
            btConfirm.Click += btConfirm_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnChooseYears);
            panel1.Controls.Add(btConfirm);
            panel1.Controls.Add(btnSortProductCustomer);
            panel1.Controls.Add(ComboBoxNameProduct);
            panel1.Controls.Add(lbSelection);
            panel1.Controls.Add(comboBoxDate);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBoxDate2);
            panel1.Location = new Point(21, 162);
            panel1.Name = "panel1";
            panel1.Size = new Size(1341, 218);
            panel1.TabIndex = 31;
            // 
            // btnChooseYears
            // 
            btnChooseYears.FlatAppearance.BorderColor = Color.FromArgb(255, 125, 8);
            btnChooseYears.FlatAppearance.MouseOverBackColor = Color.White;
            btnChooseYears.FlatStyle = FlatStyle.Flat;
            btnChooseYears.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnChooseYears.ForeColor = Color.FromArgb(255, 125, 8);
            btnChooseYears.Location = new Point(350, 11);
            btnChooseYears.Margin = new Padding(3, 2, 3, 2);
            btnChooseYears.Name = "btnChooseYears";
            btnChooseYears.Size = new Size(160, 37);
            btnChooseYears.TabIndex = 31;
            btnChooseYears.Text = "Choose Yearly";
            btnChooseYears.UseVisualStyleBackColor = false;
            btnChooseYears.Click += btnChooseYears_Click;
            // 
            // FormStatistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1416, 775);
            Controls.Add(panel1);
            Controls.Add(dataGridViewStats);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormStatistics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Statistics";
            Load += FormStatistics_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStats).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem importDataToolStripMenuItem;
        private ToolStripMenuItem manageClientDataToolStripMenuItem;
        private ToolStripMenuItem databaseToolStripMenuItem;
        private DataGridView dataGridViewStats;
        private Button btnSortProductCustomer;
        private ComboBox ComboBoxNameProduct;
        private Label lbSelection;
        private ComboBox comboBoxDate;
        private Label label1;
        private ComboBox comboBoxDate2;
        private Button btConfirm;
        private Panel panel1;
        private Button btnChooseYears;
    }
}