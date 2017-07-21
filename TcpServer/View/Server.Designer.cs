namespace TcpServer.View
{
    partial class Server
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.startListnerButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.ipAddressTextbox = new MetroFramework.Controls.MetroTextBox();
            this.portTextBox = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(132, 307);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(264, 225);
            this.listBox1.TabIndex = 7;
            // 
            // startListnerButton
            // 
            this.startListnerButton.Location = new System.Drawing.Point(132, 214);
            this.startListnerButton.Name = "startListnerButton";
            this.startListnerButton.Size = new System.Drawing.Size(264, 46);
            this.startListnerButton.TabIndex = 9;
            this.startListnerButton.Text = "Start listening";
            this.startListnerButton.UseSelectable = true;
            this.startListnerButton.Click += new System.EventHandler(this.startListnerButton_Click_1);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(177, 81);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(69, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Ip address";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(212, 128);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(34, 19);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "Port";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(195, 285);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(136, 19);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "Conencted Clients List";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(203, 170);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(43, 19);
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Runing...";
            // 
            // ipAddressTextbox
            // 
            // 
            // 
            // 
            this.ipAddressTextbox.CustomButton.Image = null;
            this.ipAddressTextbox.CustomButton.Location = new System.Drawing.Point(164, 1);
            this.ipAddressTextbox.CustomButton.Name = "";
            this.ipAddressTextbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ipAddressTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ipAddressTextbox.CustomButton.TabIndex = 1;
            this.ipAddressTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ipAddressTextbox.CustomButton.UseSelectable = true;
            this.ipAddressTextbox.CustomButton.Visible = false;
            this.ipAddressTextbox.Lines = new string[0];
            this.ipAddressTextbox.Location = new System.Drawing.Point(252, 81);
            this.ipAddressTextbox.MaxLength = 32767;
            this.ipAddressTextbox.Name = "ipAddressTextbox";
            this.ipAddressTextbox.PasswordChar = '\0';
            this.ipAddressTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ipAddressTextbox.SelectedText = "";
            this.ipAddressTextbox.SelectionLength = 0;
            this.ipAddressTextbox.SelectionStart = 0;
            this.ipAddressTextbox.ShortcutsEnabled = true;
            this.ipAddressTextbox.Size = new System.Drawing.Size(186, 23);
            this.ipAddressTextbox.TabIndex = 11;
            this.ipAddressTextbox.UseSelectable = true;
            this.ipAddressTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ipAddressTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // portTextBox
            // 
            // 
            // 
            // 
            this.portTextBox.CustomButton.Image = null;
            this.portTextBox.CustomButton.Location = new System.Drawing.Point(67, 1);
            this.portTextBox.CustomButton.Name = "";
            this.portTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.portTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.portTextBox.CustomButton.TabIndex = 1;
            this.portTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.portTextBox.CustomButton.UseSelectable = true;
            this.portTextBox.CustomButton.Visible = false;
            this.portTextBox.Lines = new string[0];
            this.portTextBox.Location = new System.Drawing.Point(252, 128);
            this.portTextBox.MaxLength = 32767;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.PasswordChar = '\0';
            this.portTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.portTextBox.SelectedText = "";
            this.portTextBox.SelectionLength = 0;
            this.portTextBox.SelectionStart = 0;
            this.portTextBox.ShortcutsEnabled = true;
            this.portTextBox.Size = new System.Drawing.Size(89, 23);
            this.portTextBox.TabIndex = 11;
            this.portTextBox.UseSelectable = true;
            this.portTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.portTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TcpServer.Properties.Resources.Dabble_logo;
            this.pictureBox1.Location = new System.Drawing.Point(32, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 560);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.ipAddressTextbox);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.startListnerButton);
            this.Controls.Add(this.listBox1);
            this.Name = "Server";
            this.Text = "Dabble Server";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroButton startListnerButton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroTextBox ipAddressTextbox;
        private MetroFramework.Controls.MetroTextBox portTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

