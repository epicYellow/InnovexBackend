using InnovexBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace InnovexBackend
{
    // This is used to define our database tables and context
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Set our tables here
        public DbSet<Staff> Staff { get; set; }

        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<AccountTypes> AccountTypes { get; set; }

        public DbSet<Transactions> Transactions { get; set; } = default!;
    }
}
