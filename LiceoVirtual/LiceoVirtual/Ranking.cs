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
using System.Threading;




namespace LiceoVirtual
{
	[Activity (Label = "Ranking")]			
	public class Ranking : Activity
	{

		ListView listView;
		List<RankingItem> listaRanking = new List<RankingItem>();
		ProgressDialog progressDialog;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Ranking);
			SetTitle (Resource.String.ranking_estudiantes);

			string ruta = "http://tenis6ta.url.ph/modelo/listar_ranking.php";
			//FetchWeatherAsync (ruta);

			listView = FindViewById<ListView>(Resource.Id.listViewRanking);
			GetRanking (ruta);

		}


		private async Task GetRanking(String ruta)
		{
			var progressDialog = ProgressDialog.Show(this, "Espere por favor...", "Cargando Ranking...", true);
			progressDialog.SetCancelable(true);
			progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
			
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (ruta));
			request.ContentType = "application/json";
			request.Method = "GET";

			using (WebResponse response = await request.GetResponseAsync ())
			{
				using (Stream stream = response.GetResponseStream ())
				{
					JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
					JsonArray ResName = (JsonArray)JsonArray.Parse (jsonDoc.ToString ());
					for (int i = 0; i < ResName.Count; i++) {
						var jsonObj = ResName [i];
						var nombre = jsonObj["nombre"];
						var puntaje = jsonObj["puntaje"];
						RankingItem r = new RankingItem ( (i+1) + "- " + nombre, puntaje+"%");
						listaRanking.Add (r);
					}
					listView.Adapter = new RankingAdapter(this, listaRanking);
					progressDialog.Hide ();
				}
			}

		}
	}
}

