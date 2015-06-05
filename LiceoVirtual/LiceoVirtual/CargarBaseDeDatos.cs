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
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 1, desbloqueado=true });
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 2, desbloqueado=false });
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 3, desbloqueado=true });
		nivelDesbloqueadoAccion.insertUpdateData(new NivelDesbloqueadoBD{ nivel= 4, desbloqueado=true });
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

		//PREGUNTAS DE PRIMERO MEDIO
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


		//PREGUNTAS DE SEGUNDO MEDIO


		//PREGUNTAS DE TERCERO MEDIO
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Las células en cuanto a alguna de sus moléculas proteicas de membrana con función adhesiva:\n I.- Permiten la unión de las células\nII.- Interacción con proteínas de la matriz extracelular\nIII.- Sólo permiten conexiones sin permitir el pasaje de iones\nSeleccione la aseveración(es), concordante(s) con el enunciado:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La activación ejercida por la adenilato ciclasa conduce a la reacción:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La proteína G que induce adenilato ciclasa que está formada por subunidades:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La proteína G, se activa por adición de:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En la adhesión mediante cadherinas ocurre:\nI.- Dimerización en superficie\nII.- Interacción con cateninas\nIII.- Unión a fibras de actina\nSon correctas:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La acetilcolina es una molécula neurotransmisora, y:\nI.- Un neurotransmisor de sistema nervioso simpático\nII.- Participa en la unión neuromuscular\nIII.- Una molécula que participa en los procesos de comunicación que conducen al aprendizaje.\nSon correctas:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El gradiente electroquímico producido en la membrana se debe a:\nI.- La concentración de iones a ambos lados de la membrana\nII.- La igualdad de concentraciones de iones en ambos lados de la membrana\nIII.- El voltaje como consecuencia de la concentración de iones\nSon correctas:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Bomba de sodio y potasio se caracteriza por:\nI. Mantener alta la concentración de ión sodio Intracelular\nII. Mantener alta la concentración de Potasio extracelular\nIII. Mantener alta la concentración de cloruro en LEC\nSon correctas:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La actividad quinasa se define como actividad:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Si el neurotransmisor producido por una  neuronas se une a un receptor metabotrópico ocurre que:\nI.- Se separa una de las subunidades de la proteína G\nII.- La proteína G puede unirse a un canal iónico\nIII.- La unión de proteína G puede llevar a que se produzca un potencial postsináptico\nSon Correctas:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La diferencia más radical entre señales hormonales y neuronales es:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Las señales químicas dadas en el proceso de comunicación celular puede  involucrar:\nI.-Primeros y segundos mensajeros moleculares\nII.- Moléculas receptoras integrantes de membrana\nIII.- Iones como el de calcio", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Se sabe que las proteínas G están compuestas de tres subunidades,  entre ellas ocurre:\nI.- La subunidad alfa se activa con GTP\nII.- La subunidades gama se activan con GTP\nIII.-La subunidad beta se activa con GTP\nSon ciertas:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Por acción de la bomba de sodio y potasio se genera el potencial de reposo de una célula. Ello significa que:\nI.- El exterior de la membrana es negativo con respecto al interior de la membrana.\nII.- En el exterior de la célula se encuentra gran concentración de iones sodio\nIII.- En el interior de la célula se acumulan grandes concentraciones de iones sodio\nSon ciertas:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Un neurotrasmisor puede ser liberado hacia:\nI.- La sangre\nII.- Glándulas\nIII.-Músculos\nSon correctas:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En el experimento de Gortel y Grendel con glóbulos rojos son ciertas las siguientes aseveraciones:\nI.- La película que quedó sobre la superficie solvente corresponde a lípidos\nII. La mancha que se formaba a nivel intermedio era parte del mosaico de proteínas\nIII.- Con este experimento se descubrió que la membrana era un mosaico fluido\nEs, o son correctas:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="A bajas temperaturas las fuerzas de van der Waals en la membrana celular, específicamente en las cadenas de carbono de los lípidos debiera llevarnos a suponer que:\nI.- Convierten las bicapas de fosfolípidos en gel sólido\nII.- Dan mayor fluidez a la membrana, sobre todo si las cadenas de ácido graso son cortas\nIII.- No se expresan si hay mucha saturación\nSon correcta(s)", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La proteína anhidrasa carbónica (enzima):\nI.- Transporta bicarbonato (HCO3-)\nII.- Se encuentra en glóbulos rojos y células alveolares\nIII.- Es la proteína de la banda 3, espectrina\nSon correcta(s)", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Las uniones comunicantes en una membrana van a permitir la función:", idImagen = -1, nivel=3});	
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El AMPc entre sus propiedades en las vías de conducción que se inician en la membrana celular, se cuenta:\nI.- Puede ser reciclado por una fosfodiesterasa\nII.- Puede actuar como promotor de genes para que estos se expresen\nIII.- Puede modular la actividad de proteínas quinasas\nSon correcta(s)", idImagen = -1, nivel=3});

		//PREGUNTAS DE CUARTO MEDIO
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El azúcar  que forma parte de los ácidos nucleicos, entre ellos el ADN es", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Las bases nitrogenadas que encontramos en el  ADN son:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Un nucleótido está formado por:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="De acuerdo a lo que usted ha podido investigar sobre la estructura del ADN, ¿Cuál de las siguientes aseveraciones sería incorrecta?", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En el ADN, las bases nitrogenadas se aparean mediante enlaces de hidrógeno en el siguiente orden (seleccione la correcta):", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Una de las siguientes afirmaciones es falsa:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En la actividad de reconstrucción de una molécula de ADN usted puede decir que el ADN consta de dos hebras antiparalelas porque:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En su diseño y construcción de la molécula de ADN suponga que la secuencia está escrita en sentido 5¨-3¨ y se denomina hebra directa: 5¨TGCGATAC3¨. En consecuencia la hebra inversa sería:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El par de  nucleótidos que no  sirven de base para la información en ADN, sería:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El filamento de ADN tiene importancia porque:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El genotipo se refiere a:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Con respecto a la poliploidia tenemos algunos descriptores para el fenómeno y estos son:\nI.- Las células contienen múltiplos del número diploide de cromosomas.\nII.- Se modifica el  número conjuntos haploides, pero el cariotipo se encuentra en equilibrio.\nIII.- En las poliploidias se encuentra suprimida la anafase y citocinesis.\nSon correctas:{\n", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En la aneuploidia ocurre que:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La meiosis se caracteriza fundamentalmente por:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La cromatina conocida como eucromatina tiene como características, excepto:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Con respecto al nucleosoma podemos anunciar las siguientes características, excepto:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Los genes tienen como características excepto:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La insulina  tiene como  características, excepto:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="En la expresión genética del gen de la insulina tenemos como principales conocimientos:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El gen de la insulina se caracteriza por:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="El gen de la insulina una vez transcrito es reconocible por:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Suponga que la hebra codificante que da origen al ARNm es A.A T A A, entonces el ARNm sería de secuencia", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La actividad de un enzima es sensible a factores com", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="Una enzima es un compuesto químico que se caracteriza por poseer:", idImagen = -1, nivel=4});
		preguntaAccion.insertUpdateData (new PreguntaBD{ pregunta="La energía de activación:", idImagen = -1, nivel=4});

	}

	private void cargarPreguntaSolucionBD(){	

		//soluciones primero medio 1-25
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
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="una lisosoma.", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=5, solucion="un cloroplasto.", esSolucion=true});
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

		//soluciones segundo medio

		//soluciones tercero medio 26-45
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=26, solucion="I y II", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="AMP   →   ADP", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="GTP   →   GDP", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=27, solucion="ATP   →   AMPc", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="alfa, gama, beta", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="beta, epsilón, delta", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=28, solucion="beta, epsilón, alfa", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="ATP", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="GDP", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=29, solucion="GTP", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="I y II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="I y III", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=30, solucion="I, II y III", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="I, II, III", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=31, solucion="I y III", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=32, solucion="I y III", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="I y II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="II y III", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=33, solucion="Ninguna", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="Fosforilante", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="De las proteínas llamadas ligandos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=34, solucion="De las proteínas que defosforilan", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="Sólo I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="I y II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=35, solucion="I, II y III", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="La velocidad de transmisión", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="La  naturaleza química de los mensajeros moleculares", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=36, solucion="Las características de los receptores", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=37, solucion="I, II, III", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="I", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=38, solucion="III", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="II", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=39, solucion="III", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=40, solucion="I, II, III", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="I", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="I y II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=41, solucion="I y III", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="I", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=42, solucion="I y II", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="I", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=43, solucion="I y II", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="Que los canales permitan el viaje de moléculas de tamaño mayor a 5900 kDa", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="Acoplamiento eléctrico entre células", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=44, solucion="De intercambio de información entre leucocitos y tejidos invadidos", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="II", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=45, solucion="I y III", esSolucion=true});

		//soluciones cuarto medio 46-70

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="Ribosa", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="Glucosa", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=46, solucion="Derribosa", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="Uracilo, guanina, citosina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="Uracilo, citosina timina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=47, solucion="Citosina, timina, guanina", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=48, solucion="Pentosa, base nitrogenada y ácido fosfórico ( Fosfato)", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=48, solucion="Ribosa, base nitrogenada y fosfato", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=48, solucion="Desoxirribosa, ribosa y bases nitrogenada más fosfato", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=49, solucion="Los nucleótidos contienen fosfato, compuesto muy energético", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=49, solucion="Los nucleótidos poseen grupos fosfatos con tres grupos fosfato de baja energía", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=49, solucion="El GTP es una guanina y tres fosfatos", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=50, solucion="A-T y C-G con dos y tres enlaces de hidrógeno respectivamente.", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=50, solucion="A-C y T-G Con dos enlaces de hidrógeno y uno entre T y G ", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=50, solucion="A-G y T-C Con dos y tres enlaces de hidrógeno respectivamente", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=51, solucion="El ARN a veces consta de una cadena", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=51, solucion="El ARN contiene uracilo, El ADN contiene timina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=51, solucion="El ARN nunca se encuentra en el núcleo, el ADN nunca se encuentra en el citoplasma", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=52, solucion="Las dos hebras siguen en igual sentido y las dos van en sentido 5¨-3¨", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=52, solucion="Las dos hebras siguen un sentido contrario 5¨ ", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=52, solucion="Cada hebra sigue un sentido 5¨- 3¨", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=53, solucion="5¨AGCGATAC3¨", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=53, solucion="3¨CATAGCGT5¨", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=53, solucion="3¨ACGCTATG5¨", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=54, solucion="Adenina y timina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=54, solucion="Guanina y citosina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=54, solucion="Guanina y Uracilo", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=55, solucion="Posee la información que permite la construcción y desarrollo de un organismo, Es Código genético", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=55, solucion="En su estructura se encuentra las instrucciones para fabricar proteínas, Su estructura puede ser traspasada de generación en generación", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=55, solucion="Todas las anteriores son correctas", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=56, solucion="Las características morfológicas (Forma) e internas de los seres vivos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=56, solucion="Es el genotipo en relación con el medio ambiente, su acción puede ser modificada por las condiciones ambientales", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=56, solucion="Todas las anteriores son correctas", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=57, solucion="I", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=57, solucion="II", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=57, solucion="I y II", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=58, solucion="Puede haber ganancia o pérdida de cromosomas, desequilibrio en el número de cromosomas", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=58, solucion="Puede producirse por la disyunción de los cromosomas en la anafase y puede ocurrer en los gametos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=58, solucion="Todas las anteriores son correctas", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=59, solucion="La reducción en el número de cromosomas", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=59, solucion="La amplificación en el número de cromosomas", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=59, solucion="Permite la reproducción sexual", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=60, solucion="Contiene proteínas y ADN muy compactadas", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=60, solucion="Aparece en distintas  células del organismo", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=60, solucion="Puede sintetizar ARN", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=61, solucion="Está formado por dos vueltas completas de ADN", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=61, solucion="Es un octámero de proteínas", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=61, solucion="Está formado por proteínas histonas ,  ADN y ácidos grasos", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=62, solucion="Poseen información en todos los seres vivos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=62, solucion="Poseen secuencias de nucleótidos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=62, solucion="Se encuentran presente en el núcleo de los organismos procariotas", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=63, solucion="Es una proteína", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=63, solucion="La  produce las células beta del páncreas", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=63, solucion="Es un azúcar", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=64, solucion="Aún no se conoce el mecanismo de la transcripción del gen", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=64, solucion="Conocemos la estructura terciaria de la insulina", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=64, solucion="Conocemos las cadenas unidas por un péptido C", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=65, solucion="Se encuentra en dos cromosomas homólogos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=65, solucion="Se encuentra presente en todos los cromosomas humanos y algunos animales", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=65, solucion="En la especie humana se encuentra en una sola copia", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=66, solucion="Su secuencia muestra aminoácidos en la secuencia transcrita de ARNm", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=66, solucion="Su secuencia muestra aminoácidos en la secuencia transcrita de ARNm", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=66, solucion="Por la secuencia de nucleótidos del ARNm y la presencia de intrones y exones", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=67, solucion="A A T T U", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=67, solucion="U U A U U", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=67, solucion="T T U T T", esSolucion=false});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=68, solucion="El pH y la temperatura", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=68, solucion="La presencia o ausencia de cofactores, además de inhibidores enzimáticos", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=68, solucion="Todas las respuestas son correctas", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=69, solucion="Estructura sólo primaria", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=69, solucion="Estructura sólo secundaria", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=69, solucion="Estructura sólo terciaria", esSolucion=true});

		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=70, solucion="Se ve disminuida en el transcurso de una reacción", esSolucion=true});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=70, solucion="Aumenta gracias a la acción catalítica", esSolucion=false});
		preguntaSolucionAccion.insertUpdateData (new PreguntaSolucionBD{idPregunta=70, solucion="No se observa influenciada por acción catalítica", esSolucion=false});
	}

}

