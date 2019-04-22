
using System;

namespace TwoCardPoker
{
    public class Player : IPlayer, IComparable<Player>
    {
        public string Name { get; set; }
        public IHand Hand { get; set; }
        public ushort Score { get; set; }

        public Player(string name, ushort size)
        {
            Name = name;
            Hand = new Hand(size);
        }

        public int CompareTo(IPlayer other)
        {
            return 1; // throw new NotImplementedException();
        }

        public int CompareTo(Player other)
        {
            throw new NotImplementedException();
        }
    }
}
