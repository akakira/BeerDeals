using System;
using Android.App;
using BeerDealsApp;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace BeerDealsApp
{
	public class LoginPageRenderer : PageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			// this is a ViewGroup - so should be able to load an AXML file and FindView<>
			var activity = this.Context as Activity;

			var auth = new OAuth2Authenticator(
				clientId: LoginConstants.ClientId, // your OAuth2 client id
				scope: LoginConstants.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
				authorizeUrl: new Uri(LoginConstants.LoginUrl), // the auth URL for the service
				redirectUrl: new Uri(LoginConstants.RedirectUrl)); // the redirect URL for the service

			auth.Completed += (sender, eventArgs) =>
			{
				if (eventArgs.IsAuthenticated)
				{
					App.SuccessfulLoginAction.Invoke();
					// Use eventArgs.Account to do wonderful things
					App.AuthorizationToken=eventArgs.Account.Properties["access_token"];
				}
				else {
					// The user cancelled
				}
			};

			activity.StartActivity(auth.GetUI(activity));
		}
	}
}
