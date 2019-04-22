using System.Collections.Generic;

namespace TwoCardPoker
{
    public class Hand : IHand
    {
        private readonly IList<ICard> Cards;

        public Hand(ushort numberOfCards)
        {
            Cards = new List<ICard>(numberOfCards);
        }

        public void Add(ICard card)
        {
            //TODO: throw exception if hand all ready full
            Cards.Add(card);
        }

        public ICard Get(ushort index)
        {
            return Cards[index];
        }
    }
}
