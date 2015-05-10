using SQLite;

namespace LiceoVirtual{

	public class PuntuacionBD
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string IdUsuario { get; set; }

		public string nivel { get; set; }

		public string fecha { get; set; }

		public string puntaje { get; set; }

		public override string ToString()
		{
			return string.Format("[Person: IdUsuario={0}, nivel={1}, fecha={2}, puntaje={3}]", IdUsuario, nivel, fecha, puntaje);
		}
	}
}

