﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuSecApp
{
    
    public partial class InitialScreens : Form
    {
        Client _client = new Client();

        public InitialScreens()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TabControlWithoutHeader tabControl = new TabControlWithoutHeader();
            RJButton button = new RJButton();

            _client.ExecuteClient();

            tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            tabControl1.TabStop = false;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = LoginScreen;
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {

        }

        private void ExtendLicenseButton_Click(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (EmailTextBox.Text.Length != 0 && PasswordTextBox.Text.Length != 0) {
                MessageBox.Show("Well done! Sending data... ");
                

            }
            
            if (EmailTextBox.Text.Length == 0)
            {
                EmailErrorLabel.Visible = true;
                EmailErrorLabel.Text = "Email cannot be empty";
            }
            else
            {
                EmailErrorLabel.Visible = false;
            }

            if (PasswordTextBox.Text.Length == 0)
            {
                PasswordErrorLabel.Visible = true;
                PasswordErrorLabel.Text = "Password cannot be empty";
            }
            else
            {
                PasswordErrorLabel.Visible = false;
            }
        }
    }
}