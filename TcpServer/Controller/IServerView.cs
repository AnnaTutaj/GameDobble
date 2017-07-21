using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TcpServer.Model;

namespace TcpServer.Controller
{
  public  interface IServerView
    {

        void SetController(ServerController controller);
        string Label3 { get; set; }
        string IpAddressTextbox { get; set; }
        string PortTextbox { get; set; }
        void AddPlayer(User user);
        void ShowInformation(string desctiption, string message);
    }
}
