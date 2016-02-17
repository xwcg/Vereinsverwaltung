using SerWalterClient.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SerWalterClient
{
    public partial class Main : Form
    {
        private BindingList<Member> members;
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
                    if (connectDialog.ShowDialog() == DialogResult.OK)
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
            List<Member> serverMembers = Network.Request.GetMembers();
            if (serverMembers == null)
                serverMembers = new List<Member>();

            members = new BindingList<Member>(serverMembers);

            dataGridMembers.DataSource = members;
        }

        private void dataGridMembers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridMembers.SelectedRows.Count > 0)
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
            panelMemberDetails.SuspendLayout();
            ignoreEvents = true;

            fieldBankAccountInfo.Text =
            fieldCity.Text =
            fieldCountry.Text =
            fieldFirstName.Text =
            fieldJobName.Text =
            fieldJobType.Text =
            fieldLastName.Text =
            fieldStreet.Text =
            fieldZipCode.Text = "";
            fieldDateOfBirth.Value = DateTime.Now;
            fieldIsSepa.Checked = false;

            if (member != null)
            {
                fieldFirstName.Text = member.first_name;
                fieldLastName.Text = member.last_name;
                fieldDateOfBirth.Value = member.dob;
                fieldJobName.Text = member.job_name;
                //fieldJobType
                fieldStreet.Text = member.street;
                fieldZipCode.Text = member.zipcode;
                fieldCity.Text = member.city;
                fieldCountry.Text = member.country;
                fieldBankAccountInfo.Text = member.bank_account.ToString();
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
    }
}