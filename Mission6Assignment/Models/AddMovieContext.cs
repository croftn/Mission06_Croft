using Microsoft.EntityFrameworkCore;


namespace NyaCroftMission6Assignment.Models
{
    public class AddMovieContext : DbContext
    {
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base(options) // Constructor
        {
        }

        public DbSet<AddMovieForm> Movies { get; set; }
    }
}