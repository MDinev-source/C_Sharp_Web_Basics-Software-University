namespace CarShop.Data
{
    using CarShop.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Issue> Issues { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-2R59647\SQLEXPRESS;Database=CarShop;Integrated Security=true;");
            }
        }
    }
}
