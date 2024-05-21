using BlogCorner.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogCorner.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<BlogPost> BlogPosts {  get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
