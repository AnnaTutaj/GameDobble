using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TcpServer.Controller;
using TcpServer.Model;
using MetroFramework.Forms;


namespace TcpServer.View
{
    public partial class Server : MetroForm, IServerView
    {

        public Server()
        {
            InitializeComponent();
        }

        ServerController _controller;

        #region Events raised  back to controller

        private void startListnerButton_Click_1(object sender, EventArgs e)
        {

            this._controller.StartListener(ipAddressTextbox.Text, portTextBox.Text);


        }

        public string Label3
        {
            get { return this.label3.Text; }
            set { this.label3.Text = value; }
        }

        public string PortTextbox
        {
            get { return this.portTextBox.Text; }
            set { this.portTextBox.Text = value; }
        }

        public string IpAddressTextbox
        {
            get { return this.ipAddressTextbox.Text; }
            set { this.ipAddressTextbox.Text = value; }
        }
        #endregion

        #region ICatalogView implementation

        public void SetController(ServerController controller)
        {
            _controller = controller;
        }

        public void AddPlayer(User usr)
        {
            listBox1.Items.Add("Nick: " + usr.UserName + " id: " + usr.UserId + " joined to server");
        }

        public void ShowInformation(string description, string message)
        {
            System.Windows.Forms.MessageBox.Show(message,
  description,
  MessageBoxButtons.OK,
  MessageBoxIcon.Information
 );
        }



        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

