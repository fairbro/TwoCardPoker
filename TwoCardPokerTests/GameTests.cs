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
        public void ShowInto_CallsUIWithIntroMessage()
        {
            var mockDealer = new Mock<IDealer>();
            var mockUi = new Mock<IUI>();

            mockUi.Setup(x => x.ShowMessage("Welcome to 2 Card Poker Challenge!"));

            var game = new Game(mockDealer.Object, mockUi.Object);

            game.ShowIntro();

            mockUi.Verify(x => x.ShowMessage("Welcome to 2 Card Poker Challenge!"), Times.Once());
        }
    }
}
