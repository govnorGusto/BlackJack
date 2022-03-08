using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player
    {
        private int cash = 100;
        private int points = 0;
        private List<Card> hand = new List<Card>();
        private int currentBet;

        public void DrawCard(Card drawCard)
        {
            // skickar in ett kort
            hand.Add(drawCard);
        }

        public int Cash
        {
            get { return cash; }
            set { cash = value; }
        }

        public int CurrentBet
        {
            get { return currentBet; }
            set { currentBet = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public List<Card> Hand
        {
            get { return hand; }
            set { hand = value; }
        }

        public void CalculatePoints()
        {
            // Set current_point till 0
            // Gå igenom listan av kort och lägg till vart korts poängvärde till current ponits (tolka ess som 1 poäng)
            // om hittade ess i listan, och kan lägga till 10 p utan att bust (val att lägga till 10p)

            bool aceFound = false;
            int calculatedPoints = 0;
            bool isTrue = false;
            while (!isTrue)
            {
                for (int current_card = 0; current_card < hand.Count; current_card++)
                {
                    calculatedPoints += (int)hand[current_card].Value;

                    switch ((int)hand[current_card].Value)
                    {
                        case 11:
                            calculatedPoints -= 1;
                            break;
                        case 12:
                            calculatedPoints -= 2;
                            break;
                        case 13:
                            calculatedPoints -= 3 ;
                            break;
                    }

                    if (hand[current_card].Value == Card.Values.ace)
                    {
                        aceFound = true;
                    }

                    // Om det finns ett ess och poängen inte överstiger 21 
                    //Gör om ess till 11
                    if (aceFound && calculatedPoints + 10 < 22)
                    {
                        calculatedPoints += 10;  // gör denna valbar
                    }  
                    points = calculatedPoints;
                }
                calculatedPoints = 0;
                isTrue = true;
            }
        }
    }
}
