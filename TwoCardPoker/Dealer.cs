using System.Collections.Generic;
using TwoCardPoker.Interfaces;

namespace TwoCardPoker
{
    public class Dealer : IDealer
    {
        private readonly IDeck _deck;

        public Dealer(IDeck deck)
        {
            _deck = deck;
        }

        public void Deal(IList<IPlayer> players, ushort numberOfCards)
        {
            ushort deckIndex = 0;

            foreach (var player in players)
            {
                player.Hand.Reset(numberOfCards);

                for (var i = 0; i < numberOfCards; i++)
                {
                    player.Hand.Add(_deck.GetCard(deckIndex));
                    deckIndex++;
                }
            }
        }

        public void Shuffle(uint numberOfShuffles)
        {
            _deck.Shuffle(numberOfShuffles);
        }
    }
}
