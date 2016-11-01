using SQLite.Net;

namespace DiscGolfPuttMiniGame.Portable.Services
{
    public interface ISqliteService
    {
        SQLiteConnection GetConnection();
    }
}