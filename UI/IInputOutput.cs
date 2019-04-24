namespace UserInterface
{
    public interface IInputOutput
    {
        void WriteLine(string message);
        void WriteLine();
        void Write(string message);
        string ReadLine();
    }
}
