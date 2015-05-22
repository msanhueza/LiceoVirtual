using SQLite;

namespace LiceoVirtual{

	public class PuntuacionBD
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public int IdUsuario { get; set; }

		public int nivel { get; set; }

		public string fecha { get; set; }

		public int puntaje { get; set; }

		public override string ToString()
		{
			return string.Format("[PuntuacionBD: IdUsuario={0}, nivel={1}, fecha={2}, puntaje={3}]", IdUsuario, nivel, fecha, puntaje);
		}
	}
}

