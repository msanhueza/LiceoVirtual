public class NivelDesbloqueadoItem
{


	public NivelDesbloqueadoItem(int nivel, bool desbloqueado){
		this.nivel = nivel;
		this.desbloqueado = desbloqueado;
	}

	public int nivel { get; set; }

	public bool desbloqueado { get; set; }

}