using System.IO;
using System.Linq;
using DiscGolfPuttMineGame.Models;
using DiscGolfPuttMineGame.Services;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace DiscGolfPuttMiniGame.Droid.Services
{
    public class SqliteService : ISqliteService
    {
        private readonly SQLiteConnection _connection;

        public SqliteService()
        {
            _connection = DependencyService.Get<ISqliteService>().GetConnection();
            _connection.CreateTable<Player>();
            _connection.CreateTable<Game>();
            _connection.CreateTable<Round>();
            _connection.CreateTable<Turn>();
        }

        SQLiteConnection ISqliteService.GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            var platform = new SQLitePlatformAndroid();
            return new SQLiteConnection(platform, path);

        }

        public void InsertPlayer(Player player)
        {
            _connection.InsertWithChildren(player);
        }

        public Player GetPlayer(int id)
        {
            return _connection.GetWithChildren<Player>(id);
        }

        public Player GetDefaultPlayer()
        {
            var players = _connection.GetAllWithChildren<Player>();

            return players.FirstOrDefault(p => p.IsDefault);
        }

        public void InsertGame(Game game)
        {
            _connection.InsertWithChildren(game);
        }

        public void InsertRound(Round round)
        {
            _connection.InsertWithChildren(round);
        }

        public void InsertTurn(Turn turn)
        {
            _connection.InsertWithChildren(turn);
        }
    }
}