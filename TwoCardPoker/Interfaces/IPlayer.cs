namespace TwoCardPoker.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        IHand Hand { get; set; }
        int Score { get; set; }
    }
}
