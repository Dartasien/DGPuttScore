using DiscGolfPuttMineGame.Models;
using SQLite.Net;

namespace DiscGolfPuttMineGame.Services
{
    public interface ISqliteService
    {
        SQLiteConnection GetConnection();

        void InsertPlayer(Player player);

        Player GetPlayer(int id);

        Player GetDefaultPlayer();
    }
}