﻿using SQLite;
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
		cargarPreguntaRespuestaBD();

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
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 1, desbloqueado=true });
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

	private void cargarPreguntaRespuestaBD(){	

		//PREGUNTAS DE PRIMERO MEDIO
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha es", idImagen = Resource.Drawable.n1_1, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="un centríolo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="una mitocondria", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=1, solucion="un retículo endoplasmico rugoso", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha es", idImagen = Resource.Drawable.n1_2, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="mitocondria", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="núcleo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=2, solucion="cloroplasto",  esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha corresponde a", idImagen = Resource.Drawable.n1_3, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="una vacuola", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="un cloroplasto", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=3, solucion="una mitocondria", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha corresponde a", idImagen = Resource.Drawable.n1_4, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="una vacuola", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="un cloroplasto", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=4, solucion="una mitocondria", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha corresponde a", idImagen = Resource.Drawable.n1_5, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="una lisosoma", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="un cloroplasto", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="la membrana nuclear", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado con la flecha tiene como función", idImagen = Resource.Drawable.n1_6, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="transporte de sustancias", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="síntesis de ATP", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=6, solucion="transcripción génica", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En la parte de la célula indicado con la flecha se realiza la función de", idImagen = Resource.Drawable.n1_7, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="transporte de sustancias", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="síntesis de ATP", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=7, solucion="síntesis de proteínas", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de los siguientes organelos es propio de la célula vegetal?", idImagen = Resource.Drawable.n1_8, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="1", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="2", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=8, solucion="3", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿En cuál de los siguientes organelos ocurre la replicación del ADN?", idImagen = Resource.Drawable.n1_9, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="1", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="2", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=9, solucion="3", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de los siguientes organelos utiliza CO2?", idImagen = Resource.Drawable.n1_10, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="1", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="2", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=10, solucion="3", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿En cuál organelo se sintetizan la mayor cantidad de proteínas?", idImagen = -1, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="Centríolos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="Mitocondria", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=11, solucion="Retículo endoplásmico rugoso", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿En cuál organelo se realiza la respiración celular?", idImagen = -1, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="El núcleo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="El cloroplasto", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=12, solucion="La mitocondria", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La parte del microscopio indicada con la flecha corresponde a", idImagen = Resource.Drawable.n1_13, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="la platina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="el objetivo", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=13, solucion="el condensador", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La parte del microscopio indicada con la flecha corresponde a", idImagen = Resource.Drawable.n1_14, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="la platina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="el cuerpo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=14, solucion="la iluminación", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿A qué tejido corresponde la siguiente imagen?", idImagen = Resource.Drawable.n1_15, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="Nervioso", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="Epitelial", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=15, solucion="Muscular", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Una de las diferencias fundamentales entre la célula vegetal y animal es que la primera presenta:", idImagen = -1, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Núcleo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Ribosoma", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=16, solucion="Pared celular", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de las siguientes imágenes corresponde al Complejo de Golgi?", idImagen = Resource.Drawable.n1_17, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="1", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="2", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=17, solucion="3", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La parte del microscopio que se indica con la flecha es", idImagen = Resource.Drawable.n1_18, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="el cuerpo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="el condensador", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=18, solucion="el ocular", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El organelo indicado en la figura se encuentra en mayor proporción en", idImagen = Resource.Drawable.n1_19, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="neurona", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="célula muscular esquelética", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=19, solucion="célula pancreática secretora de insulina", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Cuál de los siguientes organelos se encuentra en gran cantidad en las células del músculo esquelético?", idImagen = Resource.Drawable.n1_20, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="1", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="2", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=20, solucion="3", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En una célula del epitelio respiratorio que tiene como función la secreción de mucosidad para mantener húmeda la vía respiratoria debiera observarse una gran cantidad de", idImagen = -1, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=21, solucion="retículo endoplasmico rugoso", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=21, solucion="ribosomas citoplasmaticos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=21, solucion="complejo de Golgi", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En una célula de la corteza suprarenal que secreta glucocorticoides (hormona lipofílica) debiera observarse una gran cantidad de", idImagen = -1, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=22, solucion="mitocondrias", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=22, solucion="membrana plasmática", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=22, solucion="retículo endoplásmico rugoso", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El órgano indicado con la flecha corresponde a:", idImagen = Resource.Drawable.n1_23, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=23, solucion="pulmón", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=23, solucion="cerebro", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=23, solucion="riñon", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En el tejido cerebral la célula que se encuentra en mayor proporción es", idImagen = -1, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=24, solucion="el glóbulo rojo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=24, solucion="la plaqueta", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=24, solucion="la neurona", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Los glóbulos blancos son parte del tejido", idImagen = -1, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=25, solucion="sanguíneo", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=25, solucion="nervioso", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=25, solucion="epitelial", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La siguiente imagen corresponde a", idImagen = Resource.Drawable.n1_26, nivel=1});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="pulmones", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="estómago", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="vasos sanguíneos", esSolucion=true});


		//PREGUNTAS DE TERCERO MEDIO
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Las células en cuanto a alguna de sus moléculas proteicas de membrana con función adhesiva:\n I.- Permiten la unión de las células\nII.- Interacción con proteínas de la matriz extracelular\nIII.- Sólo permiten conexiones sin permitir el pasaje de iones\nSeleccione la aseveración(es), concordante(s) con el enunciado:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="I y II", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La proteína G que induce adenilato ciclasa que está formada por subunidades:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="alfa gama beta", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="beta epsilón delta", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="beta epsilón alfa", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La proteína G, se activa por adición de:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="ATP", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="GDP", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="GTP", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En la adhesión mediante cadherinas ocurre:\nI.- Dimerización en superficie\nII.- Interacción con cateninas\nIII.- Unión a fibras de actina\nSon correctas:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="I y II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="I y III", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="I, II y III", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La acetilcolina es una molécula neurotransmisora, y:\nI.- Un neurotransmisor de sistema nervioso simpático\nII.- Participa en la unión neuromuscular\nIII.- Una molécula que participa en los procesos de comunicación que conducen al aprendizaje.\nSon correctas:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="I, II, III", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="I y III", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El gradiente electroquímico producido en la membrana se debe a:\nI.- La concentración de iones a ambos lados de la membrana\nII.- La igualdad de concentraciones de iones en ambos lados de la membrana\nIII.- El voltaje como consecuencia de la concentración de iones\nSon correctas:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="I y III", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La actividad quinasa se define como actividad:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="Fosforilante", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="De las proteínas llamadas ligandos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="De las proteínas que defosforilan", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Si el neurotransmisor producido por una  neuronas se une a un receptor metabotrópico ocurre que:\nI.- Se separa una de las subunidades de la proteína G\nII.- La proteína G puede unirse a un canal iónico\nIII.- La unión de proteína G puede llevar a que se produzca un potencial postsináptico\nSon Correctas:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="I y II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="I, II y III", esSolucion=true});


		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La diferencia más radical entre señales hormonales y neuronales es:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="La velocidad de transmisión", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="La  naturaleza química de los mensajeros moleculares", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="Las características de los receptores", esSolucion=false});


		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Las señales químicas dadas en el proceso de comunicación celular puede  involucrar:\nI.-Primeros y segundos mensajeros moleculares\nII.- Moléculas receptoras integrantes de membrana\nIII.- Iones como el de calcio", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="I, II, III", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Se sabe que las proteínas G están compuestas de tres subunidades,  entre ellas ocurre:\nI.- La subunidad alfa se activa con GTP\nII.- La subunidades gama se activan con GTP\nIII.-La subunidad beta se activa con GTP\nSon ciertas:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="I", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="III", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Por acción de la bomba de sodio y potasio se genera el potencial de reposo de una célula. Ello significa que:\nI.- El exterior de la membrana es negativo con respecto al interior de la membrana.\nII.- En el exterior de la célula se encuentra gran concentración de iones sodio\nIII.- En el interior de la célula se acumulan grandes concentraciones de iones sodio\nSon ciertas:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="II", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="III", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Un neurotrasmisor puede ser liberado hacia:\nI.- La sangre\nII.- Glándulas\nIII.-Músculos\nSon correctas:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="I, II, III", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En el experimento de Gortel y Grendel con glóbulos rojos son ciertas las siguientes aseveraciones:\nI.- La película que quedó sobre la superficie solvente corresponde a lípidos\nII. La mancha que se formaba a nivel intermedio era parte del mosaico de proteínas\nIII.- Con este experimento se descubrió que la membrana era un mosaico fluido\nEs, o son correctas:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="I", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="I y II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="I y III", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="A bajas temperaturas las fuerzas de van der Waals en la membrana celular, específicamente en las cadenas de carbono de los lípidos debiera llevarnos a suponer que:\nI.- Convierten las bicapas de fosfolípidos en gel sólido\nII.- Dan mayor fluidez a la membrana, sobre todo si las cadenas de ácido graso son cortas\nIII.- No se expresan si hay mucha saturación\nSon correcta(s)", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="I", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="I y II", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La proteína anhidrasa carbónica (enzima):\nI.- Transporta bicarbonato (HCO3-)\nII.- Se encuentra en glóbulos rojos y células alveolares\nIII.- Es la proteína de la banda 3, espectrina\nSon correcta(s)", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="I", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="I y II", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Las uniones comunicantes en una membrana van a permitir la función:", idImagen = -1, nivel=3});	
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="Que los canales permitan el viaje de moléculas de tamaño mayor a 5900 kDa", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="Acoplamiento eléctrico entre células", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="De intercambio de información entre leucocitos y tejidos invadidos", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El AMPc entre sus propiedades en las vías de conducción que se inician en la membrana celular, se cuenta:\nI.- Puede ser reciclado por una fosfodiesterasa\nII.- Puede actuar como promotor de genes para que estos se expresen\nIII.- Puede modular la actividad de proteínas quinasas\nSon correcta(s)", idImagen = -1, nivel=3});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="I y III", esSolucion=true});


		//PREGUNTAS DE CUARTO MEDIO
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El azúcar  que forma parte de los ácidos nucleicos, entre ellos el ADN es", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="Ribosa", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="Glucosa", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="Derribosa", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Las bases nitrogenadas que encontramos en el  ADN son:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="Uracilo guanina citosina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="Uracilo citosina timina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="Citosina timina guanina", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Un nucleótido está formado por:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="Pentosa, base nitrogenada y ácido fosfórico", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="Ribosa, base nitrogenada y fosfato", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="Desoxirribosa, ribosa y bases nitrogenada más fosfato", esSolucion=false});

		//preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="De acuerdo a lo que usted ha podido investigar sobre la estructura del ADN, ¿Cuál de las siguientes aseveraciones sería incorrecta?", idImagen = -1, nivel=4});
		//preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=48, solucion="Los nucleótidos contienen fosfato, compuesto muy energético", esSolucion=false});
		//preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=48, solucion="Los nucleótidos poseen grupos fosfatos con tres grupos fosfato de baja energía", esSolucion=true});
		//preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=48, solucion="El GTP es una guanina y tres fosfatos", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Una de las siguientes afirmaciones es falsa:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=49, solucion="El ARN a veces consta de una cadena", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=49, solucion="El ARN contiene uracilo, El ADN contiene timina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=49, solucion="El ARN nunca se encuentra en el núcleo, el ADN nunca se encuentra en el citoplasma", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El par de  nucleótidos que no  sirven de base para la información en ADN, sería:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=50, solucion="Adenina y timina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=50, solucion="Guanina y citosina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=50, solucion="Guanina y Uracilo", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Con respecto a la poliploidia tenemos algunos descriptores para el fenómeno y estos son:\nI.- Las células contienen múltiplos del número diploide de cromosomas.\nII.- Se modifica el  número conjuntos haploides, pero el cariotipo se encuentra en equilibrio.\nIII.- En las poliploidias se encuentra suprimida la anafase y citocinesis.\nSon correctas:{\n", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=51, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=51, solucion="II", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=51, solucion="I y II", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La meiosis se caracteriza fundamentalmente por:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=52, solucion="La reducción en el número de cromosomas", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=52, solucion="La amplificación en el número de cromosomas", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=52, solucion="Permite la reproducción sexual", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Con respecto al nucleosoma podemos anunciar las siguientes características, excepto:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=53, solucion="Está formado por dos vueltas completas de ADN", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=53, solucion="Es un octámero de proteínas", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=53, solucion="Está formado por proteínas histonas, ADN y ácidos grasos", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Los genes tienen como características excepto:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=54, solucion="Poseen información en todos los seres vivos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=54, solucion="Poseen secuencias de nucleótidos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=54, solucion="Se encuentran presente en el núcleo de los organismos procariotas", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El gen de la insulina se caracteriza por:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=55, solucion="Se encuentra en dos cromosomas homólogos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=55, solucion="Se encuentra presente en todos los cromosomas humanos y algunos animales", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=55, solucion="En la especie humana se encuentra en una sola copia", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Una enzima es un compuesto químico que se caracteriza por poseer:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=56, solucion="Estructura sólo primaria", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=56, solucion="Estructura sólo secundaria", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=56, solucion="Estructura sólo terciaria", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La energía de activación:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=57, solucion="Se ve disminuida en el transcurso de una reacción", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=57, solucion="Aumenta gracias a la acción catalítica", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=57, solucion="No se observa influenciada por acción catalítica", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Los azúcares forman parte de las moléculas que dan vida y entre ellos el más importante y destacado es el que compone el ADN, y sería:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=58, solucion="Ribosa", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=58, solucion="Sacarosa", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=58, solucion="Desoxirribosa", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="A menudo el ARN debe replicarse en la fase S del ciclo celular. En ello podemos observar las siguientes características que la distinguen:", idImagen = -1, nivel=4});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=59, solucion="Semiconservativa", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=59, solucion="Conservativa", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=59, solucion="Dispersiva", esSolucion=false});

		//PREGUNTAS DE SEGUNDO MEDIO

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Un genetista realizando un experimento concluyó que: \"para identificar el genotipo desconocido de individuos fenotipicamente iguales siempre se suele utilizar al homocigoto recesivo\", esta conclusión corresponde a:", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=60, solucion="dihibridismo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=60, solucion="codominancia", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=60, solucion="retrocruzamiento", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Al realizar un cruce entre individuos heterocigotos pertenecientes a cierta especie de vegetales, se obtuvo 810 descendientes. Según esta información, ¿Cuántos aproximadamente tendrán el fenotipo dominante?", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=61, solucion="600", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=61, solucion="200", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=61, solucion="800", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La posición de las flores puede ser terminal (a) o axial (A). Qué tipo de descendencia  (fenotipo) existirá si se cruza un individuo de flores axiales homocigoto con otro de flores terminales:", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=62, solucion="75 % axial, 25 % terminal", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=62, solucion="100 % terminal", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=62, solucion="100 % axial", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="A continuación se ilustra un par de cromosomas que poseen información genética para el mismo carácter ¿Cómo se denominan estos cromosomas?", idImagen = Resource.Drawable.n2_63, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=63, solucion="homocigotos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=63, solucion="heterocigotos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=63, solucion="homólogos", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En cobayos el color negro es dominante sobre albino. Si se cruzan cobayos negros puros y se implanta uno de los embriones en gestación a una hembra albina ¿qué fenotipo tendrá este cobayo al nacer?", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=64, solucion="pelaje con tendencia al negro", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=64, solucion="pelaje gris y algunas zonas blancas con negro", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=64, solucion="pelaje negro en su totalidad", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Si una persona es homocigota para un carácter, significa que?:\nI.\tPosee dos juegos de cromosomas idénticos.\nII.\tPosee el mismo alelo en cada cromosoma homólogo.\nIII.\tPosee dos alelos dominantes en cada cromosoma homólogo.", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=65, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=65, solucion="II", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=65, solucion="III", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Cuando el ADN se encuentra en forma laxa, difusa o como hilos se denomina:", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=66, solucion="Cromosoma", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=66, solucion="Cromatina", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=66, solucion="Homocigoto", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Qué característica (s) es (son) verdadera (s) respecto de los cromosomas?\nI.\tPresentan un centromero\nII.\tRepresentan el máximo grado de condensación del material genético\nIII.\tContiene ADN e histonas\n", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=67, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=67, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=67, solucion="I, II y III", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El fenotipo depende", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=68, solucion="del genotipo solamente", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=68, solucion="del ambiente solamente", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=68, solucion="del genotipo y el ambiente", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Si la célula de cebolla tiene 16 cromosomas, un óvulo de cebolla tiene una cantidad de cromosomas igual a:", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=69, solucion="16", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=69, solucion="8", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=69, solucion="32", esSolucion=false});

		//preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿En cuál de las siguientes opciones se menciona el termino cuyo significado común para los fenómenos de regeneración de órganos, reproducción de protistas, crecimiento de metazoos y cicatrización de tejidos?", idImagen = -1, nivel=2});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="¿Donde se menciona el término cuyo significado común para los fenómenos de regeneración de órganos, reproducción de protistas, crecimiento de metazoos y cicatrización de tejidos?", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=70, solucion="Ciclosis", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=70, solucion="Mitosis", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=70, solucion="Meiosis", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En la división celular, la separación de las cromatidas ocurre en:", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=71, solucion="Metafase", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=71, solucion="Anafase", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=71, solucion="Telofase", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El esquema representa una célula que se encuentra en:", idImagen = Resource.Drawable.n2_72, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=72, solucion="Interfase", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=72, solucion="Profase", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=72, solucion="Anafase", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Ordene secuencialmente las etapas de la mitosis:\nI. Profase\nII. Anafase\nIII. Telofase\nIV. Metafase\nV. Citocinesis\n", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=73, solucion="I,II,III,IV,V", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=73, solucion="I,III,IV,II,V", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=73, solucion="I,IV,II,III,V", esSolucion=true});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Con respecto a la importancia de la mitosis, señale la(s) alternativa(s) correcta(s):\nI. Para un organismo pluricelular la mitosis significa reproducción\nII. Los organismos pluricelulares pueden regenerar tejidos a través de mitosis\nIII. Para un protozoo, una división celular de este tipo, significa reproducción\nIV. Los organismos pluricelulares crecen gracias a este proceso\n", idImagen = -1, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=74, solucion="I,II,IV", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=74, solucion="II,III,IV", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=74, solucion="I,III,IV", esSolucion=false});

		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La siguiente representa una etapa de la mitosis ¿Qué ocurrirá en la etapa siguiente?", idImagen = Resource.Drawable.n2_75, nivel=2});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=75, solucion="Separación de cromátidas homólogas", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=75, solucion="Separación de cromosomas homólogos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=75, solucion="Separación de cromátidas hermanas", esSolucion=true});


	}


}

