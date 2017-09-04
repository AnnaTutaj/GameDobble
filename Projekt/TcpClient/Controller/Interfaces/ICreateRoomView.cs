using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpClientProgram.Controller
{
    public interface ICreateRoomView
    {

        void SetController(ConnectController controller);
        void SetClientMessage(string msg);
        void Hide();
        void ShowDialogs();
        void AddItem(int i);
        void AddPicuresNames();
        void AddModesNames();

    }
}
