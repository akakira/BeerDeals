using System;
using Xamarin.Forms;
using ZXing.Mobile;
using System.Diagnostics;

namespace BeerDealsApp
{
	public partial class BeerDealsAppPage : ContentPage
	{
		public BeerDealsAppPage ()
		{
			InitializeComponent ();
		}

		protected async void btnClick(object sender, EventArgs e){
			#if __ANDROID__
			    // Initialize the scanner first so it can track the current context
    	MobileBarcodeScanner.Initialize (Application);
    #endif

			var scanner = new MobileBarcodeScanner();

			var result = await scanner.Scan();

			if (result != null)
				Debug.WriteLine("Scanned Barcode: " + result.Text);
		}
	}
}
