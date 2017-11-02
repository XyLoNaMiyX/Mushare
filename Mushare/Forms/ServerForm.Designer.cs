namespace Mushare
{
    partial class ServerForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hostPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.hostIpTextBox = new System.Windows.Forms.TextBox();
            this.copyHostIpButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.playlistActionsTable = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.songListBox1 = new Mushare.Controls.SongListBox();
            this.hostPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.playlistActionsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(392, 209);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 20);
            this.textBox1.TabIndex = 10;
            // 
            // hostPanel
            // 
            this.hostPanel.Controls.Add(this.hostIpTextBox);
            this.hostPanel.Controls.Add(this.copyHostIpButton);
            this.hostPanel.Location = new System.Drawing.Point(425, 50);
            this.hostPanel.Name = "hostPanel";
            this.hostPanel.Size = new System.Drawing.Size(157, 31);
            this.hostPanel.TabIndex = 9;
            // 
            // hostIpTextBox
            // 
            this.hostIpTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hostIpTextBox.Location = new System.Drawing.Point(3, 5);
            this.hostIpTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.hostIpTextBox.Name = "hostIpTextBox";
            this.hostIpTextBox.ReadOnly = true;
            this.hostIpTextBox.Size = new System.Drawing.Size(92, 20);
            this.hostIpTextBox.TabIndex = 3;
            this.hostIpTextBox.Text = "Loading...";
            // 
            // copyHostIpButton
            // 
            this.copyHostIpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyHostIpButton.Location = new System.Drawing.Point(101, 3);
            this.copyHostIpButton.Name = "copyHostIpButton";
            this.copyHostIpButton.Size = new System.Drawing.Size(52, 23);
            this.copyHostIpButton.TabIndex = 2;
            this.copyHostIpButton.Text = "Copy";
            this.copyHostIpButton.UseVisualStyleBackColor = true;
            this.copyHostIpButton.Click += new System.EventHandler(this.copyHostIpButton_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.welcomeLabel.Location = new System.Drawing.Point(9, 9);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(280, 17);
            this.welcomeLabel.TabIndex = 7;
            this.welcomeLabel.Text = "Welcome";
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.Location = new System.Drawing.Point(367, 53);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(52, 23);
            this.logoutButton.TabIndex = 8;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.songListBox1);
            this.groupBox1.Controls.Add(this.playlistActionsTable);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 217);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Playlist";
            // 
            // playlistActionsTable
            // 
            this.playlistActionsTable.ColumnCount = 3;
            this.playlistActionsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.playlistActionsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.playlistActionsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.playlistActionsTable.Controls.Add(this.button3, 2, 0);
            this.playlistActionsTable.Controls.Add(this.button2, 0, 0);
            this.playlistActionsTable.Controls.Add(this.button4, 1, 0);
            this.playlistActionsTable.Location = new System.Drawing.Point(6, 46);
            this.playlistActionsTable.Name = "playlistActionsTable";
            this.playlistActionsTable.RowCount = 1;
            this.playlistActionsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playlistActionsTable.Size = new System.Drawing.Size(298, 32);
            this.playlistActionsTable.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(201, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 26);
            this.button3.TabIndex = 14;
            this.button3.Text = "Create";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 26);
            this.button2.TabIndex = 13;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(102, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 26);
            this.button4.TabIndex = 15;
            this.button4.Text = "Rename";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(298, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // songListBox1
            // 
            this.songListBox1.AllowDrop = true;
            this.songListBox1.FormattingEnabled = true;
            this.songListBox1.Items.AddRange(new object[] {
            new System.DateTime(2016, 5, 7, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 8, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 9, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 10, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 11, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 12, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 13, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 14, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 15, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 16, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 17, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 18, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 19, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 20, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 21, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 22, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 23, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 24, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 25, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 26, 18, 8, 56, 0),
            new System.DateTime(2016, 5, 27, 18, 8, 56, 0)});
            this.songListBox1.Location = new System.Drawing.Point(9, 97);
            this.songListBox1.Name = "songListBox1";
            this.songListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.songListBox1.Size = new System.Drawing.Size(292, 95);
            this.songListBox1.TabIndex = 14;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.hostPanel);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.logoutButton);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.hostPanel.ResumeLayout(false);
            this.hostPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.playlistActionsTable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel hostPanel;
        private System.Windows.Forms.TextBox hostIpTextBox;
        private System.Windows.Forms.Button copyHostIpButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TableLayoutPanel playlistActionsTable;
        private Controls.SongListBox songListBox1;
    }
}