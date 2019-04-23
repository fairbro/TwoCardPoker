using Common;
using TwoCardPoker;
using Xunit;

namespace TwoCardPokerTests
{
    public class DeckTests
    {
        [Fact]
        public void GetCard_ReturnsFirstCard()
        {
            var deck = new Deck();

            var firstCard = deck.GetCard(0);

            Assert.Equal(CardTypes.Suit.Diamonds, firstCard.Suit);
            Assert.Equal(CardTypes.Value.Two, firstCard.Value);
        }

        [Fact]
        public void GetCard_ReturnsLastCard()
        {
            var deck = new Deck();

            var lastCard = deck.GetCard(51);

            Assert.Equal(CardTypes.Suit.Spades, lastCard.Suit);
            Assert.Equal(CardTypes.Value.Ace, lastCard.Value);
        }
    }
}
