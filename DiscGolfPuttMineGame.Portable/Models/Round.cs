using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace DiscGolfPuttMineGame.Portable.Models
{
    public class Round
    {
        public Round()
        {
            Turns = new List<Turn>();
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public List<Turn> Turns { get; set; }
        public int Score { get; set; }
        public bool IsCurrent { get; set; }
    }
}