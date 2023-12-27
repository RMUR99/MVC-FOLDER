using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace mvcCore.Models.Domain
{

	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


		public DbSet<Person> Person { get; set; }



	}
}
