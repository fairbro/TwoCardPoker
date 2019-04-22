using System.Collections.Generic;

namespace TwoCardPoker
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public IList<ICard> Hand { get; set; }
        public short Score { get; set; }

        public Player(string name, ushort size)
        {
            Name = name;
            Hand = new List<ICard>(size);
        }
    }
}
