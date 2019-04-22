﻿using System;
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

        public Rank GetRank()
        {
            if (IsStraightFlush())
            {
                return Rank.StraightFlush;
            }
            else if (IsFlush())
            {
                return Rank.Flush;
            }
            else if (IsStraight())
            {
                return Rank.Straight;
            }
            else if (IsPair())
            {
                return Rank.Pair;
            }

            return Rank.HighCard;
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

        public int CompareTo(IHand hand)
        {
            var rank = (int)GetRank();
            var comparisonHankRank = (int)hand.GetRank();

            if (rank > comparisonHankRank)
            {
                return 1;
            }
            else if (rank == comparisonHankRank)
            {
                var highCard = GetHighCard();
                var comparisonHighCard = hand.GetHighCard();

                if (highCard.CompareTo(comparisonHighCard) > 0)
                {
                    return 1;
                }
            }

            return -1;
        }

        public ICard GetHighCard()
        {
            return Cards[0].CompareTo(Cards[1]) > 0 ? Cards[1] : Cards[0];
        }
    }
}
