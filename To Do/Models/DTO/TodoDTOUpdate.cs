namespace To_Do.Models.DTO
{
	public class TodoDTOUpdate
	{
		public string Title { get; set; } = "";
		public string Description { get; set; } = "";

		private DateTime _deadline;
		public DateTime Deadline
		{
			get => _deadline;
			set => _deadline = DateTime.SpecifyKind(value, DateTimeKind.Utc);
		}

		public bool IsCompleted { get; set; }
	}
}
