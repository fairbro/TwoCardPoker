using System;

namespace UserInterface
{
    public class UI : IUI
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
