using System.Collections.ObjectModel;
using DiscGolfPuttMiniGame.Portable.Models;
using Xamarin.Forms;

namespace DiscGolfPuttMiniGame.Portable.Views
{
    public partial class GameRoundsX : ContentPage
    {
        private Round Round => BindingContext as Round;

        public GameRoundsX()
        {
            InitializeComponent();
        }
    }
}
