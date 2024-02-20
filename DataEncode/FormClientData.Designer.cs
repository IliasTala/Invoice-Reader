namespace DataEncode
{
    partial class FormClientData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientData));
            comboBoxCustomerNames = new ComboBox();
            btnExportClientData = new Button();
            buttonUploadMargeAndCodeFocus = new Button();
            textBoxMarge = new TextBox();
            labelMarge = new Label();
            textBoxCodeFocus = new TextBox();
            labelCodeFocus = new Label();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            importDataToolStripMenuItem = new ToolStripMenuItem();
            viewStatisticsToolStripMenuItem = new ToolStripMenuItem();
            databaseToolStripMenuItem = new ToolStripMenuItem();
            buttonDeleteLastUpdate = new Button();
            buttonExportClientFinancialOverview = new Button();
            lbSelection = new Label();
            comboBoxDate = new ComboBox();
            label2 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxCustomerNames
            // 
            comboBoxCustomerNames.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCustomerNames.FormattingEnabled = true;
            comboBoxCustomerNames.Location = new Point(295, 53);
            comboBoxCustomerNames.Name = "comboBoxCustomerNames";
            comboBoxCustomerNames.Size = new Size(170, 23);
            comboBoxCustomerNames.TabIndex = 4;
            comboBoxCustomerNames.SelectedIndexChanged += comboBoxCustomerNames_SelectedIndexChanged;
            // 
            // btnExportClientData
            // 
            btnExportClientData.BackColor = Color.Black;
            btnExportClientData.FlatAppearance.BorderColor = Color.FromArgb(255, 125, 8);
            btnExportClientData.FlatAppearance.BorderSize = 2;
            btnExportClientData.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnExportClientData.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 125, 8);
            btnExportClientData.FlatStyle = FlatStyle.Flat;
            btnExportClientData.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnExportClientData.ForeColor = Color.White;
            btnExportClientData.Location = new Point(327, 138);
            btnExportClientData.Name = "btnExportClientData";
            btnExportClientData.Size = new Size(199, 36);
            btnExportClientData.TabIndex = 6;
            btnExportClientData.Text = "Export client data";
            btnExportClientData.UseVisualStyleBackColor = false;
            btnExportClientData.Click += btnExportClientData_Click;
            // 
            // buttonUploadMargeAndCodeFocus
            // 
            buttonUploadMargeAndCodeFocus.BackColor = Color.Black;
            buttonUploadMargeAndCodeFocus.FlatAppearance.BorderColor = Color.FromArgb(255, 125, 8);
            buttonUploadMargeAndCodeFocus.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 125, 8);
            buttonUploadMargeAndCodeFocus.FlatStyle = FlatStyle.Flat;
            buttonUploadMargeAndCodeFocus.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonUploadMargeAndCodeFocus.ForeColor = Color.White;
            buttonUploadMargeAndCodeFocus.Location = new Point(188, 231);
            buttonUploadMargeAndCodeFocus.Name = "buttonUploadMargeAndCodeFocus";
            buttonUploadMargeAndCodeFocus.Size = new Size(170, 33);
            buttonUploadMargeAndCodeFocus.TabIndex = 22;
            buttonUploadMargeAndCodeFocus.Text = "Save";
            buttonUploadMargeAndCodeFocus.UseVisualStyleBackColor = false;
            buttonUploadMargeAndCodeFocus.Click += buttonUploadMargeAndCodeFocus_Click;
            // 
            // textBoxMarge
            // 
            textBoxMarge.Location = new Point(295, 152);
            textBoxMarge.Name = "textBoxMarge";
            textBoxMarge.Size = new Size(170, 23);
            textBoxMarge.TabIndex = 21;
            // 
            // labelMarge
            // 
            labelMarge.AutoSize = true;
            labelMarge.BackColor = Color.Transparent;
            labelMarge.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMarge.ForeColor = Color.FromArgb(255, 125, 8);
            labelMarge.Location = new Point(77, 151);
            labelMarge.Name = "labelMarge";
            labelMarge.Size = new Size(65, 20);
            labelMarge.TabIndex = 20;
            labelMarge.Text = "Margin :";
            // 
            // textBoxCodeFocus
            // 
            textBoxCodeFocus.Location = new Point(295, 105);
            textBoxCodeFocus.Name = "textBoxCodeFocus";
            textBoxCodeFocus.Size = new Size(170, 23);
            textBoxCodeFocus.TabIndex = 19;
            // 
            // labelCodeFocus
            // 
            labelCodeFocus.AutoSize = true;
            labelCodeFocus.BackColor = Color.Transparent;
            labelCodeFocus.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCodeFocus.ForeColor = Color.FromArgb(255, 125, 8);
            labelCodeFocus.Location = new Point(77, 104);
            labelCodeFocus.Name = "labelCodeFocus";
            labelCodeFocus.Size = new Size(98, 20);
            labelCodeFocus.TabIndex = 18;
            labelCodeFocus.Text = "Code focus :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 125, 8);
            label1.Location = new Point(77, 55);
            label1.Name = "label1";
            label1.Size = new Size(165, 20);
            label1.TabIndex = 13;
            label1.Text = "Please select a client :";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(255, 125, 8);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, importDataToolStripMenuItem, viewStatisticsToolStripMenuItem, databaseToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1416, 24);
            menuStrip1.TabIndex = 16;
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
            // databaseToolStripMenuItem
            // 
            databaseToolStripMenuItem.Font = new Font("Mongolian Baiti", 12F, FontStyle.Regular, GraphicsUnit.Point);
            databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            databaseToolStripMenuItem.Size = new Size(77, 20);
            databaseToolStripMenuItem.Text = "&Database";
            databaseToolStripMenuItem.Click += databaseToolStripMenuItem_Click;
            // 
            // buttonDeleteLastUpdate
            // 
            buttonDeleteLastUpdate.BackColor = Color.Black;
            buttonDeleteLastUpdate.FlatAppearance.BorderColor = Color.FromArgb(255, 125, 8);
            buttonDeleteLastUpdate.FlatAppearance.BorderSize = 2;
            buttonDeleteLastUpdate.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 125, 8);
            buttonDeleteLastUpdate.FlatStyle = FlatStyle.Flat;
            buttonDeleteLastUpdate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDeleteLastUpdate.ForeColor = Color.White;
            buttonDeleteLastUpdate.Location = new Point(598, 138);
            buttonDeleteLastUpdate.Name = "buttonDeleteLastUpdate";
            buttonDeleteLastUpdate.Size = new Size(199, 36);
            buttonDeleteLastUpdate.TabIndex = 24;
            buttonDeleteLastUpdate.Text = "Delete last update";
            buttonDeleteLastUpdate.UseVisualStyleBackColor = false;
            buttonDeleteLastUpdate.Click += buttonDeleteLastUpdate_Click;
            // 
            // buttonExportClientFinancialOverview
            // 
            buttonExportClientFinancialOverview.BackColor = Color.Black;
            buttonExportClientFinancialOverview.FlatAppearance.BorderColor = Color.FromArgb(255, 125, 8);
            buttonExportClientFinancialOverview.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 125, 8);
            buttonExportClientFinancialOverview.FlatStyle = FlatStyle.Flat;
            buttonExportClientFinancialOverview.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonExportClientFinancialOverview.ForeColor = Color.White;
            buttonExportClientFinancialOverview.Location = new Point(751, 227);
            buttonExportClientFinancialOverview.Name = "buttonExportClientFinancialOverview";
            buttonExportClientFinancialOverview.Size = new Size(214, 37);
            buttonExportClientFinancialOverview.TabIndex = 23;
            buttonExportClientFinancialOverview.Text = "Export client financial overview";
            buttonExportClientFinancialOverview.UseVisualStyleBackColor = false;
            buttonExportClientFinancialOverview.Click += buttonExportClientFinancialOverview_Click;
            // 
            // lbSelection
            // 
            lbSelection.AutoSize = true;
            lbSelection.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbSelection.ForeColor = Color.FromArgb(255, 125, 8);
            lbSelection.Location = new Point(674, 56);
            lbSelection.Name = "lbSelection";
            lbSelection.Size = new Size(129, 20);
            lbSelection.TabIndex = 26;
            lbSelection.Text = "Select the date : ";
            // 
            // comboBoxDate
            // 
            comboBoxDate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDate.FormattingEnabled = true;
            comboBoxDate.Location = new Point(845, 56);
            comboBoxDate.Name = "comboBoxDate";
            comboBoxDate.Size = new Size(170, 23);
            comboBoxDate.TabIndex = 25;
            comboBoxDate.SelectedIndexChanged += comboBoxDate_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(255, 125, 8);
            label2.Location = new Point(241, 62);
            label2.Name = "label2";
            label2.Size = new Size(649, 20);
            label2.TabIndex = 29;
            label2.Text = "Make changes to your data, apply filters, and then export the filtered results in Excel format.";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(btnExportClientData);
            panel3.Controls.Add(buttonDeleteLastUpdate);
            panel3.Location = new Point(127, 84);
            panel3.Name = "panel3";
            panel3.Size = new Size(1154, 203);
            panel3.TabIndex = 30;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(buttonExportClientFinancialOverview);
            panel1.Controls.Add(comboBoxDate);
            panel1.Controls.Add(comboBoxCustomerNames);
            panel1.Controls.Add(lbSelection);
            panel1.Controls.Add(textBoxCodeFocus);
            panel1.Controls.Add(labelCodeFocus);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonUploadMargeAndCodeFocus);
            panel1.Controls.Add(textBoxMarge);
            panel1.Controls.Add(labelMarge);
            panel1.Location = new Point(127, 319);
            panel1.Name = "panel1";
            panel1.Size = new Size(1154, 303);
            panel1.TabIndex = 23;
            // 
            // FormClientData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1416, 775);
            Controls.Add(panel3);
            Controls.Add(menuStrip1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormClientData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage client data";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBoxCustomerNames;
        private Button btnExportClientData;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem importDataToolStripMenuItem;
        private ToolStripMenuItem viewStatisticsToolStripMenuItem;
        private ToolStripMenuItem databaseToolStripMenuItem;
        private Button buttonUploadMargeAndCodeFocus;
        private TextBox textBoxMarge;
        private Label labelMarge;
        private TextBox textBoxCodeFocus;
        private Label labelCodeFocus;
        private Button buttonExportClientFinancialOverview;
        private Button buttonDeleteLastUpdate;
        private Label lbSelection;
        private ComboBox comboBoxDate;
        private Label label2;
        private Panel panel3;
        private Panel panel1;
    }
}