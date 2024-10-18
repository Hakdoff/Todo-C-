namespace To_Do.Models.Entities
{
	public class Todo
	{
		public int Id { get; set; }
		public string Title { get; set; } = "";
		public string Description { get; set; } = "";

		private DateTime _deadline;
		public DateTime Deadline
		{
			get => _deadline;
			set => _deadline = DateTime.SpecifyKind(value, DateTimeKind.Utc);
		}


		public bool IsCompleted { get; set; }

		private DateTime _createdAt;
		public DateTime CreatedAt
		{
			get => _createdAt;
			set => _createdAt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
		}

	}
}
