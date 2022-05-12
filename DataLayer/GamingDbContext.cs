using BusinessLayer;
using Microsoft.EntityFrameworkCore;


namespace DataLayer
{
    public class GamingDbContext : DbContext
    {
        public GamingDbContext()
        {

        }

        public GamingDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-IPT5RHP\SQLEXPRESS;Database=GamingDb;Trusted_Connection=True;");
            }

            //base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

    }
}
