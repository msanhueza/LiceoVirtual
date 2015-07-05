public class PreguntaItem
{


	public PreguntaItem(int ID, string pregunta, int idImagen, int nivel, string tipoFragment){
		this.ID= ID;
		this.pregunta = pregunta;
		this.idImagen = idImagen;
		this.nivel = nivel;
		this.tipoFragment = tipoFragment;
	}

	public int ID { get; set; }

	public string pregunta { get; set; }

	public int idImagen { get; set; }

	public int nivel { get; set; }

	public string tipoFragment { get; set; }

}

