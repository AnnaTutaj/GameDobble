using System;
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


namespace TcpClientProgram.Controller
{
    public class ConnectController
    {

        TcpClient tcpClient;
        bool isConnectedToServer = false;
        StreamWriter strWritter;
        StreamReader strReader;
        Thread incomingMessageHandler;
        Cards cards = new Cards();
        List<string> roomsNames = new List<string>();
        List<string> roomsList = new List<string>();


        IConnectView _viewConnect;
        // ICreateOrJoinRoomView _viewRoom;
        IGameView _viewGame;
        IMenuAfterLoginView _viewMenuAfterLogin;

        ICreateRoomView _viewCreateRoom;
        IJoinRoomView _viewJoinRoom;
        IRankingView _viewRanking;


        public ConnectController()
        {

        }

        public ConnectController(int a)
        {

        }



        public ConnectController(IConnectView viewConnect, IMenuAfterLoginView viewMenuAfterLogin, ICreateRoomView viewCreateRoom, IJoinRoomView viewJoinRoom, IRankingView viewRanking, IGameView viewGame)
        {
            _viewConnect = viewConnect;
            viewConnect.SetController(this);

            _viewMenuAfterLogin = viewMenuAfterLogin;
            viewMenuAfterLogin.SetController(this);

            _viewGame = viewGame;
            viewGame.SetController(this);

            _viewCreateRoom = viewCreateRoom;
            viewCreateRoom.SetController(this);

            _viewJoinRoom = viewJoinRoom;
            viewJoinRoom.SetController(this);

            _viewRanking = viewRanking;
            viewRanking.SetController(this);


        }

        public string GetLocalIpAddress()
        {
            UnicastIPAddressInformation mostSuitableIp = null;

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;

                var properties = network.GetIPProperties();

                if (properties.GatewayAddresses.Count == 0)
                    continue;

                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    if (IPAddress.IsLoopback(address.Address))
                        continue;

                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }

                    // The best IP is the IP got from DHCP server
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }

                    return address.Address.ToString();
                }
            }

            return mostSuitableIp != null
                ? mostSuitableIp.Address.ToString()
                : "";
        }


        void getResponse()
        {
            Stream stm = tcpClient.GetStream();
            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);

            string msg = "";

            for (int i = 0; i < k; i++)
            {
                msg += Convert.ToChar(bb[i]).ToString();

            }

            setClientMessageResponse(msg);
        }



        void setClientMessageResponse(string msg)
        {
            _viewGame.SetClientMessage(msg);

        }

        public void SendMessage(string totextbox, string messagebodytextbox)
        {
            string message;
            message = "SEND_MSG;" + totextbox + ";" + messagebodytextbox;
            strWritter.WriteLine(message);
            strWritter.Flush();
        }


        public void ConnectServer(string userNameTextbox, string serveripTextbox, string portTextbox, string passwordTextBox)
        {

            string connectionEstablish;

            connectionEstablish = "CONNECT_REQUEST;" + userNameTextbox + ";" + passwordTextBox;


            tcpClient = new TcpClient();
            tcpClient.Connect(serveripTextbox, int.Parse(portTextbox));
            isConnectedToServer = true;
            strWritter = new StreamWriter(tcpClient.GetStream());
            strWritter.WriteLine(connectionEstablish);
            strWritter.Flush();



            incomingMessageHandler = new Thread(() => ReceiveMessages());
            incomingMessageHandler.IsBackground = true;
            incomingMessageHandler.Start();


            SaveSettings();

            LoadViewRoom();

            _viewMenuAfterLogin.ShowDialogs();
            _viewConnect.Hide();

        }


        private void ReceiveMessages()
        {
            strReader = new StreamReader(tcpClient.GetStream());
            string numCardsInSet = "0";

            // While we are successfully connected, read incoming lines from the server
            while (isConnectedToServer)
            {
                string serverResponse = strReader.ReadLine();
                string[] data = serverResponse.Split(';');


                if (data[0].Equals("AVALIABLE_NICK"))
                {
                    // Console.WriteLine("Test = nick was avaliable. OK");

                }
                if (data[0].Equals("LOGIN_FAILED"))
                {
                    string message = data[1];
                    //ZMIENIC NA CONNECT
                    _viewConnect.ShowInformation(message, "Login failed");
                    _viewConnect.Hide();


                    Connect con = new Connect();
                    con.Visible = false;

                    MenuAfterLogin cojg = new MenuAfterLogin();
                    cojg.Visible = false;

                    Game game = new Game();
                    game.Visible = false;

                    CreateRoom createRoom = new CreateRoom();
                    createRoom.Visible = false;

                    JoinRoom joinRoom = new JoinRoom();
                    joinRoom.Visible = false;

                    Ranking ranking = new Ranking();
                    ranking.Visible = false;


                    ConnectController controller = new ConnectController(con, cojg, createRoom, joinRoom, ranking, game);


                    controller.LoadViewConnect(con);

                    con.ShowDialog();

                }

                if (data[0].Equals("WRONG_NICK"))
                {
                    string message = data[1];
                    _viewGame.ShowInformation(message, "Wrong nick");


                    Connect con = new Connect();
                    MenuAfterLogin cojg = new MenuAfterLogin();
                    Game game = new Game();

                    CreateRoom createRoom = new CreateRoom();

                    JoinRoom joinRoom = new JoinRoom();

                    Ranking ranking = new Ranking();


                    ConnectController controller = new ConnectController(con, cojg, createRoom, joinRoom, ranking, game);
                    controller.LoadViewConnect(con);
                    con.ShowDialog();
                    _viewConnect.Hide();
                    Console.WriteLine("od nowa");
                    _viewGame.ShowInformation(message, "Wrong nick");

                    _viewConnect.SetClientMessage("[Log]:" + message);

                }



                if (data[0].Equals("INCOMING_MSG"))
                {
                    string source = data[1];
                    string message = data[2];
                    _viewGame.SetClientMessage(source + ": " + message);
                }
                if (data[0].Equals("INCOMING_NUM_OF_PLAYERS"))
                {
                    string message = data[1];
                }
                if (data[0].Equals("INCOMING_SYMBOLS_NAMES"))
                {
                    string message = data[1];
                    cards.PathToImages = message;
                }


                if (data[0].Equals("ROOM_FOUND"))
                {
                    string message = data[1];
                    _viewGame.ShowInformation(message, "Room found");

                    _viewGame.SetClientMessage("[Log]:" + message);
                }

                if (data[0].Equals("ROOM_NOT_FOUND"))
                {
                    string message = data[1];
                    _viewGame.ShowInformation(message, "Room not found");

                }

                if (data[0].Equals("ROOM_FULL"))
                {
                    string message = data[1];
                    _viewGame.ShowInformation(message, "Room full");

                }


                if (data[0].Equals("START_GAME"))
                {
                    string message = data[1];

                    _viewGame.ShowInformation(message, "Start game!");


                    _viewGame.SetClientMessage("[Log]:" + message);
                }
                if (data[0].Equals("WAITING"))
                {
                    string message = data[1];
                    _viewGame.ShowInformation(message, "Waiting...");

                    _viewGame.SetClientMessage("[Log]:" + message);
                }

                if (data[0].Equals("MAIN_CARD"))
                {
                    if (data.Length == 9)
                    {
                        mainCard8(data);
                    }
                    if (data.Length == 7)
                    {
                        mainCard6(data);
                    }
                }


                if (data[0].Equals("PLAYER_CARD"))
                {
                    if (data.Length == 9)
                    {
                        symbols8(data);
                    }
                    if (data.Length == 7)
                    {
                        symbols6(data);
                    }


                }
                if (data[0].Equals("NUM_CARDS_IN_SET"))
                {
                    string message = data[1];
                    numCardsInSet = message;
                }


                if (data[0].Equals("NUM_CURRENT_CARD"))
                {
                    string message = data[1];
                    string text = message + "/" + numCardsInSet;
                    _viewGame.NumCurrentCard(text);
                }

                if (data[0].Equals("LAST_NICK"))
                {
                    string message = data[1];
                    _viewGame.LastNick(message);
                }

                if (data[0].Equals("BAN"))
                {
                    string message = data[1];
                    _viewGame.ShowInformation(message, "Ban!");
                    _viewGame.SetClientMessage(message);
                    _viewGame.Ban();

                }
                if (data[0].Equals("UNBAN"))
                {
                    string message = data[1];
                    _viewGame.ShowInformation(message, "Unban");
                    _viewGame.SetClientMessage(message);
                    _viewGame.Unban();


                }
                if (data[0].Equals("WIN"))
                {

                    string message = data[1];
                    _viewGame.ShowInformation(message, "Win!");

                    _viewGame.SetClientMessage(message);
                    _viewGame.Win();

                }


                if (data[0].Equals("ROOM_LIST"))
                {
                    string message = data[1] + data[2];
                    _viewJoinRoom.RoomList(message);
                }

                if (data[0].Equals("STATUS_CLEAR"))
                {
                    string nick = "Nick";
                    string status = "Status";
                    int a = 150;
                    int b = 56;

                    _viewGame.StatusClear(nick, status, a, b);

                }

                if (data[0].Equals("ROOM_CLEAR"))
                {
                    _viewJoinRoom.Clear();


                }

                if (data[0].Equals("STATUS_PLAYERS"))
                {

                    string col1 = data[1];
                    string col2 = data[2] + "/" + data[3];
                    _viewGame.StatusPlayers(col1, col2);
                }
                if (data[0].Equals("RANKING_ROW"))
                {

                    string col1 = data[1];
                    string col2 = data[2];
                    string col3 = data[3];

                    _viewRanking.AddRowRanking(col1, col2, col3);
                }

                if (data[0].Equals("RANKING_ROW_LOWER"))
                {

                    string col1 = data[1];
                    string col2 = data[2];
                    string col3 = data[3];

                    _viewRanking.AddRowRankingLower(col1, col2, col3);
                }



                _viewGame.AutoscrollingList();


            }

        }

        void symbols8(string[] data)
        {

            string m1 = data[1];
            string m2 = data[2];
            string m3 = data[3];
            string m4 = data[4];
            string m5 = data[5];
            string m6 = data[6];
            string m7 = data[7];
            string m8 = data[8];

            for (int i = 0; i < data.Length - 1; i++)
            {
                cards.PlayerCardTab[i] = Int32.Parse(data[i + 1]);

            }
            setPlayerCard();
        }

        void symbols6(string[] data)
        {

            string m1 = data[1];
            string m2 = data[2];
            string m3 = data[3];
            string m4 = data[4];
            string m5 = data[5];
            string m6 = data[6];


            for (int i = 0; i < data.Length - 1; i++)
            {
                cards.PlayerCardTab[i] = Int32.Parse(data[i + 1]);

            }
            setPlayerCard6();
        }


        void mainCard8(string[] data)
        {
            Console.WriteLine("dlugosc tab: + " + data.Length);
            string m1 = data[1];
            string m2 = data[2];
            string m3 = data[3];
            string m4 = data[4];
            string m5 = data[5];
            string m6 = data[6];
            string m7 = data[7];
            string m8 = data[8];

            //_viewGame.SetClientMessage("[Log]: [main card]" + m1 + ";" + m2 + ";" + m3 + ";" + m4 + ";" + m5 + ";" + m6 + ";" + m7 + ";" + m8);
            for (int i = 0; i < data.Length - 1; i++)
            {
                cards.MainCardTab[i] = Int32.Parse(data[i + 1]);
            }
            setMainCard();
        }

        void mainCard6(string[] data)
        {
            string m1 = data[1];
            string m2 = data[2];
            string m3 = data[3];
            string m4 = data[4];
            string m5 = data[5];
            string m6 = data[6];


            // _viewGame.SetClientMessage("[Log]: [main card]" + m1 + ";" + m2 + ";" + m3 + ";" + m4 + ";" + m5 + ";" + m6);
            for (int i = 0; i < data.Length - 1; i++)
            {
                cards.MainCardTab[i] = Int32.Parse(data[i + 1]);
            }
            setMainCard6();
        }


        void setMainCard()
        {
            string path = "Images/" + cards.PathToImages + "/";

            _viewGame.SetMainCard(path, cards.MainCardTab);
        }
        void setMainCard6()
        {
            string path = "Images/" + cards.PathToImages + "/";

            _viewGame.SetMainCard6(path, cards.MainCardTab);
        }

        void setPlayerCard()
        {

            string path = "Images/" + cards.PathToImages + "/";

            _viewGame.SetPlayerCard(path, cards.PlayerCardTab);
        }
        void setPlayerCard6()
        {

            string path = "Images/" + cards.PathToImages + "/";

            _viewGame.SetPlayerCard6(path, cards.PlayerCardTab);
        }


        public void LoadViewRoom()
        {
            int numberOfMaxPlayers = 8;
            for (int i = 1; i <= numberOfMaxPlayers; i++)
            {
                _viewCreateRoom.AddItem(i);

            }

            _viewCreateRoom.AddPicuresNames();
            _viewCreateRoom.AddModesNames();


        }


        public void MakeANewGame(string playersNumber, string nameOfSymbols, string modeNumber)
        {
            Console.WriteLine("makeANewGame");
            string message;

            message = "NEW_GAME;" + playersNumber + ";" + nameOfSymbols + ";" + modeNumber;
            strWritter.WriteLine(message);
            strWritter.Flush();
            startGame();
        }


        public void JoinRoom(string number)
        {
            string message;
            message = "JOIN;" + number;
            strWritter.WriteLine(message);
            strWritter.Flush();
            startGame();

        }

        void startGame()
        {
            Console.WriteLine("start game");

            _viewGame.Hide();
            LoadViewGame();
            _viewGame.ShowDialogs();
            _viewCreateRoom.Hide();
            Console.WriteLine("zmiana z connect na room");

        }


        public void RefreshList()
        {
            string message;
            message = "REFRESH_LIST";
            strWritter.WriteLine(message);
            strWritter.Flush();
        }

        public void ChosenPic(object tag)
        {
            string message;
            message = "CHOSEN_PIC;" + tag;
            strWritter.WriteLine(message);
            strWritter.Flush();
        }

        public void PlayAgain()
        {
            Console.WriteLine("playAgain");
            TcpClientProgram.View.Menu f1 = new TcpClientProgram.View.Menu();
            f1.Show();
            _viewGame.Hide();
        }
        /// 


        public void SaveSettings()
        {
            Application.UserAppDataRegistry.SetValue("serveripTextbox", _viewConnect.ServeripTextbox);
            Application.UserAppDataRegistry.SetValue("portTextbox", _viewConnect.PortTextbox);
            Application.UserAppDataRegistry.SetValue("userNameTextbox", _viewConnect.UserNameTextbox);
            Application.UserAppDataRegistry.SetValue("passwordTextbox", _viewConnect.PasswordTextbox);



        }
        public void LoadSettings(IConnectView _viewConnect)
        {
            _viewConnect.ServeripTextbox = (String)Application.UserAppDataRegistry.GetValue("serveripTextbox", String.Empty);
            _viewConnect.PortTextbox = (String)Application.UserAppDataRegistry.GetValue("portTextbox", String.Empty);
            _viewConnect.UserNameTextbox = (String)Application.UserAppDataRegistry.GetValue("userNameTextbox", String.Empty);
            _viewConnect.PasswordTextbox = (String)Application.UserAppDataRegistry.GetValue("passowrdNameTextbox", String.Empty);

        }

        public void LoadViewConnect(IConnectView _viewConnect)
        {
            LoadSettings(_viewConnect);
        }

        public void LoadViewGame()
        {


        }

        public void BackToMenuFromJoinRoom()
        {
            _viewMenuAfterLogin.ShowDialogs();

            _viewJoinRoom.Hide();
        }

        public void BackToMenuFromRanking()
        {
            _viewMenuAfterLogin.ShowDialogs();
            _viewRanking.Hide();
        }

        public void BackToMenuFromCreateRoom()
        {
            _viewMenuAfterLogin.ShowDialogs();
            _viewJoinRoom.Hide();

        }



        #region MenuAfterLogin
        public void CreateRoom()
        {
            Console.WriteLine("z sumbenu do createroom1");
            _viewMenuAfterLogin.Hide();
            _viewCreateRoom.ShowDialogs();


        }
        public void JoinGame()
        {
            Console.WriteLine("z sumbenu do JoinGame1");
            _viewMenuAfterLogin.Hide();
            _viewJoinRoom.ShowDialogs();

        }

        public void Ranking()
        {
            string message;
            message = "RANKING;";
            strWritter.WriteLine(message);
            strWritter.Flush();


            Console.WriteLine("z sumbenu do Ranking1");
            createRanking();
            _viewRanking.ShowDialogs();

        }
        #endregion

        #region Ranking 

        void createRanking()
        {
            string rank = "Rank";

            string nick = "Nick";
            string points = "Score";
            int a = 100;
            int b = 100;
            int c = 100;


            _viewRanking.RankingClear(rank, nick, points, a, b, c);

            _viewRanking.RankingClearLower(rank, nick, points, a, b, c);
            Console.WriteLine("juz po");

        }


        #endregion



    }


}
