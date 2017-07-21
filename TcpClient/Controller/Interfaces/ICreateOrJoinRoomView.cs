using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpClientProgram.Controller
{
   public interface ICreateOrJoinRoomView
    {
        void SetController(ConnectController controller);
        void SetClientMessage(string msg);
        void Hide();
        void ShowDialogs();
        void Clear();
        void RoomList(string msg);
        void AddItem(int i);
        void AddPicuresNames();
        void AddModesNames();
    }
}
