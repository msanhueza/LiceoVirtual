
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Util;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.Globalization;
using System.Threading.Tasks;
using Android.Content.PM;

namespace LiceoVirtual
{
	[Activity (Label = "Puntaje", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class Puntuacion : Activity, ActionBar.ITabListener
	{
		Fragment[] _fragments;



		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			SetContentView (Resource.Layout.PuntuacionTabs);

			ActionBar.SetHomeButtonEnabled(true);
			ActionBar.SetDisplayHomeAsUpEnabled(true);


			_fragments = new Fragment[] {
				PuntuacionFragment.NewInstance ("1"),
				PuntuacionFragment.NewInstance ("2"),
				PuntuacionFragment.NewInstance ("3"),
				PuntuacionFragment.NewInstance ("4")
			};
			AddTabToActionBar (Resource.String.nivel_1);
			AddTabToActionBar (Resource.String.nivel_2);
			AddTabToActionBar (Resource.String.nivel_3);
			AddTabToActionBar (Resource.String.nivel_4);



		}
		void AddTabToActionBar (int labelResourceId)
		{
			ActionBar.Tab tab = this.ActionBar.NewTab ()
				.SetText (labelResourceId)

				.SetTabListener (this);
			this.ActionBar.AddTab (tab);
		}

		public void OnTabSelected (ActionBar.Tab tab, FragmentTransaction ft)
		{
			FragmentManager.PopBackStack (null,PopBackStackFlags.Inclusive);

			Log.Debug ("OnTabSelected", "The tab {0} has been selected.", tab.Text);
			Fragment frag = _fragments [tab.Position];
			ft.Replace (Resource.Id.content_frame, frag);
		}

		public void OnTabReselected (ActionBar.Tab tab, FragmentTransaction ft)
		{
			Log.Debug ("OnTabReselected", "The tab {0} was re-selected.", tab.Text);
		}

		public void OnTabUnselected (ActionBar.Tab tab, FragmentTransaction ft)
		{
			// perform any extra work associated with saving fragment state here.
			Log.Debug ("OnTabUnselected", "The tab {0} as been unselected.", tab.Text);
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
				Finish();
				return true;

			}
			return base.OnOptionsItemSelected(item);
		}
			

	}

}

