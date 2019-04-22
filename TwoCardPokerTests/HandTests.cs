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

            var lowCard = new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen);
            var highCard = new Card(CardTypes.Suit.Clubs, CardTypes.Value.Queen);

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
        public void CompareTo_BothStraightFlushs_HighestRankedSuitWins()
        {
            var winningHand = new Hand(2);

            winningHand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Three));
            winningHand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Two));


            var losingHand = new Hand(2);
            losingHand.Add(new Card(CardTypes.Suit.Clubs, CardTypes.Value.Ace));
            losingHand.Add(new Card(CardTypes.Suit.Clubs, CardTypes.Value.King));

            Assert.Equal(-1, winningHand.CompareTo(losingHand));
        }

        //[Theory]
        ////Highest card determined by suit
        //[InlineData(CardTypes.Suit.Spades, CardTypes.Value.Three, CardTypes.Suit.Spades, CardTypes.Value.Two,
        //    CardTypes.Suit.Clubs, CardTypes.Value.Three, CardTypes.Suit.Clubs, CardTypes.Value.Two,
        //    "Error in highest card determined by suit")]
        //public void HighCard_Both(
        //    CardTypes.Suit handACard1Suit,
        //    CardTypes.Value handACard1Value,
        //    CardTypes.Suit handACard2Suit,
        //    CardTypes.Value handACard2Value,
        //    CardTypes.Suit handBCard1Suit,
        //    CardTypes.Value handBCard1Value,
        //    CardTypes.Suit handBCard2Suit,
        //    CardTypes.Value handBCard2Value,
        //    string message)
        //{
        //    var handA = new List<ICard> {
        //        new Card(handACard1Suit, handACard1Value),
        //        new Card(handACard2Suit, handACard2Value)
        //    };

        //    var handB = new List<ICard> {
        //        new Card(handBCard1Suit, handBCard1Value),
        //        new Card(handBCard2Suit, handBCard2Value)
        //    };

        //    Hand
        //}
    }
}
