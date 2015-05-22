public class PreguntaItem
{


	public PreguntaItem(int ID, string pregunta, int nivel){
		this.ID= ID;
		this.pregunta = pregunta;
		this.nivel = nivel;
	}

	public int ID { get; set; }

	public string pregunta { get; set; }

	public int nivel { get; set; }

}

