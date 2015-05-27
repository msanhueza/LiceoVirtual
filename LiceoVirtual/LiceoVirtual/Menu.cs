
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
using System.Threading;

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

			btnTrivia.Click += delegate {
				StartActivity (typeof(Nivel));
			};

			btnRanking.Click += delegate {
				StartActivity (typeof(Ranking));
			};				

			cargarBD ();

		}

		public void cargarBD(){
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

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
			return base.OnCreateOptionsMenu(menu);
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
			}
			return base.OnOptionsItemSelected(item);
		}

	}
}

