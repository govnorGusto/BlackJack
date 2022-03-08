using BlackJack.Properties;
using System.Linq;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        List<Card> deck = new List<Card>();
        Player player = new Player();
        Player dealer = new Player();
        //bool blackjack = false;
        //bool dealerBlackjack = false;
        //bool playerBlackjack = false;

        PictureBox pictureBoxPlayer;
        PictureBox pictureBoxDealer;
        public Form1()
        {
            InitializeComponent();
            cashDisplay.Text = "$" + player.Cash.ToString();
            pointsDisplay.Text = "";
        }

        //Ger ett kort från leken till spelaren
        void DealCard()
        {
            Card tempCard = new Card(deck[^1].Suit, deck[^1].Value, deck[^1].Image);
            player.DrawCard(tempCard);
            playerDisplay.Text += player.Hand[player.Hand.Count - 1].Value + " of "
                + player.Hand[player.Hand.Count - 1].Suit + "\n";
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = player.Hand[^1].Image;            
            }
            else if (pictureBox2.Image == null)
            {
                pictureBox2.Image = player.Hand[^1].Image;
            }
            else if (pictureBox3.Image == null)
            {
                pictureBox3.Image = player.Hand[^1].Image;
            }
            else if (pictureBox4.Image == null)
            {
                pictureBox4.Image = player.Hand[^1].Image;
            }
            else if (pictureBox5.Image == null)
            {
                pictureBox5.Image = player.Hand[^1].Image;
            }
            else if (pictureBox6.Image == null)
            {
                pictureBox6.Image = player.Hand[^1].Image;
            }
            else if (pictureBox7.Image == null)
            {
                pictureBox7.Image = player.Hand[^1].Image;
            }
            else if (pictureBox8.Image == null)
            {
                pictureBox8.Image = player.Hand[^1].Image;
            }
            else if (pictureBox9.Image == null)
            {
                pictureBox9.Image = player.Hand[^1].Image;
            }
            else if (pictureBox10.Image == null)
            {
                pictureBox10.Image = player.Hand[^1].Image;
            }

            deck.RemoveAt(deck.Count - 1);


        }

        //Ger ett kort från leken till dealern
        void DealerDealCard()
        {
            Card tempCard = new Card(deck[^1].Suit, deck[^1].Value, deck[^1].Image);
            dealer.DrawCard(tempCard);
            dealerDisplay.Text += dealer.Hand[^1].Value + " of "
                + dealer.Hand[^1].Suit + "\n";
            
            deck.RemoveAt(deck.Count - 1);
        }

        void DealerDealHiddenCard()
        {
            Card tempCard = new Card(deck[^1].Suit, deck[^1].Value, deck[^1].Image);
            dealer.DrawCard(tempCard);
            dealerDisplay.Text += "unknown card";
            
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
                    Card temp = new Card();
                    temp.Suit = (Card.Suits)currentSuit;
                    temp.Value = (Card.Values)currentValue;
                    deck.Add(temp);
                }
            }


            //läger till ett random kort
            Random tempRandom =new Random();
            deck = deck.OrderBy(whatever => tempRandom.Next()).ToList();
            
            //annat sätt att randomisera
            //Random random = new Random();
            //int randomIndex = random.Next(0, deck.Count);
            //player.Hand.Add(new Card(deck[randomIndex].Suit, deck[randomIndex].Value));
            //deck.RemoveAt(randomIndex);
        }


        private async void btnBet_Click(object sender, EventArgs e)
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
                DealerDealHiddenCard();         
                DealCard();
                DealerDealCard();
                player.CalculatePoints();
                pointsDisplay.Text = player.Points.ToString();
                player.Cash -= int.Parse(betInput.Text);
                cashDisplay.Text = "$" + player.Cash.ToString();
                dealer.CalculatePoints();
                dealerPointsDisplay.Text = dealer.Points.ToString();//remove when ready to NOT show dealers points
            }
            //Annars sktiv till spelaren alla krav på satsningen
            else
            {
                MessageBox.Show("Your bet may only contain a whole number, \n" 
                    + "Must be grater than 0, \n" 
                    + "And can't exceed cash you have on hand",
                    "Invalid bet.");
            }
            await Task.Delay(1500);
            CheckIfBlackjack();
           
        }

        // ta ett till kort
        private void btnHit_Click(object sender, EventArgs e)
        {
            DealCard();
            player.CalculatePoints();
            pointsDisplay.Text = player.Points.ToString();
            eventDisplay.Text += "You draw a card..\n\n";
            CheckIfBlackjack();

            //spelaren förlorar automatiskt om poängen går över 21p
            if (player.Points >= 22)
            {
                eventDisplay.Text += "Your points are: " +player.Points.ToString() + "p \n\n" 
                    + "Too bad! You BUST! \n\n";                
                ResetTable();
            }
        }

        //Spelaren väljer att stanna
        private void btnStand_Click(object sender, EventArgs e)
        {
            // stannar på nuvarande poäng
            // dealerns tur 

            dealer.CalculatePoints();

            //om dealern har mindre än 17p måste denne dra ett nytt kort
            while (dealer.Points <= 16)
            {
                DealerDealCard();
                dealer.CalculatePoints();
                eventDisplay.Text += "Dealer draws a card.. \n\n";
            }

            CheckIfBlackjack();

            //om dealern är tjock (mer än 21p) 
            if (dealer.Points > 21)
            {
                dealerDisplay.Text = dealer.Points.ToString();
                player.Cash += int.Parse(betInput.Text)*2;
                cashDisplay.Text = "$" + player.Cash.ToString();
                eventDisplay.Text += "Dealers goes BUST on " + dealer.Points.ToString() + "p \n\n" 
                    +"You Win! \n\n";
                ResetTable();
            }

            //om spelarens poäng är mindre eller lika med dealerns = förlust
            else if (player.Points <= dealer.Points)
            {
                playerDisplay.Text = player.Points.ToString();
                eventDisplay.Text += "Dealer have " + dealer.Points.ToString() + "p \n" 
                    +"You have " + player.Points.ToString() + "p \n\n";
                if(player.Points == dealer.Points)
                {
                    eventDisplay.Text += "The house always wins if there is a tie. \n\n";
                }
                eventDisplay.Text += "too bad! You loose! \n\n";
                ResetTable();;
            }
            //annars vinner spelaren
            else
            {
                playerDisplay.Text = player.Points.ToString();
                player.Cash += int.Parse(betInput.Text) * 2;
                cashDisplay.Text = "$" + player.Cash.ToString();
                eventDisplay.Text += "Dealer have " + dealer.Points.ToString() + "p \n" 
                    + "You have " + player.Points.ToString() + "p \n\n" 
                    + "YaY! You win! \n\n";
                ResetTable();
            }
        }
 
        void ResetTable()
        {
            //eventDisplay.Clear();
            playerDisplay.Clear();
            dealerDisplay.Clear();
            pointsDisplay.Text = null;
            dealerPointsDisplay.Text = null;
            betInput.Clear();
            btnHit.Enabled = false;
            btnStand.Enabled = false;
            btnBet.Enabled = true;
            betInput.Enabled = true;
            ResetPoints();
            ResetImages();
        }
        void ResetPoints()
        {
            player.Hand.Clear();
            dealer.Hand.Clear();
            dealer.Points = 0;
            player.Points = 0;
        }

        void ResetImages()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null; 
            pictureBox5.Image = null;
            pictureBox6.Image = null; 
            pictureBox7.Image = null;
            pictureBox8.Image = null; 
            pictureBox9.Image = null;
            pictureBox10.Image = null;
            pictureBox11.Image = null;
            pictureBox12.Image = null;
            pictureBox13.Image = null;
            pictureBox14.Image = null;
            pictureBox15.Image = null;
            pictureBox16.Image = null;
            pictureBox17.Image = null;
            pictureBox18.Image = null;
            pictureBox19.Image = null;
            pictureBox20.Image = null;
        }

        //void ResetGame()
        //{
        //    DialogResult result = MessageBox.Show("Would yo like to play again?", "GAME OVER", MessageBoxButtons.YesNo);

        //    if (result == DialogResult.Yes
        //        && int.Parse(betInput.Text) <= player.Cash)
        //    {
        //        ResetTable();
        //    }
        //    else if (result == DialogResult.No)
        //    {
        //        Application.Exit();
        //    }
        //}


        void CheckIfBlackjack()
        {
            bool isTrue = false;
            while (!isTrue)
            {
                if (player.Points == 21)
                {
                    eventDisplay.Text += "WOOooHOOoo!! You got BLACKjACK! \n\n";
                    player.Cash += int.Parse(betInput.Text) * 3;
                    cashDisplay.Text = "$" + player.Cash.ToString();
                    ResetTable();
                }
                else if (dealer.Points == 21)
                {
                    eventDisplay.Text += dealer.Points.ToString() + "The dealer got BLACKjACK!\n" 
                        + " You loose! \n";
                    ResetTable();
                }
                else
                {
                    isTrue = true;
                }
            }
        }

    }
}