using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    class Hand
    {
        private readonly List<Card> _cards = new List<Card>();
        private HandRanking _rank = HandRanking.Unknown;

        public void Add(Card c)
        {
            if(_cards.Count == 5)
            {
                throw new InvalidOperationException("Cannot add more than 5 cards to a hand.");
            }

            _cards.Add(c);

            if(_cards.Count == 5)
            {
                _rank = HandCatagorizerChain.GetRank(this);
            }
        }

        public Card HighCard
        {
            get
            {
                if(_cards.Count == 0)
                {
                    throw new InvalidOperationException();
                }

                return _cards[_cards.Count - 1];
            }
        }

        public IEnumerable<Card> Cards
        {
            get { return _cards; }
        }

        public HandRanking Rank
        {
            get { return _rank; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Card c in _cards)
            {
                sb.AppendFormat("{0} ", c);
            }

            return sb.ToString();
        }

#if FALSE
        private void DetermineRank()
        {
            _rank = HandRanking.Unknown;

            List<HandRanking> availableRanks = new List<HandRanking>
                                                   {
                                                       HandRanking.HighCard,
                                                       HandRanking.Pair,
                                                       HandRanking.TwoPair,
                                                       HandRanking.ThreeOfAKind,
                                                       HandRanking.Straight,
                                                       HandRanking.Flush,
                                                       HandRanking.FullHouse,
                                                       HandRanking.FourOfAKind,
                                                       HandRanking.StraightFlush,
                                                       HandRanking.RoyalFlush
                                                   };

            availableRanks.Reverse();

            if(!HasFlush())
            {
                availableRanks.Remove(HandRanking.Flush);
                availableRanks.Remove(HandRanking.StraightFlush);
                availableRanks.Remove(HandRanking.RoyalFlush);
            }

            if (!HasStraight())
            {
                availableRanks.Remove(HandRanking.Straight);
            }

            if (!HasTriplet())
            {
                availableRanks.Remove(HandRanking.ThreeOfAKind);
                availableRanks.Remove(HandRanking.FullHouse);
            }

            if(!HasPair())
            {
                availableRanks.Remove(HandRanking.Pair);
                availableRanks.Remove(HandRanking.TwoPair);
            }

            foreach(HandRanking potentialRank in availableRanks)
            {
                if(Satisfies(potentialRank))
                {
                    _rank = potentialRank;
                    break;
                }
            }

            Debug.Assert(_rank != HandRanking.Unknown, "Rank should never be unknown at end of DetermineRank");
        }

        private bool Satisfies(HandRanking potentialRank)
        {
            switch (potentialRank)
            {
                case HandRanking.HighCard:
                    return true;
                case HandRanking.Pair:
                    return HasNofKind(2);
                case HandRanking.TwoPair:
                    return HasTwoPair();
                case HandRanking.ThreeOfAKind:
                    return HasNofKind(3);
                case HandRanking.Straight:
                    return HasStraight();
                case HandRanking.Flush:
                    return HasFlush();
                case HandRanking.FullHouse:
                    return HasFullHouse();
                case HandRanking.FourOfAKind:
                    return HasNofKind(4);
                case HandRanking.StraightFlush:
                    return HasFlush() && HasStraight();
                case HandRanking.RoyalFlush:
                    return HasFlush() && HasStraight() && _cards[_cards.Count - 1].Value == Value.Ace;
                default:
                    throw new NotImplementedException();
            }
        }
#endif

    }

    public enum HandRanking
    {
        Unknown, 
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush,
    }
}
