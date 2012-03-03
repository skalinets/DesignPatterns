using System;

namespace Poker
{
    class Card
    {
        public Card(Suit suit, Value val)
        {
            Suit = suit;
            Value = val;
        }

        public Suit Suit
        {
            get; private set;
        }

        public Value Value
        {
            get; private set;
        }

        public override string ToString()
        {
            return ValueToString() + SuitToString();
        }

        private string SuitToString()
        {
            switch (Suit)
            {
                case Suit.Club:
                    return "C";
                case Suit.Heart:
                    return "H";
                case Suit.Diamond:
                    return "D";
                case Suit.Spade:
                    return "S";
                default:
                    throw new NotImplementedException();
            }
        }

        private string ValueToString()
        {
            switch (Value)
            {
                case Value.Two:
                    return "2";
                case Value.Three:
                    return "3";
                case Value.Four:
                    return "4";
                case Value.Five:
                    return "5";
                case Value.Six:
                    return "6";
                case Value.Seven:
                    return "7";
                case Value.Eight:
                    return "8";
                case Value.Nine:
                    return "9";
                case Value.Ten:
                    return "10";
                case Value.Jack:
                    return "J";
                case Value.Queen:
                    return "Q";
                case Value.King:
                    return "K";
                case Value.Ace:
                    return "A";
                default:
                    throw new NotImplementedException();

            }
        }
    }

    public enum Suit
    {
        Diamond,
        Club,
        Heart,
        Spade,
    }

    public enum Value
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
    }
}
