using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpClientProgram.Controller
{
   public interface IJoinRoomView
    {

        void SetController(ConnectController controller);
        void Hide();
        void ShowDialogs();
        void Clear();
        void RoomList(string msg);
    }
}
