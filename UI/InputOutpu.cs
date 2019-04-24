using System;

namespace UserInterface
{
    public class InputOutpu : IInputOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
