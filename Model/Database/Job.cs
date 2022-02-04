using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Database
{
	[Table("job", Schema = "ims")]
	public class Job : Entity
	{

		public string Title { get; set; }

		public DateTime? Date { get; set; }

		public string Description { get; set; }

		[ForeignKey(nameof(Board))]
        public string BoardId { get; set; }

        public virtual Board Board { get; set; } 

    }
}

