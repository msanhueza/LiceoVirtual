public class PreguntaSolucionItem
{


	public PreguntaSolucionItem(int ID, int idPregunta, string solucion, string imagen, bool esSolucion){
		this.ID= ID;
		this.idPregunta = idPregunta;
		this.solucion = solucion;
		this.imagen = imagen;
		this.esSolucion = esSolucion;
	}

	public int ID { get; set; }

	public int idPregunta { get; set; }

	public string solucion { get; set; }

	public string imagen { get; set; }

	public bool esSolucion { get; set; }

}

