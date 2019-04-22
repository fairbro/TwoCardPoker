namespace TwoCardPoker
{
    public interface IPlayer
    {
        string Name { get; set; }
        IHand Hand { get; set; }
        short Score { get; set; }
    }
}
