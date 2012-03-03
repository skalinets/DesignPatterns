using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    abstract class HandCatagorizer
    {
        public HandCatagorizer RegisterNext(HandCatagorizer next)
        {
            Next = next;
            return Next;
        }

        protected HandCatagorizer Next { get; private set; }

        public abstract HandRanking Catagorize(Hand hand);

        protected static bool HasNofKind(int n, Hand hand)
        {
            Dictionary<Value, int> seen = new Dictionary<Value, int>();

            foreach (Card c in hand.Cards)
            {
                if (seen.ContainsKey(c.Value))
                {
                    seen[c.Value]++;
                }
                else
                {
                    seen[c.Value] = 1;
                }
            }

            foreach (int count in seen.Values)
            {
                if (count == n)
                {
                    return true;
                }
            }

            return false;
        }

        protected static bool HasStraight(Hand hand)
        {
            List<Value> values = hand.Cards.Select(c => c.Value).ToList();
            values.Sort();

            int expectedValue = (int)values[0];

            foreach (Value value in values)
            {
                if ((int)value != expectedValue)
                {
                    return false;
                }

                expectedValue++;
            }

            return true;
        }

        protected static bool HasFlush(Hand hand)
        {
            List<Suit> suits = hand.Cards.Select(c => c.Suit).ToList();
            suits.Sort();

            Suit expected = suits[0];

            return suits.All(suit => suit == expected);
        }
    }
}
