
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace LiceoVirtual
{
	public class FragmentPreguntaB : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.FragmentPreguntaB, container, false);
			var myActivity = (Pregunta)this.Activity;
			ListadoPreguntaSolucionItem p = myActivity.getPreguntaActual ();
			var pregunta = view.FindViewById<TextView>(Resource.Id.frag2_pregunta);
			pregunta.Text = p.objPregunta.pregunta;
			var imagen = view.FindViewById<ImageView> (Resource.Id.frag2_imagen);
			if(p.objPregunta.idImagen != -1){
				imagen.SetImageResource (p.objPregunta.idImagen);
			}
			var respuestaDesordenada = view.FindViewById<TextView>(Resource.Id.frag2_respuesta_desordenada);
			respuestaDesordenada.SetTextColor (Android.Graphics.Color.Green);
			string respuestaCorrecta = obtenerRespuesta (p.objListaRespuestas).ToUpper();
			string[] respuestaPorPalabra = respuestaCorrecta.Split (' ');
			string auxRespuestaDesordenada = "";
			for (int i = 0; i<respuestaPorPalabra.Count(); i++) {
				auxRespuestaDesordenada = auxRespuestaDesordenada + " " + swap(respuestaPorPalabra[i]);
			}
			respuestaDesordenada.Text = auxRespuestaDesordenada;
			var respuesta = view.FindViewById<EditText>(Resource.Id.frag2_respuesta);
			Button botonComprobar = view.FindViewById<Button> (Resource.Id.frag2_comprobar);
			EditText editTextRespuesta = view.FindViewById <EditText> (Resource.Id.frag2_respuesta);
			botonComprobar.Click += delegate {
				string respuestaJugador = editTextRespuesta.Text.ToUpper();
				bool esCorrecta = comprobarRespuesta(respuestaCorrecta, respuestaJugador);
				botonComprobar.Enabled = false;
				editTextRespuesta.Enabled = false;
				myActivity.habilitarButtonSiguiente(true);
				if(esCorrecta){
					Toast.MakeText (myActivity, "CORRECTA", ToastLength.Long).Show();
					myActivity.incrementarRespuestasBuenas ();
				}
				else{
					Toast.MakeText (myActivity, "INCORRECTA", ToastLength.Long).Show();
					myActivity.incrementarRespuestasMalas ();
				}
			};
			return view;

		}

		public bool comprobarRespuesta(string respuesta1, string respuesta2){
			if(respuesta1.Equals(respuesta2)){
				return true;
			}
			return false;
		}

		public string swap(string palabra){
			if (palabra.Count () > 1) {
				Random r = new Random ();
				int val1 = r.Next (0, palabra.Count ());
				int val2 = 0;
				do {
					val2 = r.Next (0, palabra.Count ());
				} while(val1 == val2);
				Char[] array = palabra.ToCharArray ();
				char aux = array [val2];
				array [val2] = array [val1];
				array [val1] = aux;
				return new string(array);
			} else {
				return palabra;
			}
		}

		public string obtenerRespuesta(List<PreguntaSolucionItem> lista){
			for(int i=0; i<lista.Count; i++){
				if(lista[i].esSolucion){
					return lista [i].solucion;
				}
			}
			return "";
		}
	}
}

