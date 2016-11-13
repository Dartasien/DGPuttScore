using SQLiteNetExtensions.Attributes;

namespace DiscGolfPuttMiniGame.Portable.Models
{
    public class GamePlayer
    {
        [ForeignKey(typeof(Game))]
        public int GameId { get; set; }
        [ForeignKey(typeof(Player))]
        public int PlayerId { get; set; }
    }
}
