using BlogCorner.API.Data;
using BlogCorner.API.Models.Domain;
using BlogCorner.API.Repository;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Category>> GetAllCategoryList()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id );
        }
    }
}
