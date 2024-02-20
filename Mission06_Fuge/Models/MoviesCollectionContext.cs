using Microsoft.EntityFrameworkCore;

namespace Mission06_Fuge.Models
{
    public class MoviesCollectionContext : DbContext
    {
        public MoviesCollectionContext(DbContextOptions<MoviesCollectionContext> options) : base(options) {
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
