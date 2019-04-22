using System.Collections.Generic;

namespace TwoCardPoker
{
    public interface IDealer
    {
        void Deal(IList<IPlayer> players, ushort numberOfCards);
    }
}
