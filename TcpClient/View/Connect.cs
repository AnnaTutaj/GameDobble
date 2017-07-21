using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TcpClientProgram.Controller;
using MetroFramework;
using MetroFramework.Forms;

namespace TcpClientProgram.View
{
    public partial class Connect : MetroForm, IConnectView
    {


        public Connect()
        {
            InitializeComponent();

            InitializeMyControl();
        }

        ConnectController _controller;



        #region Events raised  back to controller
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Console.WriteLine("nick: " + userNameTextbox.Text);


            this._controller.ConnectServer(userNameTextbox.Text, serveripTextbox.Text, portTextbox.Text, passwordTextbox.Text);
        }
  



        #endregion

        #region ICatalogView implementation
        public void SetController(ConnectController controller)
        {

            _controller = controller;
        }

        public void SetClientMessage(string msg)
        {

            if (!InvokeRequired)
            {
                //listBox1.Items.Add(msg.ToString());

            }
            else
            {
                Invoke(new Action<string>(SetClientMessage), msg);
            }
        }


        public string PortTextbox
        {
            get { return this.portTextbox.Text; }
            set { this.portTextbox.Text = value; }
        }

        public string ServeripTextbox
        {
            get { return this.serveripTextbox.Text; }
            set { this.serveripTextbox.Text = value; }
        }

        public string UserNameTextbox
        {
            get { return this.userNameTextbox.Text; }
            set { this.userNameTextbox.Text = value; }
        }

        public string PasswordTextbox
        {
            get { return this.passwordTextbox.Text; }
            set { this.passwordTextbox.Text = value; }

        }
        public void Hide()
        {
            this.Visible = false;

        }

        public void ShowInformation(string message, string title)
        {

            if (!InvokeRequired)
            {

                MetroMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Invoke(new Action<string, string>(ShowInformation), message, title);
            }


        }

        #endregion

        private void InitializeMyControl()
        {
            // Set to no text.
            passwordTextbox.Text = "";
            // The password character is an asterisk.
            passwordTextbox.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            passwordTextbox.MaxLength = 14;
        }

        
    }
}
