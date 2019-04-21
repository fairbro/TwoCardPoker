using static TwoCardPoker.CardTypes;

namespace TwoCardPoker
{
    public class Card : ICard
    {
        public Suit Suit { get; private set; }
        public Value Value { get; private set; }

        public Card(Suit suit, Value value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
