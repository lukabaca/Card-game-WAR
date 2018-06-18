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

            //deck.printDeck(Deck.GameDeck);
            deck.shuffleGameDeck();
            deck.initPlayersDecks();

            //deck.printDeck(deck.ServerDeck);
            //deck.printDeck(deck.ClientDeck);

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
            if (!player_1.IsMoveMaked)
            {
                String card = player_1.getCardFromTop();
                Console.WriteLine("Player_1 card: " + card);

                label6.Text = card;
            }

        }

        private void makeMovePlayer2(object sender, EventArgs e)
        {
            //Console.WriteLine("Player_2 moves");
            if (!player_2.IsMoveMaked)
            {
                String card = player_2.getCardFromTop();
                Console.WriteLine("Player_2 card: " + card);

                label7.Text = card;
            }
        }
    }

    
}
