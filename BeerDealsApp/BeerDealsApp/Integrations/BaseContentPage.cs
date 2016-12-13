using System;

using Xamarin.Forms;

namespace BeerDealsApp
{
	public class BaseContentPage : ContentPage
	{
		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (!App.IsLoggedIn)
			{
				Navigation.PushModalAsync(new LoginPage());
			}
		}
	}
}

