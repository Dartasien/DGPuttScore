using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace DiscGolfPuttMiniGame.Portable.Models
{
    [Table("Players")]
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
        public List<Game> Games { get; set; }
        public bool IsDefault { get; set; }
    }
}