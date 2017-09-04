using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TcpClientProgram.View;

namespace TcpClientProgram.Controller
{
    public class MenuController
    {
        IMenuView _view;


        public MenuController(IMenuView view)
        {
            _view = view;
            view.SetController(this);
        }


        public void StartGame()
        {

            Connect con = new Connect();
            MenuAfterLogin cojg = new MenuAfterLogin();
            Game game = new Game();
            CreateRoom createRoom = new CreateRoom();
            JoinRoom joinRoom = new JoinRoom();
            Ranking ranking = new Ranking();

            ConnectController controller = new ConnectController(con, cojg, createRoom, joinRoom, ranking, game);

            controller.LoadViewConnect(con);
            con.ShowDialog();
            _view.Hide();
        }

        public void CreateAnAccount()
        {
            CreateAnAccount reg = new CreateAnAccount();
            reg.Visible = false;
            CreateAnAccountController controller = new CreateAnAccountController(reg);
            controller.LoadViewCreateAnAccount();
            reg.ShowDialog();
            _view.Hide();

        }

    }
}
