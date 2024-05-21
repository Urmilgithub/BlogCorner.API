using BlogCorner.API.Data;
using BlogCorner.API.Models.Domain;
using BlogCorner.API.Models.DTO;
using BlogCorner.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogCorner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDTO addCategoryDTO)
        {
            var category = new Category
            {
                Name = addCategoryDTO.Name,
                UrlHandle = addCategoryDTO.UrlHandle,
            };

            await categoryRepository.AddCategoryAsync(category);

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
