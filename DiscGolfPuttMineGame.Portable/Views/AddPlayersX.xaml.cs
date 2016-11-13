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
                database.Insert(Game);
            }
            if (!Game.Rounds.Any())
            {
                AddRoundsToGame(database);
            }
            database.Save(Game);
            var firstRound = Game.Rounds.FirstOrDefault(r => r.IsCurrent);
            var gameRounds = new GameRoundsX {BindingContext = firstRound};

            Navigation.PushModalAsync(gameRounds);
        }

        private void AddRoundsToGame(ScoreTrackerDatabase database)
        {
            for (var i = 1; i <= 20; i++)
            {
                var round = new Round
                {
                    RoundCount = i,
                    IsCurrent = i == 1,
                    Game = Game,
                    GameId = Game.Id
                };
                database.Insert(round);

                foreach (var player in Game.Players)
                {
                    var turn = new Turn
                    {
                        Player = player,
                        Round = round,
                        RoundId = round.Id,
                        PlayerId = player.Id,
                        CurrentRange = round.IsCurrent ? 10 : 0
                    };
                    round.Turns.Add(turn);
                    database.Insert(turn);
                }
                Game.Rounds.Add(round);
            }
        }
    }
}