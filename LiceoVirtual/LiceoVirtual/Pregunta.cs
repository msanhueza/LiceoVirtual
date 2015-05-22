
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
	}
}

