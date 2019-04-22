using System.Collections.Generic;
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

        private readonly IDealer _dealer;
        private readonly IList<IPlayer> _players;
        private readonly IUI _ui;

        public Game(IDealer dealer, IUI ui)
        {
            _dealer = dealer;
            _ui = ui;
        }

        public void Run()
        {
            _ui.ShowMessage("Welcome to 2 Card Poker Challenge!");

            ushort numberOfPlayers = GetUserInput("Please enter number of players (2-6):", MIN_NUMBER_OF_PLAYERS, MAX_NUMBER_OF_PLAYERS);

            ushort numberOfRounds = GetUserInput("Please enter number of rounds (2-5):", MIN_NUMBER_OF_ROUNDS, MAX_NUMBER_OF_ROUNDS);

            InitialisePlayers(numberOfPlayers);

            Play(numberOfRounds);
        }

        private void InitialisePlayers(ushort numberOfPlayers)
        {
            for (var i = 0; i < numberOfPlayers; i++)
            {
                _players.Add(new Player($"Player {i + 1}", HAND_SIZE));
            }
        }

        private void Play(ushort numberOfRounds)
        {
            for(var i = 0; i < numberOfRounds; i++)
            {
                PlayRound();
            }
        }

        private void PlayRound()
        {
            _dealer.Deal(_players, HAND_SIZE);
        }

        private ushort GetUserInput(string message, ushort min, ushort max)
        {
            while (true)
            {
                _ui.ShowMessage(message);

                ushort userInput;

                ushort.TryParse(_ui.GetInput(), out userInput);

                bool validUserInput = userInput >= min && userInput <= max;

                if (validUserInput)
                {
                    return userInput;
                }
            }
        }
    }
}
