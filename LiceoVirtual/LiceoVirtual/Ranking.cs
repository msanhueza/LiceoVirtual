
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
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;




namespace LiceoVirtual
{
	[Activity (Label = "Ranking")]			
	public class Ranking : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Ranking);

			string ruta = "http://tenis6ta.url.ph/modelo/listar_postre.php";
			FetchWeatherAsync (ruta);

			// Create your application here
		}
			

		private async Task<JsonValue> FetchWeatherAsync (string url)
		{

			// Create an HTTP web request using the URL:
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
			request.ContentType = "application/json";
			request.Method = "GET";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync ())
			{
				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream ())
				{
					// Use this stream to build a JSON document object:
					JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
					Console.Out.WriteLine("Response: {0}", jsonDoc.ToString ());
					Toast.MakeText (this, jsonDoc.ToString(), ToastLength.Long).Show();
					//var theJsonArray = JsonArray.Parse(jsonDoc.ToString());
					//Console.Out.WriteLine("Response: {0}", theJsonArray.Count.ToString());

					return jsonDoc;
				}
			}

		}
	}
}

