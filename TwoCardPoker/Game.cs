using System.Collections.Generic;
using TwoCardPoker.Interfaces;
using UserInterface;

namespace TwoCardPoker
{
    public class Game : IGame
    {
        private const ushort HAND_SIZE = 2;
        private const ushort NUMBER_OF_SHUFFLES_PER_DEAL = 10;

        private readonly IDealer _dealer;
        private readonly IUI _ui;

        public List<IPlayer> Players;

        public Game(IDealer dealer, IUI ui)
        {
            _dealer = dealer;
            _ui = ui;
        }

        public void InitialisePlayers(ushort numberOfPlayers)
        {
            Players = new List<IPlayer>(numberOfPlayers);

            for (var i = 0; i < numberOfPlayers; i++)
            {
                Players.Add(new Player(new Hand(), $"Player {i + 1}"));
            }
        }

        public void PlayRound()
        {
            _dealer.Shuffle(NUMBER_OF_SHUFFLES_PER_DEAL);
            _dealer.Deal(Players, HAND_SIZE);
            
            Players.Sort((a,b) => (b.Hand.CompareTo(a.Hand)));

            for(var i = 0; i < Players.Count; i++)
            {
                var player = Players[i];

                int roundScore = Players.Count - i;

                player.Score += roundScore;

                _ui.ShowMessage($"{player.Name} {player.Hand.Get(0).Suit} {player.Hand.Get(0).Value} " +
                    $"{player.Hand.Get(1).Suit} {player.Hand.Get(1).Value} " +
                    $"{ player.Hand.Rank } " +
                    $"Score: {roundScore}");
            }
        }

        public void ShowResults()
        {
            Players.Sort((a, b) => (b.Score.CompareTo(a.Score)));

            _ui.ShowMessage("WINNER!");

            foreach(var player in Players)
            {
                _ui.ShowMessage($"{player.Name} Score: {player.Score}");
            }
        }
    }
}
