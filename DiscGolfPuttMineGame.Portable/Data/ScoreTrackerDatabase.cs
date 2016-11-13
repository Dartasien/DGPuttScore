using System.Collections;
using System.Collections.Generic;
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
        static object locker = new object();
        SQLiteConnection database;

        public ScoreTrackerDatabase()
        {
            database = DependencyService.Get<ISqliteService>().GetConnection();
            database.CreateTable<Player>();
            database.CreateTable<Game>();
            database.CreateTable<Round>();
            database.CreateTable<Turn>();
            database.CreateTable<GamePlayer>();
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

        public void Insert<T>(T item) where T : class 
        {
            database.InsertWithChildren(item, true);
        }

        public void Save<T>(T item) where T : class
        {
            database.UpdateWithChildren(item);
        }

        public T GetItem<T>(int id) where T : class
        {
            var item = database.GetWithChildren<T>(id);
            database.GetChildren(item, true);
            return item;
        }
    }
}