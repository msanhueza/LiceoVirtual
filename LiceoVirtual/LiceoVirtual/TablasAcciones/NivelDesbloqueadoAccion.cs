using System.Collections.Generic;
using SQLite;
using LiceoVirtual;

public class NivelDesbloqueadoAccion
{

	string docsFolder;
	string pathToDatabase;

	public NivelDesbloqueadoAccion(){
		docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
		pathToDatabase = System.IO.Path.Combine(docsFolder, "liceo_virtual.db");
	}

	public string insertUpdateData(NivelDesbloqueadoBD data)
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

	public int findNumberRecords()
	{
		try
		{
			var db = new SQLiteConnection(pathToDatabase);
			// this counts all records in the database, it can be slow depending on the size of the database
			var count = db.ExecuteScalar<int>("SELECT Count(*) FROM NivelDesbloqueadoBD");

			// for a non-parameterless query
			// var count = db.ExecuteScalar<int>("SELECT Count(*) FROM Person WHERE FirstName="Amy");

			return count;
		}
		catch (SQLiteException)
		{
			return -1;
		}
	}

	public List<NivelDesbloqueadoItem> getNivelesDesbloqueados(){
		try
		{
			var db = new SQLiteConnection(pathToDatabase);
			var lista = db.Query<NivelDesbloqueadoBD>("SELECT * FROM NivelDesbloqueadoBD");
			List<NivelDesbloqueadoItem> listaNivelesDesbloqueados = new List<NivelDesbloqueadoItem>();
			for(int i=0; i<lista.Count; i++){
				var nivel = lista[i].nivel;
				var desbloqueado = lista[i].desbloqueado;
				NivelDesbloqueadoItem n = new NivelDesbloqueadoItem(nivel, desbloqueado);
				listaNivelesDesbloqueados.Add(n);

			}
			return listaNivelesDesbloqueados;

		}
		catch (SQLiteException)
		{
			return null;
		}
	}

	public void desbloquearNivel(string nivel){
		try{
			var db = new SQLiteConnection(pathToDatabase);
			var resultado = db.ExecuteScalar<int>("UPDATE NivelDesbloqueadoBD Set desbloqueado  = ? WHERE nivel = ?",true,nivel);
		}
		catch (SQLiteException)
		{

		}

	}

}


