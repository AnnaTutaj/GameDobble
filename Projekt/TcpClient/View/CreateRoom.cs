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
    public partial class CreateRoom : MetroForm, ICreateRoomView
    {
        public CreateRoom()
        {
            InitializeComponent();

            this.Text = "Create a room";

        }

        ConnectController _controller;


        #region Events raised  back to controller

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        private void button1_Click(object sender, EventArgs e)
        {
            this._controller.RefreshList();

        }

        private void numberOfPlayersBT_Click(object sender, EventArgs e)
        {
            this.Hide();

            this._controller.MakeANewGame(comboBox2.Text, comboBox3.Text, comboBox4.Text);

        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this._controller.BackToMenuFromCreateRoom();

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

        public void AddItem(int i)
        {
            comboBox2.Items.Add(i);

        }

        public void AddPicuresNames()
        {
            comboBox3.Items.Add("Anime");
            comboBox3.Items.Add("Shapes");
            comboBox3.Items.Add("Food");
            comboBox3.Items.Add("Animals");

        }

        public void AddModesNames()
        {
            comboBox4.Items.Add(8);
            comboBox4.Items.Add(6);

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
