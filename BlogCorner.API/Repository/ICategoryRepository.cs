using BlogCorner.API.Models.Domain;
using Microsoft.Identity.Client;

namespace BlogCorner.API.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategoryList();
        Task<Category?> GetCategoryByIdAsync(Guid id);
        Task<Category?> UpdateCategoryByIdAsync(Guid id, Category category);


    }
}
