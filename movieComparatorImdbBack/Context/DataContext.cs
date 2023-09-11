global using Microsoft.EntityFrameworkCore;
using minimalWebApiDotNet.config;
using minimalWebApiDotNet.models;

namespace minimalWebApiDotNet.Context
{
    public class DataContext:DbContext
    {

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //la connection string ne doit pes être codée en dur.
            optionsBuilder.UseSqlServer(ConnectionString.GetString());
        }

    }
}
