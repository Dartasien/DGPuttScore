using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DiscGolfPuttMiniGame.Portable.Annotations;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
// ReSharper disable UnusedMember.Global

namespace DiscGolfPuttMiniGame.Portable.Models
{
    public class Round : INotifyPropertyChanged
    {
        public Round()
        {
            Turns = new ObservableCollection<Turn>();
        }

        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id {
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

        private int _roundCount;

        public int RoundCount
        {
            get
            {
                return _roundCount;
            }
            set
            {
                _roundCount = value;
                OnPropertyChanged(nameof(RoundCount));
            }
        }

        private bool _isRoundOver;
        public bool IsRoundOver
        {
            get
            {
                return _isRoundOver;
            }
            set
            {
                _isRoundOver = value;
                OnPropertyChanged(nameof(IsRoundOver));
            }
        }

        private int _score;
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        private bool _isCurrent;

        public bool IsCurrent
        {
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

        private int _gameId;

        [ForeignKey(typeof(Game))]
        public int GameId
        {
            get
            {
                return _gameId;
            }
            set
            {
                _gameId = value;
                OnPropertyChanged(nameof(GameId));
            }
        }

        private Game _game;
        [ManyToOne]
        public Game Game {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
                OnPropertyChanged(nameof(Game));
            }
        }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Turn> Turns { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}