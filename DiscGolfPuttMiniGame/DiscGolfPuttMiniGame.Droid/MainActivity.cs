using Android.App;
using Android.Content;
using Android.OS;
using DiscGolfPuttMiniGame.Portable;

namespace DiscGolfPuttMiniGame.Droid
{
    [Activity(Label = "Disc Golf Putt Mini Game Score Tracker", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
            //// Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);
            //// Get our button from the layout resource,
            //// and attach an event to it
            //var button = FindViewById<Button>(Resource.Id.playerCountButton);

            //button.Click += delegate
            //{
            //    var playerCountText = FindViewById<EditText>(Resource.Id.playerCount);
            //    var count = playerCountText.Text;
            //    var addPlayersActivity = new Intent(this, typeof(AddPlayersActivity));
            //    addPlayersActivity.PutExtra("count", count);
            //    StartActivity(addPlayersActivity);
            //};
        }
    }
}

