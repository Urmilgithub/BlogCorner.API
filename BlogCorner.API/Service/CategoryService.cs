using BlogCorner.API.Data;
using BlogCorner.API.Models.Domain;
using BlogCorner.API.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<Category?> DeleteCategoryByIdAsync(Guid id)
        {
            var categoryDomain = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (categoryDomain == null)
            {
                return null;
            }

            dbContext.Categories.Remove(categoryDomain);
            await dbContext.SaveChangesAsync();

            return categoryDomain;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryList()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id );
        }

        public async Task<Category?> UpdateCategoryByIdAsync(Guid id, Category category)
        {
            var categories = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (categories == null)
            {
                return null;
            }

            dbContext.Entry(categories).CurrentValues.SetValues(category);

            await dbContext.SaveChangesAsync();
            return categories;
        }
    }
}
