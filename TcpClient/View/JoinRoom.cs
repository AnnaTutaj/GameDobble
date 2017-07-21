using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TcpClientProgram.Controller;
using MetroFramework.Forms;
using MetroFramework;

namespace TcpClientProgram.View
{
    public partial class JoinRoom : MetroForm, IJoinRoomView
    {
        public JoinRoom()
        {
            InitializeComponent();

            this.Text = "Join a room";

        }

        ConnectController _controller;


        #region Events raised  back to controller


        private void button1_Click(object sender, EventArgs e)
        {
            this._controller.RefreshList();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Hide();

            string[] data = comboBox1.Text.Split(' ');
            this._controller.JoinRoom(data[0]);

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this._controller.BackToMenuFromJoinRoom();

        }

        #endregion

        #region ICatalogView implementation
        public void SetController(ConnectController controller)
        {
            _controller = controller;
        }


        public void Clear()
        {
            comboBox1.Items.Clear();

        }

        public void RoomList(string message)
        {
            comboBox1.Items.Add(message);

        }


        public void ShowDialogs()
        {
            this.ShowDialog();
        }


        public void Hide()
        {
            this.Visible = false;
        }


        #endregion

        
    }
}
