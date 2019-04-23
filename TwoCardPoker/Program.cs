using Microsoft.Extensions.DependencyInjection;
using System;
using TwoCardPoker.Interfaces;
using UserInterface;

namespace TwoCardPoker
{
    class Program
    {
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

            var numberOfPlayers = game.GetNumberOfPlayers();

            var numberOfRounds = game.GetNumberOfRounds();

            game.InitialisePlayers(numberOfPlayers);

            for (var i = 0; i < numberOfRounds; i++)
            {
                ui.ShowMessage($"Round {i + 1}");
                game.PlayRound();
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
