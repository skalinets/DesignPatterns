using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class Deck
    {
        public Deck()
        {
            Cards = new Queue<Card>();

            const int suitMin = (int)Suit.Diamond;
            const int suitMax = (int)Suit.Spade;

            const int valueMin = (int)Value.Two;
            const int valueMax = (int)Value.Ace;

            for (int s = suitMin; s <= suitMax; s++)
            {
                for (int v = valueMin; v <= valueMax; v++)
                {
                    Cards.Enqueue(new Card((Suit)s, (Value)v));
                }
            }
        }

        public Card Deal()
        {
            return Cards.Dequeue();
        }

        public void Shuffle()
        {
            Shuffle(7);
        }

        public void Shuffle(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Queue<Card> newDeck = new Queue<Card>(Cards.OrderBy(a => Guid.NewGuid()));
                Cards = newDeck;
            }
        }

        private Queue<Card> Cards { get; set; }
    }
}
