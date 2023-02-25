namespace SimuSecApp
{
    partial class SimuSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimuSec));
            this.tabControlWithoutHeader1 = new SimuSecApp.TabControlWithoutHeader();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ChooseNetworkButton = new SimuSecApp.RJButton();
            this.ChooseWebButton = new SimuSecApp.RJButton();
            this.ChooseApplicationButton = new SimuSecApp.RJButton();
            this.ChooseAttackTypeLabel = new System.Windows.Forms.Label();
            this.tabControlWithoutHeader1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlWithoutHeader1
            // 
            this.tabControlWithoutHeader1.Controls.Add(this.tabPage1);
            this.tabControlWithoutHeader1.Controls.Add(this.tabPage2);
            this.tabControlWithoutHeader1.Location = new System.Drawing.Point(0, -2);
            this.tabControlWithoutHeader1.Multiline = true;
            this.tabControlWithoutHeader1.Name = "tabControlWithoutHeader1";
            this.tabControlWithoutHeader1.SelectedIndex = 0;
            this.tabControlWithoutHeader1.Size = new System.Drawing.Size(1383, 754);
            this.tabControlWithoutHeader1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.tabPage1.Controls.Add(this.ChooseAttackTypeLabel);
            this.tabPage1.Controls.Add(this.ChooseApplicationButton);
            this.tabPage1.Controls.Add(this.ChooseWebButton);
            this.tabPage1.Controls.Add(this.ChooseNetworkButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1375, 725);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 71);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ChooseNetworkButton
            // 
            this.ChooseNetworkButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ChooseNetworkButton.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.ChooseNetworkButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ChooseNetworkButton.BorderRadius = 0;
            this.ChooseNetworkButton.BorderSize = 0;
            this.ChooseNetworkButton.FlatAppearance.BorderSize = 0;
            this.ChooseNetworkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseNetworkButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseNetworkButton.ForeColor = System.Drawing.Color.White;
            this.ChooseNetworkButton.Location = new System.Drawing.Point(351, 140);
            this.ChooseNetworkButton.Name = "ChooseNetworkButton";
            this.ChooseNetworkButton.Size = new System.Drawing.Size(673, 104);
            this.ChooseNetworkButton.TabIndex = 0;
            this.ChooseNetworkButton.Text = "Network";
            this.ChooseNetworkButton.TextColor = System.Drawing.Color.White;
            this.ChooseNetworkButton.UseVisualStyleBackColor = false;
            this.ChooseNetworkButton.Click += new System.EventHandler(this.ChooseNetworkButton_Click);
            // 
            // ChooseWebButton
            // 
            this.ChooseWebButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ChooseWebButton.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.ChooseWebButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ChooseWebButton.BorderRadius = 0;
            this.ChooseWebButton.BorderSize = 0;
            this.ChooseWebButton.FlatAppearance.BorderSize = 0;
            this.ChooseWebButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseWebButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseWebButton.ForeColor = System.Drawing.Color.White;
            this.ChooseWebButton.Location = new System.Drawing.Point(351, 310);
            this.ChooseWebButton.Name = "ChooseWebButton";
            this.ChooseWebButton.Size = new System.Drawing.Size(673, 104);
            this.ChooseWebButton.TabIndex = 1;
            this.ChooseWebButton.Text = "Web";
            this.ChooseWebButton.TextColor = System.Drawing.Color.White;
            this.ChooseWebButton.UseVisualStyleBackColor = false;
            this.ChooseWebButton.Click += new System.EventHandler(this.ChooseWebButton_Click);
            // 
            // ChooseApplicationButton
            // 
            this.ChooseApplicationButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ChooseApplicationButton.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.ChooseApplicationButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ChooseApplicationButton.BorderRadius = 0;
            this.ChooseApplicationButton.BorderSize = 0;
            this.ChooseApplicationButton.FlatAppearance.BorderSize = 0;
            this.ChooseApplicationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseApplicationButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseApplicationButton.ForeColor = System.Drawing.Color.White;
            this.ChooseApplicationButton.Location = new System.Drawing.Point(351, 487);
            this.ChooseApplicationButton.Name = "ChooseApplicationButton";
            this.ChooseApplicationButton.Size = new System.Drawing.Size(673, 104);
            this.ChooseApplicationButton.TabIndex = 2;
            this.ChooseApplicationButton.Text = "Application";
            this.ChooseApplicationButton.TextColor = System.Drawing.Color.White;
            this.ChooseApplicationButton.UseVisualStyleBackColor = false;
            this.ChooseApplicationButton.Click += new System.EventHandler(this.ChooseApplicationButton_Click);
            // 
            // ChooseAttackTypeLabel
            // 
            this.ChooseAttackTypeLabel.AutoSize = true;
            this.ChooseAttackTypeLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseAttackTypeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ChooseAttackTypeLabel.Location = new System.Drawing.Point(418, 40);
            this.ChooseAttackTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChooseAttackTypeLabel.Name = "ChooseAttackTypeLabel";
            this.ChooseAttackTypeLabel.Size = new System.Drawing.Size(495, 62);
            this.ChooseAttackTypeLabel.TabIndex = 3;
            this.ChooseAttackTypeLabel.Text = "Choose Attack Type";
            // 
            // SimuSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.tabControlWithoutHeader1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1400, 800);
            this.MinimumSize = new System.Drawing.Size(1400, 800);
            this.Name = "SimuSec";
            this.Text = "SimuSec";
            this.tabControlWithoutHeader1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControlWithoutHeader tabControlWithoutHeader1;
        private System.Windows.Forms.TabPage tabPage1;
        private RJButton ChooseApplicationButton;
        private RJButton ChooseWebButton;
        private RJButton ChooseNetworkButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label ChooseAttackTypeLabel;
    }
}