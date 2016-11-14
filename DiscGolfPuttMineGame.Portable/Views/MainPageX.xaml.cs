using System;
using DiscGolfPuttMiniGame.Portable.Data;
using DiscGolfPuttMiniGame.Portable.Models;
using Xamarin.Forms;

namespace DiscGolfPuttMiniGame.Portable.Views
{
    public partial class MainPageX
    {
        public MainPageX()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        private void StartScoreTrackerGame_OnClicked(object sender, EventArgs e)
        {
            var count = int.Parse(PlayerCount.Text);
            var game = new Game();

            var database = new ScoreTrackerDatabase();


            var defaultPlayer = database.GetDefaultPlayer() ?? new Player
            {
                NickName = "Player1",
                IsDefault = true
            };
            database.Insert(defaultPlayer);
            game.Players.Add(defaultPlayer);
            for (var i = 1; i < count; i++)
            {
                var name = "Player" + (i+1);
                var player = new Player
                {
                    NickName = name
                };
                game.Players.Add(player);
                database.Insert(player);
            }
            game.IsCurrent = true;
            game.TotalRounds = int.Parse(RoundCount.Text);
            var addPlayerPage = new AddPlayersX {BindingContext = game};
            Navigation.PushModalAsync(addPlayerPage);
        }
    }
}