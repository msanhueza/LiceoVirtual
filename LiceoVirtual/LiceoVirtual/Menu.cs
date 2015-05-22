
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
using Android.Telephony.Gsm;
using System.Threading.Tasks;

namespace LiceoVirtual
{
	[Activity (Label = "Menu")]			
	public class Menu : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Menu);

			Button btnTrivia = FindViewById<Button> (Resource.Id.btnTrivia);
			Button btnRanking = FindViewById<Button> (Resource.Id.btnRanking);
			Button btnCerrarSesion = FindViewById<Button> (Resource.Id.btnCerrarSesion);

			getPreguntasAleatorias (20);

			btnTrivia.Click += delegate {
				StartActivity (typeof(Nivel));
			};

			btnRanking.Click += delegate {
				StartActivity (typeof(Ranking));
			};

			cargarBD();

			btnCerrarSesion.Click += delegate {
				
				ISharedPreferences pref = Application.Context.GetSharedPreferences ("UserInfo", FileCreationMode.Private);
				ISharedPreferencesEditor editor = pref.Edit ();
				editor.PutString ("idUsuario", String.Empty);
				editor.PutString ("nombre", String.Empty);
				editor.PutBoolean ("guardar", false);
				//editor.PutBoolean ("estaCargadaBD", false);
				editor.Apply ();

				StartActivity(typeof(Login));
				Finish(); 
			};
		}

		public List<int> getPreguntasAleatorias(int n){
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
			for (int x = 0; x < listaNumeros.Count; x++) {
				Console.WriteLine(listaNumeros[x].ToString());
			}
			return listaNumeros;



		}

		public async Task cargarBD(){

			ISharedPreferences pref = Application.Context.GetSharedPreferences ("UserInfo", FileCreationMode.Private);
			bool estaCargadaBD = pref.GetBoolean ("estaCargadaBD", false);

			if (!estaCargadaBD) {
				CargarBaseDeDatos c = new CargarBaseDeDatos ();

				ISharedPreferencesEditor editor = pref.Edit ();
				editor.PutBoolean ("estaCargadaBD", true);
				editor.Apply ();
			}

		}
		/* con licencia se puede hacer de esta forma los listener de los botones
		[Java.Interop.Export("onClickTrivia")] // The value found in android:onClick attribute.
		public void onClickTrivia(View v)
		{
			var intent = new Intent (this, typeof(Nivel));
			intent.PutExtra ("nombre", "Mario Sanhueza");
			StartActivity (intent); 	
		}*/
	}
}

