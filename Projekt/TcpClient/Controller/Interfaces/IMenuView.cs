using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpClientProgram.Controller
{
    public interface IMenuView
    {
        void SetController(MenuController controller);
        void Hide();
    }
}
