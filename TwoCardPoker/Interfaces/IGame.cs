using System.Collections.Generic;

namespace TwoCardPoker.Interfaces
{
    public interface IGame
    {
        List<IPlayer> InitialisePlayers(ushort numberOfPlayers);
        void PlayRound(List<IPlayer> players, ushort numberOfShuffles, ushort handSize);
    }
}
