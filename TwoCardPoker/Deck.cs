using System;
using System.Collections.Generic;

namespace TwoCardPoker
{
    public class Deck
    {
        private const short NUMBER_OF_CARDS = 52;

        public List<ICard> Cards = new List<ICard>(NUMBER_OF_CARDS);

        public Deck()
        {
            foreach(CardTypes.Suit suit in Enum.GetValues(typeof(CardTypes.Suit)))
            {
                foreach(CardTypes.Value value in Enum.GetValues(typeof(CardTypes.Value)))
                {
                    Cards.Add(new Card(suit, value));
                }
            }
        }
    }
}
