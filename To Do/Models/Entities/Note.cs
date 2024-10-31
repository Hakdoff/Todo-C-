namespace To_Do.Models.Entities
{
	public class Note
	{
		public int Id { get; set; }

		public string Description { get; set; } = "";

		public DateTime CreatedAt { get; set; }

		public Note()
		{
			CreatedAt = DateTime.UtcNow;
		}
	}
}
