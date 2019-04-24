using static Common.CardTypes;

namespace TwoCArdPoker.Interfaces
{
    public interface ICard
    {
        Suit Suit { get; }
        Value Value { get; }
        int CompareTo(ICard card);
    }
}
