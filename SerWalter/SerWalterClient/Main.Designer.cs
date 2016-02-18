namespace SerWalterClient
{
    partial class Main
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMembers = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridMembers = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonMemberInvoice = new System.Windows.Forms.Button();
            this.buttonMemberAdd = new System.Windows.Forms.Button();
            this.panelMemberDetails = new System.Windows.Forms.Panel();
            this.fieldIsSepa = new System.Windows.Forms.CheckBox();
            this.buttonBankChoose = new System.Windows.Forms.Button();
            this.fieldJobType = new System.Windows.Forms.ComboBox();
            this.fieldJobName = new System.Windows.Forms.TextBox();
            this.fieldDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.fieldLastName = new System.Windows.Forms.TextBox();
            this.fieldCountry = new System.Windows.Forms.TextBox();
            this.fieldCity = new System.Windows.Forms.TextBox();
            this.fieldZipCode = new System.Windows.Forms.TextBox();
            this.fieldBankAccountInfo = new System.Windows.Forms.TextBox();
            this.fieldStreet = new System.Windows.Forms.TextBox();
            this.fieldFirstName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonMemberSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabFinance = new System.Windows.Forms.TabPage();
            this.buttonCreateBilanz = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.fieldSum = new System.Windows.Forms.TextBox();
            this.dataGridInvoices = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMembers)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelMemberDetails.SuspendLayout();
            this.tabFinance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMembers);
            this.tabControl1.Controls.Add(this.tabFinance);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 32);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1143, 718);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabMembers
            // 
            this.tabMembers.Controls.Add(this.splitContainer1);
            this.tabMembers.Location = new System.Drawing.Point(4, 36);
            this.tabMembers.Name = "tabMembers";
            this.tabMembers.Padding = new System.Windows.Forms.Padding(3);
            this.tabMembers.Size = new System.Drawing.Size(1135, 678);
            this.tabMembers.TabIndex = 0;
            this.tabMembers.Text = "Mitglieder";
            this.tabMembers.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridMembers);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelMemberDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1129, 672);
            this.splitContainer1.SplitterDistance = 739;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridMembers
            // 
            this.dataGridMembers.AllowUserToAddRows = false;
            this.dataGridMembers.AllowUserToDeleteRows = false;
            this.dataGridMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridMembers.Location = new System.Drawing.Point(0, 31);
            this.dataGridMembers.Name = "dataGridMembers";
            this.dataGridMembers.ReadOnly = true;
            this.dataGridMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMembers.Size = new System.Drawing.Size(739, 641);
            this.dataGridMembers.TabIndex = 1;
            this.dataGridMembers.SelectionChanged += new System.EventHandler(this.dataGridMembers_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonMemberInvoice);
            this.panel1.Controls.Add(this.buttonMemberAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 31);
            this.panel1.TabIndex = 0;
            // 
            // buttonMemberInvoice
            // 
            this.buttonMemberInvoice.Location = new System.Drawing.Point(108, 3);
            this.buttonMemberInvoice.Name = "buttonMemberInvoice";
            this.buttonMemberInvoice.Size = new System.Drawing.Size(229, 23);
            this.buttonMemberInvoice.TabIndex = 1;
            this.buttonMemberInvoice.Text = "Rechnung für ausgewählte erstellen";
            this.buttonMemberInvoice.UseVisualStyleBackColor = true;
            // 
            // buttonMemberAdd
            // 
            this.buttonMemberAdd.Location = new System.Drawing.Point(5, 3);
            this.buttonMemberAdd.Name = "buttonMemberAdd";
            this.buttonMemberAdd.Size = new System.Drawing.Size(97, 23);
            this.buttonMemberAdd.TabIndex = 0;
            this.buttonMemberAdd.Text = "Neues Mitglied";
            this.buttonMemberAdd.UseVisualStyleBackColor = true;
            this.buttonMemberAdd.Click += new System.EventHandler(this.buttonMemberAdd_Click);
            // 
            // panelMemberDetails
            // 
            this.panelMemberDetails.Controls.Add(this.fieldIsSepa);
            this.panelMemberDetails.Controls.Add(this.buttonBankChoose);
            this.panelMemberDetails.Controls.Add(this.fieldJobType);
            this.panelMemberDetails.Controls.Add(this.fieldJobName);
            this.panelMemberDetails.Controls.Add(this.fieldDateOfBirth);
            this.panelMemberDetails.Controls.Add(this.fieldLastName);
            this.panelMemberDetails.Controls.Add(this.fieldCountry);
            this.panelMemberDetails.Controls.Add(this.fieldCity);
            this.panelMemberDetails.Controls.Add(this.fieldZipCode);
            this.panelMemberDetails.Controls.Add(this.fieldBankAccountInfo);
            this.panelMemberDetails.Controls.Add(this.fieldStreet);
            this.panelMemberDetails.Controls.Add(this.fieldFirstName);
            this.panelMemberDetails.Controls.Add(this.label3);
            this.panelMemberDetails.Controls.Add(this.label6);
            this.panelMemberDetails.Controls.Add(this.label5);
            this.panelMemberDetails.Controls.Add(this.label4);
            this.panelMemberDetails.Controls.Add(this.label11);
            this.panelMemberDetails.Controls.Add(this.label10);
            this.panelMemberDetails.Controls.Add(this.label9);
            this.panelMemberDetails.Controls.Add(this.label13);
            this.panelMemberDetails.Controls.Add(this.label8);
            this.panelMemberDetails.Controls.Add(this.label2);
            this.panelMemberDetails.Controls.Add(this.buttonMemberSave);
            this.panelMemberDetails.Controls.Add(this.label12);
            this.panelMemberDetails.Controls.Add(this.label7);
            this.panelMemberDetails.Controls.Add(this.label1);
            this.panelMemberDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMemberDetails.Enabled = false;
            this.panelMemberDetails.Location = new System.Drawing.Point(0, 0);
            this.panelMemberDetails.Name = "panelMemberDetails";
            this.panelMemberDetails.Size = new System.Drawing.Size(386, 672);
            this.panelMemberDetails.TabIndex = 0;
            // 
            // fieldIsSepa
            // 
            this.fieldIsSepa.AutoSize = true;
            this.fieldIsSepa.Location = new System.Drawing.Point(8, 516);
            this.fieldIsSepa.Name = "fieldIsSepa";
            this.fieldIsSepa.Size = new System.Drawing.Size(74, 17);
            this.fieldIsSepa.TabIndex = 25;
            this.fieldIsSepa.Text = "Lastschrift";
            this.fieldIsSepa.UseVisualStyleBackColor = true;
            this.fieldIsSepa.CheckedChanged += new System.EventHandler(this.fieldIsSepa_CheckedChanged);
            // 
            // buttonBankChoose
            // 
            this.buttonBankChoose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBankChoose.Location = new System.Drawing.Point(282, 488);
            this.buttonBankChoose.Name = "buttonBankChoose";
            this.buttonBankChoose.Size = new System.Drawing.Size(99, 23);
            this.buttonBankChoose.TabIndex = 24;
            this.buttonBankChoose.Text = "Wählen";
            this.buttonBankChoose.UseVisualStyleBackColor = true;
            this.buttonBankChoose.Click += new System.EventHandler(this.buttonBankChoose_Click);
            // 
            // fieldJobType
            // 
            this.fieldJobType.FormattingEnabled = true;
            this.fieldJobType.Location = new System.Drawing.Point(9, 200);
            this.fieldJobType.Name = "fieldJobType";
            this.fieldJobType.Size = new System.Drawing.Size(183, 21);
            this.fieldJobType.TabIndex = 10;
            this.fieldJobType.SelectedIndexChanged += new System.EventHandler(this.fieldJobType_SelectedIndexChanged);
            // 
            // fieldJobName
            // 
            this.fieldJobName.Location = new System.Drawing.Point(9, 156);
            this.fieldJobName.Name = "fieldJobName";
            this.fieldJobName.Size = new System.Drawing.Size(183, 20);
            this.fieldJobName.TabIndex = 8;
            this.fieldJobName.TextChanged += new System.EventHandler(this.fieldJobName_TextChanged);
            // 
            // fieldDateOfBirth
            // 
            this.fieldDateOfBirth.Location = new System.Drawing.Point(9, 112);
            this.fieldDateOfBirth.Name = "fieldDateOfBirth";
            this.fieldDateOfBirth.Size = new System.Drawing.Size(183, 20);
            this.fieldDateOfBirth.TabIndex = 6;
            this.fieldDateOfBirth.ValueChanged += new System.EventHandler(this.fieldDateOfBirth_ValueChanged);
            // 
            // fieldLastName
            // 
            this.fieldLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldLastName.Location = new System.Drawing.Point(198, 68);
            this.fieldLastName.Name = "fieldLastName";
            this.fieldLastName.Size = new System.Drawing.Size(183, 20);
            this.fieldLastName.TabIndex = 4;
            this.fieldLastName.TextChanged += new System.EventHandler(this.fieldLastName_TextChanged);
            // 
            // fieldCountry
            // 
            this.fieldCountry.Location = new System.Drawing.Point(8, 400);
            this.fieldCountry.Name = "fieldCountry";
            this.fieldCountry.Size = new System.Drawing.Size(183, 20);
            this.fieldCountry.TabIndex = 20;
            this.fieldCountry.TextChanged += new System.EventHandler(this.fieldCountry_TextChanged);
            // 
            // fieldCity
            // 
            this.fieldCity.Location = new System.Drawing.Point(9, 361);
            this.fieldCity.Name = "fieldCity";
            this.fieldCity.Size = new System.Drawing.Size(183, 20);
            this.fieldCity.TabIndex = 18;
            this.fieldCity.TextChanged += new System.EventHandler(this.fieldCity_TextChanged);
            // 
            // fieldZipCode
            // 
            this.fieldZipCode.Location = new System.Drawing.Point(9, 322);
            this.fieldZipCode.Name = "fieldZipCode";
            this.fieldZipCode.Size = new System.Drawing.Size(183, 20);
            this.fieldZipCode.TabIndex = 15;
            this.fieldZipCode.TextChanged += new System.EventHandler(this.fieldZipCode_TextChanged);
            // 
            // fieldBankAccountInfo
            // 
            this.fieldBankAccountInfo.Location = new System.Drawing.Point(6, 490);
            this.fieldBankAccountInfo.Name = "fieldBankAccountInfo";
            this.fieldBankAccountInfo.ReadOnly = true;
            this.fieldBankAccountInfo.Size = new System.Drawing.Size(270, 20);
            this.fieldBankAccountInfo.TabIndex = 23;
            // 
            // fieldStreet
            // 
            this.fieldStreet.Location = new System.Drawing.Point(9, 283);
            this.fieldStreet.Name = "fieldStreet";
            this.fieldStreet.Size = new System.Drawing.Size(183, 20);
            this.fieldStreet.TabIndex = 13;
            this.fieldStreet.TextChanged += new System.EventHandler(this.fieldStreet_TextChanged);
            // 
            // fieldFirstName
            // 
            this.fieldFirstName.Location = new System.Drawing.Point(9, 68);
            this.fieldFirstName.Name = "fieldFirstName";
            this.fieldFirstName.Size = new System.Drawing.Size(183, 20);
            this.fieldFirstName.TabIndex = 2;
            this.fieldFirstName.TextChanged += new System.EventHandler(this.fieldFirstName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nachname";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Beschäftigungstyp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Beschäftigung";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Geburtstag";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 384);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Land";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Stadt";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "PLZ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 474);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Konto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Straße";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vorname";
            // 
            // buttonMemberSave
            // 
            this.buttonMemberSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMemberSave.Location = new System.Drawing.Point(260, 4);
            this.buttonMemberSave.Name = "buttonMemberSave";
            this.buttonMemberSave.Size = new System.Drawing.Size(121, 32);
            this.buttonMemberSave.TabIndex = 0;
            this.buttonMemberSave.Text = "Speichern";
            this.buttonMemberSave.UseVisualStyleBackColor = false;
            this.buttonMemberSave.Click += new System.EventHandler(this.buttonMemberSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 439);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 25);
            this.label12.TabIndex = 21;
            this.label12.Text = "Finanzen";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Adresse";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Details";
            // 
            // tabFinance
            // 
            this.tabFinance.Controls.Add(this.dataGridInvoices);
            this.tabFinance.Controls.Add(this.fieldSum);
            this.tabFinance.Controls.Add(this.label14);
            this.tabFinance.Controls.Add(this.buttonCreateBilanz);
            this.tabFinance.Location = new System.Drawing.Point(4, 36);
            this.tabFinance.Name = "tabFinance";
            this.tabFinance.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinance.Size = new System.Drawing.Size(1135, 678);
            this.tabFinance.TabIndex = 1;
            this.tabFinance.Text = "Finanzen";
            this.tabFinance.UseVisualStyleBackColor = true;
            // 
            // buttonCreateBilanz
            // 
            this.buttonCreateBilanz.Location = new System.Drawing.Point(6, 6);
            this.buttonCreateBilanz.Name = "buttonCreateBilanz";
            this.buttonCreateBilanz.Size = new System.Drawing.Size(192, 23);
            this.buttonCreateBilanz.TabIndex = 0;
            this.buttonCreateBilanz.Text = "Jahresbilanz erstellen";
            this.buttonCreateBilanz.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Summe";
            // 
            // fieldSum
            // 
            this.fieldSum.Location = new System.Drawing.Point(56, 51);
            this.fieldSum.Name = "fieldSum";
            this.fieldSum.ReadOnly = true;
            this.fieldSum.Size = new System.Drawing.Size(181, 20);
            this.fieldSum.TabIndex = 2;
            // 
            // dataGridInvoices
            // 
            this.dataGridInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInvoices.Location = new System.Drawing.Point(11, 94);
            this.dataGridInvoices.Name = "dataGridInvoices";
            this.dataGridInvoices.Size = new System.Drawing.Size(1116, 576);
            this.dataGridInvoices.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 718);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "Vereinsverwaltung";
            this.tabControl1.ResumeLayout(false);
            this.tabMembers.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMembers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelMemberDetails.ResumeLayout(false);
            this.panelMemberDetails.PerformLayout();
            this.tabFinance.ResumeLayout(false);
            this.tabFinance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMembers;
        private System.Windows.Forms.TabPage tabFinance;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMemberInvoice;
        private System.Windows.Forms.Button buttonMemberAdd;
        private System.Windows.Forms.Panel panelMemberDetails;
        private System.Windows.Forms.Button buttonMemberSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fieldLastName;
        private System.Windows.Forms.TextBox fieldFirstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fieldJobType;
        private System.Windows.Forms.TextBox fieldJobName;
        private System.Windows.Forms.DateTimePicker fieldDateOfBirth;
        private System.Windows.Forms.TextBox fieldCountry;
        private System.Windows.Forms.TextBox fieldCity;
        private System.Windows.Forms.TextBox fieldZipCode;
        private System.Windows.Forms.TextBox fieldStreet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonBankChoose;
        private System.Windows.Forms.TextBox fieldBankAccountInfo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox fieldIsSepa;
        private System.Windows.Forms.DataGridView dataGridMembers;
        private System.Windows.Forms.Button buttonCreateBilanz;
        private System.Windows.Forms.TextBox fieldSum;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dataGridInvoices;
    }
}

