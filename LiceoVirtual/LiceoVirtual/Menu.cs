﻿
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
using Android.Telephony.Gsm;
using System.Threading.Tasks;
using System.Threading;
using Android.Content.PM;

namespace LiceoVirtual
{
	[Activity (Label = "Preguntas Biología", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class Menu : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Menu);

			ImageButton btnTrivia = FindViewById<ImageButton> (Resource.Id.btnJugar);
			ImageButton btnRanking = FindViewById<ImageButton> (Resource.Id.btnRanking);

			//ActionBar.SetHomeButtonEnabled(true);
			//ActionBar.SetDisplayHomeAsUpEnabled(true);

			btnTrivia.Click += delegate {
				StartActivity (typeof(Nivel));
			};

			btnRanking.Click += delegate {
				var intent = new Intent (this, typeof(Puntuacion));
				intent.PutExtra ("nivel", "1");
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

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			/*case Resource.Id.cerrarSesion:
				ISharedPreferences pref = Application.Context.GetSharedPreferences ("UserInfo", FileCreationMode.Private);
				ISharedPreferencesEditor editor = pref.Edit ();
				editor.PutString ("idUsuario", String.Empty);
				editor.PutString ("nombre", String.Empty);
				editor.PutBoolean ("guardar", false);
				//editor.PutBoolean ("estaCargadaBD", false);
				editor.Apply ();

				StartActivity(typeof(Login));
				Finish(); 
				return true;*/

			case Resource.Id.salir:
				Finish ();
				return true;
				
			}
			return base.OnOptionsItemSelected(item);
		}

	}
}

