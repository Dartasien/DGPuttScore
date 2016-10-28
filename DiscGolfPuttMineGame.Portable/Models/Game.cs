using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace DiscGolfPuttMineGame.Portable.Models
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
        public List<Round> Rounds { get; set; }
        public List<Player> Players { get; set; }
        public int WinnerId { get; set; }
        public bool IsCurrent { get; set; }
    }
}