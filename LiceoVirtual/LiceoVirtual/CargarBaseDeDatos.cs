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
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha es", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha es", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha corresponde a", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha corresponde a", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha corresponde a", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha tiene como función", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En la parte de la célula indicado con la flecha se realiza la función de", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Las células de la siguiente imagen tienen como función principal", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de los siguientes organelos es propio de la célula vegetal?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿En cuál de los siguientes organelos ocurre la replicación del ADN?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de los siguientes organelos utiliza CO2?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿En cuál de los siguientes organelos se sintetizan la mayor cantidad de proteínas?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿En cuál de los siguientes organelos se realiza la respiración celular?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La parte del microscopio indicada con la flecha corresponde a", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La parte del microscopio indicada con la flecha corresponde a", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿A qué tejido corresponde la siguiente imagen?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La secuencia de menor a mayor aumento es", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Una de las diferencias fundamentales entre la célula vegetal y animal es que la primera presenta:", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de las siguientes imágenes corresponde al Complejo de Golgi?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado en la figura se encuentra en mayor proporción en", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de los siguientes organelos se encuentra en gran cantidad en las células del músculo esquelético?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En una célula del epitelio respiratorio que tiene como función la secreción de mucosidad para mantener húmeda la vía respiratoria debiera observarse una gran cantidad de", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En una célula de la corteza suprarenal que secreta glucocorticoides (hormona lipofílica) debiera observarse una gran cantidad de", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La figura a continuación muestra 2 compartimentos separados por una membrana permeable solo al solvente, donde inicialmente el compartimento A contiene 10 mM de NaCl y el compartimento B contiene 100 mM de NaCl. El estado final de esta condición será", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cual de las siguientes figuras muestra una solución hipertónica en el compartimento A?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La secuencia de las siguientes imágenes vistas al microscopio de menor a mayor aumento es:", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La secuencia correcta de imágenes de menor a mayor aumento es:", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de las siguientes imágenes corresponde a un tejido visto en aumento 40X?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de las siguientes imágenes corresponde a un tejido visto en aumento 10X?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de las siguientes imágenes corresponde a un tejido visto en aumento 40X?", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El órgano indicado con la flecha corresponde a", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El órgano de la imagen corresponde a:", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La imagen corresponde a", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La imagen del tejido y su órgano corresponde respectivamente a:", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En el tejido cerebral la célula que se encuentra en mayor proporción es", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Los glóbulos blancos son parte del tejido", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El tejido que se muestra en la imagen se encuentra en:", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La célula de la imagen corresponde a", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La célula de la imagen es", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La siguiente imagen corresponde a", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo de la célula que se indica en la imagen es:", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El órganelo de la célula vegetal que se indica con la flecha es:", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Cuando en un vaso de agua se echa jugo concentrado ocurre", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La imagen corresponde a:", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En la siguiente imagen se muestran:", nivel=1});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La siguiente imagen corresponde a:", nivel=1});

	}

	private void cargarPreguntaSolucionBD(){	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="un centríolo.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="una mitocondria.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="un retículo endoplasmico rugoso.", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="mitocondria.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="núcleo.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="cloroplasto.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="una vacuola.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="un cloroplasto.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="una mitocondria.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="una vacuola.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="un cloroplasto.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="una mitocondria.", imagen="imagen", esSolucion=false});

		// HAY QUE CORROBORAR ESTA RESPUESTA, YA QUE NO VIENE EN EL DOC DE PREGUNTAS
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="una lisosoma.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="un cloroplasto.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="la membrana nuclear.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="transporte de sustancias.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="síntesis de ATP.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="transcripción génica.", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="transporte de sustancias.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="síntesis de ATP.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="síntesis de proteínas.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="el transporte de sustancias.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="la síntesis de ATP.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="la secreción de sustancias.", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="1", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="3", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="5", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="1", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="2", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="4", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="1", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="2", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="3", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="Centríolos", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="Mitocondria", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="Retículo endoplásmico rugoso", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="El núcleo", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="El cloroplasto", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="La mitocondria", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="la platina.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="el objetivo.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="el condensador.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="la platina.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="el cuerpo.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="la iluminación.", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Nervioso", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Epitelial", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Muscular", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="1-2-3-4", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="2-3-1-4", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="4-2-3-1", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="Núcleo", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="Ribosoma", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="Pared celular", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="1", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="2", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="3", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="el cuerpo", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="el condensador", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="el ocular", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=21, solucion="neurona.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=21, solucion="célula muscular esquelética.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=21, solucion="célula pancreática secretora de insulina (beta).", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=22, solucion="1", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=22, solucion="2", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=22, solucion="3", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=23, solucion="retículo endoplasmico rugoso.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=23, solucion="ribosomas citoplasmaticos", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=23, solucion="complejo de Golgi.", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=24, solucion="mitocondrias.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=24, solucion="membrana plasmática.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=24, solucion="retículo endoplásmico rugoso.", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=25, solucion="1", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=25, solucion="2", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=25, solucion="3", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="solo III", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="solo I y III.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="solo II y IV.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="1-2-4-3", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="4-3-2-1", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="2-4-3-1", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="3-2-4-1", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="3-4-1-2", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="2-3-4-1", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="5", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="2", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="1", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="2", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="5", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="1", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="1", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="4", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="3", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="pulmón.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="cerebro.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="intestino.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="corazón.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="cerebro.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="intestino", imagen="imagen", esSolucion=true});
	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="tejido estriado.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="tejido nervioso.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="tejido epitelial.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="tejido óseo y hueso.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="tejido muscular y corazón.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="tejido hepático e hígado.", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="el nefrón.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="el glóbulo rojo.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="la neurona.", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="sanguíneo.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="nervioso.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="renal.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="el estómago.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="la piel.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="el hueso.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="un adiposito.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="un melanocito.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="un hepatocito.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="una neurona.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="un hepatocito.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="un nefrón.", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="pulmones.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="estómago.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="vasos sanguíneos.", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="mitocondria.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="núcleo.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="complejo de Golgi.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="pared celular.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="cloroplasto.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="membrana plasmática.", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="difusión.", imagen="imagen", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="difusión facilitada.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="Transporte activo", imagen="imagen", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="eritrocitos en un medio hipertónico", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="leucocitos en un medio hipotónico", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="eritrocitos en un medio isotónico", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="eritrocitos en un medio hipotónico", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="eritrocitos en un medio isotónico", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="eritrocitos en un medio hipotónico", imagen="imagen", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="células vegetales en un medio hipotónico.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="células animales en un medio hipertónico.", imagen="imagen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="células vegetales en un medio hipertónico.", imagen="imagen", esSolucion=true});

	}

}

