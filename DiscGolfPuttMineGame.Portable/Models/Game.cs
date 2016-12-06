using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace DiscGolfPuttMiniGame.Portable.Models
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
        public bool IsCurrent { get; set; }

        [ForeignKey(typeof(Player))]
        public int WinningPlayerId { get; set; }

        public int WinningScore { get; set; }

        public int TotalRounds { get; set; }

        [ManyToOne]
        public Player WinningPlayer { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Round> Rounds { get; set; }
        [ManyToMany(typeof(GamePlayer), CascadeOperations = CascadeOperation.All)]
        public List<Player> Players { get; set; }

    }
}