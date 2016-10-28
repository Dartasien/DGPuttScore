using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscGolfPuttMineGame.Portable.Models;
using DiscGolfPuttMineGame.Portable.Services;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace DiscGolfPuttMiniGame.Portable.Data
{
    public class ScoreTrackerDatabase
    {
        static object locker = new object();
        SQLiteConnection database;

        public ScoreTrackerDatabase()
        {
            database = DependencyService.Get<ISqliteService>().GetConnection();
            database.CreateTable<Player>();
            database.CreateTable<Game>();
            database.CreateTable<Round>();
            database.CreateTable<Turn>();
        }


        public void InsertPlayer(Player player)
        {
            database.InsertWithChildren(player);
        }

        public Player GetPlayer(int id)
        {
            return database.GetWithChildren<Player>(id);
        }

        public Player GetDefaultPlayer()
        {
            var players = database.GetAllWithChildren<Player>();

            return players.FirstOrDefault(p => p.IsDefault);
        }

        public void InsertGame(Game game)
        {
            database.InsertWithChildren(game);
        }

        public void InsertRound(Round round)
        {
            database.InsertWithChildren(round);
        }

        public void InsertTurn(Turn turn)
        {
            database.InsertWithChildren(turn);
        }
    }
}
