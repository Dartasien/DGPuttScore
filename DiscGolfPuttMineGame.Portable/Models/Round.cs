using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
// ReSharper disable UnusedMember.Global

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
        public int Score { get; set; }
        public bool IsCurrent { get; set; }

        [ForeignKey(typeof(Game))]
        public int GameId { get; set; }
        [ManyToOne]
        public Game Game { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Turn> Turns { get; set; }
    }
}