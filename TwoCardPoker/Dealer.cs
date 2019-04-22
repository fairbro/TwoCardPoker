using System.Collections.Generic;

namespace TwoCardPoker
{
    public class Dealer : IDealer
    {
        private readonly IDeck _deck;

        public Dealer(IDeck deck)
        {
            _deck = deck;
        }
    }
}
