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

                var player = players[i];

                var card1 = player.Hand.Get(0);
                var card2 = player.Hand.Get(1);

                roundResults.Add(new PlayerRoundResult {
                    Name = player.Name,
                    Score = roundScore,
                    Hand = $"{card1.Value} {card1.Suit}\t{card2.Value} {card2.Suit}\t{player.Hand.Rank}",
                });

                player.Score += roundScore;
            }

            return roundResults;
        }
    }
}
