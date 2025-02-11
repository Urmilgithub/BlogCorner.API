using BlogCorner.API.Data;
using BlogCorner.API.Models.Domain;
using BlogCorner.API.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BlogCorner.API.Service
{
    public class BlogPostService : IBlogPostRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BlogPostService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<BlogPost> AddBlogAsync(BlogPost blogPost)
        {
            await dbContext.BlogPosts.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();

            return blogPost;
        }

        public async Task<BlogPost?> DeleteBlogByIdAsync(Guid id)
        {
            var blogpostDomain = await dbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
            if (blogpostDomain == null)
            {
                return null;
            }

            dbContext.BlogPosts.Remove(blogpostDomain);
            await dbContext.SaveChangesAsync();

            return blogpostDomain;
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogPost()
        {
           return await dbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost?> GetBlogByIdAsync(Guid id)
        {
            return dbContext.BlogPosts.FirstOrDefault(x => x.Id == id);
        }

        public async Task<BlogPost?> UpdateBlogByIdAsync(Guid id, BlogPost blogPost)
        {
            var Blogposts = await dbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
            if (Blogposts == null) 
            {
                return null;
            }
            
            dbContext.Entry(Blogposts).CurrentValues.SetValues(blogPost);

            await dbContext.SaveChangesAsync();
            return Blogposts;
        }
    }
}
