using Microsoft.Extensions.DependencyInjection;
using System;
using TwoCardPoker.Interfaces;
using UserInterface;

namespace TwoCardPoker
{
    class Program
    {
        private const ushort MIN_NUMBER_OF_PLAYERS = 2;
        private const ushort MAX_NUMBER_OF_PLAYERS = 6;
        private const ushort MIN_NUMBER_OF_ROUNDS = 2;
        private const ushort MAX_NUMBER_OF_ROUNDS = 5;
        private const ushort NUMBER_OF_SHUFFLES = 10;
        private const ushort HAND_SIZE = 2;

        static void Main(string[] args)
        {
            //Dependency Injection
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IGame, Game>()
            .AddTransient<IDeck, Deck>()
            .AddTransient<IDealer, Dealer>()
            .AddTransient<IHand, Hand>()
            .AddTransient<IUI, UI>()
            .BuildServiceProvider();

            var game = serviceProvider.GetService<IGame>();
            var ui = serviceProvider.GetService<IUI>();

            ui.ShowIntro();

            var numberOfPlayers = ui.GetNumericInput("Please enter number of players (2-6):",
                MIN_NUMBER_OF_PLAYERS, MAX_NUMBER_OF_PLAYERS);

            var numberOfRounds = ui.GetNumericInput("Please enter number of rounds (2-5):",
                MIN_NUMBER_OF_ROUNDS, MAX_NUMBER_OF_ROUNDS);

            game.InitialisePlayers(numberOfPlayers);

            for (var i = 0; i < numberOfRounds; i++)
            {
                ui.ShowMessage($"Round {i + 1}");
                game.PlayRound(NUMBER_OF_SHUFFLES, HAND_SIZE);
                ui.ShowMessage("");
                ui.ShowMessage("'ENTER' to continue");
                ui.WaitForNextCommand();
            }

            game.ShowResults();

            Console.ReadKey();

            serviceProvider.Dispose();
        }
    }
}
