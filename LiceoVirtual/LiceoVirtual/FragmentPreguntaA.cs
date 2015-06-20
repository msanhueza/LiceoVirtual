
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
	public class FragmentPreguntaA : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.FragmentPreguntaA, container, false);
			var myActivity = (Pregunta)this.Activity;
			ListadoPreguntaSolucionItem p = myActivity.getPreguntaActual ();

			var pregunta = view.FindViewById<TextView>(Resource.Id.frag1_pregunta);
			var imagen = view.FindViewById<ImageView> (Resource.Id.frag1_imagen);
			var radioGroup = view.FindViewById<RadioGroup> (Resource.Id.frag1_radio_group);
			var radio1 = view.FindViewById<RadioButton> (Resource.Id.frag1_radio1);
			var radio2 = view.FindViewById<RadioButton> (Resource.Id.frag1_radio2);
			var radio3 = view.FindViewById<RadioButton> (Resource.Id.frag1_radio3);

			radio1.Click += RadioButtonClick;
			radio2.Click += RadioButtonClick;
			radio3.Click += RadioButtonClick;

			radio1.Checked = false;
			radio2.Checked = false;
			radio3.Checked = false;

			pregunta.Text = p.objPregunta.pregunta;
			imagen.SetImageResource (p.objPregunta.idImagen);
			radio1.Text = p.objListaRespuestas [0].solucion;
			radio2.Text = p.objListaRespuestas [1].solucion;
			radio3.Text = p.objListaRespuestas [2].solucion;

			return view;

		}

		private void RadioButtonClick (object sender, EventArgs e)
		{
			RadioButton radioButtonSeleccionado = (RadioButton)sender;
			radioButtonSeleccionado.Checked = true;

			var myActivity = (Pregunta)this.Activity;
			ListadoPreguntaSolucionItem p = myActivity.getPreguntaActual ();
			ResultadoRespuestaItem resultado = comprobarRespuesta (p.objListaRespuestas);
     
			mostrarResultado(resultado.respuesta, radioButtonSeleccionado, resultado.esCorrecta);
			myActivity.habilitarButtonSiguiente (true);

		}

		public ResultadoRespuestaItem comprobarRespuesta(List<PreguntaSolucionItem> listaRespuestas){
			ResultadoRespuestaItem rri;
			string auxSol = "";
			RadioGroup radioGroup = View.FindViewById<RadioGroup> (Resource.Id.frag1_radio_group);
			int idRadioButtonSeleccionado = radioGroup.CheckedRadioButtonId;
			RadioButton radioButtonSeleccionado = View.FindViewById<RadioButton> (idRadioButtonSeleccionado);
			String respuesta = radioButtonSeleccionado.Text;
			for (int i = 0; i<listaRespuestas.Count; i++) {
				if(listaRespuestas[i].esSolucion){
					auxSol = listaRespuestas[i].solucion;
					if (( auxSol ).Equals (respuesta)) {
						rri = new ResultadoRespuestaItem (true, auxSol);
						return rri;
					}
				}
			}
			rri = new ResultadoRespuestaItem (false, auxSol);
			return rri;
		}

		public void mostrarResultado(string resultado, RadioButton radioButtonSeleccionado, bool esCorrecta){
			RadioButton radio1 = View.FindViewById<RadioButton> (Resource.Id.frag1_radio1);
			RadioButton radio2 = View.FindViewById<RadioButton> (Resource.Id.frag1_radio2);
			RadioButton radio3 = View.FindViewById<RadioButton> (Resource.Id.frag1_radio3);
			string r1 = radio1.Text;
			string r2 = radio2.Text;
			string r3 = radio3.Text;
			radio1.Enabled = false;
			radio2.Enabled = false;
			radio3.Enabled = false;
			if(r1.Equals(resultado)){
				radio1.Text = "(Respuesta Correcta) - " + r1;
				radio1.SetTextColor(Android.Graphics.Color.Green);
			}
			else if(r2.Equals(resultado)){
				radio2.Text = "(Respuesta Correcta) - " + r2;
				radio2.SetTextColor(Android.Graphics.Color.Green);
			}
			else{ // r3 es igual al resultado
				radio3.Text = "(Respuesta Correcta) - " + r3;
				radio3.SetTextColor(Android.Graphics.Color.Green);
			}

			if (!esCorrecta) { // SOLO si la respuesta NO ES CORRECTA, se pinta en rojo
				radioButtonSeleccionado.Text = "(Respuesta Incorrecta) - " + radioButtonSeleccionado.Text;
				radioButtonSeleccionado.SetTextColor (Android.Graphics.Color.Red);
			}

		}
			
	}
}

