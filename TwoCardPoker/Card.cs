using System;
using TwoCardPoker.Interfaces;
using static TwoCardPoker.CardTypes;

namespace TwoCardPoker
{
    public class Card : ICard, IComparable<ICard>
    {
        public Suit Suit { get; private set; }
        public Value Value { get; private set; }

        public Card(Suit suit, Value value)
        {
            Suit = suit;
            Value = value;
        }

        public int CompareTo(ICard card)
        {
            if (Suit > card.Suit || (Suit == card.Suit && Value > card.Value))
            {
                return 1;
            }

            return -1;
        }
    }
}
