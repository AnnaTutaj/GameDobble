using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpClientProgram.Controller
{
    public interface IGameView
    {
        void SetController(ConnectController controller);
        void Hide();
        void ShowDialogs();
        void SetClientMessage(string msg);

        void NumCurrentCard(string msg);
        void LastNick(string msg);

        void SetMainCard(string path, int [] tab);
        void SetPlayerCard(string path, int[] tab);
        void SetMainCard6(string path, int[] tab);
        void SetPlayerCard6(string path, int[] tab);

        void Ban();
        void Unban();
        void Win();
        void StatusClear(string nick, string status, int a, int b);
        void StatusPlayers(string col1, string col2);
        void AutoscrollingList();
        void ShowInformation(string message, string title);
    }
}
