using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace DiscGolfPuttMineGame.Models
{
    public class Round
    {
        public Round()
        {
            Turns = new List<Turn>();
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Turn> Turns { get; set; }
        public int Score { get; set; }
        public bool IsCurrent { get; set; }
    }
}