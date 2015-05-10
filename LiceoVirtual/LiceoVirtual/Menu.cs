
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Android.Export;
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

			Button btnCerrarSesion = FindViewById<Button> (Resource.Id.btnCerrarSesion);

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


			Button btnTrivia = FindViewById<Button> (Resource.Id.btnTrivia);

			btnTrivia.Click += delegate {

				var intent = new Intent (this, typeof(Nivel));
				//intent.PutExtra ("nombre", "Mario Sanhueza");
				StartActivity (intent); 	
			};

		}
		/* con licencia se puede hacer de esta forma los listener de los botones
		[Java.Interop.Export("onClickTrivia")] // The value found in android:onClick attribute.
		public void onClickTrivia(View v)
		{
			var intent = new Intent (this, typeof(Nivel));
			intent.PutExtra ("nombre", "Mario Sanhueza");
			StartActivity (intent); 	
		}*/
	}
}

