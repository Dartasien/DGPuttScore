using DiscGolfPuttMiniGame.Portable.Data;
using DiscGolfPuttMiniGame.Portable.Views;
using Xamarin.Forms;

namespace DiscGolfPuttMiniGame.Portable
{
	public class App : Application
	{
	    private static ScoreTrackerDatabase _database;

		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};
		}

	    public static ScoreTrackerDatabase Database => _database ?? (_database = new ScoreTrackerDatabase());

	    protected override void OnStart ()
		{
			// Handle when your app starts
            var mainPage = new NavigationPage( new MainPageX());
	        MainPage.Navigation.PushModalAsync(mainPage, false);
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
