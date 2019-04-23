using Common.Interfaces;

namespace TwoCardPoker.Interfaces
{
    public interface IDeck
    {
        ICard GetCard(ushort index);
        void Shuffle(uint numberOfShuffles);
    }
}
