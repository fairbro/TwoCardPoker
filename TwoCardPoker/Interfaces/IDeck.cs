namespace TwoCardPoker
{
    public interface IDeck
    {
        ICard GetCard(ushort index);
        void Shuffle(uint numberOfShuffles);
    }
}
