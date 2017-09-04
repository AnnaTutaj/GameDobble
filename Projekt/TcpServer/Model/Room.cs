using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
namespace TcpServer.Model
{

    public class Room : Cards
    {
        private string roomName;
        private int idNumberUser;
        private int idNumberRoom;
        private int numberOfPlayers;
        private int numberMode;
        private  int p;
        
        private List<int> players = new List<int>();
        private Cards cards;
    
   
        public Room(string roomName, int idNumberUser, int numberOfPlayers, int numberMode)
        {
            this.roomName = roomName;
            this.idNumberUser = idNumberUser;
            this.idNumberRoom = idNumberUser;
            this.numberOfPlayers = numberOfPlayers;
            this.NumberMode = numberMode;
            p = numberMode - 1;
            cards = new Cards(idNumberRoom, numberMode);

        }
    

        public Cards Cards
        {
            get { return cards; }
            set { cards = value; }
        }


        public void addPlayer(int idNumberUser)
        {
            Players.Add(idNumberUser);
        }


        public List<int> Players
        {

            get { return players; }
            set { players = value; }
        }

        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }

        public int RoomIdNumberUser
        {
            get { return idNumberUser; }
            set { idNumberUser = value; }

        }

        public int RoomId
        {
            get { return idNumberRoom; }
            set { idNumberRoom = value; }

        }

        public int RoomNumberOfPlayers
        {
            get { return numberOfPlayers; }
            set { numberOfPlayers = value; }

        }

        public int P
        {
            get
            {
                return p;
            }

            set
            {
                p = value;
            }
        }

        public int NumberMode
        {
            get
            {
                return numberMode;
            }

            set
            {
                numberMode = value;
            }
        }
    }
}
