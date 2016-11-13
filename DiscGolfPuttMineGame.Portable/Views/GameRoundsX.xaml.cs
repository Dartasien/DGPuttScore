using System;
using System.Collections.Generic;
using System.Linq;
using DiscGolfPuttMiniGame.Portable.Data;
using DiscGolfPuttMiniGame.Portable.Models;

namespace DiscGolfPuttMiniGame.Portable.Views
{
    public partial class GameRoundsX
    {
        private Round Round => BindingContext as Round;

        public GameRoundsX()
        {
            InitializeComponent();
        }

        private void FinishTurnButton_OnClicked(object sender, EventArgs e)
        {
            Round.IsRoundOver = true;
            Round.IsCurrent = false;
            var database = new ScoreTrackerDatabase();
            database.Save(Round);
            foreach (var turn in Round.Turns)
            {
                database.Save(turn);
            }
            var game = database.GetItem<Game>(Round.GameId);
            if (!game.Rounds.All(r => r.IsRoundOver))
            {
                var roundCount = Round.RoundCount + 1;
                var nextRound = game.Rounds.FirstOrDefault(r => r.RoundCount == roundCount);
                nextRound.IsCurrent = true;
                var nextRoundX = new GameRoundsX {BindingContext = nextRound};
                Navigation.PushModalAsync(nextRoundX);
            }
            else
            {

                var turns = game.Rounds.SelectMany(r => r.Turns).ToList();
                var playerScores = new Dictionary<int, int>();

                foreach (var player in game.Players)
                {
                    if (!playerScores.ContainsKey(player.Id))
                    {
                        playerScores.Add(player.Id, 0);
                    }
                    
                }

                foreach (var turn in turns)
                {
                    playerScores[turn.PlayerId] += turn.Score;
                }

                foreach (var player in game.Players)
                {
                    if (playerScores[player.Id] <= game.WinningScore) continue;
                    game.WinningPlayer = player;
                    game.WinningScore = playerScores[player.Id];
                }

                var winnerNewGame = new WinnerNewGame {BindingContext = game};
                Navigation.PushModalAsync(winnerNewGame);
            }
        }
    }
}