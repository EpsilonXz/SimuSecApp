using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuSecApp
{
    public partial class SimuSec : Form
    {
        Client _client;
        public SimuSec(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private void ChooseNetworkButton_Click(object sender, EventArgs e)
        {
            
        }

        private void ChooseWebButton_Click(object sender, EventArgs e)
        {

        }

        private void ChooseApplicationButton_Click(object sender, EventArgs e)
        {

        }
    }
}
