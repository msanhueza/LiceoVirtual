using SQLite;

namespace LiceoVirtual{

	public class PreguntaBD
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string pregunta { get; set; }

		public int nivel { get; set; }

		public override string ToString()
		{
			return string.Format("[PreguntaBD: pregunta={0}, nivel={1}", pregunta, nivel);
		}
	}
}

