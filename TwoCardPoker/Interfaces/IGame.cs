namespace TwoCardPoker.Interfaces
{
    public interface IGame
    {
        void ShowIntro();
        ushort GetNumberOfPlayers();
        ushort GetNumberOfRounds();
        void InitialisePlayers(ushort numberOfPlayers);
        void PlayRounds(ushort numberOfRounds);
    }
}
