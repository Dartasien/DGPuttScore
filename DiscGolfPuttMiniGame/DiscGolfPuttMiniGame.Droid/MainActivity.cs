using Android.App;
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

        }
    }
}

