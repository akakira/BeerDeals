using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;

namespace co.willowsoft.BeerDealsApp
{
	public partial class FbLogin : ContentPage
	{
		public FbLogin()
		{
			InitializeComponent();

			var auth =  new OAuth2Authenticator(
				clientId: LoginConstants.ClientId, // your OAuth2 client id
				scope: LoginConstants.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
				authorizeUrl: new Uri(LoginConstants.LoginUrl), // the auth URL for the service
				redirectUrl: new Uri(LoginConstants.RedirectUrl)); // the redirect URL for the service

			auth.Completed += (sender, eventArgs) =>
			{

				// We presented the UI, so it's up to us to dimiss it on iOS.
				#if __IOS__
					DismissViewController(true, null);
				#endif

				if (eventArgs.IsAuthenticated)
				{
					// Use eventArgs.Account to do wonderful things
				}
				else {
					// The user cancelled
				}
			};

			auth.GetInitialUrlAsync();

		}
	}
}
