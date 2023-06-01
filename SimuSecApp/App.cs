using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;

namespace SimuSecApp
{
    public partial class SimuSec : Form
    {
        Client _client;
        Protocol protocol = new Protocol();
        //Fields
        private int borderSize = 2;
        public SimuSec(Client client)
        {
            InitializeComponent();
            _client = client;
            CollapseMenu();
            this.Padding = new Padding(borderSize);
            _client.Send("HOME");

            string[] result = _client.Receive();
            int creds_wanted_amount = int.Parse(result[0]);
            
            int creds_found_amount = int.Parse(result[1]);
            int scan_status = int.Parse(result[2]);

            string dosStrPer = result[3];
            int dosPercent = 0;
            if (dosStrPer != "Could'nt send packets to host")
            {
                dosPercent = int.Parse(result[3]);
            }

            DosProgBar.Maximum = 100;
            DosProgBar.Value = dosPercent;

            phishingProgBar.Value = creds_found_amount;
            phishingProgBar.Maximum = creds_wanted_amount;

            ChangeScanBarByStatus(scan_status);
            TopTabControl.SelectedTab = HomePage;

        }

        private void ChangeScanBarByStatus(int statusKey)
        {
            switch (statusKey)
            {
                case 0:
                    ScannerProgBar.Value = 0;
                    ScannerProgBar.Style = ProgressBarStyle.Continuous;
                    break;
                case 1:
                    ScannerProgBar.Maximum = 100;
                    ScannerProgBar.Value = 50;
                    ScannerProgBar.Style = ProgressBarStyle.Marquee;
                    ScannerProgBar.AnimationSpeed = 2000;
                    break;
                case 2:
                    ScannerProgBar.Style = ProgressBarStyle.Continuous;
                    ScannerProgBar.Value = 1;
                    ScannerProgBar.Maximum = 1;
                    break;
                default:
                    break;

            }
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

        private void LogoSU_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
            if(this.panelMenu.Width > 200) {
                panelMenu.Width = 120;
                this.LogoSU.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0,0,50,0);
                }
            }
            else
            {
                panelMenu.Width = 230;
                LogoSU.Visible = true;
                btnMenu.Dock = DockStyle.None;
                
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "    " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10,0,0,0);
                }
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            _client.Send("HOME");

            string[] result = _client.Receive();
            int creds_wanted_amount = int.Parse(result[0]);

            int creds_found_amount = int.Parse(result[1]);
            int scan_status = int.Parse(result[2]);

            string dosStrPer = result[3];
            int dosPercent = 0;
            if (dosStrPer != "Could'nt send packets to host")
            {
                dosPercent = int.Parse(result[3]);
            }
            DosProgBar.Maximum = 100;
            DosProgBar.Value = dosPercent;

            phishingProgBar.Value = creds_found_amount;
            phishingProgBar.Maximum = creds_wanted_amount;

            ChangeScanBarByStatus(scan_status);
            TopTabControl.SelectedTab = HomePage;
        }

        private void ScannerButton_Click(object sender, EventArgs e)
        {
            TopTabControl.SelectedTab = ScannerPage;
        }

        private void PhishingButton_Click(object sender, EventArgs e)
        {
            TopTabControl.SelectedTab = PhishingPage;
            PhishingTabControl.SelectedTab = SendEmailTab;
            ToAddressTextBox.Text = "Example: email1@gmail.com, email2@gmail.com";
            ToAddressTextBox.ForeColor = Color.LightGray;
            ToAddrErrorLabel.Visible= false;
            GeneralPhishingErrorLabel.Visible= false;

            

        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            _client.Send("LOGOUT");
            InitialScreens appForm = new InitialScreens();
            this.Hide();
            appForm.ShowDialog(); // Need to close the other form
            this.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EmailLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ToAddressTextBox_Enter(object sender, EventArgs e)
        {
            if (ToAddressTextBox.Text == "Example: email1@gmail.com, email2@gmail.com")
            {
                ToAddressTextBox.Text = "";
                ToAddressTextBox.ForeColor = Color.Black;
            }
        }

        private void ToAddressTextBox_Leave(object sender, EventArgs e)
        {
            if (ToAddressTextBox.Text == "") 
            {
                ToAddressTextBox.Text = "Example: email1@gmail.com, email2@gmail.com";
                ToAddressTextBox.ForeColor = Color.LightGray;
            }
        }

        private void SendEmailButton_Click(object sender, EventArgs e)
        {
            if (ToAddressTextBox.Text != "Example: email1@gmail.com, email2@gmail.com"
                && !(WordpressLinkButton.BackColor == Color.MidnightBlue && MicrosoftLinkButton.BackColor == Color.MidnightBlue))
            {

                string service = "";

                if (WordpressLinkButton.BackColor == Color.RoyalBlue)
                    service = "WORDPRESS";
                else if (MicrosoftLinkButton.BackColor == Color.RoyalBlue)
                    service = "MICROSOFT";

                string[] args = { ToAddressTextBox.Text, service };
                string packed = protocol.PackByProtocol(args, type: "PHISHING");
                _client.Send(packed);

                string[] result = _client.Receive();
                string toAddrStatus = result[0];

                if (!protocol.isVerified(toAddrStatus))
                {
                    ToAddrErrorLabel.Text = toAddrStatus;
                    ToAddrErrorLabel.ForeColor= Color.Red;
                    ToAddrErrorLabel.Visible = true;
                }
                else
                {
                    string[] result2 = _client.Receive();
                    string generalStatus = result2[0]; ;

                    GeneralPhishingErrorLabel.Visible = true;

                    if (!protocol.isVerified(generalStatus))
                    {
                        GeneralPhishingErrorLabel.Text = generalStatus;
                        GeneralPhishingErrorLabel.ForeColor = Color.Red;
                        GeneralPhishingErrorLabel.Visible = true;
                    }
                    else
                    {
                        GeneralPhishingErrorLabel.Text = "Sent Emails! Listener started!";
                        GeneralPhishingErrorLabel.ForeColor = Color.Green;
                    }


                }
                
            }
            else
            {
                GeneralPhishingErrorLabel.Visible = true;
                GeneralPhishingErrorLabel.Text = "Fill all fields";
            }
            


        }

        private void SendEmailButton_EnabledChanged(object sender, EventArgs e)
        {
            if (ToAddressTextBox.Text != "Example: email1@gmail.com, email2@gmail.com")
            {
                SendEmailButton.Enabled = true;
            }
            else
            {
                SendEmailButton.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SendEmailTab_Click(object sender, EventArgs e)
        {

        }

        private void WordpressLinkButton_Click(object sender, EventArgs e)
        {
            WordpressLinkButton.BackColor = Color.RoyalBlue;

            // Disable the other button
            MicrosoftLinkButton.BackColor = Color.MidnightBlue;
        }

        private void MicrosoftLinkButton_Click(object sender, EventArgs e)
        {
            MicrosoftLinkButton.BackColor = Color.RoyalBlue;

            // Disable the other button
            WordpressLinkButton.BackColor = Color.MidnightBlue;

        }

        private void HomeTopLabel_Click(object sender, EventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void phishingProgBar_Click(object sender, EventArgs e)
        {
            _client.Send("PHISH_STATS");
            
            PhishingStatsTable.Rows.Clear();

            int amount = int.Parse(_client.Receive()[0]);

            for(int i = 0; i < amount; i++)
            {
                string[] data = _client.Receive();
                string ip = data[0];
                string email = data[1];
                string passwd = data[2];
                PhishingStatsTable.Rows.Add(ip, email, passwd);

            }


            TopTabControl.SelectedTab = PhishingStatsPage;
            StyleTableGrid(PhishingStatsTable);
        }

        private void PhishingProgressTopLabel_Click(object sender, EventArgs e)
        {

        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void StartScanButton_Click(object sender, EventArgs e)
        {
            if(RouterIpTextBox.Text.Length > 0)
            {
                string[] args = { RouterIpTextBox.Text };
                string packed = protocol.PackByProtocol(args, type: "SCAN");
                _client.Send(packed);

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ScannerProgBar_Click(object sender, EventArgs e)
        {
            if(ScannerProgBar.Style == ProgressBarStyle.Continuous && ScannerProgBar.Value == 1 
                && ScannerProgBar.Maximum == 1)
            {
                TopTabControl.SelectedTab = ScanStats;

            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            HomeButton_Click(sender, e);
        }

        private void TopTabControl_Enter(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StyleTableGrid(DataGridView table)
        {
            table.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 25, 51);//selection color
            table.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(64, 64, 64);
            foreach (DataGridViewColumn c in table.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Lucida Console", 16);
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            }

            //dataGridView1.Rows[0].Cells.
            foreach (DataGridViewRow row in table.Rows)
            {

                row.DefaultCellStyle.BackColor = Color.Black;
                row.DefaultCellStyle.ForeColor = Color.RoyalBlue;
                row.Height = 25;

            }
            for (int a = 0; a < table.Rows.Count - 1; a += 2)
            {
                table.Rows[a + 1].DefaultCellStyle.BackColor = Color.FromArgb(32, 32, 32);// design each two gray


            }
            table.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(32, 32, 32);//header backColor
            table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;//header foreColor
            table.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida Console", 16);//header font
            table.EnableHeadersVisualStyles = false;//design header
            table.BackgroundColor = Color.Black;//dataGrid backColor
            table.GridColor = Color.FromArgb(64, 64, 64);//lines color
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//selection mode

            table.RowHeadersVisible = false;

            table.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        
        }

        private void ScanStats_Enter(object sender, EventArgs e)
        {
            _client.Send("SCAN_STATS");

            TableOfAttacks.Rows.Clear();

            int amount = int.Parse(_client.Receive()[0]);

            for(int i = 0; i< amount; i++)
            {
                string[] exploit = _client.Receive();
                string service = exploit[0];
                string Type = exploit[1];
                string CVE = exploit[2];
                string Severity = exploit[3];
                string Description = exploit[4];

                TableOfAttacks.Rows.Add(service, Type, CVE, Severity, Description);
            }

            StyleTableGrid(TableOfAttacks);
        }

        private void iconButton13_Click(object sender, EventArgs e)
        {
            TopTabControl.SelectedTab = DOS;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void AttackDOS_Click(object sender, EventArgs e)
        {
            if (RouterIpTextBoxDos.Text.Length > 0 && DosPortTextBox.Text.Length > 0)
            {
                string[] args = { RouterIpTextBoxDos.Text, DosPortTextBox.Text };
                string packed = protocol.PackByProtocol(args, type: "DOS");
                _client.Send(packed);
                string status = _client.Receive()[0];

                DosAttackErrorLabel.Visible = true;
                if(status != "OK")
                {
                    DosAttackErrorLabel.Text = status;
                    DosAttackErrorLabel.Visible = true;
                    DosAttackErrorLabel.ForeColor = Color.Red;
                }
                else
                {
                    DosAttackErrorLabel.ForeColor = Color.Green;
                    DosAttackErrorLabel.Text = $"Attacking {RouterIpTextBoxDos.Text}";

                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void DosProgBar_Click(object sender, EventArgs e)
        {

                _client.Send("DOS_STATS");

                DosAttacksTable.Rows.Clear();

                int amount = int.Parse(_client.Receive()[0]);

                for (int i = 0; i < amount; i++)
                {
                    string[] data = _client.Receive();
                    string ip = data[0];
                    string port = data[1];
                    string percent = data[2];
                    string status = data[3];
                    
                    if(status == "1") status= "Done";
                    else status= "Running";
                    DosAttacksTable.Rows.Add(ip, port, percent, status);

                }


                TopTabControl.SelectedTab = DosStats;
                StyleTableGrid(DosAttacksTable);
        }
    }
}
