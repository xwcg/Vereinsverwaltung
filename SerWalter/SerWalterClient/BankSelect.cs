using SerWalterClient.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerWalterClient
{
    public partial class BankSelect : Form
    {
        BindingList<BankAccount> banks;

        public BankAccount SelectedAccount;

        public BankSelect()
        {
            InitializeComponent();
        }

        private void ReloadBanks()
        {
            List<BankAccount> serverBanks = Network.Request.GetBanks();
            if (serverBanks == null)
                serverBanks = new List<BankAccount>();

            banks = new BindingList<BankAccount>(serverBanks);

            dataGridBanks.DataSource = banks;
        }

        private void BankSelect_Load(object sender, EventArgs e)
        {
            ReloadBanks();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (BankCreate dialog = new BankCreate())
            {
                if(dialog.ShowDialog(this) == DialogResult.OK)
                {
                    ReloadBanks();
                }
            }
        }

        private void dataGridBanks_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridBanks.SelectedRows.Count == 1)
            {
                SelectedAccount = (BankAccount)dataGridBanks.SelectedRows[0].DataBoundItem;
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
