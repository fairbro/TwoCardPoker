
using TwoCardPoker.Interfaces;

namespace TwoCardPoker
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public IHand Hand { get; set; }
        public int Score { get; set; }

        public Player(IHand hand, string name)
        {
            Name = name;
            Hand = hand;
        }
    }
}
