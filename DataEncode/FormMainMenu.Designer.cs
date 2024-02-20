namespace DataEncode
{
    partial class FormMainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.roundButton1 = new RoundButton();
            this.roundButton2 = new RoundButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.button_ManageData = new System.Windows.Forms.Button();
            this.button_Database = new System.Windows.Forms.Button();
            this.button_Stats = new System.Windows.Forms.Button();
            this.button_ImportData = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // roundButton1
            // 
            this.roundButton1.Location = new System.Drawing.Point(0, 0);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(75, 23);
            this.roundButton1.TabIndex = 0;
            // 
            // roundButton2
            // 
            this.roundButton2.Location = new System.Drawing.Point(0, 0);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.Size = new System.Drawing.Size(75, 23);
            this.roundButton2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 123);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelTitle);
            this.panel2.Controls.Add(this.button_ManageData);
            this.panel2.Controls.Add(this.button_Database);
            this.panel2.Controls.Add(this.button_Stats);
            this.panel2.Controls.Add(this.button_ImportData);
            this.panel2.Location = new System.Drawing.Point(49, 221);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 289);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Varela Round", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Welcome! To get started, select one of the options above. ";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Varela Round", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.labelTitle.Location = new System.Drawing.Point(13, 28);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(282, 46);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Invoice Reader";
            // 
            // button_ManageData
            // 
            this.button_ManageData.BackColor = System.Drawing.Color.Black;
            this.button_ManageData.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_ManageData.FlatAppearance.BorderSize = 2;
            this.button_ManageData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.button_ManageData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ManageData.Font = new System.Drawing.Font("Varela Round", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_ManageData.ForeColor = System.Drawing.Color.Transparent;
            this.button_ManageData.Location = new System.Drawing.Point(604, 170);
            this.button_ManageData.Name = "button_ManageData";
            this.button_ManageData.Size = new System.Drawing.Size(160, 40);
            this.button_ManageData.TabIndex = 3;
            this.button_ManageData.Text = "Manage data";
            this.button_ManageData.UseVisualStyleBackColor = false;
            this.button_ManageData.Click += new System.EventHandler(this.button_ManageData_Click);
            // 
            // button_Database
            // 
            this.button_Database.BackColor = System.Drawing.Color.Black;
            this.button_Database.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Database.FlatAppearance.BorderSize = 2;
            this.button_Database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.button_Database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Database.Font = new System.Drawing.Font("Varela Round", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Database.ForeColor = System.Drawing.Color.Transparent;
            this.button_Database.Location = new System.Drawing.Point(403, 170);
            this.button_Database.Name = "button_Database";
            this.button_Database.Size = new System.Drawing.Size(183, 40);
            this.button_Database.TabIndex = 2;
            this.button_Database.Text = "Database access";
            this.button_Database.UseVisualStyleBackColor = false;
            this.button_Database.Click += new System.EventHandler(this.button_Database_Click);
            // 
            // button_Stats
            // 
            this.button_Stats.BackColor = System.Drawing.Color.Black;
            this.button_Stats.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Stats.FlatAppearance.BorderSize = 2;
            this.button_Stats.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.button_Stats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Stats.Font = new System.Drawing.Font("Varela Round", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Stats.ForeColor = System.Drawing.Color.Transparent;
            this.button_Stats.Location = new System.Drawing.Point(201, 170);
            this.button_Stats.Name = "button_Stats";
            this.button_Stats.Size = new System.Drawing.Size(183, 40);
            this.button_Stats.TabIndex = 1;
            this.button_Stats.Text = "View statistics";
            this.button_Stats.UseVisualStyleBackColor = false;
            this.button_Stats.Click += new System.EventHandler(this.button_Stats_Click);
            // 
            // button_ImportData
            // 
            this.button_ImportData.BackColor = System.Drawing.Color.Black;
            this.button_ImportData.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_ImportData.FlatAppearance.BorderSize = 2;
            this.button_ImportData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(0)))));
            this.button_ImportData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ImportData.Font = new System.Drawing.Font("Varela Round", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_ImportData.ForeColor = System.Drawing.Color.White;
            this.button_ImportData.Location = new System.Drawing.Point(22, 170);
            this.button_ImportData.Name = "button_ImportData";
            this.button_ImportData.Size = new System.Drawing.Size(160, 40);
            this.button_ImportData.TabIndex = 0;
            this.button_ImportData.Text = "Import data";
            this.button_ImportData.UseVisualStyleBackColor = false;
            this.button_ImportData.Click += new System.EventHandler(this.button_ImportData_Click);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1416, 775);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private RoundButton roundButton1;
        private RoundButton roundButton2;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Button button_ManageData;
        private Button button_Database;
        private Button button_Stats;
        private Button button_ImportData;
        private Label labelTitle;
        private Label label1;
    }
}