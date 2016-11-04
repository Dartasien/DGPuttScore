using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
// ReSharper disable UnusedMember.Global

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
        public bool IsDefault { get; set; }
        [ForeignKey(typeof(Game))]
        public int GameId { get; set; }
        [ForeignKey(typeof(Round))]
        public int RoundId { get; set; }
        [ForeignKey(typeof(Turn))]
        public int TurnId { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        // ReSharper disable once MemberCanBePrivate.Global
        public List<Game> Games { get; set; }
    }
}