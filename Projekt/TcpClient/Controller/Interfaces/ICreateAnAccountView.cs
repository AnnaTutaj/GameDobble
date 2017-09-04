using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpClientProgram.Controller
{
    public interface ICreateAnAccountView
    {
        void SetController(CreateAnAccountController controller);
        void Hide();
        void Close();
        void DisposeForm();
        void AddItemGenderComboBox(string s);
        void AddItemYearComboBox(int i);
        void CreateImage();
        void ShowInformation(string s1, string s2);
        string ServeripTextbox { get; set; }
        string UserNameTextbox { get; set; }
        string PortTextbox { get; set; }
        string PasswordTextbox { get; set; }
    }
}
