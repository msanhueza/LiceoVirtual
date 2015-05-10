
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
	[Activity (Label = "Menu")]			
	public class Menu : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Menu);

			Button btnTrivia = FindViewById<Button> (Resource.Id.btnTrivia);
			Button btnRanking = FindViewById<Button> (Resource.Id.btnRanking);
			Button btnCerrarSesion = FindViewById<Button> (Resource.Id.btnCerrarSesion);


			btnTrivia.Click += delegate {
				StartActivity (typeof(Nivel));
			};

			btnRanking.Click += delegate {
				StartActivity (typeof(Ranking));
			};

			btnCerrarSesion.Click += delegate {
				
				ISharedPreferences pref = Application.Context.GetSharedPreferences ("UserInfo", FileCreationMode.Private);
				ISharedPreferencesEditor editor = pref.Edit ();
				editor.PutString ("idUsuario", String.Empty);
				editor.PutString ("nombre", String.Empty);
				editor.PutBoolean ("guardar", false);
				editor.Apply ();

				StartActivity(typeof(Login));
				Finish(); 
			};
				
		}
	}
}

