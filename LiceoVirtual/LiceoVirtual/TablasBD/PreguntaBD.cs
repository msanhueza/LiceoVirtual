using SQLite;

namespace LiceoVirtual{

	public class PreguntaBD
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string pregunta { get; set; }

		public int idImagen { get; set; }

		public int nivel { get; set; }

		public string tipoFragment { get; set; }

		public override string ToString()
		{
			return string.Format("[PreguntaBD: pregunta={0}, idImagen={1}, nivel={2}, tipoFragment{3}", pregunta, idImagen, nivel, tipoFragment);
		}
	}
}

