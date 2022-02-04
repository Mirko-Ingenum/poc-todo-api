using System;
using Model.Database;

namespace Model.DTO
{
	public class UpdateBoardDto
	{
		public string Label { get; set; }

		public List<Job> Jobs { get; set; }
	}
}

