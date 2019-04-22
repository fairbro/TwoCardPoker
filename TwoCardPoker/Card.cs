using System;
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
            if (card.Suit > Suit || (card.Suit == Suit && card.Value > Value))
            {
                return 1;
            }

            return -1;
        }
    }
}
