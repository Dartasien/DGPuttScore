using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DiscGolfPuttMiniGame.Portable.Annotations;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace DiscGolfPuttMiniGame.Portable.Models
{
    public class Game : INotifyPropertyChanged
    {
        public Game()
        {
            Rounds = new ObservableCollection<Round>();
            Players = new ObservableCollection<Player>();
        }

        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private bool _isCurrent;
        public bool IsCurrent {
            get
            {
                return _isCurrent;
            }
            set
            {
                _isCurrent = value;
                OnPropertyChanged(nameof(IsCurrent));
            }
        }

        private int _winningPlayerId;
        [ForeignKey(typeof(Player))]
        public int WinningPlayerId {
            get
            {
                return _winningPlayerId;
            }
            set
            {
                _winningPlayerId = value;
                OnPropertyChanged(nameof(WinningPlayerId));
            }
        }

        private int _winningScore;
        public int WinningScore
        {
            get
            {
                return _winningScore;
            }
            set
            {
                _winningScore = value;
                OnPropertyChanged(nameof(WinningScore));
            }
        }

        private int _totalRounds;
        public int TotalRounds
        {
            get
            {
                return _totalRounds;
            }
            set
            {
                _totalRounds = value;
                OnPropertyChanged(nameof(TotalRounds));
            }
        }


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Round> Rounds { get; set; }
        [ManyToMany(typeof(GamePlayer), CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Player> Players { get; set; }

        private Player _winningPlayer;
        [ManyToOne]
        public Player WinningPlayer {
            get
            {
                return _winningPlayer;
            }
            set
            {
                _winningPlayer = value;
                OnPropertyChanged(nameof(WinningPlayer));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}