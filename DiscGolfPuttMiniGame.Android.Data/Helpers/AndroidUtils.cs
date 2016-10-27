using SQLite.Net.Platform.XamarinAndroid;
using Environment = System.Environment;

namespace DiscGolfPuttMiniGame.Android.Data.Helpers
{
    public static class AndroidUtils
    {
        /// <summary>
        /// Returns the proper database file path to initialize the SQLite connection. 
        /// </summary>
        public static string DatabaseFilePath => Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public static SQLitePlatformAndroid GetPlatform()
        {
            return new SQLitePlatformAndroid();
        }
    }
}