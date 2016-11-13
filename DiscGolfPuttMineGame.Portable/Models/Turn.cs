using System.ComponentModel;
using System.Runtime.CompilerServices;
using DiscGolfPuttMiniGame.Portable.Annotations;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
// ReSharper disable UnusedMember.Global

namespace DiscGolfPuttMiniGame.Portable.Models
{
    public class Turn : INotifyPropertyChanged
    {
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

        private bool _isTurnOver;

        public bool IsTurnOver
        {
            get
            {
                return _isTurnOver;
            }
            set
            {
                _isTurnOver = value;
                OnPropertyChanged(nameof(IsTurnOver));
            }
        }

        private int _roundId;
        [ForeignKey(typeof(Round))]
        public int RoundId
        {
            get
            {
                return _roundId;
            }
            set
            {
                _roundId = value;
                OnPropertyChanged(nameof(RoundId));
            }
        }

        private int _playerId;
        [ForeignKey(typeof(Player))]
        public int PlayerId
        {
            get
            {
                return _playerId;
            }
            set
            {
                _playerId = value;
                OnPropertyChanged(nameof(PlayerId));
            }
        }

        private int _successfulThrows;
        public int SuccessfulThrows
        {
            get
            {
                return _successfulThrows;
            }
            set
            {
                _successfulThrows = value;
                OnPropertyChanged(nameof(SuccessfulThrows));
            }
        }

        private int _currentRange;

        public int CurrentRange
        {
            get
            {
                return _currentRange;
            }
            set
            {
                _currentRange = value;
                OnPropertyChanged(nameof(CurrentRange));
            }
        }

        private int _nextRange;

        public int NextRange
        {
            get
            {
                return _nextRange;
            }
            set
            {
                _nextRange = value;
                OnPropertyChanged(nameof(NextRange));
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

        private Round _round;
        [ManyToOne]
        public Round Round
        {
            get
            {
                return _round;
            }
            set
            {
                _round = value;
                OnPropertyChanged(nameof(Round));
            }
        }

        private Player _player;
        [ManyToOne]
        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value; 
                OnPropertyChanged(nameof(Player));
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