using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Diagnostics;

using TcpServer.View;
using TcpServer.Model;

using System.Data;
using System.Windows.Forms;


namespace TcpServer.Controller
{
    public class Server
    {
        private IPAddress serverIp;
        private int serverPort;
        private TcpListener serverListener;
        private bool isServerRunning = false;

        private Thread backgroundListner;
        private Thread connectionThread;



        private List<User> tcpClients = new List<User>();
        private List<Room> room = new List<Room>();

        public delegate void PropertyChangeHandler(object sender, EventArgs args);
        public event PropertyChangeHandler OnclientConnected;


        public Server(string serverIp, int serverPort)
        {
            this.serverIp = IPAddress.Parse(serverIp);
            this.serverPort = serverPort;
        }

        public List<User> TcpClients
        {
            get { return tcpClients; }
            set { tcpClients = value; }
        }
        DataBaseOperations dbOp = new DataBaseOperations();


        public void startListing()
        {


            this.serverListener = new TcpListener(this.serverIp, this.serverPort);
            this.serverListener.Start();
            this.isServerRunning = true;
            Console.WriteLine("start");
            backgroundListner = new Thread(() => KeepListening());
            backgroundListner.IsBackground = true;
            backgroundListner.Start();
        }

        private void KeepListening()
        {
            // While the server is running
            while (this.isServerRunning == true)
            {

                TcpClient tcpClient = this.serverListener.AcceptTcpClient();

                connectionThread = new Thread(() => connectionHandler(tcpClient));
                connectionThread.IsBackground = true;
                connectionThread.Start();

            }
        }

        #region Answers_Types
        void answerInt(string command, int message, int id)
        {

            User destination = this.TcpClients.Where(c => c.UserId == id).Select(c => c).FirstOrDefault();
            string client_chat = command + ";" + message;
            Stream desStream = destination.TcpClient.GetStream();
            StreamWriter wr = new StreamWriter(desStream);
            wr.WriteLine(client_chat);
            wr.Flush();

        }

        void answerCardId(string command, int[] message, int id, Room r)
        {
            Console.WriteLine("wybiramy wariant");
            User destination = this.TcpClients.Where(c => c.UserId == id).Select(c => c).FirstOrDefault();
            string client_chat = "";
            if (r.NumberMode == 8)
            {
                Console.WriteLine("wybiramy wariant 8");

                client_chat = command + ";" + message[0] + ";" + message[1] + ";" + message[2] + ";" + message[3] + ";" + message[4] + ";" + message[5] + ";" + message[6] + ";" + message[7];
            }
            else
                 if (r.NumberMode == 6)

            {
                Console.WriteLine("wybiramy wariant 6");

                client_chat = command + ";" + message[0] + ";" + message[1] + ";" + message[2] + ";" + message[3] + ";" + message[4] + ";" + message[5];
            }
            else
            {
                Console.WriteLine("wybiramy wariant error");

                client_chat = "ERROR: answerCardId";
            }

            Stream desStream = destination.TcpClient.GetStream();
            StreamWriter wr = new StreamWriter(desStream);
            wr.WriteLine(client_chat);
            wr.Flush();

        }

        void answerCardIdForOnePlayer(TcpClient this_client, string command, int[] message, Room r)
        {
            User destination = this.TcpClients.Where(c => c.TcpClient.Equals(this_client)).Select(c => c).FirstOrDefault();
            string client_chat = "";

            if (r.NumberMode == 8)
            {
                Console.WriteLine("wybiramy wariant 8888888");

                client_chat = command + ";" + message[0] + ";" + message[1] + ";" + message[2] + ";" + message[3] + ";" + message[4] + ";" + message[5] + ";" + message[6] + ";" + message[7];
            }
            else
                 if (r.NumberMode == 6)
            {
                Console.WriteLine("wybiramy wariant 66666");

                client_chat = command + ";" + message[0] + ";" + message[1] + ";" + message[2] + ";" + message[3] + ";" + message[4] + ";" + message[5];
            }
            else
            {
                Console.WriteLine("wybiramy wariant erorrr");

                client_chat = "ERROR: answerCardIdForOnePlayer";
            }

            Stream desStream = destination.TcpClient.GetStream();
            StreamWriter wr = new StreamWriter(desStream);
            wr.WriteLine(client_chat);
            wr.Flush();
        }



        void answer(TcpClient this_client, string command, string message)
        {
            User destination = this.TcpClients.Where(c => c.TcpClient.Equals(this_client)).Select(c => c).FirstOrDefault();
            string client_chat = command + ";" + message;
            Stream desStream = destination.TcpClient.GetStream();
            StreamWriter wr = new StreamWriter(desStream);
            wr.WriteLine(client_chat);
            wr.Flush();
        }

        void answerByPlayerId(string command, string message, int id)
        {

            User destination = this.TcpClients.Where(c => c.UserId == id).Select(c => c).FirstOrDefault();
            string client_chat = command + ";" + message;
            Stream desStream = destination.TcpClient.GetStream();
            StreamWriter wr = new StreamWriter(desStream);
            wr.WriteLine(client_chat);
            wr.Flush();
        }
        #endregion region Answers_Types

        public void ConnectDataBase()
        {
            Console.WriteLine("polaczono");

            dbOp.ConnectDataBase();
            //USUNAC
            //    dbOp.fillRankingList();
            dbOp.checkConnectionByAddPoints();
        }

        bool checkNick(string name)
        {
            if (name.Any(Char.IsWhiteSpace))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        bool loginFailed(string[] response)
        {
            Console.WriteLine("spr login");

            string nick = response[1];
            string password = response[2];
            if (dbOp.CheckLogin(nick, password) == true)
            {

                return true;
            }
            else
            {
                return false;
            }

        }

        bool invalidNick(string nick)
        {
            if (dbOp.InvalidNick(nick) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool invalidPassword(string password)
        {

            if (password.Length < 6)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        bool invalidEmail(string email)
        {

            if (!email.Contains('@'))
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        bool isTheSameName(string name)
        {
            foreach (User c in tcpClients)
            {
                if (c.UserName.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }


        bool isTooLong(string name)
        {
            int maxLength = 20;
            foreach (User c in tcpClients)
            {
                if (c.UserName.Length > maxLength)
                {
                    return true;
                }
            }
            return false;
        }



        int createAccount(TcpClient client, string[] response)
        {
            Console.WriteLine("Create Account request");

            User usr = new User(client, response[1], tcpClients.Count);
            Console.WriteLine("lista podlaczonych przed ");
            foreach (User c in tcpClients)
            {
                Console.WriteLine("nick: " + c.UserName + "id: " + c.UserId);
            }

            bool ifNickISAlreadyTaken = isTheSameName(response[1]);
            tcpClients.Add(usr);
            OnclientConnected(usr, new EventArgs());
            //dopisac spr czy juz ktos o takim nicku istnieje 

            string nick = response[1];
            string password = response[2];
            string email = response[3];



            if (checkNick(response[1]) == true)
            {
                answer(client, "WRONG_NICK", "Nick cannot contain space. Please type another. ");
                tcpClients.Remove(usr);
                return (-1);
            }
            else
                if (ifNickISAlreadyTaken)
            {
                answer(client, "WRONG_NICK", "That nick is already taken. Please type another. ");
                tcpClients.Remove(usr);
                return (-1);

            }
            else
                    if (isTooLong(response[1]))
            {
                answer(client, "WRONG_NICK", "Too long nick. Max length is 20. Please type another. ");
                tcpClients.Remove(usr);
                return (-1);

            }

            if (invalidNick(nick) == true)
            {
                Console.WriteLine("Nick juz jest w bazie ");

                answer(client, "NICK_INVALID", "Nick is already used. Please type another. ");
                tcpClients.Remove(usr);
                return (-1);

            }
            else
              if (invalidPassword(password) == true)
            {
                Console.WriteLine("Haslo za krotkie");

                answer(client, "PASSWORD_INVALID", "Create a password 6 character minimum case sensitive");
                tcpClients.Remove(usr);
                return (-1);

            }
            if (invalidEmail(email) == true)
            {
                Console.WriteLine("Mail bez @");

                answer(client, "EMAIL_INVALID", "Invalid e-mail address");
                tcpClients.Remove(usr);
                return (-1);

            }

            else
            {
                answer(client, "ACCOUNT_CREATED_SUCCESFULLY", "Nick is avaliable ");
                dbOp.createNewAccount(response);

                refreshList(client, response);
                tcpClients.Remove(usr);

                return (1);


            }


        }

        void connectRequest(TcpClient client, string[] response)
        {
            Console.WriteLine("Connection request");

            User usr = new User(client, response[1], tcpClients.Count);
            Console.WriteLine("lista podlaczonych przed ");
            foreach (User c in tcpClients)
            {
                Console.WriteLine("nick: " + c.UserName + "id: " + c.UserId);
            }

            bool ifNickISAlreadyTaken = isTheSameName(response[1]);
            tcpClients.Add(usr);
            OnclientConnected(usr, new EventArgs());


            if (loginFailed(response) == true)
            {

                answer(client, "LOGIN_FAILED", "Login failed. Please check your nick and password and try again ");
                tcpClients.Remove(usr);
            }
            else

            if (checkNick(response[1]) == true)
            {
                answer(client, "WRONG_NICK", "Nick cannot contain space. Please type another. ");
                tcpClients.Remove(usr);
            }
            else
                if (ifNickISAlreadyTaken)
            {
                answer(client, "WRONG_NICK", "That nick is already taken. Please type another. ");
                tcpClients.Remove(usr);
            }
            else
                    if (isTooLong(response[1]))
            {
                answer(client, "WRONG_NICK", "Too long nick. Max length is 20. Please type another. ");
                tcpClients.Remove(usr);
            }

            else
            {
                answer(client, "AVALIABLE_NICK", "Nick is avaliable ");

                refreshList(client, response);
            }

            Console.WriteLine("lista podlaczonych");
            foreach (User c in tcpClients)
            {
                Console.WriteLine("nick: " + c.UserName + "id: " + c.UserId);
            }

        }




        void chatWithOtherUser(TcpClient this_client, string[] response)
        {

            string to = response[1];
            string msgBody = response[2];

            User source = this.TcpClients.Where(c => c.TcpClient.Equals(this_client)).Select(c => c).FirstOrDefault();
            User destination = this.TcpClients.Where(c => c.UserName == to).Select(c => c).FirstOrDefault();

            string client_chat = "INCOMING_MSG;" + source.UserName + ";" + msgBody;

            Stream desStream = destination.TcpClient.GetStream();

            StreamWriter wr = new StreamWriter(desStream);
            wr.WriteLine(client_chat);
            wr.Flush();
        }



        void createNewRoom(TcpClient this_client, string[] response)
        {
            string number = response[1];
            string nameOfSymbols = response[2];
            int numberOfSymbols = Int32.Parse(response[3]);

            User destination = this.TcpClients.Where(c => c.TcpClient.Equals(this_client)).Select(c => c).FirstOrDefault();
             Room room = new Room(destination.UserName, destination.UserId, Int32.Parse(number), numberOfSymbols);


            this.room.Add(room);

            room.addPlayer(destination.UserId);
            string message = "Name of room: " + room.RoomName + ", ID room:" + room.RoomId + ", Num of players: " + room.RoomNumberOfPlayers;
            destination.IdRoom = room.RoomId;
            answer(this_client, "INCOMING_NUM_OF_PLAYERS", message);
            room.Cards.PathToImages = response[2];
            answer(this_client, "INCOMING_SYMBOLS_NAMES", nameOfSymbols);

            int numberOfCardsForPlayer = room.cardsPerSetFunc(room.RoomNumberOfPlayers);


            room.createCardsForGame(room.RoomNumberOfPlayers, room.P);


            checkIfAllPlayersAreReady(this_client, response);
            Console.WriteLine("done createNewRoom");


        }


        void showAllAboutPlayer()
        {

            foreach (User u in TcpClients)
            {
                u.showAllInfoAboutUser();
            }
        }


        void createCardsForPlayer(int player, int numberOfSet, Room r)
        {

            User u = this.TcpClients.Where(c => c.UserId == player).Select(c => c).FirstOrDefault();
            //lista z tab intow -  
            u.SetForPlayer = r.SetsOfCards.ElementAt(numberOfSet);
            //zeby miec ile kart na set
            u.Set = r.ListOfSets.ElementAt(numberOfSet);
            Console.WriteLine("done: createCardsForPlayer");
        }

        void join(TcpClient this_client, string[] response)
        {

            User user = this.TcpClients.Where(c => c.TcpClient.Equals(this_client)).Select(c => c).FirstOrDefault();

            string roomName = response[1];
            Console.WriteLine("[join] sprawdzam room Name: " + roomName + ".");
            bool found = false;
            foreach (Room r in room)
            {
                Console.WriteLine("[join]mamy taki rooms name: " + r.RoomName + ".");
                if (roomName.Equals(r.RoomName))
                {
                    if (r.RoomNumberOfPlayers == r.Players.Count)
                    {
                        answer(this_client, "ROOM_FULL", "Room is full already. Please join to other");
                        found = true;

                    }
                    else
                    {
                        r.addPlayer(user.UserId);

                        foreach (Room ro in room)
                        {
                            string message = ro.RoomName + "; (" + ro.Players.Count + "/" + ro.RoomNumberOfPlayers + ")";
                            Console.WriteLine(message);
                        }

                        answer(this_client, "ROOM_FOUND", "Joined suceffuly :)");
                        Console.WriteLine("joined to: " + r.RoomName);
                        answer(this_client, "INCOMING_SYMBOLS_NAMES", r.Cards.PathToImages);

                        checkIfAllPlayersAreReady(this_client, response);
                        statusGameList(r, this_client);
                        found = true;
                        user.IdRoom = r.RoomId;
                    }
                }
            }
            if (found.Equals(false))
            {
                answer(this_client, "ROOM_NOT_FOUND", "Couldn't connected to room. Check name.");

            }

        }

        void checkIfAllPlayersAreReady(TcpClient this_client, string[] response)
        {
            User user = this.TcpClients.Where(c => c.TcpClient.Equals(this_client)).Select(c => c).FirstOrDefault();

            foreach (Room r in room)
            {
                Console.WriteLine("Room name: " + r.RoomName);
                if (r.Players.Contains(user.UserId))
                {
                    Console.WriteLine("Jest tu gracz : " + user.UserId + "o nicku: " + user.UserName);

                    if (r.RoomNumberOfPlayers == r.Players.Count)
                    {

                        Console.WriteLine("JEST ZACZYNAMY!!! trzeba kazdemu powiedzieec");

                        int i = 0;
                        foreach (int player in r.Players)
                        {
                            //zrob mu talie kart
                            User u = this.TcpClients.Where(c => c.UserId == player).Select(c => c).FirstOrDefault();

                            createCardsForPlayer(player, i, r);
                            answerByPlayerId("START_GAME", "All players are ready - we're starting the game!:)", player);


                            answerCardId("MAIN_CARD", r.MainCardTab, player, r);
                            Console.WriteLine("wysylam karty graczom");
                            u.currentCardElements(0, r);
                            answerCardId("PLAYER_CARD", u.CurrentCard, player, r);

                            answerInt("NUM_CARDS_IN_SET", r.cardsPerSetFunc(r.RoomNumberOfPlayers), player);
                            int firstCardNumber = 1;
                            answerInt("NUM_CURRENT_CARD", firstCardNumber, player);
                            i++;
                        }

                        statusGameList(r, this_client);
                    }
                    else
                    {
                        Console.WriteLine("CZEKAMY NA INNYCH GRACZY ");
                        answer(this_client, "WAITING", "Waiting for the rest players...");

                    }
                }

            }
        }

        void statusGameList(Room r, TcpClient this_client)
        {
            List<string> listCurrentCard = new List<string>();
            foreach (int player in r.Players)
            {

                answerByPlayerId("STATUS_CLEAR", "cleaning status", player);
            }

            foreach (int player in r.Players)
            {
                User u = this.TcpClients.Where(c => c.UserId == player).Select(c => c).FirstOrDefault();
                int CurrentCardNumber = u.CurrentCardId + 1;
                string status = u.UserName + ";" + CurrentCardNumber + ";" + r.cardsPerSetFunc(r.RoomNumberOfPlayers);
                listCurrentCard.Add(status);
                // answerByPlayerId("STATUS_PLAYERS",status, player);
            }



            foreach (string s in listCurrentCard)
            {
                foreach (int player in r.Players)
                {

                    answerByPlayerId("STATUS_PLAYERS", s, player);

                }

                Console.WriteLine(s);
            }
        }


        void chosenPic(TcpClient client, string[] response)
        {
            User u = this.TcpClients.Where(c => c.TcpClient.Equals(client)).Select(c => c).FirstOrDefault();
            Room r = this.room.Where(c => c.RoomId.Equals(u.IdRoom)).Select(c => c).FirstOrDefault();

            int chosenNumber = Int32.Parse(response[1]);

            int numberOnCard;
            for (int i = 0; i < u.NumberOfSymbols; i++)
                if (chosenNumber == i + 1)
                {
                    Console.WriteLine("wybrano: " + r.MainCardTab[i]);
                    numberOnCard = r.MainCardTab[i];
                    checkIfSymbolIsOnPlayerCard(client, numberOnCard);
                }

        }

        void checkIfSymbolIsOnPlayerCard(TcpClient client, int numberOnCard)
        {
            User u = this.TcpClients.Where(c => c.TcpClient.Equals(client)).Select(c => c).FirstOrDefault();
            Room r = this.room.Where(c => c.RoomId.Equals(u.IdRoom)).Select(c => c).FirstOrDefault();

            if (u.CurrentCard.Contains(numberOnCard))
            {
                takeMainNextCard(client);
                takePlayerNextCard(client);
                statusGameList(r, client);

            }
            else
            {
                Console.WriteLine("Ban za zle wskazanie!");
                answer(client, "BAN", "Wrong choice. You have to wait 3 sec!");
                Thread.Sleep(3000);
                answer(client, "UNBAN", "You came back to the game. Don't try to cheat again!");


            }
        }


        void showMainTab(Room r)
        {
            Console.WriteLine("Main Tab");

            Console.WriteLine("----------------------------------------------");

            for (int i = 0; i < r.NumberOfSymbols; i++)
            {
                Console.Write(r.MainCardTab[i] + ", ");

            }
            Console.WriteLine("");

            Console.WriteLine("----------------------------------------------");


        }

        void showCurrentTab(User u)
        {
            Console.WriteLine("Current Tab");


            for (int i = 0; i < u.NumberOfSymbols; i++)
            {
                Console.Write(u.CurrentCard[i] + ", ");

            }
            Console.WriteLine("");

            Console.WriteLine("----------------------------------------------");


        }

        int calculatePoints(TcpClient client)
        {
            User u = this.TcpClients.Where(c => c.TcpClient.Equals(client)).Select(c => c).FirstOrDefault();
            Room r = this.room.Where(c => c.RoomId.Equals(u.IdRoom)).Select(c => c).FirstOrDefault();
            double d = 0.5 * r.RoomNumberOfPlayers;
            return (int)(r.NumberMode * Math.Ceiling(d));
        }

        void playerWin(TcpClient client)
        {
            User u = this.TcpClients.Where(c => c.TcpClient.Equals(client)).Select(c => c).FirstOrDefault();
            Room r = this.room.Where(c => c.RoomId.Equals(u.IdRoom)).Select(c => c).FirstOrDefault();
            // wyslac do all 
            int gainedPoints = calculatePoints(client);
            string message = u.UserName + " won and gained " + gainedPoints + " points!";
            foreach (int player in r.Players)
            {
                answerByPlayerId("WIN", message, player);
            }
            int mode = r.NumberMode;

            if (r.RoomNumberOfPlayers > 1)
            {
                Console.WriteLine("dodajemy pkt!");
                dbOp.AddPointsToDatabase(u.UserName, gainedPoints, mode);
            }
            else
            {
                Console.WriteLine("nie dodajemy pkt, bo to tylko trening!");

            }
        }


        void takePlayerNextCard(TcpClient client)
        {
            User u = this.TcpClients.Where(c => c.TcpClient.Equals(client)).Select(c => c).FirstOrDefault();
            Room r = this.room.Where(c => c.RoomId.Equals(u.IdRoom)).Select(c => c).FirstOrDefault();

            Console.WriteLine("Gracz: " + u.UserName + ", id karty" + u.CurrentCardId + ", wszytkie karty: " + r.cardsPerSetFunc(r.RoomNumberOfPlayers));
            if (u.CurrentCardId + 1 == r.cardsPerSetFunc(r.RoomNumberOfPlayers))
            {
                Console.WriteLine("wygral ktos!!!! :) ");
                playerWin(client);


            }
            else
            {
                u.CurrentCardId++;
                Console.WriteLine("Wykladamy kolejna karte dla gracza");
                u.currentCardElements(u.CurrentCardId, r);
                answerCardIdForOnePlayer(client, "PLAYER_CARD", u.CurrentCard, r);
                answerInt("NUM_CURRENT_CARD", u.CurrentCardId + 1, u.UserId);

            }
        }

        void takeMainNextCard(TcpClient client)
        {
            User u = this.TcpClients.Where(c => c.TcpClient.Equals(client)).Select(c => c).FirstOrDefault();
            Room r = this.room.Where(c => c.RoomId.Equals(u.IdRoom)).Select(c => c).FirstOrDefault();

            Console.WriteLine("Zmieniam wartosci dla mainTab");
            // BARDZO MĄDRY ZAPIS PRZYPISU WARTOŚCI DO TABLICY r.MainCardTab = u.CurrentCard;

            for (int i = 0; i < r.NumberMode; i++)
            {
                r.MainCardTab[i] = u.CurrentCard[i];

            }

            foreach (int player in r.Players)
            {
                answerCardId("MAIN_CARD", r.MainCardTab, player, r);
                answerByPlayerId("LAST_NICK", u.UserName, player);
            }
        }

        void removePlayer(TcpClient client)
        {
            User u = this.TcpClients.Where(c => c.TcpClient.Equals(client)).Select(c => c).FirstOrDefault();


            if (!u.IdRoom.Equals(-1))
            {
                Console.WriteLine("Był z kims w pokoju");

                Room r = this.room.Where(c => c.RoomId.Equals(u.IdRoom)).Select(c => c).FirstOrDefault();

                int idInList = 0;
                foreach (int player in r.Players)
                {
                    Console.WriteLine("Sprawdzamy gracza o id, czy on jest na liscie uzytkownikow: " + player);

                    if (player == u.UserId)
                    {
                        Console.WriteLine("Usuwamy tego z dc: " + player + " o nicku: " + u.UserName);
                        r.Players.RemoveAt(idInList);
                        Console.WriteLine("Usunieto pomyslnie");
                        break;


                    }
                    idInList++;
                }
            }


            int idInUserList = 0;
            foreach (User user in tcpClients)
            {

                if (user.UserName == u.UserName)
                {
                    Console.WriteLine("Usuwamy usera z listy o nicku: " + u.UserName);
                    tcpClients.RemoveAt(idInUserList);
                    Console.WriteLine("Usunieto pomyslnie");
                    break;

                }
                idInUserList++;
            }

        }

    

        void refreshList(TcpClient client, string[] response)
        {
            answer(client, "ROOM_CLEAR", "czyscimy");
            foreach (Room r in room)
            {
                string message = r.RoomName + "; (" + r.Players.Count + "/" + r.RoomNumberOfPlayers + ")";
                Console.WriteLine(message);
                answer(client, "ROOM_LIST", message);
            }
        }
        ///////////////////////////////////////////////////


        #region Ranking
        void createRanking(TcpClient client, string[] response)
        {
            Console.WriteLine("createRanking");
            dbOp.fillRankingList();
            dbOp.fillRankingListLower();


            //tutja cos
            foreach (string s in dbOp.ListRanking)
            {
                Console.WriteLine("sle" + s);

                answer(client, "RANKING_ROW", s);

            }

            foreach (string s in dbOp.ListRankingLower)
            {
                Console.WriteLine("sle" + s);

                answer(client, "RANKING_ROW_LOWER", s);

            }
        }


        #endregion Ranking

        private void connectionHandler(TcpClient client)
        {
            TcpClient this_client = client;
            Stream clientStream = this_client.GetStream();

            StreamWriter strWritter = new StreamWriter(clientStream);
            StreamReader strReader = new StreamReader(clientStream);
            string clientMessage;


            while (true)
            {

                // odbieranie wiadomosci od klienta 
                while (this.isServerRunning == true)
                {

                    try
                    {

                        clientMessage = strReader.ReadLine();


                        string[] response = clientMessage.Split(';');

                        if (response[0] == "CONNECT_REQUEST")
                        {
                            connectRequest(client, response);
                        }

                        if (response[0] == "SEND_MSG")
                        {
                            chatWithOtherUser(this_client, response);
                        }

                        if (response[0] == "NEW_GAME")
                        {
                            createNewRoom(this_client, response);
                        }

                        if (response[0] == "JOIN")
                        {
                            join(this_client, response);
                        }

                        if (response[0] == "CHOSEN_PIC")
                        {
                            chosenPic(this_client, response);
                        }

                        if (response[0] == "REFRESH_LIST")
                        {
                            refreshList(this_client, response);
                        }


                        if (response[0] == "CREATE_ACCOUNT")
                        {
                            createAccount(this_client, response);
                        }
                        if (response[0] == "RANKING")
                        {
                            createRanking(this_client, response);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Lost connection");
                        removePlayer(this_client);
                        this_client.Close();
                        return;

                    }


                }
            }

        }
    }
}
