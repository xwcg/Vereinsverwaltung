using System;
using System.Windows.Forms;

namespace SerWalterClient
{
    public partial class Main : Form
    {
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
        }
    }
}