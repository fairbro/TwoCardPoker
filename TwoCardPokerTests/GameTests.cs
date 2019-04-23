using Moq;
using TwoCardPoker;
using TwoCardPoker.Interfaces;
using UserInterface;
using Xunit;

namespace TwoCardPokerTests
{
    public class GameTests
    {
        [Fact]
        public void InitialisePlayers_PlayersCreatedAndAddedToCollection()
        {
            var mockDealer = new Mock<IDealer>();
            var mockUI = new Mock<IUI>();

            var game = new Game(mockDealer.Object, mockUI.Object);

            game.InitialisePlayers(2);

            var players = game.Players;

            Assert.Equal(2, players.Count);
            Assert.Equal("Player 1", players[0].Name);
            Assert.Equal("Player 2", players[1].Name);
        }
    }
}
