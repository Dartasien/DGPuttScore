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

            game.Players.Add(defaultPlayer);
            for (var i = 0; i < count - 1; i++)
            {
                game.Players.Add(new Player());
            }
            var addPlayerPage = new AddPlayersX {BindingContext = game};
            Navigation.PushModalAsync(addPlayerPage);
        }
    }
}
