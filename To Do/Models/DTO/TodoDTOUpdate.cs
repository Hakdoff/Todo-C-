﻿namespace To_Do.Models.DTO
{
	public class TodoDTOUpdate
	{
		public string Title { get; set; } = "";
		public string Description { get; set; } = "";

		public DateTime Deadline { get; set; }

		public bool IsCompleted { get; set; }
	}
}