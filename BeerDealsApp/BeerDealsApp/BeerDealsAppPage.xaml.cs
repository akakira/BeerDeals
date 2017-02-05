using System;
using Xamarin.Forms;
using ZXing.Mobile;
using System.Diagnostics;
using ZXing.Net.Mobile.Forms;
using Xamarin.Auth;

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
			//remember the navigation hierarchy, this was causing issues when i had opened a model in a model window. 
			Navigation.PushModalAsync(new LoginPage());


		}
	}
}
