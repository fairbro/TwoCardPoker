using System.Collections.Generic;
using TwoCardPoker.Interfaces;

namespace TwoCardPoker
{
    public class Game : IGame
    {
        private readonly IDealer _dealer;

        public Game(IDealer dealer)
        {
            _dealer = dealer;
        }

        public List<IPlayer> InitialisePlayers(ushort numberOfPlayers)
        {
            var players = new List<IPlayer>(numberOfPlayers);

            for (var i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player(new Hand(), $"Player {i + 1}"));
            }

            return players;
        }

        public void PlayRound(List<IPlayer> players, ushort numberOfShuffles, ushort handSize)
        {
            _dealer.Shuffle(numberOfShuffles);
            _dealer.Deal(players, handSize);
        }
    }
}
