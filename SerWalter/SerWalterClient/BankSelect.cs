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

        public BankSelect()
        {
            InitializeComponent();
        }

        private void BankSelect_Load(object sender, EventArgs e)
        {
            List<BankAccount> serverBanks;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
