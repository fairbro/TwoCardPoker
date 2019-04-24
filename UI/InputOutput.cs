using System;

namespace UserInterface
{
    public class InputOutput : IInputOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
