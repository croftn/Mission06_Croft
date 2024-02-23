using Microsoft.EntityFrameworkCore;


namespace Mission06_Croft.Models
{
    public class AddMovieContext : DbContext
    {
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base(options) // Constructor
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}