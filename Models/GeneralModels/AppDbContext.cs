using Microsoft.EntityFrameworkCore;

namespace DevAlApplication.Models.GeneralModels
{
    public class AppDbContext : DbContext
    {
        private string _connectionstring;
        public AppDbContext()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionstring = config["ConnectionStrings:configurationDb"];
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionstring);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.UserID);
            modelBuilder.Entity<Post>().HasKey(e => e.ID);
            modelBuilder.Entity<Category>().HasKey(e => e.Id);
        }
    }
}
