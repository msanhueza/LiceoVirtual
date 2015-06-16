
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
			imagen.SetImageResource (p.objPregunta.idImagen);
			var respuestaDesordenada = view.FindViewById<TextView>(Resource.Id.frag2_respuesta_desordenada);
			var respuesta = view.FindViewById<TextView>(Resource.Id.frag2_respuesta);

			return view;

		}
	}
}

