using SQLite;

namespace LiceoVirtual{

	public class NivelDesbloqueadoBD
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public int nivel { get; set; }

		public bool desbloqueado { get; set; }

		public override string ToString()
		{
			return string.Format("[NivelDesbloqueadoBD: nivel={0}, desbloqueado={1}", nivel, desbloqueado);
		}
	}
}

