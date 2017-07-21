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
    public partial class MenuAfterLogin : MetroForm, IMenuAfterLoginView
    {
        public MenuAfterLogin()
        {
            InitializeComponent();
            this.Text = "Menu";

        }


        ConnectController _controller;

        #region Events raised  back to controller

        private void createGameButton_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            this._controller.CreateRoom();
        }

        private void joinGameButton_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            this._controller.JoinGame();

        }

        private void rakingButton_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            this._controller.Ranking();


        }


        #endregion

        #region ICatalogView implementation
        public void SetController(ConnectController controller)
        {

            _controller = controller;
        }

        public void Hide()
        {
            this.Visible = false;

        }

        public void ShowDialogs()
        {
            this.ShowDialog();
        }


        #endregion


    }
}
