
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
			pregunta.Text = p.objPregunta.pregunta;
			var imagen = view.FindViewById<ImageView> (Resource.Id.frag1_imagen);
			imagen.SetImageResource (p.objPregunta.idImagen);
			var radioGroup = view.FindViewById<RadioGroup> (Resource.Id.frag1_radio_group);
			var radio1 = view.FindViewById<RadioButton> (Resource.Id.frag1_radio1);
			radio1.Text = p.objListaRespuestas [0].solucion;
			var radio2 = view.FindViewById<RadioButton> (Resource.Id.frag1_radio2);
			radio2.Text = p.objListaRespuestas [1].solucion;
			var radio3 = view.FindViewById<RadioButton> (Resource.Id.frag1_radio3);
			radio3.Text = p.objListaRespuestas [2].solucion;
			return view;

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
						rri = new ResultadoRespuestaItem (true, "");
						return rri;
					}
				}
			}
			rri = new ResultadoRespuestaItem (false, auxSol);
			return rri;
		}

		public void habilitarRadiosButton(){
			RadioButton radioOp1 = View.FindViewById<RadioButton> (Resource.Id.frag1_radio1);
			RadioButton radioOp2 = View.FindViewById<RadioButton> (Resource.Id.frag1_radio2);
			RadioButton radioOp3 = View.FindViewById<RadioButton> (Resource.Id.frag1_radio3);			
			radioOp1.Checked = true; // para dejar siempre el primer radio button seleccionado
			radioOp1.SetTextColor(Android.Graphics.Color.Black);
			radioOp2.SetTextColor(Android.Graphics.Color.Black);
			radioOp3.SetTextColor(Android.Graphics.Color.Black);
			radioOp1.Enabled = true;
			radioOp2.Enabled = true;
			radioOp3.Enabled = true;
		}

		public void mostrarResultado(string resultado){
			RadioButton radioOp1 = View.FindViewById<RadioButton> (Resource.Id.frag1_radio1);
			RadioButton radioOp2 = View.FindViewById<RadioButton> (Resource.Id.frag1_radio2);
			RadioButton radioOp3 = View.FindViewById<RadioButton> (Resource.Id.frag1_radio3);
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

		}
	}
}

