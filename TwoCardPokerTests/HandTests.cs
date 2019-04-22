using TwoCardPoker;
using Xunit;

namespace TwoCardPokerTests
{
    public class HandTests
    {
        [Fact]
        public void Hand_Add()
        {
            var hand = new Hand(2);

            hand.Add(new Card(CardTypes.Suit.Spades, CardTypes.Value.Two));
            hand.Add(new Card(CardTypes.Suit.Hearts, CardTypes.Value.Queen));

            var card = hand.Get(1);

            Assert.Equal(CardTypes.Suit.Hearts, card.Suit);
            Assert.Equal(CardTypes.Value.Queen, card.Value);
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