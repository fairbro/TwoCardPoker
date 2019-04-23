using Common;
using Common.Interfaces;
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

            var playerRoundResults = scorer.GetRoundResults(players)[0];

            Assert.Equal("Jason Statham", playerRoundResults.Name);
            Assert.Equal(1, playerRoundResults.Score);
            Assert.Equal(Rank.Straight, playerRoundResults.Rank);
            Assert.Equal(CardTypes.Suit.Hearts, playerRoundResults.Hand[0].Suit);
            Assert.Equal(CardTypes.Value.Queen, playerRoundResults.Hand[0].Value);
            Assert.Equal(CardTypes.Suit.Spades, playerRoundResults.Hand[1].Suit);
            Assert.Equal(CardTypes.Value.King, playerRoundResults.Hand[1].Value);
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
