using TwoCardPoker;
using Xunit;

namespace TwoCardPokerTests
{
    public class CardTests
    {
        [Fact]
        public void CompareTo_InputCardIsHigherValue_ReturnsNeg1()
        {
            var losingCard = new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen);
            var winningCard = new Card(CardTypes.Suit.Hearts, CardTypes.Value.King);

            var result = losingCard.CompareTo(winningCard);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void CompareTo_InputCardIsLowerValue_Returns1()
        {
            var losingCard = new Card(CardTypes.Suit.Hearts, CardTypes.Value.King);
            var winningCard = new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen);

            var result = losingCard.CompareTo(winningCard);

            Assert.Equal(1, result);
        }

        [Fact]
        public void CompareTo_InputCardIsLowerValueButHigherSuit_ReturnsNeg1()
        {
            var losingCard = new Card(CardTypes.Suit.Hearts, CardTypes.Value.King);
            var winningCard = new Card(CardTypes.Suit.Clubs, CardTypes.Value.Queen);

            var result = losingCard.CompareTo(winningCard);

            Assert.Equal(-1, result);
        }
    }
}
