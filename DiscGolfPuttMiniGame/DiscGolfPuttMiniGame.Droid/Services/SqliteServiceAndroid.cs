using System.IO;
using DiscGolfPuttMineGame.Portable.Services;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

namespace DiscGolfPuttMiniGame.Droid.Services
{
    public class SqliteServiceAndroid : ISqliteService
    {

        SQLiteConnection ISqliteService.GetConnection()
        {
            const string sqliteFilename = "ScoreTracker.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            var platform = new SQLitePlatformAndroid();
            return new SQLiteConnection(platform, path);
        }
    }
}