using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TcpClientProgram.Controller
{
    public interface IRankingView
    {
        void SetController(ConnectController controller);
        void Hide();
        void ShowDialogs();
        void RankingClear(string rank, string nick, string points, int a, int b, int c);
        void AddRowRanking(string col1, string col2, string col3);

        void RankingClearLower(string rank, string nick, string points, int a, int b, int c);
        void AddRowRankingLower(string col1, string col2, string col3);

    }
}
