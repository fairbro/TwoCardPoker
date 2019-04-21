using UserInterface;

namespace TwoCardPoker
{
    public class Game : IGame
    {
        private const ushort MIN_NUMBER_OF_PLAYERS = 2;
        private const ushort MAX_NUMBER_OF_PLAYERS = 6;
        private const ushort MIN_NUMBER_OF_ROUNDS = 2;
        private const ushort MAX_NUMBER_OF_ROUNDS = 5;

        private readonly IDeck _deck;
        private readonly IUI _ui;

        public Game(IDeck deck, IUI ui)
        {
            _deck = deck;
            _ui = ui;
        }

        public void Run()
        {
            _ui.ShowMessage("Welcome to 2 Card Poker Challenge!");

            ushort numberOfPlayers = GetUserInput("Please enter number of players (2-6):", MIN_NUMBER_OF_PLAYERS, MAX_NUMBER_OF_PLAYERS);

            ushort numberOfRounds = GetUserInput("Please enter number of rounds (2-5):", MIN_NUMBER_OF_ROUNDS, MAX_NUMBER_OF_ROUNDS);

            //Console.WriteLine($"NumberOfPlayers: {numberOfPlayers}, NumberOfRounds: {numberOfRounds}");
            Play();
        }

        public void Play()
        {

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
