
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
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Pregunta);

			string nivel = Intent.GetStringExtra ("nivel") ?? "0";

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

			btnPreguntaSiguiente.Click += delegate {
				StartActivity (typeof(MensajeResultado));
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
				List<PreguntaSolucionItem> listaPreguntaSolucion = ps.getPreguntasSolucionBD (pregunta.ID);
				ListadoPreguntaSolucionItem item = new ListadoPreguntaSolucionItem (pregunta, listaPreguntaSolucion);
				resultado.Add (item);
			}
			return resultado;
		}
	}
}

