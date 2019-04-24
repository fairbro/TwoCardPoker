using Moq;
using System.Collections.Generic;
using UserInterface;
using Xunit;

namespace UserInterfaceTests
{
    public class UITests
    {
        [Fact]
        public void ShowIntro_DisplaysWelcomeMessage()
        {
            var mockConsoleWrapper = new Mock<IInputOutput>(MockBehavior.Strict);

            var s = new MockSequence();

            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine("**************************************"));
            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine("* Welcome to 2 Card Poker Challenge! *"));
            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine("**************************************"));
            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine());

            var ui = new UI(mockConsoleWrapper.Object);

            ui.ShowIntro();

            mockConsoleWrapper.Verify(x => x.WriteLine("**************************************"));
            mockConsoleWrapper.Verify(x => x.WriteLine("* Welcome to 2 Card Poker Challenge! *"));
            mockConsoleWrapper.Verify(x => x.WriteLine("**************************************"));
            mockConsoleWrapper.Verify(x => x.WriteLine());
        }
    }
}
