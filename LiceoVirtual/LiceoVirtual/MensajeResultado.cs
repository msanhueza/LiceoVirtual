
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
	[Activity (Label = "Trivia", ScreenOrientation = ScreenOrientation.Portrait)]			
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

			int auxNivel = Int32.Parse(nivel);
			int auxPuntaje = puntaje * 10;
			tvPuntajeMensajeResultado.Text = (auxPuntaje) + "%";
			guardarPuntaje(auxNivel, auxPuntaje);

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
				SetTitle (Resource.String.trivianivel_1);
			} else if (nivel.Equals ("2")) {
				mensaje = baseTexto + segundo;
				SetTitle (Resource.String.trivianivel_2);
			} else if (nivel.Equals ("3")) {
				mensaje = baseTexto + tercero;
				SetTitle (Resource.String.trivianivel_3);
			} else {
				mensaje = baseTexto + cuarto;
				SetTitle (Resource.String.trivianivel_4);
			}

			tvTextoMensajeResultado.Text = mensaje;

			Button btnAceptarTerminoTrivia = FindViewById<Button> (Resource.Id.btnAceptarTerminoTrivia);

			btnAceptarTerminoTrivia.Click += delegate {
				terminarActivity();
			};

			// Create your application here
		}

		public void guardarPuntaje(int auxNivel, int auxPuntaje){
			DateTime date = DateTime.Now;
			string auxDate = String.Format("{0:dd/MM/yyyy}", date);	
			PuntuacionAccion puntuacionAccion = new PuntuacionAccion ();
			puntuacionAccion.insertUpdateData(new PuntuacionBD{ IdUsuario= 1, nivel= auxNivel, fecha= auxDate, puntaje=auxPuntaje });
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

