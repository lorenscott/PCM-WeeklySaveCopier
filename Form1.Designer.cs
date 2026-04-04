namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.cboVersion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.btnOpenSource = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestFolder = new System.Windows.Forms.TextBox();
            this.btnOpenDest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewFileName = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colFileName = new System.Windows.Forms.ColumnHeader();
            this.colDateTime = new System.Windows.Forms.ColumnHeader();
            this.colFileSize = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.cboVersion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSourceFolder);
            this.panel1.Controls.Add(this.btnOpenSource);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDestFolder);
            this.panel1.Controls.Add(this.btnOpenDest);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNewFileName);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 130);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = false;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(5, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(117, 15);
            this.lblVersion.TabIndex = 10;
            this.lblVersion.Text = "PCM Version:";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboVersion
            // 
            this.cboVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVersion.Location = new System.Drawing.Point(127, 6);
            this.cboVersion.Name = "cboVersion";
            this.cboVersion.Size = new System.Drawing.Size(350, 23);
            this.cboVersion.TabIndex = 0;
            this.cboVersion.SelectedIndexChanged += new System.EventHandler(this.cboVersion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Folder:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSourceFolder.Location = new System.Drawing.Point(127, 35);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.PlaceholderText = "Source Folder";
            this.txtSourceFolder.Size = new System.Drawing.Size(559, 23);
            this.txtSourceFolder.TabIndex = 1;
            this.txtSourceFolder.TextChanged += new System.EventHandler(this.txtSourceFolder_TextChanged);
            this.txtSourceFolder.Leave += new System.EventHandler(this.txtSourceFolder_Leave);
            //
            // btnOpenSource
            // 
            this.btnOpenSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSource.BackColor = System.Drawing.Color.FromArgb(58, 90, 135);
            this.btnOpenSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSource.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(58, 90, 135);
            this.btnOpenSource.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(75, 115, 165);
            this.btnOpenSource.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpenSource.ForeColor = System.Drawing.Color.White;
            this.btnOpenSource.Location = new System.Drawing.Point(691, 35);
            this.btnOpenSource.Name = "btnOpenSource";
            this.btnOpenSource.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSource.TabIndex = 2;
            this.btnOpenSource.Text = "\uE838";
            this.btnOpenSource.UseVisualStyleBackColor = false;
            this.btnOpenSource.Click += new System.EventHandler(this.btnOpenSource_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = false;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination Folder:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDestFolder
            // 
            this.txtDestFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDestFolder.Location = new System.Drawing.Point(127, 64);
            this.txtDestFolder.Name = "txtDestFolder";
            this.txtDestFolder.PlaceholderText = "Destination Folder";
            this.txtDestFolder.Size = new System.Drawing.Size(559, 23);
            this.txtDestFolder.TabIndex = 4;
            this.txtDestFolder.Leave += new System.EventHandler(this.txtDestFolder_Leave);
            //
            // btnOpenDest
            // 
            this.btnOpenDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDest.BackColor = System.Drawing.Color.FromArgb(58, 90, 135);
            this.btnOpenDest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(58, 90, 135);
            this.btnOpenDest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(75, 115, 165);
            this.btnOpenDest.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpenDest.ForeColor = System.Drawing.Color.White;
            this.btnOpenDest.Location = new System.Drawing.Point(691, 64);
            this.btnOpenDest.Name = "btnOpenDest";
            this.btnOpenDest.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDest.TabIndex = 4;
            this.btnOpenDest.Text = "\uE838";
            this.btnOpenDest.UseVisualStyleBackColor = false;
            this.btnOpenDest.Click += new System.EventHandler(this.btnOpenDest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = false;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "New File Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewFileName
            // 
            this.txtNewFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewFileName.Location = new System.Drawing.Point(127, 98);
            this.txtNewFileName.Name = "txtNewFileName";
            this.txtNewFileName.PlaceholderText = "New File Name";
            this.txtNewFileName.Size = new System.Drawing.Size(559, 23);
            this.txtNewFileName.TabIndex = 7;
            this.txtNewFileName.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(0, 120, 212);
            this.btnCopy.Enabled = false;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 90, 158);
            this.btnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(16, 110, 190);
            this.btnCopy.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Location = new System.Drawing.Point(691, 98);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "COPY";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.button1_Click);
            //
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colFileName,
                this.colDateTime,
                this.colFileSize});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 130);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(800, 370);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // colFileName
            // 
            this.colFileName.Text = "File Name";
            this.colFileName.Width = 300;
            // 
            // colDateTime
            // 
            this.colDateTime.Text = "Date/Time";
            this.colDateTime.Width = 200;
            // 
            // colFileSize
            // 
            this.colFileSize.Text = "Size";
            this.colFileSize.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.MinimumSize = new System.Drawing.Size(816, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pro Cycling Manager Weekly Save Copier v3.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblVersion;
        private ComboBox cboVersion;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNewFileName;
        private TextBox txtDestFolder;
        private TextBox txtSourceFolder;
        private Button btnCopy;
        private ListView listView1;
        private ColumnHeader colFileName;
        private ColumnHeader colDateTime;
        private ColumnHeader colFileSize;
        private Button btnOpenSource;
        private Button btnOpenDest;
    }
}
