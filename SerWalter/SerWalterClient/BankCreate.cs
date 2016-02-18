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
    public partial class BankCreate : Form
    {
        public BankCreate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankAccount bank = new BankAccount();
            bank.id = -1;
            bank.holder_name = fieldHolder.Text;
            bank.institute_name = fieldInstitute.Text;
            bank.iban = fieldIBAN.Text;
            bank.bic = fieldBIC.Text;

            bank.Push();
        }
    }
}
