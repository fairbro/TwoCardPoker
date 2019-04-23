using static Common.CardTypes;

namespace Common.Interfaces
{
    public interface ICard
    {
        Suit Suit { get; }
        Value Value { get; }
        int CompareTo(ICard card);
    }
}
