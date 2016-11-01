using System.IO;
using DiscGolfPuttMiniGame.Droid.Services;
using DiscGolfPuttMiniGame.Portable.Services;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteServiceAndroid))]
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