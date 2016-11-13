using System;

namespace DiscGolfPuttMiniGame.Portable.Views
{
    public partial class WinnerNewGame
    {
        public WinnerNewGame()
        {
            InitializeComponent();
        }

        private void NewGame_OnClicked(object sender, EventArgs e)
        {
            var mainPageX = new MainPageX();
            Navigation.PushModalAsync(mainPageX);
        }
    }
}
