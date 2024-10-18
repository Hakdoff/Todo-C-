﻿namespace To_Do.Models.Entities
{
	public class Todo
	{
		public int Id { get; set; }
		public string Title { get; set; } = "";
		public string Description { get; set; } = "";

		public DateTime Deadline { get; set; }

		public bool IsCompleted { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}
