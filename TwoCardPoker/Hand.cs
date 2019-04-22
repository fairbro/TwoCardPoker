using System;
using System.Collections.Generic;

namespace TwoCardPoker
{
    public class Hand : IHand, IComparable<IHand>
    {
        private readonly IList<ICard> Cards;

        public Hand(ushort numberOfCards)
        {
            Cards = new List<ICard>(numberOfCards);
        }

        public enum Rank
        {
            HighCard,
            Pair,
            Straight,
            Flush,
            StraightFlush
        }

        public ICard Get(ushort index)
        {
            return Cards[index];
        }

        public void Add(ICard card)
        {
            //TODO: throw exception if hand all ready full
            Cards.Add(card);
        }

        public bool IsStraightFlush()
        {
            return Cards[0].Suit == Cards[1].Suit && (Math.Abs(Cards[0].Value - Cards[1].Value)) <= 1;
        }

        public bool IsFlush()
        {
            return Cards[0].Suit == Cards[1].Suit && (Math.Abs(Cards[0].Value - Cards[1].Value)) >= 1;
        }

        public bool IsStraight()
        {
            return Cards[0].Suit != Cards[1].Suit && (Math.Abs(Cards[0].Value - Cards[1].Value)) <= 1;
        }

        public bool IsPair()
        {
            return Cards[0].Value == Cards[1].Value;
        }

        public int CompareTo(IHand other)
        {
            throw new NotImplementedException();
        }
    }
}
