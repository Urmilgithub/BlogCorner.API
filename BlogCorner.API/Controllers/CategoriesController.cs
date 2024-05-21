using BlogCorner.API.Data;
using BlogCorner.API.Models.Domain;
using BlogCorner.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogCorner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDTO addCategoryDTO)
        {
            var category = new Category
            {
                Name = addCategoryDTO.Name,
                UrlHandle = addCategoryDTO.UrlHandle,
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var addcategory = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

            return Ok(category);
        }
    }
}
