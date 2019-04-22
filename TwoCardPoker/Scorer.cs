using System.Collections.Generic;
using System.Linq;
using TwoCardPoker.Interfaces;

namespace TwoCardPoker
{
    public class Scorer : IScorer
    {
        public void Score(IList<IPlayer> players)
        {
            players.OrderByDescending(p => p.Hand);
        }
    }
}
