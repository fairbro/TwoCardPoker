using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UserInterface
{
    public class UI : IUI
    {
        private readonly IInputOutput _inputOutput;

        public UI(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
        }

        public void ShowIntro()
        {
            _inputOutput.WriteLine("**************************************");
            _inputOutput.WriteLine("* Welcome to 2 Card Poker Challenge! *");
            _inputOutput.WriteLine("**************************************");
            _inputOutput.WriteLine();
        }

        public ushort GetNumericInput(string message, ushort min, ushort max)
        {
            while (true)
            {
                _inputOutput.Write(message);

                ushort userInput;

                ushort.TryParse(_inputOutput.ReadLine(), out userInput);

                bool validUserInput = userInput >= min && userInput <= max;

                if (validUserInput)
                {
                    return userInput;
                }
            }
        }

        public void ShowRoundResults(IEnumerable<IPlayerRoundResult> roundResults, int roundNumber)
        {
            _inputOutput.WriteLine($"Round {roundNumber}:\n");

            foreach(var roundResult in roundResults)
            {
                _inputOutput.WriteLine($"{roundResult.Name}\t" +
                    $"Round Score: {roundResult.Score}\t" +
                    $"{roundResult.Hand}");
            }

            _inputOutput.WriteLine();
            _inputOutput.WriteLine("'ENTER' to continue");
            _inputOutput.ReadLine();
        }

        public void ShowFinalResults(IEnumerable<IPlayerFinalScore> playerResults)
        {
            var results = playerResults.ToList();

            results.Sort((a, b) => b.Score.CompareTo(a.Score));

            _inputOutput.WriteLine("Final Results:\n");

            foreach (var result in results)
            {
                _inputOutput.WriteLine($"{result.Name}\tScore: {result.Score}");
            }
        }
    }
}
