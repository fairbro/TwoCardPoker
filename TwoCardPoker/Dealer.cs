using System.Collections.Generic;

namespace TwoCardPoker
{
    public class Dealer : IDealer
    {
       // private const ushort NUMBER_OF_CARDS = 2;

        private readonly IDeck _deck;

        public Dealer(IDeck deck)
        {
            _deck = deck;
        }

        public void Deal(IList<IPlayer> players, ushort numberOfCards)
        {
            ushort deckIndex = 0;

            foreach(var player in players)
            {
                for(var i = 0; i < numberOfCards; i++)
                {
                    player.Hand.Add(_deck.GetCard(deckIndex));
                    deckIndex++;
                }
            }
        }
    }
}
