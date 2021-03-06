﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameSpace
{
    public class Player
    {
        /*
        private static Dictionary<String, int> comparingMap = new Dictionary<string, int>()
        {
         {"2", 2}, { "3",3 }, { "4",4 }, { "5", 5 },
         { "6", 6 }, { "7", 7 }, {"8", 8 }, {"9", 9},
         {"10", 10}, {"J", 11 }, {"D", 12}, {"K", 13},
         {"A", 14}
         
        };
        */

        private static Dictionary<String, int> comparingMap = new Dictionary<string, int>()
        {
         {"2", 2}, { "3",3 }, { "4",4 }, { "5", 5 },
         { "6", 6 }, { "7", 7 }

        };


        private List<String> currentDeck;
        //kupka kart, ktore wygralismy
        private List<String> wonCardsDeck;

        private Boolean isPlaying;

        private Boolean isWar;

        private War war;

        private Boolean isMoveAvailable;

        private Boolean isBonusWar;

        public Player()
        {
            currentDeck = new List<String>();
            wonCardsDeck = new List<String>();
            isPlaying = true;

            isWar = false;
            isMoveAvailable = true;

            isBonusWar = false;

            war = new War();
        }
       
        private String getLastCardFromDeck()
        {
            int lastElement = currentDeck.Count - 1;
            String card = currentDeck.ElementAt(lastElement);
            return card;
        }

        public String getCardFromTop()
        {
            isMoveAvailable = false;
            String card = "";
            

            if (!isCurrentDeckEmpty())
            {
                Console.WriteLine("current lsita nie jest pusta");


                card = getLastCardFromDeck();
                removeCardFromDeck(card);
            }
            else
            {
                Console.WriteLine("current lsita jest pusta");
                if (!iswWonCardsDeckyEmpty())
                {
                    Console.WriteLine("won card deck nie jest pusta");
                    loadDeck(wonCardsDeck);
                    Console.WriteLine("CZYSZCZE wonCardsDeck");
                    resetWonCardsDeckk();

                    card = getLastCardFromDeck();
                    removeCardFromDeck(card);
                }
                //jesli oba decki sa puste to znaczy ze przegralem
                else
                {
                    isPlaying = false;
                    card = null;
                }
            }

            
            return card;

        }

        public String changeCardFormat(String card)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (char sign in card)
            {
                
                if (sign.Equals('_'))
                {
                    break;
                }
                else
                {
                    
                    stringBuilder.Append(sign);
                }
            }

            String cardFormatted = stringBuilder.ToString();
            return cardFormatted;

        }
        private void addCardsToWonCardsDeckFromWar(List<String> myWarCardDeck, List<String> opponentWarCardDeck)
        {
            foreach(String card in myWarCardDeck)
            {
                wonCardsDeck.Add(card);
            }

            foreach (String card in opponentWarCardDeck)
            {
                wonCardsDeck.Add(card);
            }
        }

        public void cardBattle(String myCard, String opponentCard)
        {
            String myCardFormatted = changeCardFormat(myCard);
            String opponentCardFormatted = changeCardFormat(opponentCard);

            int myCardValue = comparingMap[myCardFormatted];
            int opponentCardValue = comparingMap[opponentCardFormatted];


            if (myCardValue > opponentCardValue)
            {
                //dodaje moja karte, ktora pokonalem przeciwnika i karte przeciwnika do 2 listy, "kupki" kart
                Console.WriteLine(myCard + " > " + opponentCard);

                if(isWar)
                {
                    //removeCardFromDeck(myCard);
                    Console.WriteLine("Rozstrzgajaca potyczka podczas wojny");
                    war.addCardsToDecks(myCard, opponentCard);

                    //tu musze dodac karty do kupki z puli wojny
                    addCardsToWonCardsDeckFromWar(war.MyCardDeck, war.OpponentCardDeck);


                    war.clearDecks();
                    isWar = false;
                }
                else
                {
                    Console.WriteLine("Rozstrzgajaca potyczka podczas wojny");
                    //removeCardFromDeck(myCard);

                    wonCardsDeck.Add(myCard);
                    wonCardsDeck.Add(opponentCard);
                }

                
            }

            if(myCardValue < opponentCardValue)
            {
                Console.WriteLine(myCard + " < " + opponentCard);

                if(isWar)
                {
                    //removeCardFromDeck(myCard);

                    war.clearDecks();
                    isWar = false;
                }
                else
                {
                    //removeCardFromDeck(myCard);
                }
            }

            if(myCardValue == opponentCardValue)
            {
                Console.WriteLine("JEST WOJNA");
                isWar = true;

                isBonusWar = true;
                //removeCardFromDeck(myCard);

                war.addCardsToDecks(myCard, opponentCard);
               
                //przypadek wojny
            }
            isMoveAvailable = true;

        }
        //dodaje karty do puli wojny, te co sa 'ukryte'
        public void addCardsToWarBonus(String myCard, String opponentCard)
        {
            //currentDeck.Remove(myCard);

            war.addCardsToDecks(myCard, opponentCard);
            isMoveAvailable = true;

            isBonusWar = false;
        }


        private Boolean isCurrentDeckEmpty()
        {
            if(currentDeck.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean iswWonCardsDeckyEmpty()
        {
            if (wonCardsDeck.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //do kupki odkladam karte, ktora wylozylem i pokonala przeciwnika oraz karte przeciwnika
        public void addCardToWonCardsDeck(String myCard, String opponentCard)
        {
            wonCardsDeck.Add(myCard);
            wonCardsDeck.Add(opponentCard);
        }
        public void removeCardFromDeck(String card)
        {
            
            if (!isCurrentDeckEmpty())
            {
                //Console.WriteLine("current lsita nie jest pusta");
                currentDeck.Remove(card);
            }
            else 
            {
                //Console.WriteLine("current lsita jest pusta");
                if (!iswWonCardsDeckyEmpty())
                {
                    //Console.WriteLine("won card deck nie jest pusta");
                    loadDeck(wonCardsDeck);
                    //Console.WriteLine("CZYSZCZE wonCardsDeck");
                    resetWonCardsDeckk();
                }
                //jesli oba decki sa puste to znaczy ze przegralem
                else
                {
                    isPlaying = false;
                }
            }
            
            

        }

        public void loadDeck(List<String> deck)
        {
            for (int i = 0; i < deck.Count; i++)
            {
                String card = deck.ElementAt(i);
                currentDeck.Add(card);
            }

        }

        public void resetWonCardsDeckk()
        {
            wonCardsDeck.Clear();
        }

        public void printCurrentDeck()
        {
            Console.WriteLine("Current deck: ");
            foreach (String card in currentDeck)
            {
                Console.WriteLine(card + " ");
            }
            Console.WriteLine("###########################");
        }

        public void printWonCardsDeck()
        {
            Console.WriteLine("Deck with won cards: ");
            foreach (String card in wonCardsDeck)
            {
                Console.WriteLine(card + " ");
            }
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@");
        }

        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }

            set
            {
                isPlaying = value;
            }
        }

        public bool IsWar
        {
            get
            {
                return isWar;
            }

            set
            {
                isWar = value;
            }
        }

        public List<string> CurrentDeck
        {
            get
            {
                return currentDeck;
            }

            set
            {
                currentDeck = value;
            }
        }

        public List<string> WonCardsDeck
        {
            get
            {
                return wonCardsDeck;
            }

            set
            {
                wonCardsDeck = value;
            }
        }

        public bool IsMoveAvailable
        {
            get
            {
                return isMoveAvailable;
            }

            set
            {
                isMoveAvailable = value;
            }
        }

        public War War
        {
            get
            {
                return war;
            }

            set
            {
                war = value;
            }
        }

        public bool IsBonusWar
        {
            get
            {
                return isBonusWar;
            }

            set
            {
                isBonusWar = value;
            }
        }
    }
}
