using CrudAPIPractice.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CrudAPIPractice.Data
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions options) : base(options)
		{
			
		}
		public DbSet<Inventory> Inventories { get; set; }
	}
}
