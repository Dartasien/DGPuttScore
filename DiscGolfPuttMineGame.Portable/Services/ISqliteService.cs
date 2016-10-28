using SQLite.Net;

namespace DiscGolfPuttMineGame.Portable.Services
{
    public interface ISqliteService
    {
        SQLiteConnection GetConnection();
    }
}