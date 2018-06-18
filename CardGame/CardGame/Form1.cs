using System.Windows.Forms;
using gameSpace;
using System.Collections.Generic;
using System;

namespace CardGame
{
    public partial class Form1 : Form
    {
        private Player player_1;
        private Player player_2;

        public Form1()
        {
            InitializeComponent();

            player_1 = new Player();
            player_2 = new Player();

            Deck deck = initDecks();

            player_1.loadDeck(deck.Player1_deck);
            player_2.loadDeck(deck.Player2_deck);

            player_1.printCurrentDeck();
            player_2.printCurrentDeck();

            
            
        }

        private Deck initDecks()
        {
            Deck deck = new Deck();

            deck.shuffleGameDeck();
            deck.initPlayersDecks();

            return deck;
        }

        public void loadCurrentDeck(List<String> currentDeck, int playerNumber)
        {
            //gracz po lewo to 1
            List<String> currentDeckOfPlayer = new List<String>();
            foreach(String card in currentDeck)
            {
                currentDeckOfPlayer.Add(card);
            }

            if (playerNumber == 1)
            {
                listBox1.DataSource = currentDeckOfPlayer;
            }
            else
            {
                listBox3.DataSource = currentDeckOfPlayer;
            }
            
        }

        public void loadWonCardsDeck(List<String> wonCardsDeck, int playerNumber)
        {
            //gracz po lewo to 1
            List<String> currentDeckOfPlayer = new List<String>();
            foreach (String card in wonCardsDeck)
            {
                currentDeckOfPlayer.Add(card);
            }

            if (playerNumber == 1)
            {
                listBox2.DataSource = currentDeckOfPlayer;
            }
            else
            {
                listBox4.DataSource = currentDeckOfPlayer;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void loadDecks(object sender, EventArgs e)
        {
            loadCurrentDeck(player_1.CurrentDeck, 1);
            loadCurrentDeck(player_2.CurrentDeck, 2);
        }

        

        private void makeMovePlayer1(object sender, EventArgs e)
        {
            //Console.WriteLine("Player_1 moves");
            if (player_1.IsMoveAvailable)
            {
                if (player_1.IsPlaying)
                {
                    /*
                    if(player_1.isCurrentDeckEmptyAndTransfer())
                    {
                        loadCurrentDeck(player_1.CurrentDeck, 1);
                        player_1.resetWonCardsDeckk();
                        loadCurrentDeck(player_1.WonCardsDeck, 1);
                    }
                    */
                    String card = player_1.getCardFromTop();

                    loadCurrentDeck(player_1.CurrentDeck, 1);
                    loadWonCardsDeck(player_1.WonCardsDeck, 1);

                    Console.WriteLine("Player_1 card: " + card);

                    label6.Text = card;
                }
                else
                {
                    Console.WriteLine("Player_1 lost");
                }
            }

        }

        private void makeMovePlayer2(object sender, EventArgs e)
        {
            //Console.WriteLine("Player_2 moves");
            if (player_2.IsMoveAvailable)
            {
                if (player_2.IsPlaying)
                {
                    /*
                    if (player_2.isCurrentDeckEmptyAndTransfer())
                    {
                        loadCurrentDeck(player_2.CurrentDeck, 2);
                        player_2.resetWonCardsDeckk();
                        loadCurrentDeck(player_2.WonCardsDeck, 2);
                    }*/

                    String card = player_2.getCardFromTop();

                    loadCurrentDeck(player_2.CurrentDeck, 2);
                    loadWonCardsDeck(player_2.WonCardsDeck, 2);

                    Console.WriteLine("Player_2 card: " + card);

                    label7.Text = card;
                }
                else
                {
                    Console.WriteLine("Player_2 lost");
                }
            }
        }
        private void addCardsToWarListBox(List<String> cardWarDeckOfPlayer_1, List<String> cardWarDeckOfPlayer_2)
        {
            List<String> warDeckPlayer_1 = new List<String>();
            List<String> warDeckPlayer_2 = new List<String>();

            foreach (String card in cardWarDeckOfPlayer_1)
            {
                warDeckPlayer_1.Add(card);
            }

            foreach (String card in cardWarDeckOfPlayer_2)
            {
                warDeckPlayer_2.Add(card);
            }

            listBox5.DataSource = warDeckPlayer_1;
            listBox6.DataSource = warDeckPlayer_2;


        }
        private void clearWarListBoxes()
        {
           
        }
        private void fightButton(object sender, EventArgs e)
        {
            
            
            if ((label6.Text.Length) > 0 && (label7.Text.Length > 0))
            {
                Console.WriteLine("FIGHT");
                String player1_card = label6.Text;
                String player2_card = label7.Text;

                if (player_1.IsBonusWar)//w tym przypadku karty nie walcza ale sa dodane do puli do wojny
                {
                    player_1.addCardsToWarBonus(player1_card, player2_card);
                    player_2.addCardsToWarBonus(player2_card, player1_card);


                }
                else
                {
                    player_1.cardBattle(player1_card, player2_card);
                    player_2.cardBattle(player2_card, player1_card);
                }

                if (player_1.IsWar && player_2.IsWar)
                {
                    addCardsToWarListBox(player_1.War.MyCardDeck, player_1.War.OpponentCardDeck);
                }
                else
                {

                    Console.WriteLine("PLAYER 1 after battle");
                    player_1.printCurrentDeck();
                    player_1.printWonCardsDeck();

                    Console.WriteLine("PLAYER 2 after battle");
                    player_2.printCurrentDeck();
                    player_2.printWonCardsDeck();


                    /*
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    listBox4.Items.Clear();
                    */

                    //player_1.addCardsToWarBonus(player1_card, player2_card);
                    //player_2.addCardsToWarBonus(player2_card, player1_card);

                    loadCurrentDeck(player_1.CurrentDeck, 1);
                    loadWonCardsDeck(player_1.WonCardsDeck, 1);

                    loadCurrentDeck(player_2.CurrentDeck, 2);
                    loadWonCardsDeck(player_2.WonCardsDeck, 2);
                }

                label6.Text = "";
                label7.Text = "";

            }
            
        }
    }

    
}
