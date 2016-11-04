using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
// ReSharper disable UnusedMember.Global

namespace DiscGolfPuttMiniGame.Portable.Models
{
    public class Turn
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Round))]
        public int RoundId { get; set; }
        [ForeignKey(typeof(Player))]
        public int PlayerId { get; set; }
        public int Score { get; set; }
        public bool IsCurrent { get; set; }

        [ManyToOne]
        public Round Round { get; set; }
        [ManyToOne]
        public Player Player { get; set; }
    }
}