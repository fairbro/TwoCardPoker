using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UserInterface
{
    public class UI : IUI
    {
        public void ShowIntro()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("* Welcome to 2 Card Poker Challenge! *");
            Console.WriteLine("**************************************");
            Console.WriteLine();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public ushort GetNumericInput(string message, ushort min, ushort max)
        {
            while (true)
            {
                Console.Write(message);

                ushort userInput;

                ushort.TryParse(Console.ReadLine(), out userInput);

                bool validUserInput = userInput >= min && userInput <= max;

                if (validUserInput)
                {
                    return userInput;
                }
            }
        }

        public void ShowRoundResults(IEnumerable<IPlayerRoundResult> roundResults, int roundNumber)
        {
            Console.WriteLine($"Round {roundNumber}:\n");

            foreach(var roundResult in roundResults)
            {
                Console.WriteLine($"{roundResult.Name}\t" +
                    $"Round Score: {roundResult.Score}\t" +
                    $"{roundResult.Hand[0].Value} {roundResult.Hand[0].Suit}\t" +
                    $"{roundResult.Hand[1].Value} {roundResult.Hand[1].Suit}\t" +
                    $"{roundResult.Rank}");
            }

            Console.WriteLine("");
            Console.WriteLine("'ENTER' to continue");
            Console.ReadLine();
        }

        public void ShowFinalResults(IEnumerable<IPlayerFinalScore> playerResults)
        {
            var results = playerResults.ToList();
                
            results.Sort((a, b) => b.Score.CompareTo(a.Score));

            Console.WriteLine("Final Results:\n");

            foreach(var result in results)
            {
                Console.WriteLine($"{result.Name}\t Score: {result.Score}");
            }
        }
    }
}
