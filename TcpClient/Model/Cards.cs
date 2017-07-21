using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpClientProgram.Model
{
    public class Cards
    {


        public static int numberOfCards = 56, numberOfSymbols = 8;

        int[] mainCardTab = new int[numberOfSymbols];
        int[] playerCardTab = new int[numberOfSymbols];

        string pathToImages = "";

        public string PathToImages
        {
            get { return pathToImages; }
            set { pathToImages = value; }

        }
        public int[] MainCardTab
        {
            get { return mainCardTab; }
            set { mainCardTab = value; }
        }

        public int[] PlayerCardTab
        {
            get { return playerCardTab; }
            set { playerCardTab = value; }
        }
        public int NumberOfSymbols
        {
            get { return numberOfSymbols; }
            set { numberOfSymbols = value; }
        }


    }
}
