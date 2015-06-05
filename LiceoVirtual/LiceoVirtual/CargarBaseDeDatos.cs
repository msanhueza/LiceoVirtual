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
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha es", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha es", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha corresponde a", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha corresponde a", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha corresponde a", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha tiene como función", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En la parte de la célula indicado con la flecha se realiza la función de", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Las células de la siguiente imagen tienen como función principal", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de los siguientes organelos es propio de la célula vegetal?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿En cuál de los siguientes organelos ocurre la replicación del ADN?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de los siguientes organelos utiliza CO2?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿En cuál de los siguientes organelos se sintetizan la mayor cantidad de proteínas?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿En cuál de los siguientes organelos se realiza la respiración celular?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La parte del microscopio indicada con la flecha corresponde a", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La parte del microscopio indicada con la flecha corresponde a", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿A qué tejido corresponde la siguiente imagen?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La secuencia de menor a mayor aumento es", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Una de las diferencias fundamentales entre la célula vegetal y animal es que la primera presenta:", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de las siguientes imágenes corresponde al Complejo de Golgi?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado en la figura se encuentra en mayor proporción en", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de los siguientes organelos se encuentra en gran cantidad en las células del músculo esquelético?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En una célula del epitelio respiratorio que tiene como función la secreción de mucosidad para mantener húmeda la vía respiratoria debiera observarse una gran cantidad de", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En una célula de la corteza suprarenal que secreta glucocorticoides (hormona lipofílica) debiera observarse una gran cantidad de", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La figura a continuación muestra 2 compartimentos separados por una membrana permeable solo al solvente, donde inicialmente el compartimento A contiene 10 mM de NaCl y el compartimento B contiene 100 mM de NaCl. El estado final de esta condición será", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cual de las siguientes figuras muestra una solución hipertónica en el compartimento A?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La secuencia de las siguientes imágenes vistas al microscopio de menor a mayor aumento es:", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La secuencia correcta de imágenes de menor a mayor aumento es:", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de las siguientes imágenes corresponde a un tejido visto en aumento 40X?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de las siguientes imágenes corresponde a un tejido visto en aumento 10X?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de las siguientes imágenes corresponde a un tejido visto en aumento 40X?", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El órgano indicado con la flecha corresponde a", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El órgano de la imagen corresponde a:", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La imagen corresponde a", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La imagen del tejido y su órgano corresponde respectivamente a:", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En el tejido cerebral la célula que se encuentra en mayor proporción es", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Los glóbulos blancos son parte del tejido", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El tejido que se muestra en la imagen se encuentra en:", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La célula de la imagen corresponde a", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La célula de la imagen es", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La siguiente imagen corresponde a", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo de la célula que se indica en la imagen es:", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El órganelo de la célula vegetal que se indica con la flecha es:", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Cuando en un vaso de agua se echa jugo concentrado ocurre", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La imagen corresponde a:", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En la siguiente imagen se muestran:", idImagen = -1, nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La siguiente imagen corresponde a:", idImagen = -1, nivel=1});

	}

	private void cargarPreguntaSolucionBD(){	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="un centríolo.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="una mitocondria.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="un retículo endoplasmico rugoso.", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="mitocondria.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="núcleo.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="cloroplasto.",  esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="una vacuola.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="un cloroplasto.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="una mitocondria.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="una vacuola.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="un cloroplasto.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="una mitocondria.", esSolucion=false});

		// HAY QUE CORROBORAR ESTA RESPUESTA, YA QUE NO VIENE EN EL DOC DE PREGUNTAS
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="una lisosoma.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="un cloroplasto.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="la membrana nuclear.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="transporte de sustancias.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="síntesis de ATP.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="transcripción génica.", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="transporte de sustancias.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="síntesis de ATP.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="síntesis de proteínas.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="el transporte de sustancias.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="la síntesis de ATP.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="la secreción de sustancias.", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="1", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="3", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="5", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="1", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="2", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="4", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="1", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="2", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="3", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="Centríolos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="Mitocondria", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="Retículo endoplásmico rugoso", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="El núcleo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="El cloroplasto", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="La mitocondria", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="la platina.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="el objetivo.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="el condensador.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="la platina.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="el cuerpo.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="la iluminación.", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Nervioso", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Epitelial", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Muscular", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="1-2-3-4", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="2-3-1-4", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="4-2-3-1", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="Núcleo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="Ribosoma", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="Pared celular", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="1", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="2", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="3", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="el cuerpo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="el condensador", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="el ocular", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=21, solucion="neurona.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=21, solucion="célula muscular esquelética.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=21, solucion="célula pancreática secretora de insulina (beta).", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=22, solucion="1", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=22, solucion="2", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=22, solucion="3", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=23, solucion="retículo endoplasmico rugoso.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=23, solucion="ribosomas citoplasmaticos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=23, solucion="complejo de Golgi.", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=24, solucion="mitocondrias.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=24, solucion="membrana plasmática.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=24, solucion="retículo endoplásmico rugoso.", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=25, solucion="1", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=25, solucion="2", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=25, solucion="3", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="solo III", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="solo I y III.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="solo II y IV.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="1-2-4-3", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="4-3-2-1", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="2-4-3-1", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="3-2-4-1", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="3-4-1-2", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="2-3-4-1", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="5", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="2", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="1", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="2", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="5", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="1", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="1", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="4", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="3", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="pulmón.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="cerebro.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="intestino.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="corazón.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="cerebro.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="intestino", esSolucion=true});
	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="tejido estriado.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="tejido nervioso.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="tejido epitelial.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="tejido óseo y hueso.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="tejido muscular y corazón.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="tejido hepático e hígado.", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="el nefrón.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="el glóbulo rojo.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="la neurona.", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="sanguíneo.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="nervioso.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="renal.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="el estómago.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="la piel.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="el hueso.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="un adiposito.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="un melanocito.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="un hepatocito.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="una neurona.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="un hepatocito.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="un nefrón.", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="pulmones.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="estómago.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="vasos sanguíneos.", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="mitocondria.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="núcleo.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="complejo de Golgi.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="pared celular.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="cloroplasto.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="membrana plasmática.", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="difusión.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="difusión facilitada.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="Transporte activo", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="eritrocitos en un medio hipertónico", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="leucocitos en un medio hipotónico", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="eritrocitos en un medio isotónico", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="eritrocitos en un medio hipotónico", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="eritrocitos en un medio isotónico", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="eritrocitos en un medio hipotónico", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="células vegetales en un medio hipotónico.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="células animales en un medio hipertónico.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="células vegetales en un medio hipertónico.", esSolucion=true});

	}

}

