using static TwoCardPoker.CardTypes;

namespace TwoCardPoker.Interfaces
{
    public interface ICard
    {
        Suit Suit { get; }
        Value Value { get; }
        int CompareTo(ICard card);
    }
}
