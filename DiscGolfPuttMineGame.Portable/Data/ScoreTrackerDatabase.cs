using System.Linq;
using DiscGolfPuttMiniGame.Portable.Models;
using DiscGolfPuttMiniGame.Portable.Services;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace DiscGolfPuttMiniGame.Portable.Data
{
    public class ScoreTrackerDatabase
    {
        private static readonly object Locker = new object();
        private readonly SQLiteConnection _database;

        public ScoreTrackerDatabase()
        {
            _database = DependencyService.Get<ISqliteService>().GetConnection();
            _database.CreateTable<Player>();
            _database.CreateTable<Game>();
            _database.CreateTable<Round>();
            _database.CreateTable<Turn>();
            _database.CreateTable<GamePlayer>();
        }

        public Player GetDefaultPlayer()
        {
            lock (Locker)
            {
                var players = _database.GetAllWithChildren<Player>();
                var defaultPlayer = players.FirstOrDefault(p => p.IsDefault);
                _database.GetChildren(defaultPlayer, true);
                return defaultPlayer;
            }
        }

        public void Insert<T>(T item) where T : class 
        {
            lock (Locker)
            {
                _database.InsertWithChildren(item, true);
            }
        }

        public void Save<T>(T item) where T : class
        {
            lock (Locker)
            {
                _database.UpdateWithChildren(item);
            }
        }

        public T GetItem<T>(int id) where T : class
        {
            lock (Locker)
            {
                var item = _database.GetWithChildren<T>(id);
                _database.GetChildren(item, true);
                return item;
            }
        }
    }
}