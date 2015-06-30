
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
		public static FragmentPreguntaA fragmentPreguntaA;
		public static FragmentPreguntaB fragmentPreguntaB;
		public static bool preguntaA;
		public static int indicePregunta;
		public static List<ListadoPreguntaSolucionItem> listadoPreguntas;
		public static int progreso;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Pregunta);
			preguntaA = true;
			fragmentPreguntaA = new FragmentPreguntaA ();
			fragmentPreguntaB = new FragmentPreguntaB ();
			indicePregunta = 0;

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
			TextView tvProgreso = FindViewById<TextView> (Resource.Id.tvProgreso);
			TextView tvCorrectas = FindViewById<TextView> (Resource.Id.tvCorrectas);
			TextView tvIncorrectas = FindViewById<TextView> (Resource.Id.tvIncorrectas);

			progreso = 10; 
			buenas = 0;
			malas = 0;
			tvCorrectas.Text = "CORRECTAS: " + buenas+"/10";
			tvIncorrectas.Text = "INCORRECTAS: " + malas+"/2";
			pbPregunta.Progress = progreso;
			tvProgreso.Text = "Pregunta: " + (numPregunta + 1) + " / 10";




			int auxNivel = Int32.Parse(nivel);
			listadoPreguntas = getListadoPreguntaSolucion (auxNivel);

			//obtengo la respuesta correcta de la pregunta actual
			ListadoPreguntaSolucionItem preguntaActual = getPreguntaActual ();	
			string respuestaActual = obtenerRespuesta (preguntaActual.objListaRespuestas);

			//Decido si ocupo fragment A o B para la primera pregunta
			if (getTipoFragment (respuestaActual) == 1) {
				mostrarFragmentA ();
			}
			else{
				mostrarFragmentB ();
			}
			//else if(getTipoFragment (respuestaActual) == 3){
			//	mostrarFragmentC ();
			//}


			habilitarButtonSiguiente (false);

			btnPreguntaSiguiente.Click += delegate {
				indicePregunta++;
				preguntaActual = getPreguntaActual ();
				respuestaActual = obtenerRespuesta (preguntaActual.objListaRespuestas);
				if(malas == 2 && buenas<10){
					cambiarActivity(false);
				}
				else{
					if(indicePregunta == 10){
						cambiarActivity(true);
					}

					actualizarProgressBar();
					habilitarButtonSiguiente (false);
					if(indicePregunta == 9){
						btnPreguntaSiguiente.Text = "Terminar";
					}
					if(indicePregunta < 10){        //Decido si ocupo fragment A o B
						if (getTipoFragment (respuestaActual) == 1) {
							mostrarFragmentA ();
						}
						else if(getTipoFragment (respuestaActual) == 2){
							mostrarFragmentB ();
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

		public void incrementarRespuestasBuenas(){
			buenas++;

			TextView tvCorrectas = FindViewById<TextView> (Resource.Id.tvCorrectas);
			TextView tvIncorrectas = FindViewById<TextView> (Resource.Id.tvIncorrectas);

			tvCorrectas.Text = "CORRECTAS: " + buenas+"/10";
			tvIncorrectas.Text = "INCORRECTAS: " + malas+"/2";
		}

		public void actualizarProgressBar(){
			ProgressBar pbPregunta = FindViewById<ProgressBar> (Resource.Id.pbPregunta);
			TextView tvProgreso = FindViewById<TextView> (Resource.Id.tvProgreso);

			progreso += 10;
			pbPregunta.Progress = progreso;
			tvProgreso.Text = "Pregunta: " + (indicePregunta + 1) + " / 10";

		}

		public void incrementarRespuestasMalas(){
			malas++;
			TextView tvCorrectas = FindViewById<TextView> (Resource.Id.tvCorrectas);
			TextView tvIncorrectas = FindViewById<TextView> (Resource.Id.tvIncorrectas);

			tvCorrectas.Text = "CORRECTAS: " + buenas+"/10";
			tvIncorrectas.Text = "INCORRECTAS: " + malas+"/2";
		}

		public int getBuenas(){
			return buenas;
		}

		public int getMalas(){
			return malas;
		}

		public ListadoPreguntaSolucionItem getPreguntaActual(){
			ListadoPreguntaSolucionItem p = listadoPreguntas[indicePregunta];
			return p;
		}

		public void habilitarButtonSiguiente(bool habilitar){
			Button btnPreguntaSiguiente = FindViewById<Button> (Resource.Id.btnPreguntaSiguiente);
			if (habilitar) {
				btnPreguntaSiguiente.Enabled = true;
				btnPreguntaSiguiente.Visibility = ViewStates.Visible;
			} else {
				btnPreguntaSiguiente.Enabled = false;
				btnPreguntaSiguiente.Visibility = ViewStates.Gone;
			}
		}

		public void cambiarTextoBotonSiguiente(string mensaje){
			Button btnPreguntaSiguiente = FindViewById<Button> (Resource.Id.btnPreguntaSiguiente);
			btnPreguntaSiguiente.Text = mensaje;
		}

		public void mostrarFragmentA(){
			FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
			fragmentPreguntaA = new FragmentPreguntaA();
			fragmentTx.Replace(Resource.Id.fragment_container, fragmentPreguntaA);
			//fragmentTx.AddToBackStack(null);
			fragmentTx.Commit();
		}

		public void mostrarFragmentB(){
			FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
			fragmentPreguntaB = new FragmentPreguntaB();
			fragmentTx.Replace(Resource.Id.fragment_container, fragmentPreguntaB);
			//fragmentTx.AddToBackStack(null);
			fragmentTx.Commit();
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

		/**
		 * Funcion que retorna la respuesta correcta desde un listado de respuestas
		 * de una pregunta actual
		 * */
		public string obtenerRespuesta(List<PreguntaSolucionItem> lista){
			for(int i=0; i<lista.Count; i++){
				if(lista[i].esSolucion){
					return lista [i].solucion;
				}
			}
			return "";
		}

		/**
		 * Funcion que retorna 1, 2 o 3 si la respuesta es para el fragment A, B, C
		 * */
		public int getTipoFragment(string respuesta)
		{
			//tiene una sola palabra sin saber si tiene caracateres raros
			string[] palabras = respuesta.Split(' ');
			int npalabras = palabras.Count();
			if (npalabras == 1) {
				//si es un numero Romano
				if (palabras [0].Equals ("I") ||
				    palabras [0].Equals ("II") ||
				    palabras [0].Equals ("III") ||
				    palabras [0].Equals ("IV") ||
				    palabras [0].Equals ("Ninguna")) {
					return 1;
				} else if (Regex.IsMatch (respuesta, @"^[a-zA-Z]+$")) {
					return 2;
				}


			}
			else 
			{
				//numero Romano
				if (palabras [0].Equals ("I") ||
					palabras [0].Equals ("II") ||
					palabras [0].Equals ("III") ||
					palabras [0].Equals ("IV") ||
					palabras [0].Equals ("Ninguna")) {
					return 1;
				} 
				//palabras humanas de mas de una letra
				else if (palabras[0].Count() >1 && Regex.IsMatch (respuesta, @"^[a-zA-Z ]+$")) {
					return 3;
				}


			}
			return 1;

		}

	}

}

