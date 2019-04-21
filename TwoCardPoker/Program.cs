﻿using Microsoft.Extensions.DependencyInjection;
using System;
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
            .AddTransient<IUI, UI>()
            .BuildServiceProvider();

            var game = serviceProvider.GetService<IGame>();

            game.Run();

            Console.ReadKey();
        }
    }
}
