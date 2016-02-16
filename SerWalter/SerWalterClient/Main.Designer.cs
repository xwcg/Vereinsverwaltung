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
            this.tabFinance = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonMemberAdd = new System.Windows.Forms.Button();
            this.buttonMemberInvoice = new System.Windows.Forms.Button();
            this.listMembers = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonMemberSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(1073, 688);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabMembers
            // 
            this.tabMembers.Controls.Add(this.splitContainer1);
            this.tabMembers.Location = new System.Drawing.Point(4, 36);
            this.tabMembers.Name = "tabMembers";
            this.tabMembers.Padding = new System.Windows.Forms.Padding(3);
            this.tabMembers.Size = new System.Drawing.Size(1065, 648);
            this.tabMembers.TabIndex = 0;
            this.tabMembers.Text = "Mitglieder";
            this.tabMembers.UseVisualStyleBackColor = true;
            // 
            // tabFinance
            // 
            this.tabFinance.Location = new System.Drawing.Point(4, 36);
            this.tabFinance.Name = "tabFinance";
            this.tabFinance.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinance.Size = new System.Drawing.Size(1079, 660);
            this.tabFinance.TabIndex = 1;
            this.tabFinance.Text = "Finanzen";
            this.tabFinance.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listMembers);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1059, 642);
            this.splitContainer1.SplitterDistance = 688;
            this.splitContainer1.TabIndex = 0;
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
            this.panel1.Size = new System.Drawing.Size(688, 31);
            this.panel1.TabIndex = 1;
            // 
            // buttonMemberAdd
            // 
            this.buttonMemberAdd.Location = new System.Drawing.Point(5, 3);
            this.buttonMemberAdd.Name = "buttonMemberAdd";
            this.buttonMemberAdd.Size = new System.Drawing.Size(97, 23);
            this.buttonMemberAdd.TabIndex = 0;
            this.buttonMemberAdd.Text = "Neues Mitglied";
            this.buttonMemberAdd.UseVisualStyleBackColor = true;
            // 
            // buttonMemberInvoice
            // 
            this.buttonMemberInvoice.Location = new System.Drawing.Point(108, 3);
            this.buttonMemberInvoice.Name = "buttonMemberInvoice";
            this.buttonMemberInvoice.Size = new System.Drawing.Size(229, 23);
            this.buttonMemberInvoice.TabIndex = 0;
            this.buttonMemberInvoice.Text = "Rechnung für ausgewählte erstellen";
            this.buttonMemberInvoice.UseVisualStyleBackColor = true;
            // 
            // listMembers
            // 
            this.listMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listMembers.CheckBoxes = true;
            this.listMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMembers.FullRowSelect = true;
            this.listMembers.GridLines = true;
            this.listMembers.Location = new System.Drawing.Point(0, 31);
            this.listMembers.Name = "listMembers";
            this.listMembers.Size = new System.Drawing.Size(688, 611);
            this.listMembers.TabIndex = 2;
            this.listMembers.UseCompatibleStateImageBehavior = false;
            this.listMembers.View = System.Windows.Forms.View.List;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonMemberSave);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 642);
            this.panel2.TabIndex = 0;
            // 
            // buttonMemberSave
            // 
            this.buttonMemberSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMemberSave.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonMemberSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemberSave.ForeColor = System.Drawing.Color.White;
            this.buttonMemberSave.Location = new System.Drawing.Point(241, 4);
            this.buttonMemberSave.Name = "buttonMemberSave";
            this.buttonMemberSave.Size = new System.Drawing.Size(121, 32);
            this.buttonMemberSave.TabIndex = 3;
            this.buttonMemberSave.Text = "Speichern";
            this.buttonMemberSave.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Details";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 688);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.Text = "Vereinsverwaltung";
            this.tabControl1.ResumeLayout(false);
            this.tabMembers.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMembers;
        private System.Windows.Forms.TabPage tabFinance;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listMembers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMemberInvoice;
        private System.Windows.Forms.Button buttonMemberAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonMemberSave;
        private System.Windows.Forms.Label label1;
    }
}

