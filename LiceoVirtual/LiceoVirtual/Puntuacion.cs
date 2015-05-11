
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
using SQLite;

namespace LiceoVirtual
{
	[Activity (Label = "Puntuacion")]			
	public class Puntuacion : Activity
	{

		ListView listView;
		List<PuntuacionItem> listaPuntuaciones = new List<PuntuacionItem>();


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Puntuacion);


			string nivel = Intent.GetStringExtra ("nivel") ?? "0";

			var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var pathToDatabase = System.IO.Path.Combine(docsFolder, "liceo_virtual.db");

			var result = createDatabase(pathToDatabase);
			//Toast.MakeText (this, result.ToString(), ToastLength.Short).Show();

			//var result2 = insertUpdateData(new PuntuacionBD{ IdUsuario= "1", nivel="1", fecha= DateTime.Now.ToString(), puntaje="123" }, pathToDatabase);
			//var records = findNumberRecords(pathToDatabase);
			//Toast.MakeText (this, getPuntuacionesBD(pathToDatabase).Count.ToString(), ToastLength.Short).Show();

			listView = FindViewById<ListView>(Resource.Id.listViewPuntuacion);
			//listaPuntuaciones = getPuntuacionesBD (pathToDatabase, nivel);
			PuntuacionItem p1 = new PuntuacionItem("11/05/2015", "7.0");
			PuntuacionItem p2 = new PuntuacionItem("10/05/2015", "7.0");
			PuntuacionItem p3 = new PuntuacionItem("08/05/2015", "6.0");
			PuntuacionItem p4 = new PuntuacionItem("05/05/2015", "5.4");
			listaPuntuaciones.Add (p1);
			listaPuntuaciones.Add (p2);
			listaPuntuaciones.Add (p3);
			listaPuntuaciones.Add (p4);
			listView.Adapter = new PuntuacionAdapter(this, listaPuntuaciones);

			Button btnIrTrivia = FindViewById<Button> (Resource.Id.btnIrTrivia);


			btnIrTrivia.Click += delegate {
				var intent = new Intent (this, typeof(Pregunta));
				intent.PutExtra ("nivel", nivel);
				StartActivity (intent);				
			};


			// Create your application here
		}

		private string createDatabase(string path)
		{
			try
			{
				var connection = new SQLiteConnection(path);
				connection.CreateTable<PuntuacionBD>();
				return "BD creada";
			}
			catch (SQLiteException ex)
			{
				return ex.Message;
			}
		}

		private string insertUpdateData(PuntuacionBD data, string path)
		{
			try
			{
				var db = new SQLiteConnection(path);
				if (db.Insert(data) != 0)
					db.Update(data);
				return "Insertado o Actualizado";
			}
			catch (SQLiteException ex)
			{
				return ex.Message;
			}
		}

		private List<PuntuacionItem> getPuntuacionesBD(string path, String nivel)
		{
			try
			{
				var db = new SQLiteConnection(path);
				var lista = db.Query<PuntuacionBD>("SELECT * FROM PuntuacionBD WHERE nivel="+nivel);
				List<PuntuacionItem> listaPuntuaciones = new List<PuntuacionItem>();
				for(int i=0; i<lista.Count; i++){
					var fecha = lista[i].fecha;
					var puntaje = lista[i].puntaje;
					PuntuacionItem p = new PuntuacionItem(fecha, puntaje);
					listaPuntuaciones.Add(p);
				}
				return listaPuntuaciones;
			}
			catch (SQLiteException)
			{
				return null;
			}
		}

		private int findNumberRecords(string path)
		{
			try
			{
				var db = new SQLiteConnection(path);
				// this counts all records in the database, it can be slow depending on the size of the database
				var count = db.ExecuteScalar<int>("SELECT Count(*) FROM PuntuacionBD");

				// for a non-parameterless query
				// var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Person WHERE FirstName="Amy");

				return count;
			}
			catch (SQLiteException)
			{
				return -1;
			}
		}


	}

}

