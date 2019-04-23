using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IPlayerRoundResult
    {
        string Name { get; set; }
        IList<ICard> Hand { get; set; }
        Rank Rank { get; set; }
        int Score { get; set; }
    }
}
