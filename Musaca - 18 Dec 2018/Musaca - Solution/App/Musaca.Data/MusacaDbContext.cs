namespace Musaca.Data
{
    using Microsoft.EntityFrameworkCore;

    public class MusacaDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(DataSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
