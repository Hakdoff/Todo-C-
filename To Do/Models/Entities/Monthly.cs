﻿namespace To_Do.Models.Entities
{
	public class Monthly
	{
		public int Id { get; set; }
		public string Title { get; set; } = "";
		public string Description { get; set; } = "";

		public bool IsCompleted { get; set; }
		public DateTime CreatedAt { get; set; }

		public Monthly()
		{
			CreatedAt = DateTime.UtcNow;
		}
	}
}
