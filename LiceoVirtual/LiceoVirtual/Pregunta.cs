
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
using System.Threading;
using Android.Content.PM;

namespace LiceoVirtual
{
	[Activity (Label = "Pregunta", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class Pregunta : Activity
	{

		public static int numPregunta;
		public static string nivel;
		public static int buenas;
		public static int malas;
		public static bool esCorrecta;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Pregunta);

			ActionBar.SetHomeButtonEnabled(true);
			ActionBar.SetDisplayHomeAsUpEnabled(true);

			nivel = Intent.GetStringExtra ("nivel") ?? "0";

			if (nivel.Equals ("1")) {
				SetTitle (Resource.String.preguntas_n1);
			} else if (nivel.Equals ("2")) {
				SetTitle (Resource.String.preguntas_n2);
			} else if (nivel.Equals ("3")) {
				SetTitle (Resource.String.preguntas_n3);
			} else {
				SetTitle (Resource.String.preguntas_n4);
			}

			Button btnPreguntaSiguiente = FindViewById<Button> (Resource.Id.btnPreguntaSiguiente);
			ProgressBar pbPregunta = FindViewById<ProgressBar> (Resource.Id.pbPregunta);
			TextView tvPregunta = FindViewById<TextView> (Resource.Id.tvPregunta);
			TextView tvProgreso = FindViewById<TextView> (Resource.Id.tvProgreso);
			TextView tvCorrectas = FindViewById<TextView> (Resource.Id.tvCorrectas);
			TextView tvIncorrectas = FindViewById<TextView> (Resource.Id.tvIncorrectas);
			RadioButton radioOp1 = FindViewById<RadioButton> (Resource.Id.rbOp1);
			RadioButton radioOp2 = FindViewById<RadioButton> (Resource.Id.rbOp2);
			RadioButton radioOp3 = FindViewById<RadioButton> (Resource.Id.rbOp3);
			ImageView imgPregunta = FindViewById<ImageView> (Resource.Id.imgPregunta);

			esCorrecta = true;
			int progreso = 10;
			buenas = 0;
			malas = 0;
			tvCorrectas.Text = "CORRECTAS: " + buenas+"/10";
			tvIncorrectas.Text = "INCORRECTAS: " + malas+"/2";
			pbPregunta.Progress = progreso;
			numPregunta = 0; // comienza en 0 para poder recorrer la lista de preguntas hasta llegar a 9 (10 preguntas)
			tvProgreso.Text = "Pregunta: " + (numPregunta + 1) + " / 10";
			int auxNivel = Int32.Parse(nivel);

			List<ListadoPreguntaSolucionItem> aux = getListadoPreguntaSolucion (auxNivel);
			ListadoPreguntaSolucionItem p = aux[numPregunta];
			string textPregunta = p.objPregunta.pregunta;
			tvPregunta.Text = textPregunta;
			string opcion1 = p.objListaRespuestas[0].solucion;
			string opcion2 = p.objListaRespuestas[1].solucion;
			string opcion3 = p.objListaRespuestas[2].solucion;
			radioOp1.Text = opcion1;
			radioOp2.Text = opcion2;
			radioOp3.Text = opcion3;
			if (p.objPregunta.idImagen != -1) {
				imgPregunta.Visibility = ViewStates.Visible;
				imgPregunta.SetImageResource (p.objPregunta.idImagen);
			}
			else{
				imgPregunta.Visibility = ViewStates.Invisible;
			}
			btnPreguntaSiguiente.Click += delegate {
				ResultadoRespuestaItem resp;
				if(esCorrecta){
					resp = comprobarRespuesta(p.objListaRespuestas);
					if(resp.esCorrecta){
						mostrarToastConImagen(Resource.Drawable.correct);
						buenas++;
						tvCorrectas.Text = "CORRECTAS: " + buenas+"/10";
					}
					else{
						malas++;
						tvIncorrectas.Text = "INCORRECTAS: " + malas+"/2";
						esCorrecta = false;
						tvIncorrectas.SetTextColor(Android.Graphics.Color.Red);
						mostrarToastConImagen(Resource.Drawable.incorrect);
						mostrarResultado(resp.respuesta);
						if(malas == 2){
							btnPreguntaSiguiente.Text = "Terminar";
						}
					}
				}
				else{
					esCorrecta = true;
					if(malas == 2 && buenas < 8){
						cambiarActivity(false);
						esCorrecta = false; // para que no muestre las siguientes preguntas
					}
				}

				if(numPregunta == 9 && esCorrecta){ // si se terminaron las preguntas
					cambiarActivity(true);
				}
				else{ // si quedan preguntas
					if(esCorrecta){
						numPregunta++;
						progreso = progreso + 10;
						pbPregunta.Progress = progreso;
						tvProgreso.Text = "Pregunta: " + (numPregunta + 1) + " / 10";
						p = aux[numPregunta];
						textPregunta = p.objPregunta.pregunta;
						tvPregunta.Text = textPregunta;
						habilitarRadiosButton();
						opcion1 = p.objListaRespuestas[0].solucion;
						opcion2 = p.objListaRespuestas[1].solucion;
						opcion3 = p.objListaRespuestas[2].solucion;
						radioOp1.Text = opcion1;
						radioOp2.Text = opcion2;
						radioOp3.Text = opcion3;
						if (p.objPregunta.idImagen != -1) {
							imgPregunta.Visibility = ViewStates.Visible;
							imgPregunta.SetImageResource (p.objPregunta.idImagen);
						}
						else{
							imgPregunta.Visibility = ViewStates.Invisible;
						}
						if(numPregunta == 9){ // si se llega a la ultima pregunta se cambia el texto del boton siguiente
							btnPreguntaSiguiente.Text = "Terminar";
						}

					}

				}

			};
				
		}

		public void cambiarActivity(bool aprobo){
			var intent = new Intent (this, typeof(MensajeResultado));
			intent.PutExtra ("nivel", nivel);
			intent.PutExtra ("buenas", buenas);
			intent.PutExtra ("malas", malas);
			intent.PutExtra("aprobo", aprobo);
			StartActivity (intent);
			Finish ();
		}
			

		public ResultadoRespuestaItem comprobarRespuesta(List<PreguntaSolucionItem> listaRespuestas){
			ResultadoRespuestaItem rri;
			string auxSol = "";
			RadioGroup radioGroup = FindViewById<RadioGroup> (Resource.Id.radioGroup1);
			int idRadioButtonSeleccionado = radioGroup.CheckedRadioButtonId;
			RadioButton radioButtonSeleccionado = FindViewById<RadioButton> (idRadioButtonSeleccionado);
			String respuesta = radioButtonSeleccionado.Text;
			for (int i = 0; i<listaRespuestas.Count; i++) {
				if(listaRespuestas[i].esSolucion){
					auxSol = listaRespuestas[i].solucion;
					if (( auxSol ).Equals (respuesta)) {
						rri = new ResultadoRespuestaItem (true, "");
						return rri;
					}
				}
			}
			rri = new ResultadoRespuestaItem (false, auxSol);
			return rri;
		}

		public List<int> getDiezPreguntasAleatorias(int n){
			List<int> listaTotalPreguntas = new List<int>();
			int total = n;
			for(int i=1; i<=total; i++){
				listaTotalPreguntas.Add (i);
			}
			Random r = new Random(DateTime.Now.Millisecond);
			List<int> listaNumeros = new List<int>();
			for (int j = 0; j < 10; j++) {
				int numero = r.Next(0, listaTotalPreguntas.Count());
				listaNumeros.Add (listaTotalPreguntas[numero]);
				listaTotalPreguntas.RemoveAt (numero);
			}
			return listaNumeros;
		}

		public List<ListadoPreguntaSolucionItem> getListadoPreguntaSolucion(int nivel){
			PreguntaAccion p = new PreguntaAccion ();
			PreguntaSolucionAccion ps = new PreguntaSolucionAccion ();
			List<PreguntaItem> listaPreguntas = p.getPreguntasBD (nivel);
			int totalPreguntas = listaPreguntas.Count;
			List<int> numeros = getDiezPreguntasAleatorias (totalPreguntas);
			int totalNumeros = numeros.Count;
			List<ListadoPreguntaSolucionItem> resultado = new List<ListadoPreguntaSolucionItem> ();
			for (int i = 0; i < totalNumeros; i++) {
				int idBD = numeros [i]-1; // -1 porque los idBD comienzan del 1 en adelante
				PreguntaItem pregunta = listaPreguntas [idBD];
				List<PreguntaSolucionItem> listaPreguntaSolucion = Shuffle(ps.getPreguntasSolucionBD (pregunta.ID));
				ListadoPreguntaSolucionItem item = new ListadoPreguntaSolucionItem (pregunta, listaPreguntaSolucion);
				resultado.Add (item);
			}
			return resultado;
		}

		public List<T> Shuffle<T>(List<T> list)
		{
			List<T> randomizedList = new List<T>();
			Random rnd = new Random(DateTime.Now.Millisecond);
			while (list.Count > 0)
			{
				int index = 1;
				for (int i = 0; i < 2; i++) {
					index = rnd.Next(0, list.Count);
				}
				randomizedList.Add(list[index]);
				list.RemoveAt(index);
			}
			return randomizedList;
		}


		public void mostrarToastConImagen(int idImagen){
			Toast toast = new Toast(this);
			ImageView view = new ImageView(this); 
			view.SetImageResource(idImagen);
			toast.View = view;
			toast.Duration = ToastLength.Short;
			toast.Show();
		}

		public void mostrarMensajeAlertaIncorrecto(){
			AlertDialog.Builder alert = new AlertDialog.Builder (this);
			var inputView = LayoutInflater.Inflate(Resource.Layout.AlertaRespuestaIncorrecta, null);
			alert.SetView(inputView);
			alert.SetTitle("Alerta");
			alert.SetNeutralButton ("Aceptar", (senderAlert, args) => {
				alert.Dispose();
			} );
				
			RunOnUiThread (() => {
				alert.Show();
			} );
		}

		public void habilitarRadiosButton(){
			RadioButton radioOp1 = FindViewById<RadioButton> (Resource.Id.rbOp1);
			RadioButton radioOp2 = FindViewById<RadioButton> (Resource.Id.rbOp2);
			RadioButton radioOp3 = FindViewById<RadioButton> (Resource.Id.rbOp3);			
			radioOp1.Checked = true; // para dejar siempre el primer radio button seleccionado
			radioOp1.SetTextColor(Android.Graphics.Color.Black);
			radioOp2.SetTextColor(Android.Graphics.Color.Black);
			radioOp3.SetTextColor(Android.Graphics.Color.Black);
			radioOp1.Enabled = true;
			radioOp2.Enabled = true;
			radioOp3.Enabled = true;
		}

		public void mostrarResultado(string resultado){
			RadioButton radioOp1 = FindViewById<RadioButton> (Resource.Id.rbOp1);
			RadioButton radioOp2 = FindViewById<RadioButton> (Resource.Id.rbOp2);
			RadioButton radioOp3 = FindViewById<RadioButton> (Resource.Id.rbOp3);
			string r1 = radioOp1.Text;
			string r2 = radioOp2.Text;
			string r3 = radioOp3.Text;
			radioOp1.Enabled = false;
			radioOp2.Enabled = false;
			radioOp3.Enabled = false;
			if(r1.Equals(resultado)){
				radioOp1.Text = "(Respuesta Correcta) - " + r1;
				radioOp1.SetTextColor(Android.Graphics.Color.Green);
			}
			else if(r2.Equals(resultado)){
				radioOp2.Text = "(Respuesta Correcta) - " + r2;
				radioOp2.SetTextColor(Android.Graphics.Color.Green);
			}
			else{ // r3 es igual al resultado
				radioOp3.Text = "(Respuesta Correcta) - " + r3;
				radioOp3.SetTextColor(Android.Graphics.Color.Green);
			}
			/*AlertDialog.Builder alert = new AlertDialog.Builder (this);
			alert.SetTitle("Respuesta Correcta");
			alert.SetMessage (resultado);
			alert.SetNeutralButton ("Aceptar", (senderAlert, args) => {
				alert.Dispose();
				if(malas == 2 && buenas<8){
					cambiarActivity(false);
				}
			} );

			//run the alert in UI thread to display in the screen
			RunOnUiThread (() => {
				alert.Show();
			} );*/
		}

		public void mostrarMensajeAlerta(){
			AlertDialog.Builder alert = new AlertDialog.Builder (this);
			alert.SetCancelable(false);

			alert.SetTitle ("Advertencia");
			alert.SetMessage ("Si desea salir de la trivia no quedará registrado su progreso, debe terminarla para guardar su puntaje. ¿Desea salir de todas formas?");

			alert.SetPositiveButton ("Si", (senderAlert, args) => {
				base.OnBackPressed ();
				Finish ();
			} );

			alert.SetNegativeButton ("No", (senderAlert, args) => {

			} );

			RunOnUiThread (() => {
				alert.Show();
			} );
		}

		public override void OnBackPressed ()
		{
			mostrarMensajeAlerta ();
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
				editor.Apply ();

				StartActivity(typeof(Login));
				Finish(); 
				return true;

			case Android.Resource.Id.Home:
				
				mostrarMensajeAlerta ();
				return true;

			}
			return base.OnOptionsItemSelected(item);
		}


	}
}

