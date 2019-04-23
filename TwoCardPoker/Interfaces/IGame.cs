namespace TwoCardPoker.Interfaces
{
    public interface IGame
    {
        ushort GetNumberOfPlayers();
        ushort GetNumberOfRounds();
        void InitialisePlayers(ushort numberOfPlayers);
        void PlayRound();
        void ShowResults();
    }
}
