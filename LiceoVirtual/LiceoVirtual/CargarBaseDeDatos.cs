using SQLite;
using LiceoVirtual;
using System;

public class CargarBaseDeDatos
{
	string docsFolder;
	string pathToDatabase;
	NivelDesbloqueadoAccion nivelDesbloqueadoAccion = new NivelDesbloqueadoAccion ();
	PuntuacionAccion puntuacionAccion = new PuntuacionAccion ();

	public CargarBaseDeDatos(){
		docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
		pathToDatabase = System.IO.Path.Combine(docsFolder, "liceo_virtual.db");
		crearBaseDatos (pathToDatabase);
		cargarNivelDesbloqueadoBD (pathToDatabase);
		cargarPuntuacionBD (pathToDatabase);
	}

	private string crearBaseDatos(string path)
	{
		try
		{
			var connection = new SQLiteConnection(path);
			connection.CreateTable<PuntuacionBD>();
			connection.CreateTable<NivelDesbloqueadoBD>();
			return "BD creada";
		}
		catch (SQLiteException ex)
		{
			return ex.Message;
		}
	}

	private void cargarNivelDesbloqueadoBD(string pathToDatabase){	
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 1, desbloqueado=false });
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 2, desbloqueado=false });
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 3, desbloqueado=false });
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 4, desbloqueado=false });
	}

	private void cargarPuntuacionBD(string pathToDatabase){
		DateTime date = DateTime.Now;
		string auxDate = String.Format("{0:dd/MM/yyyy}", date);		
		puntuacionAccion.insertUpdateData(new PuntuacionBD{ IdUsuario= 1, nivel= 1, fecha= auxDate, puntaje=40 });
		puntuacionAccion.insertUpdateData(new PuntuacionBD{ IdUsuario= 1, nivel= 1, fecha= auxDate, puntaje=50 });
		puntuacionAccion.insertUpdateData(new PuntuacionBD{ IdUsuario= 1, nivel= 1, fecha= auxDate, puntaje=70 });
		puntuacionAccion.insertUpdateData(new PuntuacionBD{ IdUsuario= 1, nivel= 1, fecha= auxDate, puntaje=80 });
		puntuacionAccion.insertUpdateData(new PuntuacionBD{ IdUsuario= 1, nivel= 1, fecha= auxDate, puntaje=90 });
	}

}

