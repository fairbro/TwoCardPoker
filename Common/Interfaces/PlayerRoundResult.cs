using Common.Interfaces;

namespace Common
{
    public class PlayerRoundResult : IPlayerRoundResult
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string Hand { get; set; }
    }
}
