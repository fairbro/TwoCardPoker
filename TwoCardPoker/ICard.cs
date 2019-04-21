using static TwoCardPoker.CardTypes;

namespace TwoCardPoker
{
    public interface ICard
    {
        Suit Suit { get; }
        Value Value { get; }
    }
}
