using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace DiscGolfPuttMiniGame.Portable.Models
{
    public class Turn
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public bool IsTurnOver { get; set; }

        [ForeignKey(typeof(Round))]
        public int RoundId { get; set; }

        [ForeignKey(typeof(Player))]
        public int PlayerId { get; set; }

        public int SuccessfulThrows { get; set; }

        public int CurrentRange { get; set; }

        public int NextRange { get; set; }

        public int Score { get; set; }

        public bool IsCurrent { get; set; }

        [ManyToOne]
        public Round Round { get; set; }

        [ManyToOne]
        public Player Player { get; set; }
    }
}