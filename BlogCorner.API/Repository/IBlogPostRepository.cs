using BlogCorner.API.Models.Domain;

namespace BlogCorner.API.Repository
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> AddBlogAsync(BlogPost blogPost);
        Task<IEnumerable<BlogPost>> GetAllBlogPost();
        Task<BlogPost?> GetBlogByIdAsync(Guid id);
        Task<BlogPost?> UpdateBlogByIdAsync(Guid id, BlogPost blogPost);
        Task<BlogPost?> DeleteBlogByIdAsync(Guid id);
    }
}
