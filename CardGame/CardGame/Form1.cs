using System.Windows.Forms;
using gameSpace;
using System.Collections.Generic;
using System;

namespace CardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Player player_1 = new Player();
            Player player_2 = new Player();

            Deck deck = initDecks();

            player_1.loadDeck(deck.Player1_deck);
            player_2.loadDeck(deck.Player2_deck);

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
            
            for (int i = 0; i < currentDeck.Count; i++)
            {
                currentDeck.Add(i.ToString());
            }

            if (playerNumber == 1)
            {
                listBox1.DataSource = currentDeck;
            }
            else
            {
                listBox3.DataSource = currentDeck;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void rozdajTalieButton(object sender, EventArgs e)
        {

        }
    }

    
}
