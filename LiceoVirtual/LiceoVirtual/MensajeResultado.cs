
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
		public static int malas;
		public static bool aprobo;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MensajeResultado);

			TextView tvTextoMensajeResultado = FindViewById<TextView> (Resource.Id.tvTextoMensajeResultado);
			TextView tvPuntajeMensajeResultado = FindViewById<TextView> (Resource.Id.tvPuntajeMensajeResultado);
			ImageView imgMensajeResultadoStudent = FindViewById<ImageView> (Resource.Id.imgMensajeResultadoStudent);

			nivel = Intent.GetStringExtra ("nivel") ?? "0";
			puntaje = Intent.GetIntExtra ("buenas",0);
			malas = Intent.GetIntExtra ("malas",0);
			aprobo = Intent.GetBooleanExtra ("aprobo", false);

			int auxNivel = Int32.Parse(nivel);
			int auxPuntaje = puntaje * 10;
			string aprobacion = (aprobo) ? "APROBADO" : "NO APROBADO";
			tvPuntajeMensajeResultado.Text = "CORRECTAS   : "+puntaje+"\n"+
											 "INCORRECTAS : "+malas+"\n"+
				                             "\n"+
											  aprobacion;
			guardarPuntaje(auxNivel, auxPuntaje);
			PuntuacionAccion p = new PuntuacionAccion ();
			int cantidadAprobadas = p.getPuntuacionMore80 (nivel);
			if (cantidadAprobadas == 3 && aprobo) {
				if (auxNivel <= 3) {
					NivelDesbloqueadoAccion n = new NivelDesbloqueadoAccion ();
					mostrarMensajeNivelDesbloqueado (auxNivel);
					n.desbloquearNivel ((auxNivel).ToString());	
					n.desbloquearNivel ((auxNivel+1).ToString());
				}
			}
			string mensaje = "";
			string baseTexto = "";
			string primero = "PRIMERO MEDIO";
			string segundo = "SEGUNDO MEDIO";
			string tercero = "TERCERO MEDIO";
			string cuarto = "CUARTO MEDIO";
			if(aprobo){
				baseTexto = "¡FELICITACIONES!, HAS COMPLETADO LA TRIVIA DE ";
				if (nivel.Equals ("1")) {
					mensaje = baseTexto + primero ;
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
			}
			else{
				mensaje = "No has completado la trivia.\n ¡Sigue intentandolo!";

				imgMensajeResultadoStudent.SetImageResource (Resource.Drawable.student_sad);
			}






			tvTextoMensajeResultado.Text = mensaje;

			Button btnAceptarTerminoTrivia = FindViewById<Button> (Resource.Id.btnAceptarTerminoTrivia);

			btnAceptarTerminoTrivia.Click += delegate {
				terminarActivity();
			};

			// Create your application here
		}

		public void mostrarMensajeNivelDesbloqueado(int nivel){
			int auxNivel = nivel + 1;
			AlertDialog.Builder alert = new AlertDialog.Builder (this);
			var inputView = LayoutInflater.Inflate(Resource.Layout.MensajeNivelDesbloqueado, null);
			var textView = inputView.FindViewById (Resource.Id.felicitaciones_mensaje);
			TextView tvFelicitaciones = inputView.FindViewById<TextView> (Resource.Id.felicitaciones_mensaje);
			tvFelicitaciones.Text = tvFelicitaciones.Text + " " + auxNivel.ToString();
			alert.SetView(inputView);
			alert.SetTitle("¡FELICITACIONES!");
			alert.SetNeutralButton ("Aceptar", (senderAlert, args) => {
				alert.Dispose();
			} );

			RunOnUiThread (() => {
				alert.Show();
			} );
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
			StartActivity (typeof(Nivel));
			//base.OnBackPressed();
			Finish ();
		}
	}
}

