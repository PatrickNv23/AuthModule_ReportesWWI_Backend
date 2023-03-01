using Microsoft.EntityFrameworkCore;
using webreportes_backend.Models;

namespace webreportes_backend.Context
{
	public class UserContext : DbContext
	{
		public UserContext(DbContextOptions<UserContext> options) : base(options) { }

		public DbSet<MUser> Users { get; set; }
	}
}
