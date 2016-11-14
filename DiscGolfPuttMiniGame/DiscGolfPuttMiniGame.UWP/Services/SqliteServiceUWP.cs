using System.IO;
using Windows.Storage;
using DiscGolfPuttMiniGame.Portable.Services;
using DiscGolfPuttMiniGame.UWP.Services;
using Xamarin.Forms;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

[assembly: Dependency(typeof(SqliteServiceUwp))]
namespace DiscGolfPuttMiniGame.UWP.Services
{
    public class SqliteServiceUwp : ISqliteService
    {
        public SQLiteConnection GetConnection()
        {
            const string sqliteFilename = "ScoreTracker.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var platform = new SQLitePlatformWinRT();
            return new SQLiteConnection(platform, path);
        }
    }
}