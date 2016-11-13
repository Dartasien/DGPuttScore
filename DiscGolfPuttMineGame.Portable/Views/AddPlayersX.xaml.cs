using System;
using System.Linq;
using DiscGolfPuttMiniGame.Portable.Data;
using DiscGolfPuttMiniGame.Portable.Models;

namespace DiscGolfPuttMiniGame.Portable.Views
{
    public partial class AddPlayersX
    {
        private Game Game => BindingContext as Game;

        public AddPlayersX()
        {
            InitializeComponent();
        }

        private void StartButton_OnClicked(object sender, EventArgs e)
        {
            var database = new ScoreTrackerDatabase();
            if (Game.Id <= 0)
            {
                database.InsertGame(Game);
            }
            if (!Game.Rounds.Any())
            {
                AddRoundsToGame();
            }
            database.SaveGame(Game);
            var firstRound = Game.Rounds.FirstOrDefault(r => r.IsCurrent);
            var gameRounds = new GameRoundsX {BindingContext = firstRound};

            
            Navigation.PushModalAsync(gameRounds);
        }

        private void AddRoundsToGame()
        {
            for (var i = 1; i <= 20; i++)
            {
                var round = new Round
                {
                    RoundCount = i,
                    IsCurrent = i == 1,
                    Game = Game
                };

                foreach (var player in Game.Players)
                {
                    round.Turns.Add(new Turn
                    {
                        Player = player,
                        Round = round,
                        PlayerId = player.Id,
                    });
                }
                Game.Rounds.Add(round);
            }
        }
    }
}
