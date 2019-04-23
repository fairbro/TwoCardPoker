namespace TwoCardPoker.Interfaces
{
    public interface IGame
    {
        void InitialisePlayers(ushort numberOfPlayers);
        void PlayRound();
        void ShowResults();
    }
}
