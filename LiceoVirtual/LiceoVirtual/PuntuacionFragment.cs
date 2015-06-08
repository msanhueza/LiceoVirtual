
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
	public class PuntuacionFragment : Fragment
	{


		public static PuntuacionFragment NewInstance (string nivel)
		{
			var detailsFrag = new PuntuacionFragment { Arguments = new Bundle () };
			detailsFrag.Arguments.PutString ("nivel", nivel);
			return detailsFrag;
		}

		TextView aprovadasTextView;
		TextView desaprovadasTextView;


		public String nivel {
			get { return Arguments.GetString ("nivel", "0"); }
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			if (container == null) {
				// Currently in a layout without a container, so no reason to create our view.
				return null;
			}

			var view = inflater.Inflate(Resource.Layout.PuntuacionFragment, container, false);
			PuntuacionAccion p = new PuntuacionAccion ();

			int aprovadas = p.getPuntuacionMore80 (nivel);
			int desaprovadas = p.getPuntuacionLess80 (nivel);


			aprovadasTextView = view.FindViewById<TextView> (Resource.Id.aprovadas);
			aprovadasTextView.Text = ""+aprovadas;


			desaprovadasTextView = view.FindViewById<TextView> (Resource.Id.desaprovadas);
			desaprovadasTextView.Text = ""+desaprovadas;



			return view;
		}


	}
}

