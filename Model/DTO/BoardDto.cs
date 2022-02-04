using System;
using Model.Database;

namespace Model.DTO
{
	public class BoardDto
	{
		public string Id { get; set; }

		public List<JobDto> Jobs { get; set; }
	}
}

