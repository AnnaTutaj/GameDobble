using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TcpServer.Model
{
    public class Cards
    {

        private static int numberOfCards = 56, numberOfSymbols = 8;
        private int[,] tab = new int[numberOfCards, numberOfSymbols];
        private int[] mainCardTab = new int[numberOfSymbols];
        private static Random a = new Random();
        private List<List<int>> listOfsets = new List<List<int>>();

        //setsOfCards sa dla np. dwoch graczy dwie - sety karty dla gracza; sa w nich setForPlayer - tablice z numerami kart
        private List<int[,]> setsOfCards = new List<int[,]>();
        private List<int> avaliableIdOfPlayerCards = new List<int>();
        private List<int> hashedIdOfCards = new List<int>();

        private int mainCardId;
        private int cardsPerSet = 0;

        string pathToImages = "";

        public Cards()
        {

        }

        private int cardsId;
        private int numberMode;
        public Cards(int cardsId, int numberMode)
        {
            this.cardsId = cardsId;
            this.numberMode = numberMode;

        }

        #region GetSet
        public string PathToImages
        {
            get { return pathToImages; }
            set { pathToImages = value; }

        }


        public int CardsId
        {
            get { return cardsId; }
            set { cardsId = value; }
        }

        public int MainCardId
        {
            get { return mainCardId; }
            set { mainCardId = value; }
        }

        public int NumberOfSymbols
        {
            get { return numberOfSymbols; }
            set { numberOfSymbols = value; }
        }



        public List<List<int>> ListOfSets
        {
            get { return listOfsets; }
            set { listOfsets = value; }
        }

        public List<int[,]> SetsOfCards
        {
            get { return setsOfCards; }
            set { setsOfCards = value; }
        }

        public int[] MainCardTab
        {
            get { return mainCardTab; }
            set
            {

                Console.WriteLine("[CARDS] zmieniam");
                showMainTab();
                mainCardTab = value;
                Console.WriteLine("[CARDS] zmieniono");
                showMainTab();

            }
        }
        #endregion

        void showMainTab()
        {
            Console.WriteLine("[CARDS] Main Tab");
            Console.WriteLine("----------------------------------------------");
            for (int i = 0; i < numberOfSymbols; i++)
            {
                Console.Write(MainCardTab[i] + ", ");
            }
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------");
        }


        public void showTab()
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
            Console.WriteLine("--------------------");

        }
        public void createCards(int p)
        {
         

            Console.WriteLine("Generujemy karty. z p =" + p);

            // wygeneruje wszystkie dopuszczalne liczby i wrzuci je po kolei
            //uzupelnianie kolejnych wierszy

            for (int i = 0; i < p; i++)
            {
                //uzupelnianie elemntow w wierszach

                for (int j = 0; j < p; j++)
                {
                    tab[i, j] = i * p + j;
                }
                // uzupelni ostatnia kolumne ta sama liczba (inna niz wczesniej) 
                tab[i, p] = p * p + 1;

            }

            int tmp = p;
            // generuje p wierszy
            for (int i = 0; i < p; i++)
            {
                // generuje caly wiersz
                for (int j = 0; j < p; j++)
                {
                    //generuje kolejne liczby w wierszu
                    for (int k = 0; k < p; k++)
                    {
                        // int result=  k * p + (j + i * k) % p;
                        tab[tmp, k] = k * p + (j + i * k) % p;

                    }
                    //uzupelnia ostatnimi cyframi kolumny
                    tab[tmp, numberOfSymbols - 1] = p * p + 2 + i;
                    tmp++;
                }
                
            }

            for (int i = 0; i < p + 1; i++)
            {
                // utowrzenie ostatniego wiersza
                tab[numberOfCards - 1, i] = p * p + 1 + i;
            }
            showTab();

        }



        public int cardsPerSetFunc(int numberOfPlayers)
        {

            int countOfmainCard = 1;
            double div = (numberOfCards - countOfmainCard) / numberOfPlayers;
            int c = (int)(Math.Floor(div));
            Console.WriteLine("Liczba kart dla gracza: " + c);
            cardsPerSet = c;
            return cardsPerSet;
        }



        private void startIdCard()
        {

            int mainId = a.Next(0, numberOfCards);
            Console.WriteLine("Karta glowna: " + mainId);
            mainCardId = mainId;
        }


        void mainCardElements()
        {
            for (int a = 0; a < numberOfSymbols; a++)
            {

                mainCardTab[a] = tab[mainCardId, a];

                // setForPlayer[index, a] = tab[avaliableIdOfPlayerCards.ElementAt(j), a];
            }
            suffleTab(mainCardTab);

        }


        private void fillAvaliableIdOfPlayerCards()
        {
            Console.WriteLine("Dodano id do dostepnej listy (wszystkie bez main card)");

            for (int i = 0; i < numberOfCards; i++)
            {
                if (i != mainCardId)
                {
                    avaliableIdOfPlayerCards.Add(i);

                }
            }
            Console.WriteLine("Karty dostepne");

            foreach (int card in avaliableIdOfPlayerCards)
            {
                Console.Write(card + ", ");
            }
            Console.WriteLine("");
            Console.WriteLine("Koniec kart dostepnych");


        }
        //Knuth algorytm 
        public static void suffleTab<T>(T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = a.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        public void shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = a.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            Console.WriteLine("Poczatek mieszania kart");

            foreach (int card in avaliableIdOfPlayerCards)
            {
                Console.Write(card + ", ");
            }
            Console.WriteLine("");
            Console.WriteLine("Koniec mieszania kart");

        }

        void showSet()
        {
            foreach (List<int> set in listOfsets)
            {
                Console.WriteLine("Secik");
                Console.WriteLine("");

                foreach (int cards in set)
                {
                    Console.Write(cards + ", ");
                }
                Console.WriteLine("");

                Console.WriteLine("Koniec setu");

            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");

        }


        void generateCardsForPlayer(int numberOfPlayers)
        {

            mainCardElements();
            shuffle(avaliableIdOfPlayerCards);
            int startedIndex = 0;
            int j = 0;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine("startedIndex " + startedIndex);
                List<int> set = new List<int>();
                listOfsets.Add(set);

                int[,] setForPlayer = new int[numberOfCards, numberOfSymbols];
                setsOfCards.Add(setForPlayer);
                int index = 0;
                int rage = j + cardsPerSet;
                for (j = startedIndex; j < rage; j++)
                {
                    set.Add(avaliableIdOfPlayerCards.ElementAt(j));

                    int[] tmpTab = new int[numberOfSymbols];

                    for (int a = 0; a < numberOfSymbols; a++)
                    {

                        tmpTab[a] = tab[avaliableIdOfPlayerCards.ElementAt(j), a];

                        // setForPlayer[index, a] = tab[avaliableIdOfPlayerCards.ElementAt(j), a];
                    }
                    suffleTab(tmpTab);

                    for (int a = 0; a < numberOfSymbols; a++)
                    {

                        setForPlayer[index, a] = tmpTab[a];
                    }

                    index++;

                }


                startedIndex = j;

            }
            showSet();

        }



        public void createCardsForGame(int numberOfPlayers, int p)
        {
            //  7 bo 7 do kwadatu = 49; 49 + 7 +1 = 57 kart; 7 +1= 8 symboli
            numberOfSymbols = p+1;
            numberOfCards = p * p + p;

            Console.WriteLine("ja to nummode: " + numberMode + "ja to numberOfCards: " + numberOfCards + "ja to p" + p + "ja to numberOfSymbols" + numberOfSymbols);

            mainCardTab = new int[numberOfSymbols];

            createCards(p);
            showTab();
            cardsPerSetFunc(numberOfPlayers);
            startIdCard();
            fillAvaliableIdOfPlayerCards();
            generateCardsForPlayer(numberOfPlayers);

            Console.WriteLine("done 2 createCardsForGame");


        }


 


    }//end Cards class
}//end namespace







/*
Dla p = 7 utworzy 57 kart zakres 0-57 bez 49 
Dla p = 2 tab [7, 3] 
 p^2+p+1 kart z  p^2+p+1 obrazkami, kazdy ma p+1 symboli 
 * Liczba kart: 56 o indeksach [0-55]
 * Dla liczby graczy: 
 * 2- 27 kart o indeksach [0-26] 
 * 3- 18 kart o indeksach [0-17]
 * 4- 13 kart o indeksach [0-12]
 * 5- 11 kart o indeksach [0-10]
 * 6-  9 kart o indeksach [0- 8]
 *
 * ...
 * max 55 graczy i kazdy ma po 1 karcie :D 
 */
