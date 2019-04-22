using System.Collections.Generic;
using TwoCardPoker.Interfaces;
using UserInterface;

namespace TwoCardPoker
{
    public class Game : IGame
    {
        private const ushort MIN_NUMBER_OF_PLAYERS = 2;
        private const ushort MAX_NUMBER_OF_PLAYERS = 6;
        private const ushort MIN_NUMBER_OF_ROUNDS = 2;
        private const ushort MAX_NUMBER_OF_ROUNDS = 5;
        private const ushort HAND_SIZE = 2;
        private const ushort NUMBER_OF_SHUFFLES_PER_DEAL = 10;

        private readonly IDealer _dealer;
        private List<IPlayer> _players;
        private readonly IUI _ui;

        public Game(IDealer dealer, IUI ui)
        {
            _dealer = dealer;
            _ui = ui;
        }

        public void ShowIntro()
        {
            _ui.ShowIntro();
        }

        public ushort GetNumberOfPlayers()
        {
            return _ui.GetNumericInput("Please enter number of players (2-6):",
                MIN_NUMBER_OF_PLAYERS, MAX_NUMBER_OF_PLAYERS);
        }

        public ushort GetNumberOfRounds()
        {
            return _ui.GetNumericInput("Please enter number of rounds (2-5):",
                MIN_NUMBER_OF_ROUNDS, MAX_NUMBER_OF_ROUNDS);
        }

        public void InitialisePlayers(ushort numberOfPlayers)
        {
            _players = new List<IPlayer>(numberOfPlayers);

            for (var i = 0; i < numberOfPlayers; i++)
            {
                _players.Add(new Player($"Player {i + 1}", HAND_SIZE));
            }
        }

        public void PlayRounds(ushort numberOfRounds)
        {
            for(var i = 0; i < numberOfRounds; i++)
            {
                _ui.ShowMessage($"Round {i + 1}");
                PlayRound();
                _ui.ShowMessage("");
                _ui.ShowMessage("'ENTER' to continue");
                _ui.WaitForNextCommand();
            }
        }

        private void PlayRound()
        {
            _dealer.Shuffle(NUMBER_OF_SHUFFLES_PER_DEAL);
            _dealer.Deal(_players, HAND_SIZE);
            
            _players.Sort((a,b) => (b.Hand.CompareTo(a.Hand)));

            for(var i = 0; i < _players.Count; i++)
            {
                var player = _players[i];

                int roundScore = 4 - i;

                player.Score += roundScore;

                _ui.ShowMessage($"{player.Name} {player.Hand.Get(0).Suit} {player.Hand.Get(0).Value} " +
                    $"{player.Hand.Get(1).Suit} {player.Hand.Get(1).Value} " +
                    $"{ player.Hand.GetRank() } " +
                    $"Score: {roundScore}");
            }
        }

        public void ShowResults()
        {
            _players.Sort((a, b) => (b.Score.CompareTo(a.Score)));

            _ui.ShowMessage("WINNER!");

            foreach(var player in _players)
            {
                _ui.ShowMessage($"{player.Name} Score: {player.Score}");
            }
        }
    }
}
