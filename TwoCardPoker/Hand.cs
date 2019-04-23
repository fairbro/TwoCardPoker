using Common;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using TwoCardPoker.Exceptions;
using TwoCardPoker.Interfaces;

namespace TwoCardPoker
{
    public class Hand : IHand, IComparable<IHand>
    {
        private IList<ICard> _cards;
        private const ushort HAND_SIZE = 2;

        public Hand()
        {
            _cards = new List<ICard>(HAND_SIZE);
        }

        public ICard Get(ushort index)
        {
            return _cards[index];
        }

        public void Reset(ushort numberOfCards)
        {
            _cards = new List<ICard>(numberOfCards);
            _rank = null;
        }

        private Rank? _rank;

        public Rank Rank
        {
            get {
                if (_rank == null)
                {
                    _rank = GetRank();
                }

                return _rank.Value;
            }
            set
            {
                _rank = value;
            }
        }

        private Rank GetRank()
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
            if (_cards.Count == HAND_SIZE)
            {
                throw new HandOverflowException("Hand already full.");
            }
            
            _cards.Add(card);
        }

        private bool CardsSameSuit(ICard card1, ICard card2)
        {
            return card1.Suit == card2.Suit;
        }

        private bool CardsInSequence(ICard card1, ICard card2)
        {
            return Math.Abs(card1.Value - card2.Value) == 1;
        }

        private bool IsStraightFlush()
        {
            return CardsSameSuit(_cards[0], _cards[1]) && CardsInSequence(_cards[0], _cards[1]);
        }

        private bool IsFlush()
        {
            return CardsSameSuit(_cards[0], _cards[1]) && !CardsInSequence(_cards[0], _cards[1]);
        }

        private bool IsStraight()
        {
            return !CardsSameSuit(_cards[0], _cards[1]) && CardsInSequence(_cards[0], _cards[1]);
        }

        private bool IsPair()
        {
            return _cards[0].Value == _cards[1].Value;
        }

        public int CompareTo(IHand hand)
        {
            var rank = (int)Rank;
            var comparisonHankRank = (int)hand.Rank;

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
