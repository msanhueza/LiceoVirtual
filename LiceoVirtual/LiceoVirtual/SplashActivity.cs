
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LiceoVirtual
{
	using System.Threading;

	using Android.App;
	using Android.OS;

	[Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			Thread.Sleep(3000); // Simulate a long loading process on app startup.

			ISharedPreferences pref = Application.Context.GetSharedPreferences ("UserInfo", FileCreationMode.Private);
			bool guardarSesion = pref.GetBoolean ("guardar", false);

			if (guardarSesion) {
				StartActivity(typeof(Menu));
			} else {
				StartActivity(typeof(Login));
			}

		}
	}
}

