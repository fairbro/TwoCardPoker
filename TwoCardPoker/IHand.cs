
using static TwoCardPoker.Hand;

namespace TwoCardPoker
{
    public interface IHand
    {
        ICard Get(ushort index);
        void Add(ICard card);
        Rank GetRank();
        ICard GetHighCard();
    }
}
