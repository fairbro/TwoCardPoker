﻿using System;
using System.Collections.Generic;
using TwoCardPoker.Exceptions;
using TwoCardPoker.Interfaces;

namespace TwoCardPoker
{
    public class Hand : IHand, IComparable<IHand>
    {
        private IList<ICard> _cards;
        private ushort _maxNumberOfCards;

        public Hand(ushort numberOfCards)
        {
            _maxNumberOfCards = numberOfCards;
            _cards = new List<ICard>(numberOfCards);
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
            return _cards[index];
        }

        public void Reset(ushort numberOfCards)
        {
            _cards = new List<ICard>(numberOfCards);
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
            if (_cards.Count == _maxNumberOfCards)
            {
                throw new HandOverflowException("Hand already full.");
            }
            
            _cards.Add(card);
        }

        public bool IsStraightFlush()
        {
            return _cards[0].Suit == _cards[1].Suit && (Math.Abs(_cards[0].Value - _cards[1].Value)) <= 1;
        }

        public bool IsFlush()
        {
            return _cards[0].Suit == _cards[1].Suit && (Math.Abs(_cards[0].Value - _cards[1].Value)) >= 1;
        }

        public bool IsStraight()
        {
            return _cards[0].Suit != _cards[1].Suit && (Math.Abs(_cards[0].Value - _cards[1].Value)) <= 1;
        }

        public bool IsPair()
        {
            return _cards[0].Value == _cards[1].Value;
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
            return _cards[0].CompareTo(_cards[1]) > 0 ? _cards[0] : _cards[1];
        }
    }
}
