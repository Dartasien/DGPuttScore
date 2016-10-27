using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace DiscGolfPuttMineGame.Models
{
    public class Player
    {
        public Player()
        {
            Games = new List<Game>();
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Game> Games { get; set; }

        public bool IsDefault { get; set; }
    }
}