using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace TcpServer.Model
{
    public class User
    {
        private TcpClient tcpClient;
        private string userName;
        private int idNumber;
        private int idRoom = -1;
        // np dla 2 graczy jest 27
        static List<int> set = new List<int>();

        static int numberOfSymbols = 8;
        int[,] setForPlayer = new int[set.Count, numberOfSymbols];
        private int currentCardId = 0;
        private int[] currentCard = new int[numberOfSymbols];



        public User(TcpClient tcpClient, string userName, int idNumber)
        {
            this.tcpClient = tcpClient;
            this.userName = userName;
            this.idNumber = idNumber;
        }


        public int IdRoom
        {
            get { return idRoom; }
            set { idRoom = value; }
        }
        public TcpClient TcpClient
        {
            get { return tcpClient; }
            set { tcpClient = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public int UserId
        {
            get { return idNumber; }
            set { idNumber = value; }
        }

        public List<int> Set
        {
            get { return set; }
            set { set = value; }
        }


        public int NumberOfSymbols
        {
            get { return numberOfSymbols; }
            set { numberOfSymbols = value; }
        }

        public int[,] SetForPlayer
        {
            get { return setForPlayer; }
            set { setForPlayer = value; }
        }

        public int[] CurrentCard
        {
            get { return currentCard; }
            set { currentCard = value; }
        }

        public int CurrentCardId
        {
            get { return currentCardId; }
            set { currentCardId = value; }
        }

        public int NumberOfCardsForPlayer()
        {
            return set.Count;
        }


        public void currentCardElements(int currentCardId, Room r)
        {

            for (int a = 0; a < r.NumberMode; a++)
            {
                currentCard[a] = setForPlayer[currentCardId, a];
            }

        }

        public void showAllInfoAboutUser()
        {
            Console.WriteLine("Info o graczu: ");

            Console.WriteLine("id: " + UserId + ", nick: " + UserName + ", id room: " + IdRoom);
            int i = 0;
            Console.WriteLine("Id kart w secie: ");

            foreach (int cards in Set)
            {
                Console.Write("#" + i + ": " + cards + ", ");
                i++;
            }
            Console.WriteLine("");

            Console.WriteLine("Tablica z wartosciami odpowiadajacym za symbole: ");

            showTab(set.Count, numberOfSymbols, SetForPlayer);
            Console.WriteLine("Koniec tabeli ");


        }

        void showTab(int numberOfCards, int numberOfSymbols, int[,] tab)
        {
            Console.WriteLine("--------------------");

            for (int i = 0; i < numberOfCards; i++)
            {
                Console.Write("#{0}: ", i);
                for (int j = 0; j < numberOfSymbols; j++)
                {
                    Console.Write(tab[i, j] + " ");
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");

            Console.WriteLine("--------------------");

        }


    }
}
