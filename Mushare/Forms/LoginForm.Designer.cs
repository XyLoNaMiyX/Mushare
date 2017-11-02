namespace Mushare
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.hostComboBox = new System.Windows.Forms.ComboBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.connectLabel = new System.Windows.Forms.Label();
            this.clearRecentButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.rememberCheckBox = new System.Windows.Forms.CheckBox();
            this.hostPage = new System.Windows.Forms.TabPage();
            this.hostNameLabel = new System.Windows.Forms.Label();
            this.hostNameTextBox = new System.Windows.Forms.TextBox();
            this.hostButton = new System.Windows.Forms.Button();
            this.hostLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.hostPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginTextBox
            // 
            this.loginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginTextBox.Location = new System.Drawing.Point(77, 6);
            this.loginTextBox.MaxLength = 20;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(231, 20);
            this.loginTextBox.TabIndex = 2;
            this.loginTextBox.TextChanged += new System.EventHandler(this.loginTextBox_TextChanged);
            // 
            // hostComboBox
            // 
            this.hostComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hostComboBox.FormattingEnabled = true;
            this.hostComboBox.Location = new System.Drawing.Point(77, 32);
            this.hostComboBox.Name = "hostComboBox";
            this.hostComboBox.Size = new System.Drawing.Size(115, 21);
            this.hostComboBox.TabIndex = 3;
            this.hostComboBox.TextChanged += new System.EventHandler(this.connectComboBox_TextChanged);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(6, 9);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(65, 13);
            this.loginLabel.TabIndex = 4;
            this.loginLabel.Text = "Login name:";
            // 
            // connectLabel
            // 
            this.connectLabel.AutoSize = true;
            this.connectLabel.Location = new System.Drawing.Point(6, 35);
            this.connectLabel.Name = "connectLabel";
            this.connectLabel.Size = new System.Drawing.Size(62, 13);
            this.connectLabel.TabIndex = 5;
            this.connectLabel.Text = "Connect to:";
            // 
            // clearRecentButton
            // 
            this.clearRecentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearRecentButton.Location = new System.Drawing.Point(198, 32);
            this.clearRecentButton.Name = "clearRecentButton";
            this.clearRecentButton.Size = new System.Drawing.Size(110, 23);
            this.clearRecentButton.TabIndex = 6;
            this.clearRecentButton.Text = "Clear recent hosts";
            this.clearRecentButton.UseVisualStyleBackColor = true;
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.Enabled = false;
            this.connectButton.Location = new System.Drawing.Point(6, 194);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(304, 32);
            this.connectButton.TabIndex = 7;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.mainPage);
            this.tabControl.Controls.Add(this.hostPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(324, 263);
            this.tabControl.TabIndex = 8;
            // 
            // mainPage
            // 
            this.mainPage.Controls.Add(this.rememberCheckBox);
            this.mainPage.Controls.Add(this.loginLabel);
            this.mainPage.Controls.Add(this.connectButton);
            this.mainPage.Controls.Add(this.loginTextBox);
            this.mainPage.Controls.Add(this.clearRecentButton);
            this.mainPage.Controls.Add(this.hostComboBox);
            this.mainPage.Controls.Add(this.connectLabel);
            this.mainPage.Location = new System.Drawing.Point(4, 25);
            this.mainPage.Name = "mainPage";
            this.mainPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainPage.Size = new System.Drawing.Size(316, 234);
            this.mainPage.TabIndex = 0;
            this.mainPage.Text = "Main";
            this.mainPage.UseVisualStyleBackColor = true;
            // 
            // rememberCheckBox
            // 
            this.rememberCheckBox.AutoSize = true;
            this.rememberCheckBox.Enabled = false;
            this.rememberCheckBox.Location = new System.Drawing.Point(8, 59);
            this.rememberCheckBox.Name = "rememberCheckBox";
            this.rememberCheckBox.Size = new System.Drawing.Size(94, 17);
            this.rememberCheckBox.TabIndex = 8;
            this.rememberCheckBox.Text = "Remember me";
            this.rememberCheckBox.UseVisualStyleBackColor = true;
            // 
            // hostPage
            // 
            this.hostPage.Controls.Add(this.hostNameLabel);
            this.hostPage.Controls.Add(this.hostNameTextBox);
            this.hostPage.Controls.Add(this.hostButton);
            this.hostPage.Controls.Add(this.hostLabel);
            this.hostPage.Location = new System.Drawing.Point(4, 25);
            this.hostPage.Name = "hostPage";
            this.hostPage.Padding = new System.Windows.Forms.Padding(3);
            this.hostPage.Size = new System.Drawing.Size(316, 234);
            this.hostPage.TabIndex = 1;
            this.hostPage.Text = "Host";
            this.hostPage.UseVisualStyleBackColor = true;
            // 
            // hostNameLabel
            // 
            this.hostNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hostNameLabel.AutoSize = true;
            this.hostNameLabel.Location = new System.Drawing.Point(6, 171);
            this.hostNameLabel.Name = "hostNameLabel";
            this.hostNameLabel.Size = new System.Drawing.Size(61, 13);
            this.hostNameLabel.TabIndex = 10;
            this.hostNameLabel.Text = "Host name:";
            // 
            // hostNameTextBox
            // 
            this.hostNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hostNameTextBox.Location = new System.Drawing.Point(77, 168);
            this.hostNameTextBox.MaxLength = 20;
            this.hostNameTextBox.Name = "hostNameTextBox";
            this.hostNameTextBox.Size = new System.Drawing.Size(231, 20);
            this.hostNameTextBox.TabIndex = 9;
            this.hostNameTextBox.TextChanged += new System.EventHandler(this.hostNameTextBox_TextChanged);
            // 
            // hostButton
            // 
            this.hostButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hostButton.Enabled = false;
            this.hostButton.Location = new System.Drawing.Point(6, 194);
            this.hostButton.Name = "hostButton";
            this.hostButton.Size = new System.Drawing.Size(304, 32);
            this.hostButton.TabIndex = 8;
            this.hostButton.Text = "Become a host";
            this.hostButton.UseVisualStyleBackColor = true;
            this.hostButton.Click += new System.EventHandler(this.hostButton_Click);
            // 
            // hostLabel
            // 
            this.hostLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hostLabel.Location = new System.Drawing.Point(8, 13);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(300, 146);
            this.hostLabel.TabIndex = 0;
            this.hostLabel.Text = resources.GetString("hostLabel.Text");
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 263);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(300, 260);
            this.Name = "LoginForm";
            this.Text = "Mushare: Login";
            this.tabControl.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.mainPage.PerformLayout();
            this.hostPage.ResumeLayout(false);
            this.hostPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.ComboBox hostComboBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label connectLabel;
        private System.Windows.Forms.Button clearRecentButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage mainPage;
        private System.Windows.Forms.TabPage hostPage;
        private System.Windows.Forms.CheckBox rememberCheckBox;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Button hostButton;
        private System.Windows.Forms.Label hostNameLabel;
        private System.Windows.Forms.TextBox hostNameTextBox;
    }
}

