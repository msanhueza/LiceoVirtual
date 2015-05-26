
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
				var intent = new Intent (this, typeof(Pregunta));
				intent.PutExtra ("nivel", nivel);
				StartActivity (intent);		
				Finish ();
			};


		}
			

	}

}

