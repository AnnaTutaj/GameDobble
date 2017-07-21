using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpClientProgram.Controller
{
    public interface IMenuAfterLoginView
    {
        void SetController(ConnectController controller);
        void Hide();
        void ShowDialogs();
    }
}
