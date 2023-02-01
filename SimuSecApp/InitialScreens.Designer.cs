
namespace SimuSecApp
{
    partial class InitialScreens
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialScreens));
            this.tabControl1 = new SimuSecApp.TabControlWithoutHeader();
            this.FirstPage = new System.Windows.Forms.TabPage();
            this.ExtendLicenseButton = new SimuSecApp.RJButton();
            this.SignUpButton = new SimuSecApp.RJButton();
            this.LoginButton = new SimuSecApp.RJButton();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginScreen = new System.Windows.Forms.TabPage();
            this.PasswordErrorLabel = new System.Windows.Forms.Label();
            this.EmailErrorLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new SimuSecApp.RJButton();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.FirstPage.SuspendLayout();
            this.LoginScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.FirstPage);
            this.tabControl1.Controls.Add(this.LoginScreen);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1009, 596);
            this.tabControl1.TabIndex = 0;
            // 
            // FirstPage
            // 
            this.FirstPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FirstPage.BackgroundImage")));
            this.FirstPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FirstPage.Controls.Add(this.ExtendLicenseButton);
            this.FirstPage.Controls.Add(this.SignUpButton);
            this.FirstPage.Controls.Add(this.LoginButton);
            this.FirstPage.Controls.Add(this.label1);
            this.FirstPage.Location = new System.Drawing.Point(4, 22);
            this.FirstPage.Margin = new System.Windows.Forms.Padding(2);
            this.FirstPage.Name = "FirstPage";
            this.FirstPage.Padding = new System.Windows.Forms.Padding(2);
            this.FirstPage.Size = new System.Drawing.Size(1001, 570);
            this.FirstPage.TabIndex = 0;
            this.FirstPage.Text = "FirstPage";
            this.FirstPage.UseVisualStyleBackColor = true;
            // 
            // ExtendLicenseButton
            // 
            this.ExtendLicenseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.ExtendLicenseButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.ExtendLicenseButton.BorderColor = System.Drawing.SystemColors.Desktop;
            this.ExtendLicenseButton.BorderRadius = 40;
            this.ExtendLicenseButton.BorderSize = 0;
            this.ExtendLicenseButton.FlatAppearance.BorderSize = 0;
            this.ExtendLicenseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExtendLicenseButton.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtendLicenseButton.ForeColor = System.Drawing.Color.White;
            this.ExtendLicenseButton.Location = new System.Drawing.Point(261, 368);
            this.ExtendLicenseButton.Name = "ExtendLicenseButton";
            this.ExtendLicenseButton.Size = new System.Drawing.Size(479, 84);
            this.ExtendLicenseButton.TabIndex = 3;
            this.ExtendLicenseButton.Text = "Extend License";
            this.ExtendLicenseButton.TextColor = System.Drawing.Color.White;
            this.ExtendLicenseButton.UseVisualStyleBackColor = false;
            this.ExtendLicenseButton.Click += new System.EventHandler(this.ExtendLicenseButton_Click);
            // 
            // SignUpButton
            // 
            this.SignUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.SignUpButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.SignUpButton.BorderColor = System.Drawing.SystemColors.Desktop;
            this.SignUpButton.BorderRadius = 40;
            this.SignUpButton.BorderSize = 0;
            this.SignUpButton.FlatAppearance.BorderSize = 0;
            this.SignUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignUpButton.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpButton.ForeColor = System.Drawing.Color.White;
            this.SignUpButton.Location = new System.Drawing.Point(261, 243);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(479, 84);
            this.SignUpButton.TabIndex = 2;
            this.SignUpButton.Text = "Sign Up";
            this.SignUpButton.TextColor = System.Drawing.Color.White;
            this.SignUpButton.UseVisualStyleBackColor = false;
            this.SignUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.LoginButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.LoginButton.BorderColor = System.Drawing.SystemColors.Desktop;
            this.LoginButton.BorderRadius = 40;
            this.LoginButton.BorderSize = 0;
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.Transparent;
            this.LoginButton.Location = new System.Drawing.Point(258, 129);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(479, 84);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.Text = "Login";
            this.LoginButton.TextColor = System.Drawing.Color.Transparent;
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miriam Fixed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(309, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome To SimuSec!";
            // 
            // LoginScreen
            // 
            this.LoginScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.LoginScreen.Controls.Add(this.PasswordErrorLabel);
            this.LoginScreen.Controls.Add(this.EmailErrorLabel);
            this.LoginScreen.Controls.Add(this.SubmitButton);
            this.LoginScreen.Controls.Add(this.PasswordTextBox);
            this.LoginScreen.Controls.Add(this.EmailTextBox);
            this.LoginScreen.Controls.Add(this.PasswordLabel);
            this.LoginScreen.Controls.Add(this.EmailLabel);
            this.LoginScreen.Controls.Add(this.LoginLabel);
            this.LoginScreen.Controls.Add(this.Logo);
            this.LoginScreen.Location = new System.Drawing.Point(4, 22);
            this.LoginScreen.Margin = new System.Windows.Forms.Padding(2);
            this.LoginScreen.Name = "LoginScreen";
            this.LoginScreen.Padding = new System.Windows.Forms.Padding(2);
            this.LoginScreen.Size = new System.Drawing.Size(1001, 570);
            this.LoginScreen.TabIndex = 1;
            this.LoginScreen.Text = "LoginScreen";
            // 
            // PasswordErrorLabel
            // 
            this.PasswordErrorLabel.AutoSize = true;
            this.PasswordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.PasswordErrorLabel.Location = new System.Drawing.Point(147, 249);
            this.PasswordErrorLabel.Name = "PasswordErrorLabel";
            this.PasswordErrorLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PasswordErrorLabel.Size = new System.Drawing.Size(29, 13);
            this.PasswordErrorLabel.TabIndex = 8;
            this.PasswordErrorLabel.Text = "Error";
            this.PasswordErrorLabel.Visible = false;
            // 
            // EmailErrorLabel
            // 
            this.EmailErrorLabel.AutoSize = true;
            this.EmailErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.EmailErrorLabel.Location = new System.Drawing.Point(147, 136);
            this.EmailErrorLabel.Name = "EmailErrorLabel";
            this.EmailErrorLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EmailErrorLabel.Size = new System.Drawing.Size(29, 13);
            this.EmailErrorLabel.TabIndex = 7;
            this.EmailErrorLabel.Text = "Error";
            this.EmailErrorLabel.Visible = false;
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.SystemColors.Control;
            this.SubmitButton.BackgroundColor = System.Drawing.SystemColors.Control;
            this.SubmitButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.SubmitButton.BorderRadius = 20;
            this.SubmitButton.BorderSize = 0;
            this.SubmitButton.FlatAppearance.BorderSize = 0;
            this.SubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitButton.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.ForeColor = System.Drawing.Color.Black;
            this.SubmitButton.Location = new System.Drawing.Point(342, 463);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(339, 65);
            this.SubmitButton.TabIndex = 6;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.TextColor = System.Drawing.Color.Black;
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(148, 205);
            this.PasswordTextBox.MaxLength = 24;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(533, 28);
            this.PasswordTextBox.TabIndex = 5;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.Location = new System.Drawing.Point(148, 97);
            this.EmailTextBox.MaxLength = 254;
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(533, 28);
            this.EmailTextBox.TabIndex = 4;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PasswordLabel.Location = new System.Drawing.Point(13, 200);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(112, 25);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.EmailLabel.Location = new System.Drawing.Point(13, 92);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(71, 25);
            this.EmailLabel.TabIndex = 2;
            this.EmailLabel.Text = "Email:";
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.LoginLabel.Location = new System.Drawing.Point(460, 5);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(142, 55);
            this.LoginLabel.TabIndex = 1;
            this.LoginLabel.Text = "Login";
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("Logo.InitialImage")));
            this.Logo.Location = new System.Drawing.Point(959, 5);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(37, 33);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // InitialScreens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1009, 593);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1025, 632);
            this.MinimumSize = new System.Drawing.Size(1025, 632);
            this.Name = "InitialScreens";
            this.Text = "SimuSec";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.FirstPage.ResumeLayout(false);
            this.FirstPage.PerformLayout();
            this.LoginScreen.ResumeLayout(false);
            this.LoginScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private TabControlWithoutHeader tabControl1;
        private System.Windows.Forms.TabPage FirstPage;
        private System.Windows.Forms.TabPage LoginScreen;
        private System.Windows.Forms.Label label1;
        private RJButton LoginButton;
        private RJButton ExtendLicenseButton;
        private RJButton SignUpButton;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private RJButton SubmitButton;
        private System.Windows.Forms.Label PasswordErrorLabel;
        private System.Windows.Forms.Label EmailErrorLabel;
    }
}

