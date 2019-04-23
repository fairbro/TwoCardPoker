using Moq;
using System.Collections.Generic;
using TwoCardPoker;
using TwoCardPoker.Interfaces;
using Xunit;

namespace TwoCardPokerTests
{
    public class GameTests
    {
        [Fact]
        public void InitialisePlayers_PlayersCreatedAndAddedToCollection()
        {
            var mockDealer = new Mock<IDealer>();

            var game = new Game(mockDealer.Object);

            var players = game.InitialisePlayers(2);

            Assert.Equal(2, players.Count);
            Assert.Equal("Player 1", players[0].Name);
            Assert.Equal("Player 2", players[1].Name);
        }

        [Fact]
        public void PlayRound_ShufflesDeck()
        {
            var mockDealer = new Mock<IDealer>();
            var mockPlayers = new Mock<List<IPlayer>>();

            var game = new Game(mockDealer.Object);

            ushort shuffleCount = 10;
            ushort handSize = 2;

            mockDealer.Setup(x => x.Shuffle(shuffleCount));
            mockDealer.Setup(x => x.Deal(mockPlayers.Object, handSize));

            game.PlayRound(mockPlayers.Object, shuffleCount, handSize);

            mockDealer.Verify(x => x.Shuffle(shuffleCount), Times.Once());
        }

        [Fact]
        public void PlayRound_DealsDeck()
        {
            var mockDealer = new Mock<IDealer>();
            var mockPlayers = new Mock<List<IPlayer>>();

            var game = new Game(mockDealer.Object);

            ushort shuffleCount = 10;
            ushort handSize = 2;

            mockDealer.Setup(x => x.Shuffle(shuffleCount));
            mockDealer.Setup(x => x.Deal(mockPlayers.Object, handSize));

            game.PlayRound(mockPlayers.Object, shuffleCount, handSize);

            mockDealer.Verify(x => x.Deal(mockPlayers.Object, handSize), Times.Once());
        }
    }
}
