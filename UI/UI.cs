using System;

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

        public ushort GetUserInput(string message, ushort min, ushort max)
        {
            while (true)
            {
                ShowMessage(message);

                ushort userInput;

                ushort.TryParse(Console.ReadLine(), out userInput);

                bool validUserInput = userInput >= min && userInput <= max;

                if (validUserInput)
                {
                    return userInput;
                }
            }
        }

        public void WaitForNextCommand()
        {
            Console.ReadLine();
        }
    }
}
