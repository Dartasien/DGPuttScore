using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace DiscGolfPuttMiniGame.Portable.Models
{
    public class Round
    {
        public Round()
        {
            Turns = new List<Turn>();
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int RoundCount { get; set; }

        public bool IsRoundOver { get; set; }

        public int HighestScore { get; set; }

        [ForeignKey(typeof(Player))]
        public int CurrentLeaderId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Player CurrentLeader { get; set; }

        public bool IsCurrent { get; set; }
        [ForeignKey(typeof(Game))]
        public int GameId { get; set; }

        [ManyToOne]
        public Game Game { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Turn> Turns { get; set; }
    }
}