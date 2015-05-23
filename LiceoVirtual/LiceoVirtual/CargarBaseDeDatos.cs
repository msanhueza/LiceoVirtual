using SQLite;
using LiceoVirtual;
using System;

public class CargarBaseDeDatos
{
	string docsFolder;
	string pathToDatabase;
	NivelDesbloqueadoAccion nivelDesbloqueadoAccion;
	PuntuacionAccion puntuacionAccion;
	PreguntaAccion preguntaAccion;
	PreguntaSolucionAccion preguntaSolucionAccion;

	public CargarBaseDeDatos(){
		docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
		pathToDatabase = System.IO.Path.Combine(docsFolder, "liceo_virtual.db");
		nivelDesbloqueadoAccion = new NivelDesbloqueadoAccion ();
		puntuacionAccion = new PuntuacionAccion ();
		preguntaAccion = new PreguntaAccion ();
		preguntaSolucionAccion = new PreguntaSolucionAccion ();
		crearBaseDatos ();
		cargarNivelDesbloqueadoBD ();
		cargarPuntuacionBD ();
		cargarPreguntaBD ();
		cargarPreguntaSolucionBD ();
	}

	private string crearBaseDatos()
	{
		try
		{
			var connection = new SQLiteConnection(pathToDatabase);
			connection.CreateTable<PuntuacionBD>();
			connection.CreateTable<NivelDesbloqueadoBD>();
			connection.CreateTable<PreguntaBD>();
			connection.CreateTable<PreguntaSolucionBD>();
			return "BD creada";
		}
		catch (SQLiteException ex)
		{
			return ex.Message;
		}
	}

	private void cargarNivelDesbloqueadoBD(){	
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 1, desbloqueado=false });
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 2, desbloqueado=false });
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 3, desbloqueado=false });
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 4, desbloqueado=false });
	}

	private void cargarPuntuacionBD(){
		DateTime date = DateTime.Now;
		string auxDate = String.Format("{0:dd/MM/yyyy}", date);		
		puntuacionAccion.insertUpdateData(new PuntuacionBD{ IdUsuario= 1, nivel= 1, fecha= auxDate, puntaje=40 });
		puntuacionAccion.insertUpdateData(new PuntuacionBD{ IdUsuario= 1, nivel= 1, fecha= auxDate, puntaje=50 });
		puntuacionAccion.insertUpdateData(new PuntuacionBD{ IdUsuario= 1, nivel= 1, fecha= auxDate, puntaje=70 });
		puntuacionAccion.insertUpdateData(new PuntuacionBD{ IdUsuario= 1, nivel= 1, fecha= auxDate, puntaje=80 });
		puntuacionAccion.insertUpdateData(new PuntuacionBD{ IdUsuario= 1, nivel= 1, fecha= auxDate, puntaje=90 });
	}

	private void cargarPreguntaBD(){	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 1", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 2", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 3", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 4", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 5", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 6", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 7", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 8", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 9", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 10", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 11", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 12", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 13", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 14", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 15", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 16", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 17", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 18", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 19", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Pregunta 20", nivel=1});

	}

	private void cargarPreguntaSolucionBD(){	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="Solucion a", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="Solucion b", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="Solucion c", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="Solucion a", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="Solucion b", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="Solucion c", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="Solucion a", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="Solucion b", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="Solucion c", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="Solucion a", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="Solucion b", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="Solucion c", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="Solucion a", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="Solucion b", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="Solucion c", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Solucion a", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="Solucion b", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="Solucion c", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="Solucion a", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="Solucion b", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="Solucion c", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="Solucion a", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="Solucion b", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="Solucion c", imagen="imagen", esSolucion=false});


	}

}

