using Moq;
using System.Collections.Generic;
using TwoCardPoker;
using TwoCardPoker.Interfaces;
using Xunit;

namespace TwoCardPokerTests
{
    public class DealerTests
    {
        [Fact]
        public void Deal_EachPlayerGetsDealtCardsOffTopOfDeck()
        {
            var player1 = new Player("Player 1", 2);
            var player2 = new Player("Player 2", 2);
            var player3 = new Player("Player 3", 2);

            var players = new List<IPlayer>
            {
                player1, player2, player3
            };

            var mockDeck = new Mock<IDeck>();

            var queue = new Queue<Card>();

            var card1 = new Card(CardTypes.Suit.Clubs, CardTypes.Value.Ace);
            var card2 = new Card(CardTypes.Suit.Hearts, CardTypes.Value.Two);
            var card3 =new Card(CardTypes.Suit.Diamonds, CardTypes.Value.Queen);
            var card4 = new Card(CardTypes.Suit.Spades, CardTypes.Value.King);
            var card5 = new Card(CardTypes.Suit.Hearts, CardTypes.Value.Three);
            var card6 = new Card(CardTypes.Suit.Spades, CardTypes.Value.Nine);

            mockDeck.Setup(x => x.GetCard(0)).Returns(card1);
            mockDeck.Setup(x => x.GetCard(1)).Returns(card2);
            mockDeck.Setup(x => x.GetCard(2)).Returns(card3);
            mockDeck.Setup(x => x.GetCard(3)).Returns(card4);
            mockDeck.Setup(x => x.GetCard(4)).Returns(card5);
            mockDeck.Setup(x => x.GetCard(5)).Returns(card6);

            var dealer = new Dealer(mockDeck.Object);

            dealer.Deal(players, 2);

            Assert.Equal(CardTypes.Suit.Clubs, player1.Hand.Get(0).Suit);
            Assert.Equal(CardTypes.Value.Ace, player1.Hand.Get(0).Value);
            Assert.Equal(CardTypes.Suit.Hearts, player1.Hand.Get(1).Suit);
            Assert.Equal(CardTypes.Value.Two, player1.Hand.Get(1).Value);

            Assert.Equal(CardTypes.Suit.Diamonds, player2.Hand.Get(0).Suit);
            Assert.Equal(CardTypes.Value.Queen, player2.Hand.Get(0).Value);
            Assert.Equal(CardTypes.Suit.Spades, player2.Hand.Get(1).Suit);
            Assert.Equal(CardTypes.Value.King, player2.Hand.Get(1).Value);

            Assert.Equal(CardTypes.Suit.Hearts, player3.Hand.Get(0).Suit);
            Assert.Equal(CardTypes.Value.Three, player3.Hand.Get(0).Value);
            Assert.Equal(CardTypes.Suit.Spades, player3.Hand.Get(1).Suit);
            Assert.Equal(CardTypes.Value.Nine, player3.Hand.Get(1).Value);
        }

        [Fact]
        public void Shuffle_CallsShuffleOnDeck()
        {
            var mockDeck = new Mock<IDeck>();

            var dealer = new Dealer(mockDeck.Object);

            mockDeck.Setup(x => x.Shuffle(5));

            dealer.Shuffle(5);

            mockDeck.Verify(x => x.Shuffle(5), Times.Once());
        }
    }
}
