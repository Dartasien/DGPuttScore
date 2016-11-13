using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DiscGolfPuttMiniGame.Portable.Annotations;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
// ReSharper disable UnusedMember.Global

namespace DiscGolfPuttMiniGame.Portable.Models
{
    [Table("Players")]
    public class Player : INotifyPropertyChanged
    {
        public Player()
        {
            Games = new ObservableCollection<Game>();
        }

        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int _accountId;
        public int AccountId
        {
            get
            {
                return _accountId;
            }
            set
            {
                _accountId = value; 
                OnPropertyChanged(nameof(AccountId));
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value; 
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _nickName;
        public string NickName
        {
            get
            {
                return _nickName;
            }
            set
            {
                _nickName = value;
                OnPropertyChanged(nameof(NickName));
            }
        }

        private bool _isDefault;
        public bool IsDefault
        {
            get
            {
                return _isDefault;
            }
            set
            {
                _isDefault = value; 
                OnPropertyChanged(nameof(IsDefault));
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

        private int _turnId;
        [ForeignKey(typeof(Turn))]
        public int TurnId
        {
            get
            {
                return _turnId;
            }
            set
            {
                _turnId = value;
                OnPropertyChanged(nameof(TurnId));
            }
        }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Turn> Turns { get; set; }

        [ManyToMany(typeof(GamePlayer),CascadeOperations = CascadeOperation.All)]
        // ReSharper disable once MemberCanBePrivate.Global
        public ObservableCollection<Game> Games { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}