using Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
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
            .AddSingleton<IScorer, Scorer>()
            .AddSingleton<IDeck, Deck>()
            .AddSingleton<IDealer, Dealer>()
            .AddTransient<IHand, Hand>()
            .AddSingleton<IUI, UI>()
            .AddSingleton<IInputOutput, InputOutput>()
            .BuildServiceProvider();

            var game = serviceProvider.GetService<IGame>();
            var scorer = serviceProvider.GetService<IScorer>();
            var ui = serviceProvider.GetService<IUI>();

            ui.ShowIntro();

            var numberOfPlayers = ui.GetNumericInput("Please enter number of players (2-6):",
                MIN_NUMBER_OF_PLAYERS, MAX_NUMBER_OF_PLAYERS);

            var numberOfRounds = ui.GetNumericInput("Please enter number of rounds (2-5):",
                MIN_NUMBER_OF_ROUNDS, MAX_NUMBER_OF_ROUNDS);

            var players = game.InitialisePlayers(numberOfPlayers);

            for (var i = 0; i < numberOfRounds; i++)
            {
                game.PlayRound(players, NUMBER_OF_SHUFFLES, HAND_SIZE);
                var roundScores = scorer.GetRoundResults(players);

                int roundNumber = i + 1;

                ui.ShowRoundResults(roundScores, roundNumber);
            }

            ui.ShowFinalResults(players.Select(x => new PlayerFinalScore
            {
                Name = x.Name,
                Score = x.Score
            }));

            Console.ReadKey();

            serviceProvider.Dispose();
        }
    }
}
