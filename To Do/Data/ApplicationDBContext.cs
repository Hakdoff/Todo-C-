using Microsoft.EntityFrameworkCore;
using To_Do.Models.Entities;

namespace To_Do.Data
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
		
		public DbSet<Todo> Todos { get; set; }
	}
}
