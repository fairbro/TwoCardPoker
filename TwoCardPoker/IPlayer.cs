using System.Collections.Generic;

namespace TwoCardPoker
{
    public interface IPlayer
    {
        string Name { get; set; }
        IList<ICard> Hand { get; set; }
        short Score { get; set; }
    }
}
