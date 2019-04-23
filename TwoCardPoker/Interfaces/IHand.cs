using Common;
using Common.Interfaces;

namespace TwoCardPoker.Interfaces
{
    public interface IHand
    {
        ICard Get(ushort index);
        void Add(ICard card);
        Rank Rank { get; }
        ICard GetHighCard();
        void Reset(ushort numberOfCards);
        int CompareTo(IHand hand);
    }
}
