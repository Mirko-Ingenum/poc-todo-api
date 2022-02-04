using Microsoft.EntityFrameworkCore;
using Model.Database;

namespace EntityFramework
{
    public class TodoContext : DbContext
	{
		public TodoContext(DbContextOptions<TodoContext> options): base(options)
		{
		}

		public DbSet<Job> Jobs { get; set; }

		public DbSet<Board> Boards { get; set; }
	}
}

