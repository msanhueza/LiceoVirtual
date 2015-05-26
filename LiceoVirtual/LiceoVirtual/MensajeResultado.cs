
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
	[Activity (Label = "Trivia")]			
	public class MensajeResultado : Activity
	{
		public static string nivel;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MensajeResultado);

			TextView tvTextoMensajeResultado = FindViewById<TextView> (Resource.Id.tvTextoMensajeResultado);

			nivel = Intent.GetStringExtra ("nivel") ?? "0";

			string baseTexto = "¡FELICITACIONES!, HAZ COMPLETADO LA TRIVIA DE ";
			string primero = "PRIMERO MEDIO";
			string segundo = "SEGUNDO MEDIO";
			string tercero = "TERCERO MEDIO";
			string cuarto = "CUARTO MEDIO";
			string mensaje = "";

			if (nivel.Equals ("1")) {
				mensaje = baseTexto + primero;
			} else if (nivel.Equals ("2")) {
				mensaje = baseTexto + segundo;
			} else if (nivel.Equals ("3")) {
				mensaje = baseTexto + tercero;
			} else {
				mensaje = baseTexto + cuarto;
			}

			tvTextoMensajeResultado.Text = mensaje;

			Button btnAceptarTerminoTrivia = FindViewById<Button> (Resource.Id.btnAceptarTerminoTrivia);

			btnAceptarTerminoTrivia.Click += delegate {
				terminarActivity();
			};

			// Create your application here
		}

		public override void OnBackPressed ()
		{
			terminarActivity ();
		}

		public void terminarActivity(){
			var intent = new Intent (this, typeof(Puntuacion));
			intent.PutExtra ("nivel", nivel);
			StartActivity (intent);
			//base.OnBackPressed();
			Finish ();
		}
	}
}

