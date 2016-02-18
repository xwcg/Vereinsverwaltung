using SerWalterClient.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace SerWalterClient
{
    public partial class Main : Form
    {
        private BindingList<Member> members;
        private List<CostModifier> modifiers;
        private List<Job> jobs;
        private List<BankAccount> banks;
        private List<Invoice> invoices;
        private bool ignoreEvents = false;

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (Network.Request.ServiceAddress == null)
            {
                using (ServerConnect connectDialog = new ServerConnect())
                {
                    if (connectDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        InitializeData();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }

        private void InitializeData()
        {
            ReloadBanks();

            modifiers = Network.Request.GetModifiers();
            if (modifiers == null)
                modifiers = new List<CostModifier>();

            jobs = Network.Request.GetJobs();
            if (jobs == null)
                jobs = new List<Job>();

            foreach (Job job in jobs)
                fieldJobType.Items.Add(job);

            ReloadMembers();
            ReloadInvoices();
        }

        private void ReloadBanks()
        {
            banks = Network.Request.GetBanks();
            if (banks == null)
                banks = new List<BankAccount>();
        }
        private void ReloadInvoices()
        {
            invoices = Network.Request.GetInvoices();
            if (invoices == null)
                invoices = new List<Invoice>();

            decimal debt = 0.0m;
            decimal paid = 0.0m;

            foreach (Invoice invoice in invoices)
            {
                debt += invoice.calculated_cost;
                paid += invoice.paid_cost;
            }

            fieldSum.Text = (paid - debt).ToString("C", CultureInfo.GetCultureInfo("de-DE"));
        }

        private void ReloadMembers()
        {
            List<Member> serverMembers = Network.Request.GetMembers();
            if (serverMembers == null)
                serverMembers = new List<Member>();

            members = new BindingList<Member>(serverMembers);

            dataGridMembers.DataSource = members;
        }

        private CostModifier findModifier(int id)
        {
            if (modifiers != null)
                foreach (CostModifier modifier in modifiers)
                    if (modifier.id == id)
                        return modifier;

            return null;
        }

        private Job findJob(int id)
        {
            if (jobs != null)
                foreach (Job job in jobs)
                    if (job.id == id)
                        return job;

            return null;
        }
        private BankAccount findBank(int id)
        {
            if (banks != null)
                foreach (BankAccount bank in banks)
                    if (bank.id == id)
                        return bank;

            return null;
        }
        private Member findMember(int id)
        {
            if (members != null)
                foreach (Member member in members)
                    if (member.id == id)
                        return member;

            return null;
        }

        private void dataGridMembers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridMembers.SelectedRows.Count == 1)
            {
                DetailsPopulate((Member)dataGridMembers.SelectedRows[0].DataBoundItem);
            }
            else
            {
                DetailsPopulate(null);
            }
        }

        private Member selectedMember;
        private bool selectedMemberHasPendingChanges = false;

        private void DetailsPopulate(Member member)
        {
            if (selectedMemberHasPendingChanges)
            {
                if (MessageBox.Show("Änderungen Speichern?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    selectedMember.Push();
                    selectedMemberHasPendingChanges = false;
                    ReloadMembers();
                }
            }

            panelMemberDetails.SuspendLayout();
            ignoreEvents = true;

            fieldBankAccountInfo.Text =
            fieldCity.Text =
            fieldCountry.Text =
            fieldFirstName.Text =
            fieldJobName.Text =
            fieldLastName.Text =
            fieldStreet.Text =
            fieldZipCode.Text = "";
            fieldDateOfBirth.Value = DateTime.Now;
            fieldIsSepa.Checked = false;
            fieldJobType.SelectedItem = null;

            if (member != null)
            {
                fieldFirstName.Text = member.first_name;
                fieldLastName.Text = member.last_name;
                fieldDateOfBirth.Value = member.dob;
                fieldJobName.Text = member.job_name;
                fieldJobType.SelectedItem = findJob(member.job_type);
                fieldStreet.Text = member.street;
                fieldZipCode.Text = member.zipcode;
                fieldCity.Text = member.city;
                fieldCountry.Text = member.country;
                fieldBankAccountInfo.Text = findBank(member.bank_account) == null ? "" : findBank(member.bank_account).ToString();
                fieldIsSepa.Checked = member.bank_is_sepa;
            }

            selectedMember = member;
            selectedMemberHasPendingChanges = false;

            panelMemberDetails.Enabled = (member != null);

            ignoreEvents = false;
            panelMemberDetails.ResumeLayout();
        }

        private void buttonMemberAdd_Click(object sender, EventArgs e)
        {
            Member newMember = new Member();
            newMember.id = -1;

            DetailsPopulate(newMember);
            fieldFirstName.Focus();
        }

        private void fieldFirstName_TextChanged(object sender, EventArgs e)
        {
            if (ignoreEvents) return;

            selectedMember.first_name = fieldFirstName.Text;

            selectedMemberHasPendingChanges = true;
        }

        private void fieldLastName_TextChanged(object sender, EventArgs e)
        {
            if (ignoreEvents) return;

            selectedMember.last_name = fieldLastName.Text;

            selectedMemberHasPendingChanges = true;
        }

        private void fieldDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreEvents) return;

            selectedMember.dob = fieldDateOfBirth.Value;

            selectedMemberHasPendingChanges = true;
        }

        private void fieldJobName_TextChanged(object sender, EventArgs e)
        {
            if (ignoreEvents) return;

            selectedMember.job_name = fieldJobName.Text;

            selectedMemberHasPendingChanges = true;
        }

        private void fieldJobType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ignoreEvents) return;

            if (fieldJobType.SelectedItem != null)
                selectedMember.job_type = ((Job)fieldJobType.SelectedItem).id;
            else
                selectedMember.job_type = -1;

            selectedMemberHasPendingChanges = true;
        }

        private void fieldStreet_TextChanged(object sender, EventArgs e)
        {
            if (ignoreEvents) return;

            selectedMember.street = fieldStreet.Text;

            selectedMemberHasPendingChanges = true;
        }

        private void fieldZipCode_TextChanged(object sender, EventArgs e)
        {
            if (ignoreEvents) return;

            selectedMember.zipcode = fieldZipCode.Text;

            selectedMemberHasPendingChanges = true;
        }

        private void fieldCity_TextChanged(object sender, EventArgs e)
        {
            if (ignoreEvents) return;

            selectedMember.city = fieldCity.Text;

            selectedMemberHasPendingChanges = true;
        }

        private void fieldCountry_TextChanged(object sender, EventArgs e)
        {
            if (ignoreEvents) return;

            selectedMember.country = fieldCountry.Text;

            selectedMemberHasPendingChanges = true;
        }

        private void buttonBankChoose_Click(object sender, EventArgs e)
        {
            if (ignoreEvents) return;
            using (BankSelect selecter = new BankSelect())
            {
                if (selecter.ShowDialog(this) == DialogResult.OK)
                {
                    selectedMember.bank_account = selecter.SelectedAccount.id;
                    ReloadBanks();
                    fieldBankAccountInfo.Text = findBank(selectedMember.bank_account).ToString();

                    selectedMemberHasPendingChanges = true;
                }
            }
        }

        private void fieldIsSepa_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreEvents) return;

            selectedMember.bank_is_sepa = fieldIsSepa.Checked;

            selectedMemberHasPendingChanges = true;
        }

        private void buttonMemberSave_Click(object sender, EventArgs e)
        {
            if (selectedMember != null)
            {
                selectedMember.Push();
                selectedMemberHasPendingChanges = false;
                ReloadMembers();
            }
        }

        private void buttonCreateBilanz_Click(object sender, EventArgs e)
        {
            string bilanzText = "Jahresbilanz für " + DateTime.Now.Year + "\n\r\n\r";
            bilanzText += "Mitglied\t\tSoll\t\tHaben\t\tDifferenz\n\r";
            bilanzText += "========\t\t====\t\t=====\t\t=========\n\r\n\r";

            CultureInfo deCulture = CultureInfo.GetCultureInfo("de-DE");
            decimal debt = 0.0m;
            decimal paid = 0.0m;

            foreach (Invoice i in invoices)
            {
                if (i.date.Year == DateTime.Now.Year)
                {
                    bilanzText += String.Format("{0}\t\t{1}\t\t{2}\t\t{3}\n\r",
                        findMember(i.member).ToString(),
                        i.calculated_cost.ToString("C", deCulture),
                        i.paid_cost.ToString("C", deCulture),
                        (i.paid_cost - i.calculated_cost).ToString("C", deCulture)
                        );

                    debt += i.calculated_cost;
                    paid += i.paid_cost;
                }
            }
            bilanzText += "========\t\t====\t\t=====\t\t=========\n\r";
            bilanzText += String.Format("        \t\t    \t\tSumme\t\t{0}", (paid - debt).ToString("C", deCulture));

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Textdatei (*.txt)|*.txt";
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter w = new StreamWriter(dialog.FileName))
                    {
                        w.Write(bilanzText);
                        w.Flush();
                        w.Close();
                    }

                    MessageBox.Show("OK!");
                }
            }
        }

        private void buttonMemberInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridMembers.SelectedRows.Count > 0)
            {
                List<int> invoiceIds = new List<int>();

                for (int i = 0; i < dataGridMembers.SelectedRows.Count; i++)
                {
                    invoiceIds.Add(((Member)dataGridMembers.SelectedRows[i].DataBoundItem).id);
                }

                Network.Request.Send("invoice", invoiceIds);
                ReloadInvoices();
                tabControl1.SelectedIndex = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReloadInvoices();
        }
    }
}