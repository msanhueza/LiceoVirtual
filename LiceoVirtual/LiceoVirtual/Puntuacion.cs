
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
using System.Globalization;
using System.Threading.Tasks;

namespace LiceoVirtual
{
	[Activity (Label = "Puntuacion")]			
	public class Puntuacion : Activity
	{

		ListView listView;
		List<PuntuacionItem> listaPuntuaciones = new List<PuntuacionItem>();


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Puntuacion);

			ActionBar.SetHomeButtonEnabled(true);
			ActionBar.SetDisplayHomeAsUpEnabled(true);


			string nivel = Intent.GetStringExtra ("nivel") ?? "0";

			if (nivel.Equals ("1")) {
				SetTitle (Resource.String.nivel_1);
			} else if (nivel.Equals ("2")) {
				SetTitle (Resource.String.nivel_2);
			} else if (nivel.Equals ("3")) {
				SetTitle (Resource.String.nivel_3);
			} else {
				SetTitle (Resource.String.nivel_4);
			}

			listView = FindViewById<ListView>(Resource.Id.listViewPuntuacion);
			PuntuacionAccion p = new PuntuacionAccion ();
			listaPuntuaciones = p.getPuntuacionesBD (nivel);
			listView.Adapter = new PuntuacionAdapter(this, listaPuntuaciones);

			Button btnIrTrivia = FindViewById<Button> (Resource.Id.btnIrTrivia);

			btnIrTrivia.Click += delegate {
				//var intent = new Intent (this, typeof(Pregunta));
				//intent.PutExtra ("nivel", nivel);
				//StartActivity (intent);		
				//Finish ();
			};


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

