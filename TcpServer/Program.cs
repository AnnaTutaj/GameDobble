using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TcpServer.View;
using TcpServer.Controller;

namespace TcpServer
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


            View.Server view = new View.Server();
            view.Visible = false;



            ServerController controller = new ServerController(view);
            controller.LoadView();
            view.ShowDialog();


        }
    }
}
