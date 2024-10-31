namespace To_Do.Models.DTO
{
	public class GoalDTO
	{
		public string Title { get; set; } = "";
		public bool IsCompleted { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}
