﻿using SerWalterClient.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SerWalterClient
{
    public partial class Main : Form
    {
        private BindingList<Member> members;
        private List<CostModifier> modifiers;
        private List<Job> jobs;
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
            modifiers = Network.Request.GetModifiers();
            if (modifiers == null)
                modifiers = new List<CostModifier>();

            jobs = Network.Request.GetJobs();
            if (jobs == null)
                jobs = new List<Job>();

            foreach (Job job in jobs)
                fieldJobType.Items.Add(job);

            ReloadMembers();
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
            if(selectedMemberHasPendingChanges)
            {
                if (MessageBox.Show("Änderungen Speichern?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    selectedMember.Push();
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

        }

        private void fieldIsSepa_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreEvents) return;

            selectedMember.bank_is_sepa = fieldIsSepa.Checked;

            selectedMemberHasPendingChanges = true;
        }
    }
}