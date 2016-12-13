using System;
using BeerDealsApp;
using BeerDealsApp.iOS;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace BeerDealsApp.iOS
{

	public class LoginPageRenderer : PageRenderer
	{

		bool IsShown;

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			// Fixed the issue that on iOS 8, the modal wouldn't be popped.
			// url : http://stackoverflow.com/questions/24105390/how-to-login-to-facebook-in-xamarin-forms
			if (!IsShown)
			{

				IsShown = true;

				var auth = new OAuth2Authenticator(
					clientId: LoginConstants.ClientId, // your OAuth2 client id
					scope: LoginConstants.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
					authorizeUrl: new Uri(LoginConstants.LoginUrl), // the auth URL for the service
					redirectUrl: new Uri(LoginConstants.RedirectUrl)); // the redirect URL for the service




				auth.Completed += (sender, eventArgs) =>
				{
					// We presented the UI, so it's up to us to dimiss it on iOS.
					App.SuccessfulLoginAction.Invoke();

					if (eventArgs.IsAuthenticated)
					{
						// Use eventArgs.Account to do wonderful things
						App.AuthorizationToken=eventArgs.Account.Properties["access_token"];
					}
					else {
						// The user cancelled
					}
				};

				PresentViewController(auth.GetUI(), true, null);

			}

		}
	}
}

