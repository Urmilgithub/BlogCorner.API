using BlogCorner.API.Data;
using BlogCorner.API.Models.Domain;
using BlogCorner.API.Repository;

namespace BlogCorner.API.Service
{
    public class CategoryService : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }
    }
}
