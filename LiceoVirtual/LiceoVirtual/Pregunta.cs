
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
	[Activity (Label = "Pregunta")]			
	public class Pregunta : Activity
	{

		public static int numPregunta;
		public static string nivel;

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
			RadioButton radioOp1 = FindViewById<RadioButton> (Resource.Id.rbOp1);
			RadioButton radioOp2 = FindViewById<RadioButton> (Resource.Id.rbOp2);
			RadioButton radioOp3 = FindViewById<RadioButton> (Resource.Id.rbOp3);

			int progreso = 10;
			pbPregunta.Progress = progreso;
			numPregunta = 0;
			tvProgreso.Text = (numPregunta + 1) + " / 10";

			List<ListadoPreguntaSolucionItem> aux = getListadoPreguntaSolucion (1);

			ListadoPreguntaSolucionItem p = aux[numPregunta];
			string textPregunta = p.objPregunta.pregunta;
			string opcion1 = p.objListaRespuestas[0].solucion;
			string opcion2 = p.objListaRespuestas[1].solucion;
			string opcion3 = p.objListaRespuestas[2].solucion;
			tvPregunta.Text = textPregunta;
			radioOp1.Text = opcion1;
			radioOp2.Text = opcion2;
			radioOp3.Text = opcion3;

			btnPreguntaSiguiente.Click += delegate {
				radioOp1.Checked = true; // para dejar siempre el primer radio button seleccionado
				bool resp = comprobarRespuesta(p.objListaRespuestas);
				Toast.MakeText (this, resp.ToString(), ToastLength.Short).Show();
				if(numPregunta == 9){
					var intent = new Intent (this, typeof(MensajeResultado));
					intent.PutExtra ("nivel", nivel);
					StartActivity (intent);
					Finish ();
				}
				else{
					numPregunta++;
					progreso = progreso + 10;
					pbPregunta.Progress = progreso;
					tvProgreso.Text = (numPregunta + 1) + " / 10";
					p = aux[numPregunta];
					textPregunta = p.objPregunta.pregunta;
					opcion1 = p.objListaRespuestas[0].solucion;
					opcion2 = p.objListaRespuestas[1].solucion;
					opcion3 = p.objListaRespuestas[2].solucion;
					tvPregunta.Text = textPregunta;
					radioOp1.Text = opcion1;
					radioOp2.Text = opcion2;
					radioOp3.Text = opcion3;
					if(numPregunta == 9){
						btnPreguntaSiguiente.Text = "Terminar";
					}




				}
			};
				
			/*List<ListadoPreguntaSolucionItem> aux = getListadoPreguntaSolucion (1);
			for (int i = 0; i < aux.Count; i++) {
				Console.WriteLine ("");
				Console.WriteLine (aux[i].objPregunta.pregunta);
				List<PreguntaSolucionItem> lista = aux[i].objListaRespuestas;
				for (int j = 0; j < lista.Count; j++) {
					Console.WriteLine (lista[j].solucion + " " + lista[j].esSolucion);
				}
				Console.WriteLine ("");
			}*/

		}

		public bool comprobarRespuesta(List<PreguntaSolucionItem> listaRespuestas){
			RadioGroup radioGroup = FindViewById<RadioGroup> (Resource.Id.radioGroup1);
			int idRadioButtonSeleccionado = radioGroup.CheckedRadioButtonId;
			RadioButton radioButtonSeleccionado = FindViewById<RadioButton> (idRadioButtonSeleccionado);
			String respuesta = radioButtonSeleccionado.Text;
			for (int i = 0; i<listaRespuestas.Count; i++) {
				if(listaRespuestas[i].esSolucion){
					string auxSol = listaRespuestas [i].solucion;
					if (( auxSol ).Equals (respuesta)) {
						return true;
					}
				}
			}
			return false;
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

		public void mostrarMensajeAlerta(){
			AlertDialog.Builder alert = new AlertDialog.Builder (this);
			alert.SetCancelable(false);

			alert.SetTitle ("Advertencia");
			alert.SetMessage ("Si desea salir de la trivia no quedará registrado su progreso, debe terminarla para guardar su puntaje. ¿Desea salir de todas formas?");

			alert.SetPositiveButton ("Si", (senderAlert, args) => {
				base.OnBackPressed ();
				//var intent = new Intent (this, typeof(Puntuacion));
				//intent.PutExtra ("nivel", nivel);
				//StartActivity (typeof(Nivel));
				Finish ();
			} );

			alert.SetNegativeButton ("No", (senderAlert, args) => {

			} );
			//run the alert in UI thread to display in the screen
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
				//editor.PutBoolean ("estaCargadaBD", false);
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

