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

		ListView listView;
		List<RankingItem> listaRanking = new List<RankingItem>();


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Ranking);

			string ruta = "http://tenis6ta.url.ph/modelo/listar_postre.php";
			//FetchWeatherAsync (ruta);

			listView = FindViewById<ListView>(Resource.Id.listViewRanking);
			RankingItem r1 = new RankingItem ("1-  Francisco Herrera", "7.0");
			RankingItem r2 = new RankingItem ("2-  Mario Sanhueza", "6.6");
			RankingItem r3 = new RankingItem ("3-  Gonzalo Torres", "6.5");
			RankingItem r4 = new RankingItem ("4-  Daniel Lopez", "6.3");
			RankingItem r5 = new RankingItem ("5-  Sebastian del Campo", "6.2");
			RankingItem r6 = new RankingItem ("6-  Felipe Navarro", "6.1");
			RankingItem r7 = new RankingItem ("7-  Juan Perez", "6.0");
			RankingItem r8 = new RankingItem ("8-  Rolando Gonzalez", "5.5");
			RankingItem r9 = new RankingItem ("9-  Jonnathan Osores", "5.4");
			RankingItem r10 = new RankingItem ("10- Felipe Flores", "5.3");
			listaRanking.Add (r1);
			listaRanking.Add (r2);
			listaRanking.Add (r3);
			listaRanking.Add (r4);
			listaRanking.Add (r5);
			listaRanking.Add (r6);
			listaRanking.Add (r7);
			listaRanking.Add (r8);
			listaRanking.Add (r9);
			listaRanking.Add (r10);
			listView.Adapter = new RankingAdapter(this, listaRanking);


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

