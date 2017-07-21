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
using System.Security.Cryptography;


namespace TcpServer.Controller
{
    public class DataBaseOperations
    {
        ToolBarExtras extra = new ToolBarExtras();

        DataBase db;



        public void ConnectDataBase()
        {
            Console.WriteLine("probuje polaczyc z baza");
            db = new DataBase();
            DataTable dt = db.CreateDataTable("select id, name,password,email, gender, year_of_birth  from player;");
            checkConnectionByAddPoints();

        }
        #region RandomAccounts
        List<int> usedNumbers = new List<int>();

        public static string GetRandomAlphanumericString(int length)
        {
            const string alphanumericCharacters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789";
            return GetRandomString(length, alphanumericCharacters);
        }

        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }

        void doRandomsAcc()
        {
            string nick = "Anna";
            string passoword = "qwer1234";
            string email = "ania@gmail.com";
            string age = "1993";
            string gender = "female";


            string[] res = { "", nick, passoword, email, age, gender };
            createNewAccount(res);
            /////////////

            Random rnd = new Random();
            string[] girlName = { "Addison", "Amanda", "Andrea", "Asia", "Callie", "Camelia", "Chelsa", "China", "dabria", "ester", "Eraaa", "Hunter", "Linn", "Pink", "Poppy", "Rosa" };
            string[] nameBoy = { "Andey", "Alcott", "alger", "almond", "ANSON", "Arden", "Ashby", "Baker", "ballard", "Cade", "Colden", "Dylan", "Dee", "Dudu", "Garfield", "Happy", "lucky", "Star", "Irvin", "Kevin", "Linton", "Newt", "Paxton", "ProPlayer", "Skipper", "Teddy", "True", "Tayler" };
            string[] emailAdress = { "@onet.pl", "@gmail.com", "@outlook.com", "@hotmail.com", "@hushmail.me", "@techie.com", "@gmx.com", "@facebook.com" };
            int newNumber = rnd.Next(1, 2017);
            int number;

            for (int i = 0; i < girlName.Length; i++)
            {
                number = newNumber;
                nick = girlName[i];

                passoword = GetRandomAlphanumericString(rnd.Next(8, 12));
                email = girlName[i] + emailAdress[1];
                age = rnd.Next(1970, 2011).ToString();
                gender = "female";
                string[] sqlInsert = { "a", nick, passoword, email, age, gender };
                createNewAccount(sqlInsert);
                newNumber = rnd.Next(1, 2017);
            }

            for (int i = 0; i < nameBoy.Length; i++)
            {
                number = newNumber;
                nick = nameBoy[i];

                passoword = GetRandomAlphanumericString(rnd.Next(8, 12));
                email = nameBoy[i] + emailAdress[1];
                age = rnd.Next(1970, 2011).ToString();
                gender = "male";
                string[] sqlInsert = { "a", nick, passoword, email, age, gender };
                createNewAccount(sqlInsert);
                newNumber = rnd.Next(1, 2017);
            }


            for (int i = 0; i < girlName.Length; i++)
            {
                int countOFSingeNick = rnd.Next(1, 2);
                for (int j = 0; j <= countOFSingeNick; j++)
                {


                    if (usedNumbers.Contains(newNumber))
                    {
                        Console.WriteLine("Nick was already taken");
                    }
                    else
                    {
                        number = newNumber;
                        nick = girlName[i] + number;
                        passoword = GetRandomAlphanumericString(rnd.Next(8, 12));
                        email = girlName[i] + number + emailAdress[countOFSingeNick];
                        age = rnd.Next(1970, 2017).ToString();
                        gender = "female";
                        string[] sqlInsert = { "a", nick, passoword, email, age, gender };
                        createNewAccount(sqlInsert);
                        newNumber = rnd.Next(1, 2017);


                    }
                }
            }

            for (int i = 0; i < nameBoy.Length; i++)
            {
                int ifAdd = rnd.Next(1, 2);
                if (ifAdd == 1)
                {

                    number = newNumber;
                    nick = nameBoy[i] + number;
                    passoword = GetRandomAlphanumericString(rnd.Next(8, 12));
                    email = nameBoy[i] + number + emailAdress[5];
                    age = rnd.Next(1970, 2017).ToString();
                    gender = "other";
                    string[] sqlInsert = { "a", nick, passoword, email, age, gender };
                    createNewAccount(sqlInsert);
                    newNumber = rnd.Next(1, 2017);

                }
            }

        }

        void makeAPoints()
        {

        }
        #endregion RandomAccounts
        int nextId(DataTable dt)
        {
            int id = 0;
            foreach (DataRow dr in dt.Rows)
            {
                id = Convert.ToInt32(dr["id"]);
            }
            return id;
        }

        public void createNewAccount(string[] response)
        {
            //     Console.WriteLine("dodajemy uzytkownika do bazy");
            DataTable dt = db.CreateDataTable("select id, name,password,email, gender, year_of_birth from player;");

            try
            {
                int id = nextId(dt) + 1;

                Console.WriteLine("id: " + id);

                Console.WriteLine(response[4]);

                int age = Convert.ToInt32(response[4]);

                string sql = "insert into GameDatabase.dbo.player values('{0}','{1}','{2}','{3}','{4}','{5}');";
                sql = "insert into GameDatabase.dbo.player values('" + id + "','" + response[1] + "','" + response[2] + "','" + response[3] + "','" + response[5] + "','" + age + "');";

                db.RunQuery(sql);

            }
            catch
            {
                extra.ShowInformation("Error", "Error with save data");

            }

        }

        public bool CheckLogin(string nick, string password)
        {
            DataTable dt = db.CreateDataTable("select name,password, id from player;");

            foreach (DataRow dr in dt.Rows)
            {

                if (dr["name"].Equals(nick))
                {
                    if (dr["password"].Equals(password))
                    {
                        return false;
                    }
                }
            }
            Console.WriteLine("Nie zgadaja sie ");

            return true;

        }
        public bool InvalidNick(string nick)
        {
            DataTable dt = db.CreateDataTable("select name,password, id from player;");

            foreach (DataRow dr in dt.Rows)
            {

                if (dr["name"].Equals(nick))
                {

                    return true;

                }
            }

            return false;

        }

        #region Addpoints
        int takeId(string nick, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (dr["name"].Equals(nick))
                    {
                        Console.WriteLine(nick + " Mamy nick! a to ID: " + Convert.ToInt32(dr["id"]));

                        return Convert.ToInt32(dr["id"]);
                    }
                }
                catch
                {
                    Console.WriteLine("Error, nie ma gracza o takiem nicku w bazie O.o ");
                }
            }
            return -1;
        }

        public void AddPointsToDatabase(string nick, int gainedPoints, int mode)
        {
            Console.WriteLine("dodajemy punkty dla gracza");
            DataTable dt = db.CreateDataTable("select id, name from player;");

            DataTable dtPlayerPoints = db.CreateDataTable("select id, playerId, pointsId, amount from player_points;");

            DataTable dtPoints = db.CreateDataTable("select id, name from points;");



            int playerId = takeId(nick, dt);
            int pointsId = takePointsID(mode);
            int finallyPoints = sumPoints(playerId, pointsId, dtPlayerPoints, gainedPoints);

            if (ifRowAlreadyExist(playerId, pointsId, dtPlayerPoints))
            {
                updatePLayerPoints(playerId, pointsId, finallyPoints);
            }
            else
            {
                insertPlayerPoints(playerId, pointsId, finallyPoints);
            }
        }

        int sumPoints(int playerId, int pointsId, DataTable dtPlayerPoints, int gainedPoints)
        {
            foreach (DataRow dr in dtPlayerPoints.Rows)
            {
                try
                {
                    if (Convert.ToInt32(dr["playerId"]) == playerId && Convert.ToInt32(dr["pointsId"]) == pointsId)
                    {
                        Console.WriteLine(Convert.ToInt32(dr["amount"]) + " z " + gainedPoints);
                        return Convert.ToInt32(dr["amount"]) + gainedPoints;
                    }
                }
                catch
                {
                    Console.WriteLine("Error, no i czesc");
                }
            }
            return gainedPoints;

        }

        int takePointsID(int mode)
        {
            switch (mode)
            {
                case 8:
                    return 1;
                case 6:
                    return 2;
                default:
                    Console.WriteLine("Default case");
                    return -1;
            }
        }


        bool ifRowAlreadyExist(int playerId, int pointsId, DataTable dtPlayerPoints)
        {
            foreach (DataRow dr in dtPlayerPoints.Rows)
            {
                try
                {
                    if (dr["playerId"].Equals(playerId) && dr["pointsId"].Equals(pointsId))
                    {
                        return true;
                    }
                }
                catch
                {
                    Console.WriteLine("Error w ifRowAlreadyExist ");
                }
            }
            return false;
        }

        public void updatePLayerPoints(int playerId, int pointsId, int finallyPoints)
        {
            Console.WriteLine("aktualizujemy pkt");
            DataTable dtPlayerPoints = db.CreateDataTable("select id, playerId, pointsId, amount from player_points;");


            try
            {

                string sql = "update GameDatabase.dbo.player_points set amount ='{0}' where GameDatabase.dbo.player_points.playerId = '{1}' and GameDatabase.dbo.player_points.pointsId ='{2}';";

                sql = "update GameDatabase.dbo.player_points set amount =" + finallyPoints + "where GameDatabase.dbo.player_points.playerId = " + playerId + "and GameDatabase.dbo.player_points.pointsId =" + pointsId;
                db.RunQuery(sql);

            }
            catch
            {
                extra.ShowInformation("Error", "Error with save data - updatePLayerPoints");

            }

        }

        public void insertPlayerPoints(int playerId, int pointsId, int finallyPoints)
        {
            Console.WriteLine("dodajemy  punkty do nowego wiersza");
            DataTable dtPlayerPoints = db.CreateDataTable("select id, playerId, pointsId, amount from player_points;");


            try
            {
                int curretnId = nextId(dtPlayerPoints) + 1;

                string sql = "insert into GameDatabase.dbo.player_points values('{0}','{1}','{2}','{3}');";
                sql = "insert into GameDatabase.dbo.player_points values('" + curretnId + "','" + playerId + "','" + pointsId + "','" + finallyPoints + "');";
                db.RunQuery(sql);

            }
            catch
            {
                extra.ShowInformation("Error", "Error with save data");

            }

        }

        #endregion Addpoints

        #region Ranking
        List<string> listRanking = new List<string>();
        List<string> listRankingLower = new List<string>();

        public List<string> ListRanking
        {
            get
            {
                return listRanking;
            }

            set
            {
                listRanking = value;
            }
        }

        public List<string> ListRankingLower
        {
            get
            {
                return listRankingLower;
            }

            set
            {
                listRankingLower = value;
            }
        }

        public void fillRankingList()
        {
            Console.WriteLine("robimy datatable");

            DataTable ranking = db.CreateDataTable("Select ROW_NUMBER() OVER(ORDER BY player_points.amount DESC) as rank, player.name as name, player_points.amount as amount from player, player_points where player_points.playerId = player.id AND player_points.pointsId = 1 ORDER BY player_points.amount DESC;");


            foreach (DataRow dr in ranking.Rows)
            {
                try
                {
                    Console.WriteLine(Convert.ToInt32(dr["rank"]) + ";" + Convert.ToString(dr["name"]) + ";" + Convert.ToString(dr["amount"]));
                    string row = Convert.ToInt32(dr["rank"]) + ";" + Convert.ToString(dr["name"]) + ";" + Convert.ToString(dr["amount"]);
                    listRanking.Add(row);

                }
                catch
                {
                    Console.WriteLine("Error, no i czesc");
                }
            }

        }

        public void fillRankingListLower()
        {
            Console.WriteLine("robimy datatable");

            DataTable ranking = db.CreateDataTable("Select ROW_NUMBER() OVER(ORDER BY player_points.amount DESC) as rank, player.name as name, player_points.amount as amount from player, player_points where player_points.playerId = player.id AND player_points.pointsId = 2 ORDER BY player_points.amount DESC;");


            foreach (DataRow dr in ranking.Rows)
            {
                try
                {
                    Console.WriteLine(Convert.ToInt32(dr["rank"]) + ";" + Convert.ToString(dr["name"]) + ";" + Convert.ToString(dr["amount"]));
                    string row = Convert.ToInt32(dr["rank"]) + ";" + Convert.ToString(dr["name"]) + ";" + Convert.ToString(dr["amount"]);
                    ListRankingLower.Add(row);

                }
                catch
                {
                    Console.WriteLine("Error, no i czesc");
                }
            }

        }


        #endregion Ranking
        #region tests

        public void checkConnectionByAddPoints()
        {

            AddPointsToDatabase("Dylan", 2, 8);
            AddPointsToDatabase("Chelsa", 5, 8);
            AddPointsToDatabase("Linn", 4, 8);
            AddPointsToDatabase("Poppy", 3, 8);
            AddPointsToDatabase("Alcott", 2, 8);
            AddPointsToDatabase("Happy", 2, 8);
            AddPointsToDatabase("Paxton", 1, 8);
            AddPointsToDatabase("John", 16, 6);
            AddPointsToDatabase("Mirek34", 9, 6);

            #endregion
        }
    }
}
