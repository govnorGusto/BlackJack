using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Card
    {
        public Card(Suits suit, Values value )
        {
            this.value = value;
            this.suit = suit;
        }

        public enum Suits
        {
            hearts = 1,
            spades,
            diamonds,
            clubs
        }

        public enum Values
        {
            ace = 1,
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine,
            ten ,
            jack ,
            queen ,
            king , 
        }

        private Suits suit;
        private Values value;

        public Suits Suit
        {
            get { return this.suit; }
            // set { this.suit = value; }  behövs denna?
        }
        public Values Value
        {
            get { return this.value; }
            // set { this.value = value; }  samma med denna? 
        }

    }
}
