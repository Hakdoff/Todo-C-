namespace To_Do.Models.Entities
{
	public class Schedule
	{
		public int Id { get; set; }
		public string Title { get; set; } = "";

		public DateTime CreatedAt { get; set; }

		public Schedule()
		{
			CreatedAt = DateTime.UtcNow;
		}
	}
}
