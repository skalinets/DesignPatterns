using System;
using System.Collections.Generic;

namespace Poker
{
    class Program
    {
        static readonly Dictionary<HandRanking, int> ranks = new Dictionary<HandRanking,int>();

        static void Main()
        {
            Hand[] hands = new Hand[10];
            Deck d = new Deck();
            d.Shuffle();

            for (int i = 0; i < hands.Length; i++)
            {
                hands[i] = new Hand();
            }

            for (int cardCount = 0; cardCount < 5; cardCount++)
            {
                foreach (Hand t in hands)
                {
                    t.Add(d.Deal());
                }
            }

            foreach (Hand hand in hands)
            {
                Console.WriteLine("{0} ({1})", hand.Rank, hand);
            }
        }
    }
}
