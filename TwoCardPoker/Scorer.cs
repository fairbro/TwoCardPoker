using Common;
using Common.Interfaces;
using System.Collections.Generic;
using TwoCardPoker.Interfaces;

namespace TwoCardPoker
{
    public class Scorer : IScorer
    {
        public IList<IPlayerRoundResult> GetRoundResults(List<IPlayer> players)
        {
            players.Sort((a, b) => (b.Hand.CompareTo(a.Hand)));

            var roundResults = new List<IPlayerRoundResult>();

            for(var i=0; i< players.Count; i++)
            {
                var roundScore = players.Count - i;

                roundResults.Add(new PlayerRoundResult {
                    Name = players[i].Name,
                    Hand = new List<ICard> { players[i].Hand.Get(0), players[i].Hand.Get(1) },
                    Rank = players[i].Hand.Rank,
                    Score = roundScore
                });

                players[i].Score += roundScore;
            }

            return roundResults;
        }
    }
}
