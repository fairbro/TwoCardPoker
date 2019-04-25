using Common;
using Common.Interfaces;
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

        [Fact]
        public void GetNumericInput_DisplaysMessage()
        {
            var mockConsoleWrapper = new Mock<IInputOutput>();

            var ui = new UI(mockConsoleWrapper.Object);

            mockConsoleWrapper.Setup(x => x.Write("A test message"));
            mockConsoleWrapper.Setup(x => x.ReadLine()).Returns("5");

            ui.GetNumericInput("A test message", 4, 6);

            mockConsoleWrapper.Verify(x => x.Write("A test message"));
        }

        [Fact]
        public void GetNumericInput_RejectsValueOutsideRangeAndResendsMessage()
        {
            var mockConsoleWrapper = new Mock<IInputOutput>();

            var ui = new UI(mockConsoleWrapper.Object);

            mockConsoleWrapper.Setup(x => x.Write("A test message"));

            var queue = new Queue<string>();

            queue.Enqueue("7");
            queue.Enqueue("5");

            mockConsoleWrapper.Setup(x => x.ReadLine()).Returns(() => queue.Dequeue());

            var result = ui.GetNumericInput("A test message", 4, 6);

            Assert.Equal(5, result);

            mockConsoleWrapper.Verify(x => x.Write("A test message"), Times.Exactly(2));
        }

        [Fact]
        public void GetNumericInput_AcceptsValueEqualToMin()
        {
            var mockConsoleWrapper = new Mock<IInputOutput>();

            var ui = new UI(mockConsoleWrapper.Object);

            mockConsoleWrapper.Setup(x => x.Write("A test message"));

            mockConsoleWrapper.Setup(x => x.ReadLine()).Returns("4");

            var result = ui.GetNumericInput("A test message", 4, 6);

            Assert.Equal(4, result);

            mockConsoleWrapper.Verify(x => x.Write("A test message"), Times.Once());
        }

        [Fact]
        public void GetNumericInput_AcceptsValueEqualToMax()
        {
            var mockConsoleWrapper = new Mock<IInputOutput>();

            var ui = new UI(mockConsoleWrapper.Object);

            mockConsoleWrapper.Setup(x => x.Write("A test message"));

            mockConsoleWrapper.Setup(x => x.ReadLine()).Returns("6");

            var result = ui.GetNumericInput("A test message", 4, 6);

            Assert.Equal(6, result);

            mockConsoleWrapper.Verify(x => x.Write("A test message"), Times.Once());
        }

        [Fact]
        public void ShowRoundResults_ShowsEachPlayersResultsForTheRound()
        {
            var mockConsoleWrapper = new Mock<IInputOutput>(MockBehavior.Strict);

            var s = new MockSequence();

            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine($"Round 5:\n"));
            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine("Player 1\tRound Score: 3\tQueen Hearts King Hearts Straight Flush"));
            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine("Player 2\tRound Score: 2\tQueen Spades Ace Spades Flush"));
            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine("Player 3\tRound Score: 1\tTen Clubs Joker Hearts Straight"));
            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine());
            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine("'ENTER' to continue"));
            mockConsoleWrapper.InSequence(s).Setup(x => x.ReadLine()).Returns("\n");

            var ui = new UI(mockConsoleWrapper.Object);

            var playerRoundResults = new List<IPlayerRoundResult>
            {
                new PlayerRoundResult
                {
                    Name = "Player 1",
                    Score = 3,
                    Hand = "Queen Hearts King Hearts Straight Flush"
                },
                new PlayerRoundResult
                {
                    Name = "Player 2",
                    Score = 2,
                    Hand = "Queen Spades Ace Spades Flush"
                },
                new PlayerRoundResult
                {
                    Name = "Player 3",
                    Score = 1,
                    Hand = "Ten Clubs Joker Hearts Straight"
                }
            };

            ui.ShowRoundResults(playerRoundResults, 5);

            mockConsoleWrapper.Verify(x => x.WriteLine($"Round 5:\n"));
            mockConsoleWrapper.Verify(x => x.WriteLine("Player 1\tRound Score: 3\tQueen Hearts King Hearts Straight Flush"));
            mockConsoleWrapper.Verify(x => x.WriteLine("Player 2\tRound Score: 2\tQueen Spades Ace Spades Flush"));
            mockConsoleWrapper.Verify(x => x.WriteLine("Player 3\tRound Score: 1\tTen Clubs Joker Hearts Straight"));
            mockConsoleWrapper.Verify(x => x.WriteLine());
            mockConsoleWrapper.Verify(x => x.WriteLine("'ENTER' to continue"));
            mockConsoleWrapper.Verify(x => x.ReadLine());
        }

        [Fact]
        public void ShowFinalResults_DisplaysSortedResults()
        {
            var finalScores = new List<PlayerFinalScore>
            {
                new PlayerFinalScore { Name = "Player 1", Score = 9},
                new PlayerFinalScore { Name = "Player 2", Score = 21},
                new PlayerFinalScore { Name = "Player 3", Score = 11}
            };

            var mockConsoleWrapper = new Mock<IInputOutput>(MockBehavior.Strict);

            var s = new MockSequence();

            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine("Final Results:\n"));
            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine("Player 2\tScore: 21"));
            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine("Player 3\tScore: 11"));
            mockConsoleWrapper.InSequence(s).Setup(x => x.WriteLine("Player 1\tScore: 9"));

            var ui = new UI(mockConsoleWrapper.Object);

            ui.ShowFinalResults(finalScores);

            mockConsoleWrapper.Verify(x => x.WriteLine("Final Results:\n"));
            mockConsoleWrapper.Verify(x => x.WriteLine("Player 2\tScore: 21"));
            mockConsoleWrapper.Verify(x => x.WriteLine("Player 3\tScore: 11"));
            mockConsoleWrapper.Verify(x => x.WriteLine("Player 1\tScore: 9"));
        }
    }
}
