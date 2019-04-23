namespace TwoCardPoker.Interfaces
{
    public interface IGame
    {
        void InitialisePlayers(ushort numberOfPlayers);
        void PlayRound(ushort numberOfShuffles, ushort handSize);
        void ShowResults();
    }
}
