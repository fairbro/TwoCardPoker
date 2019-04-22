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
            .AddTransient<IUI, UI>()
            .BuildServiceProvider();

            var game = serviceProvider.GetService<IGame>();

            game.ShowIntro();

            var numberOfPlayers = game.GetNumberOfPlayers();

            var numberOfRounds = game.GetNumberOfRounds();

            game.InitialisePlayers(numberOfPlayers);

            game.PlayRounds(numberOfRounds);

            Console.ReadKey();
        }
    }
}
