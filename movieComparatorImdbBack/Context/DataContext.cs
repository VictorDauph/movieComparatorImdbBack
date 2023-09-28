global using Microsoft.EntityFrameworkCore;
using movieComparatorImdbBack.config;
using movieComparatorImdbBack.models;

namespace minimalWebApiDotNet.Context
{
    public class DataContext:DbContext
    {
        public DbSet<WordClass> Words{ get; set; } = null!;

        public DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //la connection string ne doit pes être codée en dur.
            optionsBuilder.UseSqlServer(ConnectionString.GetString());
        }

    }
}
