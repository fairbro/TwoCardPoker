using TwoCardPoker;
using Xunit;

namespace TwoCardPokerTests
{
    public class HandTests
    {
        [Fact]
        public void Add()
        {
            var hand = new Hand(2);

            hand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Two));
            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));

            var card = hand.Get(1);

            Assert.Equal(CardTypes.Suit.Hearts, card.Suit);
            Assert.Equal(CardTypes.Value.Queen, card.Value);
        }

        [Fact]
        public void IsStraightFlush()
        {
            var hand = new Hand(2);

            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Jack));
            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));

            Assert.True(hand.IsStraightFlush());
        }

        [Fact]
        public void IsFlush()
        {
            var hand = new Hand(2);

            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Two));
            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));

            Assert.True(hand.IsFlush());
        }

        [Fact]
        public void IsStraight()
        {
            var hand = new Hand(2);

            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Jack));
            hand.Add(new Card(CardTypes.Suit.Clubs, CardTypes.Value.Queen));

            Assert.True(hand.IsStraight());
        }

        [Fact]
        public void IsPair()
        {
            var hand = new Hand(2);

            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));
            hand.Add(new Card(CardTypes.Suit.Clubs, CardTypes.Value.Queen));

            Assert.True(hand.IsPair());
        }

        [Fact]
        public void GetHighCard_FirstCardHighestValue_ReturnFirstCard()
        {
            var hand = new Hand(2);

            var highCard = new Card(CardTypes.Suit.Clubs, CardTypes.Value.Queen);
            var lowCard = new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen);

            hand.Add(highCard);
            hand.Add(lowCard);

            var returnedCard = hand.GetHighCard();

            Assert.Same(highCard, returnedCard);
        }

        [Fact]
        public void GetHighCard_LastCardHighestValue_ReturnLastCard()
        {
            var hand = new Hand(2);

            var lowCard = new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen);
            var highCard = new Card(CardTypes.Suit.Clubs, CardTypes.Value.Queen);
            
            hand.Add(lowCard);
            hand.Add(highCard);

            Assert.Same(highCard, hand.GetHighCard());
        }

        [Fact]
        public void CompareTo_FirstHandHigherRank_Returns1()
        {
            var winningHand = new Hand(2);

            winningHand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Three));
            winningHand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Two));


            var losingHand = new Hand(2);
            losingHand.Add(new Card(CardTypes.Suit.Clubs, CardTypes.Value.Ace));
            losingHand.Add(new Card(CardTypes.Suit.Clubs, CardTypes.Value.King));

            Assert.Equal(1, winningHand.CompareTo(losingHand));
        }
    }
}
