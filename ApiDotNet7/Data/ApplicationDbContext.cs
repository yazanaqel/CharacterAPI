using ApiDotNet7.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNet7.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Character> Characters => Set<Character>();
	}
}
