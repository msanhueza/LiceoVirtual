public class PreguntaSolucionItem
{


	public PreguntaSolucionItem(int ID, int idPregunta, string solucion, bool esSolucion){
		this.ID= ID;
		this.idPregunta = idPregunta;
		this.solucion = solucion;
		this.esSolucion = esSolucion;
	}

	public int ID { get; set; }

	public int idPregunta { get; set; }

	public string solucion { get; set; }

	public bool esSolucion { get; set; }

}

