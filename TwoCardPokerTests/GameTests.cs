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
        public void ShowInto_CallsUIShowIntro()
        {
            var mockDealer = new Mock<IDealer>();
            var mockUI = new Mock<IUI>();

            mockUI.Setup(x => x.ShowIntro());

            var game = new Game(mockDealer.Object, mockUI.Object);

            game.ShowIntro();

            mockUI.Verify(x => x.ShowIntro(), Times.Once());
        }

        [Fact]
        public void GetNumberOfPlayers_ReturnsValueFromUI()
        {
            var mockDealer = new Mock<IDealer>();
            var mockUI = new Mock<IUI>();

            mockUI.Setup(x => x.GetNumericInput("Please enter number of players (2-6):", It.IsAny<ushort>(), It.IsAny<ushort>())).Returns(3);

            var game = new Game(mockDealer.Object, mockUI.Object);

            var numberOfPlayers = game.GetNumberOfPlayers();

            Assert.Equal(3, numberOfPlayers);

            mockUI.Setup(x => x.GetNumericInput("Please enter number of players (2-6):", It.IsAny<ushort>(), It.IsAny<ushort>()));
        }

        [Fact]
        public void GetNumberOfRounds_ReturnsValueFromUI()
        {
            var mockDealer = new Mock<IDealer>();
            var mockUI = new Mock<IUI>();

            mockUI.Setup(x => x.GetNumericInput("Please enter number of rounds (2-5):", It.IsAny<ushort>(), It.IsAny<ushort>())).Returns(3);

            var game = new Game(mockDealer.Object, mockUI.Object);

            var numberOfRounds = game.GetNumberOfRounds();

            Assert.Equal(3, numberOfRounds);

            mockUI.Setup(x => x.GetNumericInput("Please enter number of rounds (2-5):", It.IsAny<ushort>(), It.IsAny<ushort>()));
        }
    }
}
