using System.Collections.Generic;

public class ListadoPreguntaSolucionItem
{


	public ListadoPreguntaSolucionItem(PreguntaItem objPregunta, List<PreguntaSolucionItem> objListaRespuestas){
		this.objPregunta= objPregunta;
		this.objListaRespuestas = objListaRespuestas;
	}

	public PreguntaItem objPregunta { get; set; }

	public List<PreguntaSolucionItem> objListaRespuestas { get; set;}

}