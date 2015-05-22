
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

			// Create your application here
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
	}
}

