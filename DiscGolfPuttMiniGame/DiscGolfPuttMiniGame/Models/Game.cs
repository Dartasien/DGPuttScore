using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace DiscGolfPuttMineGame.Models
{
    public class Game
    {
        public Game()
        {
            Rounds = new List<Round>();
            Players = new List<Player>();
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Round> Rounds { get; set; }
        public List<Player> Players { get; set; }
        public int WinnerId { get; set; }
        public bool IsCurrent { get; set; }
    }
}