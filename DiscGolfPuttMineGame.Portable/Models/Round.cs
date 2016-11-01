using System.Collections.ObjectModel;
using SQLite.Net.Attributes;

namespace DiscGolfPuttMiniGame.Portable.Models
{
    public class Round
    {
        public Round()
        {
            Turns = new ObservableCollection<Turn>();
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public ObservableCollection<Turn> Turns { get; set; }
        public int Score { get; set; }
        public bool IsCurrent { get; set; }
    }
}