
namespace TwoCardPoker
{
    public interface IHand
    {
        ICard Get(ushort index);
        void Add(ICard card);
    }
}
