public class ResultadoRespuestaItem
{


	public ResultadoRespuestaItem(bool esCorrecta, string respuesta){
		this.esCorrecta = esCorrecta;
		this.respuesta = respuesta;
	}

	public bool esCorrecta { get; set; }

	public string respuesta { get; set; }

}