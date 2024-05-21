using BlogCorner.API.Models.Domain;

namespace BlogCorner.API.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategoryAsync(Category category);
    }
}
