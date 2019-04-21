using System;

namespace TwoCardPoker
{
    class Program
    {
        private const ushort MIN_NUMBER_OF_PLAYERS = 2;
        private const ushort MAX_NUMBER_OF_PLAYERS = 6;
        private const ushort MIN_NUMBER_OF_ROUNDS = 2;
        private const ushort MAX_NUMBER_OF_ROUNDS = 5;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to 2 Card Poker Challenge!");

            ushort numberOfPlayers = GetUserInput("Please enter number of players (2-6):", MIN_NUMBER_OF_PLAYERS, MAX_NUMBER_OF_PLAYERS);

            ushort numberOfRounds = GetUserInput("Please enter number of rounds (2-5):", MIN_NUMBER_OF_ROUNDS, MAX_NUMBER_OF_ROUNDS);

            Console.WriteLine($"NumberOfPlayers: {numberOfPlayers}, NumberOfRounds: {numberOfRounds}");
            Console.ReadKey();
        }

        private static ushort GetUserInput(string message, ushort min, ushort max)
        {
            while (true)
            {
                Console.WriteLine(message);

                ushort userInput;

                ushort.TryParse(Console.ReadLine(), out userInput);

                bool validUserInput = userInput >= min && userInput <= max;

                if (validUserInput)
                {
                    return userInput;
                }
            }
        }
    }
}
