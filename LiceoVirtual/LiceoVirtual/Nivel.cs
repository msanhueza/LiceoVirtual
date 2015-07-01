
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
using SQLite;
using Android.Content.PM;

namespace LiceoVirtual
{
	[Activity (Label = "Nivel", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class Nivel : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Nivel);
			SetTitle (Resource.String.niveles);

			ActionBar.SetHomeButtonEnabled(true);
			ActionBar.SetDisplayHomeAsUpEnabled(true);

			Button btn1 = FindViewById<Button> (Resource.Id.btn1);
			Button btn2 = FindViewById<Button> (Resource.Id.btn2);
			Button btn3 = FindViewById<Button> (Resource.Id.btn3);
			Button btn4 = FindViewById<Button> (Resource.Id.btn4);
			NivelDesbloqueadoAccion n = new NivelDesbloqueadoAccion ();
			List<NivelDesbloqueadoItem> listaNivelesDesbloqueados = n.getNivelesDesbloqueados ();
			for (int i = 0; i < listaNivelesDesbloqueados.Count; i++) {
				NivelDesbloqueadoItem item = listaNivelesDesbloqueados [i];
				if (item.nivel == 1) {
					if(item.desbloqueado == true){
						btn1.SetBackgroundResource (Resource.Drawable.LVButton);
					}
					else{
						btn1.SetBackgroundResource (Resource.Drawable.LVBlockedButton);
					}
					btn1.Click += delegate {
						var intent = new Intent (this, typeof(Pregunta));
						intent.PutExtra ("nivel", "1");
						StartActivity (intent);
						Finish();
					};
				} else if (item.nivel == 2) {
					if(item.desbloqueado == true){
						btn2.SetBackgroundResource (Resource.Drawable.LVButton);
					}
					else{
						btn2.SetBackgroundResource (Resource.Drawable.LVBlockedButton);
					}
					btn2.Click += delegate {
						if(item.desbloqueado == true){
							var intent = new Intent (this, typeof(Pregunta));
							intent.PutExtra ("nivel", "2");
							StartActivity (intent);
							Finish();
						}
						else{
							Toast.MakeText (this, "Debes desbloquear el NIVEL 1", ToastLength.Short).Show();
						}
					};
				} else if (item.nivel == 3) {
					if(item.desbloqueado == true){
						btn3.SetBackgroundResource (Resource.Drawable.LVButton);
					}
					else{
						btn3.SetBackgroundResource (Resource.Drawable.LVBlockedButton);
					}
					btn3.Click += delegate {
						if(item.desbloqueado == true){
							var intent = new Intent (this, typeof(Pregunta));
							intent.PutExtra ("nivel", "3");
							StartActivity (intent);
							Finish();
						}
						else{
							Toast.MakeText (this, "Debes desbloquear el NIVEL 2", ToastLength.Short).Show();
						}
					};
				} else { // nivel == 4
					if(item.desbloqueado == true){
						btn4.SetBackgroundResource (Resource.Drawable.LVButton);
					}
					else{
						btn4.SetBackgroundResource (Resource.Drawable.LVBlockedButton);
					}
					btn4.Click += delegate {
						if(item.desbloqueado == true){
							var intent = new Intent (this, typeof(Pregunta));
							intent.PutExtra ("nivel", "4");
							StartActivity (intent);
							Finish();
						}
						else{
							Toast.MakeText (this, "Debes desbloquear el NIVEL 3", ToastLength.Short).Show();
						}
					};
				}
			}

			// Create your application here
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case Resource.Id.cerrarSesion:
				ISharedPreferences pref = Application.Context.GetSharedPreferences ("UserInfo", FileCreationMode.Private);
				ISharedPreferencesEditor editor = pref.Edit ();
				editor.PutString ("idUsuario", String.Empty);
				editor.PutString ("nombre", String.Empty);
				editor.PutBoolean ("guardar", false);
				//editor.PutBoolean ("estaCargadaBD", false);
				editor.Apply ();

				StartActivity(typeof(Login));
				Finish(); 
				return true;

			case Android.Resource.Id.Home:
				Finish();
				return true;

			}
			return base.OnOptionsItemSelected(item);
		}


	}
}

