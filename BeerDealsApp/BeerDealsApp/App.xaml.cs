using System;
using Xamarin.Forms;

namespace BeerDealsApp
{
	public partial class App : Application
	{
		public static Page MainPageRef;
		public App()
		{
			InitializeComponent();

			MainPage =  new NavigationPage(new BeerDealsAppPage());

			App.MainPageRef = MainPage;
		}

		public static string AuthorizationToken { get; set; } //persist to local storage

		public static bool IsLoggedIn { get { return !string.IsNullOrWhiteSpace(AuthorizationToken); }}

		public static Action SuccessfulLoginAction
		{
			get
			{
				return new Action(() =>
				{
					MainPageRef.Navigation.PopModalAsync();
				});
			}
		}

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
