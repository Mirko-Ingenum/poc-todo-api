using System;
namespace Model.DTO
{
	public class AddJobDto
	{
		public string Title { get; set; }

		public DateTime? DueDate { get; set; }

		public string Description { get; set; }

		public string BoardId { get; set; }
	}
}

