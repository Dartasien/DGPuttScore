using Android.App;
using Android.OS;

namespace DiscGolfPuttMiniGame.Droid
{
    [Activity(Label = "AddPlayersActivity")]
    public class AddPlayersActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddPlayers);

            var count = int.Parse(Intent.GetStringExtra("Count") ?? "1");
        }
    }
}