using System;
using TwoCardPoker;
using TwoCardPoker.Exceptions;
using Xunit;

namespace TwoCardPokerTests
{
    public class HandTests
    {
        [Fact]
        public void Add()
        {
            var hand = new Hand();

            hand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Two));
            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));

            var card = hand.Get(1);

            Assert.Equal(CardTypes.Suit.Hearts, card.Suit);
            Assert.Equal(CardTypes.Value.Queen, card.Value);
        }

        [Fact]
        public void Add_ThrowsExceptionIfTryingToAddTooManyCards()
        {
            var hand = new Hand();

            hand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Two));
            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));

            Exception ex = Assert.Throws<HandOverflowException>(() =>
                hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.King)));

            Assert.Equal("Hand already full.", ex.Message);
        }

        [Fact]
        public void Rank_IsStraightFlush_ReturnsStraightFlush()
        {
            var hand = new Hand();

            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Jack));
            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));

            Assert.Equal(Rank.StraightFlush, hand.Rank);
        }

        [Fact]
        public void Rank_IsFlush_ReturnsFlush()
        {
            var hand = new Hand();

            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Two));
            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));

            Assert.Equal(Rank.Flush, hand.Rank);
        }

        [Fact]
        public void Rank_IsStraight_ReturnsStraight()
        {
            var hand = new Hand();

            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Jack));
            hand.Add(new Card(CardTypes.Suit.Clubs, CardTypes.Value.Queen));

            Assert.Equal(Rank.Straight, hand.Rank);
        }

        [Fact]
        public void Rank_IsPair_ReturnsPair()
        {
            var hand = new Hand();

            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));
            hand.Add(new Card(CardTypes.Suit.Clubs, CardTypes.Value.Queen));

            Assert.Equal(Rank.Pair, hand.Rank);
        }

        [Fact]
        public void Rank_IsHighCard_ReturnsHighCard()
        {
            var hand = new Hand();

            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));
            hand.Add(new Card(CardTypes.Suit.Clubs, CardTypes.Value.Ace));

            Assert.Equal(Rank.HighCard, hand.Rank);
        }

        [Fact]
        public void GetHighCard_FirstCardHighestValue_ReturnFirstCard()
        {
            var hand = new Hand();

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
            var hand = new Hand();

            var lowCard = new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen);
            var highCard = new Card(CardTypes.Suit.Clubs, CardTypes.Value.Queen);
            
            hand.Add(lowCard);
            hand.Add(highCard);

            Assert.Same(highCard, hand.GetHighCard());
        }

        [Fact]
        public void CompareTo_FirstHandHigherRank_Returns1()
        {
            var winningHand = new Hand();

            winningHand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Three));
            winningHand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Two));


            var losingHand = new Hand();
            losingHand.Add(new Card(CardTypes.Suit.Clubs, CardTypes.Value.Ace));
            losingHand.Add(new Card(CardTypes.Suit.Clubs, CardTypes.Value.King));

            Assert.Equal(1, winningHand.CompareTo(losingHand));
        }

        [Fact]
        public void Reset_RemovesCardsFromHand()
        {
            var hand = new Hand();

            hand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Three));
            hand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Two));

            hand.Reset(2);

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => hand.Get(0));
        }

        [Fact]
        public void Reset_RankCanUpateOnRedeal()
        {
            var hand = new Hand();

            hand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Three));
            hand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Two));

            Assert.Equal(Rank.StraightFlush, hand.Rank);

            hand.Reset(2);

            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Ace));
            hand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Two));

            Assert.Equal(Rank.HighCard, hand.Rank);
        }
    }
}
