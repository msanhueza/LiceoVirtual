using SQLite;
using LiceoVirtual;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

public class PuntuacionAccion
{
	
	string docsFolder;
	string pathToDatabase;

	public PuntuacionAccion(){
		docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
		pathToDatabase = System.IO.Path.Combine(docsFolder, "liceo_virtual.db");
	}

	public string insertUpdateData(PuntuacionBD data)
	{
		try
		{
			var db = new SQLiteConnection(pathToDatabase);
			if (db.Insert(data) != 0)
				db.Update(data);
			return "Insertado o Actualizado";
		}
		catch (SQLiteException ex)
		{
			return ex.Message;
		}
	}

	public List<PuntuacionItem> getPuntuacionesBD(string nivel)
	{
		try
		{
			var db = new SQLiteConnection(pathToDatabase);
			var lista = db.Query<PuntuacionBD>("SELECT * FROM PuntuacionBD " +
				"WHERE nivel=" + nivel + " " +
				"ORDER BY puntaje DESC");
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

	public int findNumberRecords()
	{
		try
		{
			var db = new SQLiteConnection(pathToDatabase);
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

	public int getPuntuacionLess80(string nivel){
		try
		{
			var db = new SQLiteConnection(pathToDatabase);
			// this counts all records in the database, it can be slow depending on the size of the database
			var count = db.ExecuteScalar<int>("SELECT Count(*) FROM PuntuacionBD " +
				"WHERE nivel=" + nivel+" AND puntaje < 80");

			return count;
		}
		catch (SQLiteException)
		{
			return -1;
		}
	}

	public int getPuntuacionMore80(string nivel){
		try
		{
			var db = new SQLiteConnection(pathToDatabase);
			// this counts all records in the database, it can be slow depending on the size of the database
			var count = db.ExecuteScalar<int>("SELECT Count(*) FROM PuntuacionBD " +
				"WHERE nivel=" + nivel+" AND puntaje >= 80");

			return count;
		}
		catch (SQLiteException)
		{
			return -1;
		}
	}


}


