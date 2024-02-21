using Microsoft.EntityFrameworkCore;

namespace Mission06_Fuge.Models
{
    public class MoviesCollectionContext : DbContext
    {
        public MoviesCollectionContext(DbContextOptions<MoviesCollectionContext> options) : base(options) {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
