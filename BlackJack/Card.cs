using BlackJack.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Card
    {
        public Card(Suits suit, Values value, Image image)
        {
            this.value = value;
            this.suit = suit;
            this.image = image;
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
        Image image;

        public Image Image
        {
            get { return this.image; }
        }

        public Suits Suit
        {
            get { return this.suit; }
            set { this.suit = value; GetImage(); }  
        }
        public Values Value
        {
            get { return this.value; }
            set { this.value = value; GetImage(); }
        }

        public Card()
        {
            value = 0;
            suit = 0;
            image = null;
        }

        private void GetImage()
        {
            if (this.Suit != 0 && this.Value != 0)
            {
                int x = 0;  // starting ponit from left
                int y = 0;  // starting ponit from top, can be varied(depending of type)
                int height = 115;
                int width = 88;

                switch (this.Suit)
                {
                    case Suits.diamonds:
                        y = 0;
                        break;
                    case Suits.clubs:
                        y = 128;
                        break;
                    case Suits.hearts:
                        y = 257;
                        break;
                    case Suits.spades:
                        y = 386;
                        break;
                }

                x = width * ((int)this.Value - 1);

                Bitmap source = Resources.deck_of_cards;
                Bitmap img = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(img);
                g.DrawImage(source, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
                g.Dispose();
                this.image = img;
            }
        }
    }
}
