using SQLite;

namespace LiceoVirtual{

	public class PreguntaSolucionBD
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public int idPregunta { get; set; }

		public string solucion { get; set; }

		public string imagen { get; set; }

		public bool esSolucion { get; set; }

		public override string ToString()
		{
			return string.Format("[PreguntaSolucionBD: idPregunta={0}, solucion={1}, imagen={2}, esSolucion={3}", idPregunta, solucion, imagen, esSolucion);
		}
	}
}

