using System;
using Xamarin.Forms;
using ZXing.Mobile;
using System.Diagnostics;
using ZXing.Net.Mobile.Forms;

namespace BeerDealsApp
{
	public partial class BeerDealsAppPage : ContentPage
	{
		public BeerDealsAppPage ()
		{
			InitializeComponent ();
		}

		protected async void btnClick(object sender, EventArgs e){
			var scanPage = new ZXingScannerPage ();

			scanPage.OnScanResult += (result) => {
				// Stop scanning
				scanPage.IsScanning = false;

				// Pop the page and show the result
				Device.BeginInvokeOnMainThread (() => {
					Navigation.PopAsync ();        
					DisplayAlert("Scanned Barcode", result.Text, "OK");
				});
			};

			// Navigate to our scanner page
			await Navigation.PushAsync (scanPage);

		}

		protected void btnDoFBLogin(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new NavigationPage(new ProfilePage()));
		}
	}
}
