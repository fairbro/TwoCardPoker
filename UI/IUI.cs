
namespace UserInterface
{
    public interface IUI
    {
        void ShowIntro();

        void ShowMessage(string message);

        ushort GetNumericInput(string message, ushort min, ushort max);

        void WaitForNextCommand();
    }
}
