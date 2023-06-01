using System;
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
using System.Xml;

namespace SimuSecApp
{
    
    public partial class InitialScreens : Form
    {
        Client _client = new Client();
        Protocol protocol = new Protocol();
        string _optionPickedPrice;

        public InitialScreens(Client client = null)
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
            tabControl1.SelectedTab = SignUpScreen;
            CurrentDateLabelSignUp.Text = $"Current Date: {protocol.GetCurrentTimeAsString()}";
        }

        private void ExtendLicenseButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = ExtendLicenseScreen;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (EmailTextBox.Text.Length != 0 && PasswordTextBox.Text.Length != 0) {

                string[] args = { EmailTextBox.Text, PasswordTextBox.Text };
                string toSend = _client.PackByProtocol(args, type: "LOGIN");
                _client.Send(toSend);

                string verificationRes = _client.Receive()[0];

                if (!(protocol.isVerified(verificationRes))) {
                    GeneralLoginErrorLabel.Text = verificationRes;
                    GeneralLoginErrorLabel.Visible = true;
                    return;
                }

                SimuSec appForm = new SimuSec(_client);
                this.Hide();
                appForm.ShowDialog(); // Need to close the other form
                this.Close();


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

        private void Logo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = FirstPage;
        }

        private void SubmitSUButton_Click(object sender, EventArgs e)
        {
            if (ConfirmPasswordTextBoxSU.Text.Length != 0 && PasswordTextBoxSU.Text.Length != 0
                && EmailTextBoxSU.Text.Length != 0)
            {
                string[] args = { EmailTextBoxSU.Text, PasswordTextBoxSU.Text };
                string toSend = _client.PackByProtocol(args, type: "SIGNUP");
                _client.Send(toSend);

                string verificationRes = _client.Receive()[0];

                if (!(protocol.isVerified(verificationRes)))
                {
                    GeneralSUErrorLabel.Text = verificationRes;
                    GeneralLoginErrorLabel.Visible = true;
                    return;
                }


            }

            if (EmailTextBoxSU.Text.Length == 0)
            {
                EmailErrorLabelSU.Visible = true;
                EmailErrorLabelSU.Text = "Email cannot be empty";
            }
            else
            {
                EmailErrorLabelSU.Visible = false;
            }

            if (PasswordTextBoxSU.Text.Length == 0)
            {
                PasswordErrorLabelSU.Visible = true;
                PasswordErrorLabelSU.Text = "Password cannot be empty";
            }
            else
            {
                PasswordErrorLabelSU.Visible = false;
            }

            if (ConfirmPasswordTextBoxSU.Text.Length == 0)
            {
                ConfirmPassErrorLabelSU.Visible = true;
                ConfirmPassErrorLabelSU.Text = "Confirm Password cannot be empty";
            }
            else if (ConfirmPasswordTextBoxSU.Text != PasswordTextBoxSU.Text)
            {
                ConfirmPassErrorLabelSU.Visible = true;
                ConfirmPassErrorLabelSU.Text = "Passwords do not match...";
            }
            else
            {
                ConfirmPassErrorLabelSU.Visible = false;
            }
        }


        private void Plan1MonthButton_Click(object sender, EventArgs e)
        {
            Plan1MonthButton.BackColor = Color.RoyalBlue;
            Plan1PriceLabel.BackColor  = Color.RoyalBlue;

            // Disable the other 2 buttons
            Plan6MonthButton.BackColor = Color.MidnightBlue;
            Plan2PriceLabel.BackColor  = Color.MidnightBlue;

            Plan12MonthButton.BackColor = Color.MidnightBlue;
            Plan3PriceLabel.BackColor   = Color.MidnightBlue;
        }

        private void Plan6MonthButton_Click(object sender, EventArgs e)
        {
            Plan6MonthButton.BackColor = Color.RoyalBlue;
            Plan2PriceLabel.BackColor  = Color.RoyalBlue;

            // Disable the other 2 buttons
            Plan1MonthButton.BackColor = Color.MidnightBlue;
            Plan1PriceLabel.BackColor  = Color.MidnightBlue;

            Plan12MonthButton.BackColor = Color.MidnightBlue;
            Plan3PriceLabel.BackColor   = Color.MidnightBlue;
        }
        private void Plan12MonthButton_Click(object sender, EventArgs e)
        {
            Plan12MonthButton.BackColor = Color.RoyalBlue;
            Plan3PriceLabel.BackColor   = Color.RoyalBlue;

            // Disable the other 2 buttons
            Plan1MonthButton.BackColor = Color.MidnightBlue;
            Plan1PriceLabel.BackColor  = Color.MidnightBlue;

            Plan6MonthButton.BackColor = Color.MidnightBlue;
            Plan2PriceLabel.BackColor = Color.MidnightBlue;
        }

        private void LogoEXL1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = FirstPage;
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            

            Color selectedColor = Color.RoyalBlue;

            if (Plan1MonthButton.BackColor == selectedColor)
            {
                _optionPickedPrice = Plan1PriceLabel.Text;
            }
            else if(Plan6MonthButton.BackColor == selectedColor)
            {
                _optionPickedPrice = Plan2PriceLabel.Text;
            }
            else
            {
                _optionPickedPrice = Plan3PriceLabel.Text;
            }

            tabControl1.SelectedTab = PaymentScreen;
            TotalPriceCart.Text = _optionPickedPrice.ToString();

        }

        private void Plan1PriceLabel_Click(object sender, EventArgs e)
        {
            Plan1MonthButton.BackColor = Color.RoyalBlue;
            Plan1PriceLabel.BackColor = Color.RoyalBlue;

            // Disable the other 2 buttons
            Plan6MonthButton.BackColor = Color.MidnightBlue;
            Plan2PriceLabel.BackColor = Color.MidnightBlue;

            Plan12MonthButton.BackColor = Color.MidnightBlue;
            Plan3PriceLabel.BackColor = Color.MidnightBlue;
        }

        private void Plan2PriceLabel_Click(object sender, EventArgs e)
        {
            Plan6MonthButton.BackColor = Color.RoyalBlue;
            Plan2PriceLabel.BackColor = Color.RoyalBlue;

            // Disable the other 2 buttons
            Plan1MonthButton.BackColor = Color.MidnightBlue;
            Plan1PriceLabel.BackColor = Color.MidnightBlue;

            Plan12MonthButton.BackColor = Color.MidnightBlue;
            Plan3PriceLabel.BackColor = Color.MidnightBlue;
        }

        private void Plan3PriceLabel_Click(object sender, EventArgs e)
        {
            Plan12MonthButton.BackColor = Color.RoyalBlue;
            Plan3PriceLabel.BackColor = Color.RoyalBlue;

            // Disable the other 2 buttons
            Plan1MonthButton.BackColor = Color.MidnightBlue;
            Plan1PriceLabel.BackColor = Color.MidnightBlue;

            Plan6MonthButton.BackColor = Color.MidnightBlue;
            Plan2PriceLabel.BackColor = Color.MidnightBlue;
        }

        private void CardExpirationDateMonths_Enter(object sender, EventArgs e)
        {
            if (CardExpirationDateMonths.Text == "MM")
            {
                CardExpirationDateMonths.Text = "";
                CardExpirationDateMonths.ForeColor = Color.Black;
            }
        }

        private void CardExpirationDateYears_Enter(object sender, EventArgs e)
        {
            if (CardExpirationDateYears.Text == "YY")
            {
                CardExpirationDateYears.Text = "";
                CardExpirationDateYears.ForeColor = Color.Black;
            }
        }

        private void CardExpirationDateMonths_Leave(object sender, EventArgs e)
        {
            if (CardExpirationDateMonths.Text == "")
            {
                CardExpirationDateMonths.Text = "MM";
                CardExpirationDateMonths.ForeColor = Color.Silver;
            }
        }

        private void CardExpirationDateYears_Leave(object sender, EventArgs e)
        {
            if (CardExpirationDateYears.Text == "")
            {
                CardExpirationDateYears.Text = "YY";
                CardExpirationDateYears.ForeColor = Color.Silver;
            }
        }

        private void CVVTextBox_Enter(object sender, EventArgs e)
        {
            if (CardCVVTextBox.Text == "XXX")
            {
                CardCVVTextBox.Text = "";
                CardCVVTextBox.ForeColor = Color.Black;
            }
        }

        private void CVVTextBox_Leave(object sender, EventArgs e)
        {
            if (CardCVVTextBox.Text == "")
            {
                CardCVVTextBox.Text = "XXX";
                CardCVVTextBox.ForeColor = Color.Silver;
            }
        }

        private void PaymentButtton_Click(object sender, EventArgs e)
        {

            if (UserEmailTextBoxPayment.Text != "" && CardExpirationDateYears.Text != "" && CardExpirationDateMonths.Text != "" &&
                CardCVVTextBox.Text != "" && CardHolderNameTextBox.Text != "" && 
                CardNumberTextBox.Text != "")
            {

                string cardHolderNameToSend = protocol.PackCardHolderNameFormat(CardHolderNameTextBox.Text);
                string cardNumberToSend = protocol.PackCardNumberFormat(CardNumberTextBox.Text);
                string cardExpirationDateToSend = protocol.PackCardExpirationDateFormat(CardExpirationDateMonths.Text,
                                                                                        CardExpirationDateYears.Text);
                string cardCVVToSend = protocol.PackCardCVVFormat(CardCVVTextBox.Text);

                // Send the data
                string[] args = { UserEmailTextBoxPayment.Text, TotalPriceCart.Text, cardHolderNameToSend, cardNumberToSend,cardExpirationDateToSend, cardCVVToSend };
                string toSend = _client.PackByProtocol(args, type: "PAY");
                _client.Send(toSend);

                string verificationRes = _client.Receive()[0];

                if (!(protocol.isVerified(verificationRes)))
                {
                    GeneralCardErrorLabel.Text = verificationRes;
                    GeneralCardErrorLabel.Visible = true;
                    return;
                }

            }

            if (CardExpirationDateYears.Text == "" || CardExpirationDateMonths.Text == "")
            {
                CardExpirationDateErrorLabel.Text = "Date cannot be empty";
                CardExpirationDateErrorLabel.Visible = true;
            }
            else
            {
                CardExpirationDateErrorLabel.Visible = false;
            }
            if (CardCVVTextBox.Text.Length == 0)
            {
                CardCVVErrorLabel.Text = "CVV Cannot be empty";
                CardCVVErrorLabel.Visible = true;
            }
            else
            {
                CardCVVErrorLabel.Visible = false;
            }
            if (CardHolderNameTextBox.Text == "")
            {
                CardHolderNameErrorLabel.Text = "Card holder name cannot be empty";
                CardHolderNameErrorLabel.Visible = true;
            }
            else
            {
                CardHolderNameErrorLabel.Visible = false;
            }
            if (CardNumberTextBox.Text == "")
            {
                CardNumberErrorLabel.Text = "Card number cannot be empty";
                CardNumberErrorLabel.Visible = true;
            }
            else
            {
                CardNumberErrorLabel.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = ExtendLicenseScreen;
        }
    }
}
