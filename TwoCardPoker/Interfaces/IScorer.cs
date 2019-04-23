using Common.Interfaces;
using System.Collections.Generic;

namespace TwoCardPoker.Interfaces
{
    public interface IScorer
    {
        IList<IPlayerRoundResult> GetRoundResults(List<IPlayer> players);
    }
}
