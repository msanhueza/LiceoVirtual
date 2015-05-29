using SQLite;
using LiceoVirtual;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

public class PreguntaAccion
{

	string docsFolder;
	string pathToDatabase;

	public PreguntaAccion(){
		docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
		pathToDatabase = System.IO.Path.Combine(docsFolder, "liceo_virtual.db");
	}

	public string insertUpdateData(PreguntaBD data)
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

	public List<PreguntaItem> getPreguntasBD(int nivel)
	{
		try
		{
			var db = new SQLiteConnection(pathToDatabase);
			var lista = db.Query<PreguntaBD>("SELECT * FROM PreguntaBD " +
				"WHERE nivel=" + nivel);
			List<PreguntaItem> listaPreguntas = new List<PreguntaItem>();
			for(int i=0; i<lista.Count; i++){
				var ID = lista[i].ID;
				var pregunta = lista[i].pregunta;
				var nivelPregunta = lista[i].nivel;
				PreguntaItem p = new PreguntaItem(ID, pregunta, nivelPregunta);
				listaPreguntas.Add(p);
			}
			return listaPreguntas;
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
			var count = db.ExecuteScalar<int>("SELECT Count(*) FROM PreguntaBD");

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

