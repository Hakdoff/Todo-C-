namespace To_Do.Models.DTO
{
	public class WeeklyUpdateDTO
	{
		public string Title { get; set; } = "";
		public string Description { get; set; } = "";

		public bool IsCompleted { get; set; }
	}
}
