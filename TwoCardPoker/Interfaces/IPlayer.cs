namespace TwoCardPoker
{
    public interface IPlayer
    {
        string Name { get; set; }
        IHand Hand { get; set; }
        ushort Score { get; set; }
        int CompareTo(Player other);
        //int CompareTo(object obj);
    }
}
