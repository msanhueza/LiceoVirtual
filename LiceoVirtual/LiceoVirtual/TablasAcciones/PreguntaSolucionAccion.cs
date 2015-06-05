using SQLite;
using LiceoVirtual;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

public class PreguntaSolucionAccion
{

	string docsFolder;
	string pathToDatabase;

	public PreguntaSolucionAccion(){
		docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
		pathToDatabase = System.IO.Path.Combine(docsFolder, "liceo_virtual.db");
	}

	public string insertUpdateData(PreguntaSolucionBD data)
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

	public List<PreguntaSolucionItem> getPreguntasSolucionBD(int idPregunta)
	{
		try
		{
			var db = new SQLiteConnection(pathToDatabase);
			var lista = db.Query<PreguntaSolucionBD>("SELECT * FROM PreguntaSolucionBD " +
				"WHERE idPregunta=" + idPregunta);
			List<PreguntaSolucionItem> listaPreguntasSolucion = new List<PreguntaSolucionItem>();
			for(int i=0; i<lista.Count; i++){
				var ID = lista[i].ID;
				var iDPregunta = lista[i].idPregunta;
				var solucion = lista[i].solucion;
				var esSolucion = lista[i].esSolucion;
				PreguntaSolucionItem p = new PreguntaSolucionItem(ID, iDPregunta, solucion, esSolucion);
				listaPreguntasSolucion.Add(p);
			}
			return listaPreguntasSolucion;
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
			var count = db.ExecuteScalar<int>("SELECT Count(*) FROM PreguntaSolucionBD");

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

