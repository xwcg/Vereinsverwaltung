using Newtonsoft.Json;
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
    public partial class ServerConnect : Form
    {
        public ServerConnect()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Network.Request.ServiceAddress = fieldIp.Text;
            try
            {
                if (JsonConvert.DeserializeObject<Network.SimplifiedResponse>(Network.Request.Send("ping", null)).success)
                {
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            { }
        }

        private void fieldIp_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void fieldIp_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void fieldIp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonConnect.PerformClick();
        }
    }
}
