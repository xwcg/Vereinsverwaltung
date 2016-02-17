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
    }
}