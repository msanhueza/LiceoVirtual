
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
		public static int puntaje;
		public static bool aprobo;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MensajeResultado);

			TextView tvTextoMensajeResultado = FindViewById<TextView> (Resource.Id.tvTextoMensajeResultado);
			TextView tvPuntajeMensajeResultado = FindViewById<TextView> (Resource.Id.tvPuntajeMensajeResultado);
			ImageView imgMensajeResultadoStudent = FindViewById<ImageView> (Resource.Id.imgMensajeResultadoStudent);

			nivel = Intent.GetStringExtra ("nivel") ?? "0";
			puntaje = Intent.GetIntExtra ("puntaje",0);
			aprobo = Intent.GetBooleanExtra ("aprobo", false);

			tvPuntajeMensajeResultado.Text = (puntaje*10) + "%";

			string baseTexto = "";
			if(aprobo){
				baseTexto = "¡FELICITACIONES!, HAS COMPLETADO LA TRIVIA DE ";
			}
			else{
				baseTexto = "¡SIGUE INTENTANDOLO!, NO HAS COMPLETADO LA TRIVIA DE ";
				imgMensajeResultadoStudent.SetImageResource (Resource.Drawable.student_sad);
			}
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
			//StartActivity (typeof(Nivel));
			base.OnBackPressed();
			Finish ();
		}
	}
}

