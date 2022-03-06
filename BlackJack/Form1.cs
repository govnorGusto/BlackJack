namespace BlackJack
{
    public partial class Form1 : Form
    {
        List<Card> deck = new List<Card>();
        Player player = new Player();
        Player dealer = new Player();

        public Form1()
        {
            InitializeComponent();
            cashDisplay.Text = "$" + player.Cash.ToString();
            pointsDisplay.Text = "";
        }

        //Ger ett kort från leken till spelaren
        void DealCard()
        {
            Card tempCard = new Card(deck[^1].Suit, deck[^1].Value);
            player.DrawCard(tempCard);
            playerDisplay.Text += player.Hand[player.Hand.Count - 1].Value + " of "
                + player.Hand[player.Hand.Count - 1].Suit + "\n";
            deck.RemoveAt(deck.Count - 1);
        }
        //Ger ett kort från leken till dealern
        void DealerDealCard()
        {
            Card tempCard = new Card(deck[^1].Suit, deck[^1].Value);
            dealer.DrawCard(tempCard);
            dealerDisplay.Text += dealer.Hand[dealer.Hand.Count - 1].Value + " of "
                + dealer.Hand[dealer.Hand.Count - 1].Suit + "\n";
            deck.RemoveAt(deck.Count - 1);
        }

        //skapar enn kortlek av 52 kort och blandar dessa
        public void CreateAndShuffleDeck()
        {
            deck.RemoveRange(0, deck.Count);    //töm vid ny runda

            for (int currentSuit = 1; currentSuit <= 4; currentSuit++)
            {
                for (int currentValue = 1; currentValue <= 13; currentValue++)
                {
                    Card temp = new Card((Card.Suits)currentSuit, (Card.Values)currentValue);
                    deck.Add(temp);
                }
            }


            Random tempRandom =new Random();
            deck = deck.OrderBy(whatever => tempRandom.Next()).ToList();
            
            //läger till ett random kort
            //Random random = new Random();
            //int randomIndex = random.Next(0, deck.Count);
            //player.Hand.Add(new Card(deck[randomIndex].Suit, deck[randomIndex].Value));
            //deck.RemoveAt(randomIndex);
        }


        private void btnBet_Click(object sender, EventArgs e)
        {
            //kollar om spelaren ha nog med cash
            //att inte satsade 0 elle neg.tal
            //att textfältet för bet inte var tomt
            if (int.TryParse(betInput.Text, out _) == true
                && int.Parse(betInput.Text) > 0
                && int.Parse(betInput.Text) <= player.Cash)
            {
                eventDisplay.Text = "";
                btnHit.Enabled = true;
                btnStand.Enabled = true;
                btnBet.Enabled = false;
                betInput.Enabled = false;
                CreateAndShuffleDeck();
                player.CurrentBet = int.Parse(betInput.Text);
                DealCard();
                DealerDealCard();
                DealCard();
                player.CalculatePoints();
                pointsDisplay.Text = player.Points.ToString();
                player.Cash -= int.Parse(betInput.Text);
                cashDisplay.Text = "$" + player.Cash.ToString();


                //----Change DealerDealCard() below to this when done testing ---
                DealerDealCard();  
                //Card tempCard = new Card(deck[deck.Count -1].Suit, deck[deck.Count -1].Value);
                //dealer.DrawCard(tempCard);
                //dealerDisplay.Text += "unknown card";
                dealer.CalculatePoints();
                dealerPoints.Text = dealer.Points.ToString();//remove when ready to NOT show dealers points
            }
            //Annars sktiv till spelaren alla krav på satsningen
            else
            {
                MessageBox.Show("Your bet must contain only a whole number, must be grater than 0, and can not be greater than the cash you have on hand",
                    "Invalid bet helt enkelt..");
            }

            CardsLeft();

        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            DealCard();
            player.CalculatePoints();
            pointsDisplay.Text = player.Points.ToString();
            CardsLeft();

            //spelaren förlorar automatiskt om poängen går över 21p
            if (player.Points > 21)
            {
                btnHit.Enabled = false;
                btnStand.Enabled = false;
                btnBet.Enabled = true;
                betInput.Enabled = true;
                ResetGame();
            }
        }

        //Spelaren väljer att stanna
        private void btnStand_Click(object sender, EventArgs e)
        {
            // stannar på nuvarande poäng
            // dealerns tur 

            dealer.CalculatePoints();

            //banker move
            while (dealer.Points <= 16)
            {
                DealerDealCard();
                dealer.CalculatePoints();
            }

            if (dealer.Points > 21)
            {
                dealerDisplay.Text = dealer.Points.ToString();  
                MessageBox.Show("You win!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ResetGame();
            }
            else if (player.Points <= dealer.Points)
            {
                playerDisplay.Text = player.Points.ToString();
                //resultLabel.Text = String.Format
                //    ("The sum of your cards is: {0}, you lose!", player.Points);
                MessageBox.Show("You lose!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ResetGame();
            }
            else
            {
                playerDisplay.Text = player.Points.ToString();
                //resultLabel.Text = String.Format
                //    ("The sum of your cards is: {0}, you win!", player.Points);
                MessageBox.Show("You win!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ResetGame();
            }
        }

        //hur många kort finns kvar i leken
        void CardsLeft()
        {
            eventDisplay.Text = "";
            //printar den genererade decken
            for (int i = 0; i < deck.Count; i++)
            {
                eventDisplay.Text += deck[i].Value + " of " + deck[i].Suit + "\n";
            }
        }
        //tömmer textfält på spelplanen
        void ResetTableVisuals()
        {
            eventDisplay.Clear();
            playerDisplay.Clear();
            dealerDisplay.Clear();
            pointsDisplay.Text = "";
            dealerDisplay.Text = "";
            betInput.Clear();
        }

        void ResetGame()
        {
            DialogResult result = MessageBox.Show("Would yo like to play again?", "GAME OVER", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes
                && int.Parse(betInput.Text) <= player.Cash)
            {
                ResetTableVisuals();
            }
            else if (result == DialogResult.No)
            {
                Application.Exit();
            }
        }

    }
}