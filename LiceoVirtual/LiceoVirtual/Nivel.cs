
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
	[Activity (Label = "Nivel")]			
	public class Nivel : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Nivel);

			Button btn1 = FindViewById<Button> (Resource.Id.btn1);
			Button btn2 = FindViewById<Button> (Resource.Id.btn2);
			Button btn3 = FindViewById<Button> (Resource.Id.btn3);
			Button btn4 = FindViewById<Button> (Resource.Id.btn4);

			btn1.Click += delegate {
				var intent = new Intent (this, typeof(Puntuacion));
				intent.PutExtra ("nivel", "1");
				StartActivity (intent);
			};

			btn2.Click += delegate {
				var intent = new Intent (this, typeof(Puntuacion));
				intent.PutExtra ("nivel", "2");
				StartActivity (intent);
			};

			btn3.Click += delegate {
				var intent = new Intent (this, typeof(Puntuacion));
				intent.PutExtra ("nivel", "3");
				StartActivity (intent);
			};

			btn4.Click += delegate {
				var intent = new Intent (this, typeof(Puntuacion));
				intent.PutExtra ("nivel", "4");
				StartActivity (intent);
			};

			// Create your application here
		}
	}
}

