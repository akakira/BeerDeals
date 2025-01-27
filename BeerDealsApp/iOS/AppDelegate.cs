﻿using System;
using System.Collections.Generic;
using System.Linq;
using ZXing.Net.Mobile.Forms.iOS;
using Foundation;
using UIKit;

namespace BeerDealsApp.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			LoadApplication (new App ());
			Platform.Init();

			return base.FinishedLaunching (app, options);


		}
	}
}
