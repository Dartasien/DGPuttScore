using SQLite.Net.Attributes;

namespace DiscGolfPuttMineGame.Portable.Models
{
    public class Turn
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int RoundId { get; set; }
        public Round Round { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int Score { get; set; }
        public bool IsCurrent { get; set; }
    }
}