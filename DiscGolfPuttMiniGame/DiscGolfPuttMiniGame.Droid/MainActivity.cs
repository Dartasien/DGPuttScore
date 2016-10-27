using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using DiscGolfPuttMineGame.Models;
using DiscGolfPuttMineGame.Services;
using Button = Android.Widget.Button;

namespace DiscGolfPuttMiniGame.Droid
{
    [Activity(Label = "TestDiscGolfApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private readonly ISqliteService _sqliteService;

        public MainActivity()
        { }
        public MainActivity(ISqliteService sqliteService)
        {
            _sqliteService = sqliteService;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var defaultPlayer = _sqliteService.GetDefaultPlayer();

            if (defaultPlayer == null)
            {
                defaultPlayer = new Player
                {
                    IsDefault = true,
                    NickName = "Player1"
                };
                _sqliteService.InsertPlayer(defaultPlayer);
            }
            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.playerCountButton);

            button.Click += delegate
            {
                var playerCountText = FindViewById<EditText>(Resource.Id.playerCount);
                var count = playerCountText.Text;
                var addPlayersActivity = new Intent(this, typeof(AddPlayersActivity));
                addPlayersActivity.PutExtra("count", count);
                StartActivity(addPlayersActivity);
            };
        }
    }
}

