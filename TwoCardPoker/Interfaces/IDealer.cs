using System.Collections.Generic;

namespace TwoCardPoker.Interfaces
{
    public interface IDealer
    {
        void Deal(IList<IPlayer> players, ushort numberOfCards);
        void Shuffle(uint numberOfShuffles);
    }
}
