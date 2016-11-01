using System.Collections.ObjectModel;
using SQLite.Net.Attributes;

namespace DiscGolfPuttMiniGame.Portable.Models
{
    public class Game
    {
        public Game()
        {
            Rounds = new ObservableCollection<Round>();
            Players = new ObservableCollection<Player>();
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public ObservableCollection<Round> Rounds { get; set; }
        public ObservableCollection<Player> Players { get; set; }
        public int WinnerId { get; set; }
        public bool IsCurrent { get; set; }
    }
}