namespace To_Do.Models.DTO
{
	public class WeeklyDTO
	{
		public string Title { get; set; } = "";
		public string Description { get; set; } = "";

		public bool IsCompleted { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}
