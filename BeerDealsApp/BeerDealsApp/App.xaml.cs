using Xamarin.Forms;

namespace BeerDealsApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new BeerDealsAppPage());
			App.FbServices = DependencyService.Get<IFaceBookServices>();
		}

		public static IFaceBookServices FbServices {get;set;}

		protected override void OnStart ()
		{
			// Handle when your app starts
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
