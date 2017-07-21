
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Net;
using System.Net.NetworkInformation;
using TcpClientProgram.Model;
using TcpClientProgram.View;
using System;

namespace TcpClientProgram.Controller
{

    public class CreateAnAccountController
    {
        ICreateAnAccountView _view;

        TcpClient tcpClient;
        bool isConnectedToServer = false;
        StreamWriter strWritter;
        StreamReader strReader;
        Thread incomingMessageHandler;
        bool ACCOUNT_CREATED_SUCCESFULLY = false;

        public CreateAnAccountController(ICreateAnAccountView view)
        {
            _view = view;
            view.SetController(this);
        }



        public void LoadViewCreateAnAccount()
        {
            LoadSettings();

            int currentYear = 2017;
            for (int i = currentYear; i >= currentYear - 120; i--)
            {
                _view.AddItemYearComboBox(i);

            }

            _view.AddItemGenderComboBox("female");
            _view.AddItemGenderComboBox("male");
            _view.AddItemGenderComboBox("other");

            _view.CreateImage();

        }
        public void SaveSettings()
        {
            Application.UserAppDataRegistry.SetValue("serveripTextbox", _view.ServeripTextbox);
            Application.UserAppDataRegistry.SetValue("portTextbox", _view.PortTextbox);
            Application.UserAppDataRegistry.SetValue("userNameTextbox", _view.UserNameTextbox);
            Application.UserAppDataRegistry.SetValue("passwordTextbox", _view.PasswordTextbox);




        }
        public void LoadSettings()
        {
            _view.ServeripTextbox = (String)Application.UserAppDataRegistry.GetValue("serveripTextbox", String.Empty);
            _view.PortTextbox = (String)Application.UserAppDataRegistry.GetValue("portTextbox", String.Empty);
            _view.UserNameTextbox = (String)Application.UserAppDataRegistry.GetValue("userNameTextbox", String.Empty);
            _view.PasswordTextbox = (String)Application.UserAppDataRegistry.GetValue("passowrdNameTextbox", String.Empty);

        }


        public void AddNewAccount(string serveripTextbox, string portTextbox, string userNameTextbox, string passwordTextbox, string emailTextbox, string yearComboBox, string genderComboBox, string captchaTextbox)
        {

            string connectionEstablish;

            connectionEstablish = "CREATE_ACCOUNT;" + userNameTextbox + ";" + passwordTextbox + ";" + emailTextbox + ";" + yearComboBox + ";" + genderComboBox;


            tcpClient = new TcpClient();
            tcpClient.Connect(serveripTextbox, int.Parse(portTextbox));
            isConnectedToServer = true;
            strWritter = new StreamWriter(tcpClient.GetStream());
            strWritter.WriteLine(connectionEstablish);
            strWritter.Flush();


            Console.WriteLine("nowy Connection");

            incomingMessageHandler = new Thread(() => ReceiveMessages());
            incomingMessageHandler.IsBackground = true;
            incomingMessageHandler.Start();

            int interval = 3000;


            while (!ACCOUNT_CREATED_SUCCESFULLY)

            {
                Console.WriteLine("spie 3 sek: ");
                Thread.Sleep(interval);
                if (ACCOUNT_CREATED_SUCCESFULLY == true)
                {
                    Console.WriteLine("JEST JUZ OK, ZAMYKAMY!");

                    SaveSettings();

                    ConnectController c = new ConnectController();


                    Connect con = new Connect();
                    MenuAfterLogin cojg = new MenuAfterLogin();
                    Game game = new Game();

                    CreateRoom createRoom = new CreateRoom();

                    JoinRoom joinRoom = new JoinRoom();

                    Ranking ranking = new Ranking();


                    ConnectController controller = new ConnectController(con, cojg, createRoom, joinRoom, ranking, game);
                    controller.LoadViewConnect(con);
                    con.ShowDialog();

                    _view.Hide();
                    _view.Close();
                    _view.DisposeForm();

                    Console.WriteLine(ACCOUNT_CREATED_SUCCESFULLY + "jest just tru!!");
                }
                Console.WriteLine("ja zyje");

            }

        }




        private void ReceiveMessages()
        {
            strReader = new StreamReader(tcpClient.GetStream());

            // While we are successfully connected, read incoming lines from the server
            while (isConnectedToServer)
            {

                string serverResponse = strReader.ReadLine();
                string[] data = serverResponse.Split(';');


                if (data[0].Equals("WRONG_NICK") || data[0].Equals("NICK_INVALID") || data[0].Equals("PASSWORD_INVALID") || data[0].Equals("EMAIL_INVALID"))
                {
                    Console.WriteLine("zlyNick, mail albo haslo!!!");
                    string message = data[1];


                    _view.ShowInformation("Error", message);

                    _view.Hide();

                    CreateAnAccount reg = new CreateAnAccount();
                    reg.Visible = false;

                    CreateAnAccountController controller = new CreateAnAccountController(reg);
                    controller.LoadViewCreateAnAccount();
                    reg.ShowDialog();
                    _view.Close();

                }
                if (data[0].Equals("ACCOUNT_CREATED_SUCCESFULLY"))
                {
                    ACCOUNT_CREATED_SUCCESFULLY = true;
                    Console.WriteLine("ACCOUNT_CREATED_SUCCESFULLY");


                }

            }
        }



    }
}
