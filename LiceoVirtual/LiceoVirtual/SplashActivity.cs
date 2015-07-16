
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
using Android.Content.PM;

namespace LiceoVirtual
{
	using System.Threading;

	using Android.App;
	using Android.OS;

	[Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			cargarBD ();
			Thread.Sleep(3000); // Simulate a long loading process on app startup.

			ISharedPreferences pref = Application.Context.GetSharedPreferences ("UserInfo", FileCreationMode.Private);
			bool guardarSesion = pref.GetBoolean ("guardar", false);

			//if (guardarSesion) {
				StartActivity(typeof(Menu));
			//} 
			//else {
			//	StartActivity(typeof(Login));
			//}

		}

		public void cargarBD(){
			ISharedPreferences pref = Application.Context.GetSharedPreferences ("UserInfo", FileCreationMode.Private);
			bool estaCargadaBD = pref.GetBoolean ("estaCargadaBD", false);

			if (!estaCargadaBD) {
				CargarBaseDeDatos c = new CargarBaseDeDatos ();

				ISharedPreferencesEditor editor = pref.Edit ();
				editor.PutBoolean ("estaCargadaBD", true);
				editor.Apply ();
			}
		}

	}
}

