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
    public partial class CreateOrJoinRoom : MetroForm, ICreateOrJoinRoomView
    {
        public CreateOrJoinRoom()
        {
            InitializeComponent();

            this.Text = "Create or join room";

        }

        ConnectController _controller;


        #region Events raised  back to controller

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Hide();

            string[] data = comboBox1.Text.Split(' ');
            this._controller.JoinRoom(data[0]);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._controller.RefreshList();

        }

        private void numberOfPlayersBT_Click(object sender, EventArgs e)
        {
            this.Hide();
            //  string[] data1 = comboBox2.Text.Split(' ');


            this._controller.MakeANewGame(comboBox2.Text, comboBox3.Text, comboBox4.Text);

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



        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Console.WriteLine("sialala2");


            }
            // Prompt user to save his data

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                Console.WriteLine("sialala");
            }
            // Autosave and clear up ressources
        }








        #endregion

    }
}
