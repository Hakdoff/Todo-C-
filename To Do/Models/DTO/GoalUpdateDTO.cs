namespace To_Do.Models.DTO
{
	public class GoalUpdateDTO
	{
		public string Title { get; set; } = "";

		public bool IsCompleted { get; set; }

		public DateTime createdAt { get; set; }

	}
}
