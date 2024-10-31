using Microsoft.EntityFrameworkCore;
using To_Do.Models.Entities;

namespace To_Do.Data
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
		
		public DbSet<Todo> Todos { get; set; }
		public DbSet<Goal> Goals { get; set; }

		public DbSet<Note> Notes { get; set; }

		public DbSet<Weekly> Weekly { get; set; }

		public DbSet<Monthly> Monthly { get; set; }

	}
}
