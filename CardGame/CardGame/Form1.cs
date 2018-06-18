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
        }

        public void loadMyCurrentDeck(List<String> currentDeck)
        {

            for (int i = 0; i < currentDeck.Count; i++)
            {
                currentDeck.Add(i.ToString());
            }

            listBox1.DataSource = currentDeck;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

    
}
