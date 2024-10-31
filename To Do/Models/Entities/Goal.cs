namespace To_Do.Models.Entities
{
	public class Goal
	{
		public int Id { get; set; }
		public string Title { get; set; } = "";

		public bool IsCompleted { get; set; }

		public DateTime CreatedAt { get; set; }

		public Goal()
		{
			CreatedAt = DateTime.UtcNow;
		}
	}


}
