using Microsoft.EntityFrameworkCore;

namespace libraly.Models
{
    public class libraryContext:DbContext
    {
        public libraryContext(DbContextOptions<libraryContext> options) : base(options)
        {

        }
        public DbSet<libralyModel> libralyModels { get; set; }
    }
}
