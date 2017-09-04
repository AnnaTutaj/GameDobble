using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TcpClientProgram.Controller;
using TcpClientProgram.View;
using MetroFramework.Forms;
using MetroFramework;


namespace TcpClientProgram.View
{
    public partial class Menu : MetroForm, IMenuView
    {


        public Menu()
        {
            InitializeComponent();
            this.Text = "Start";


        }

        MenuController _controller;

        #region Events raised  back to controller
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this._controller.StartGame();

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this._controller.CreateAnAccount();

        }

        #endregion

        #region ICatalogView implementation
        public void SetController(MenuController controller)
        {

            _controller = controller;
        }

        public void Hide()
        {
            this.Visible = false;


        }

     
        #endregion


    }
}
