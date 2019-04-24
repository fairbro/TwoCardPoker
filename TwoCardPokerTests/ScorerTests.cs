using Common;
using Moq;
using System.Collections.Generic;
using TwoCardPoker;
using TwoCardPoker.Interfaces;
using Xunit;

namespace TwoCardPokerTests
{
    public class ScorerTests
    {
        [Fact]
        public void GetRoundResults_ConvertsToRoundResult()
        {
            var mockHand = new Mock<IHand>();

            mockHand.Setup(x => x.Get(0)).Returns(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));
            mockHand.Setup(x => x.Get(1)).Returns(new Card(CardTypes.Suit.Spades, CardTypes.Value.King));
            mockHand.Setup(x => x.Rank).Returns(Rank.Straight);

            List<IPlayer> players = new List<IPlayer>
            {
                new Player(mockHand.Object, "Jason Statham")
            };

            var scorer = new Scorer();

            var playerRoundResult = scorer.GetRoundResults(players)[0];

            Assert.Equal("Jason Statham", playerRoundResult.Name);
            Assert.Equal(1, playerRoundResult.Score);
            Assert.Equal("Queen Hearts\tKing Spades\tStraight", playerRoundResult.Hand);
        }

        [Fact]
        public void GetRoundResults_AccumulatesTotalScore()
        {
            var mockHand = new Mock<IHand>();

            mockHand.Setup(x => x.Get(0)).Returns(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));
            mockHand.Setup(x => x.Get(1)).Returns(new Card(CardTypes.Suit.Spades, CardTypes.Value.King));
            mockHand.Setup(x => x.Rank).Returns(Rank.Straight);

            var player = new Player(mockHand.Object, "");
            player.Score = 7;

            List<IPlayer> players = new List<IPlayer> { player };

            var scorer = new Scorer();

            var playerRoundResults = scorer.GetRoundResults(players)[0];

            Assert.Equal(8, player.Score);
        }
    }
}
