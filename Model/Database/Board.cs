using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Database
{
	[Table("board", Schema = "ims")]
	public class Board : Entity
	{
		public string Label { get; set; }

		public virtual ICollection<Job> Jobs { get; set; }

		//public List<Job> Jobs { get; set; }
	}
}

