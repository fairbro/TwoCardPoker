using Common.Interfaces;
using System.Collections.Generic;

namespace Common
{
    public class PlayerRoundResult : IPlayerRoundResult
    {
        public string Name { get; set; }
        public IList<ICard> Hand { get; set; }
        public Rank Rank { get; set; }
        public int Score { get; set; }
    }
}
