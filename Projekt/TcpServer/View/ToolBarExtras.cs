using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TcpServer.View
{
    public class ToolBarExtras
    {
        public void ShowInformation(string description, string message)
        {
            System.Windows.Forms.MessageBox.Show(message,
  description,
  MessageBoxButtons.OK,
  MessageBoxIcon.Information
 );
        }
    }
}
