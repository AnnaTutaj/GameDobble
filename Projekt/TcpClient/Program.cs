using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TcpClientProgram.Controller;
using TcpClientProgram.View;

namespace TcpClientProgram
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TcpClientProgram.View.Menu view = new TcpClientProgram.View.Menu();
            view.Visible = false;
            MenuController controller = new MenuController(view);
            view.ShowDialog();
        }
    }
}
