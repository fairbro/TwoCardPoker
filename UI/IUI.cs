
namespace UserInterface
{
    public interface IUI
    {
        void ShowIntro();

        void ShowMessage(string message);

        ushort GetUserInput(string message, ushort min, ushort max);

        void WaitForNextCommand();
    }
}
