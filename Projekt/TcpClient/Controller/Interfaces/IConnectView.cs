using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TcpClientProgram.Controller
{
  public interface IConnectView
    {
        void SetController(ConnectController controller);
        void SetClientMessage(string msg);
        string ServeripTextbox { get; set; }
        string UserNameTextbox { get; set; }
        string PortTextbox { get; set; }
        string PasswordTextbox { get; set; }
        void Hide();
        void ShowInformation(string message, string title);

    }
}
