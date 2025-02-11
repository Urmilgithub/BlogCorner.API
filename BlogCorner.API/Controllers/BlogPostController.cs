using BlogCorner.API.Models.Domain;
using BlogCorner.API.Models.DTO;
using BlogCorner.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogCorner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPostController(IBlogPostRepository _blogPostRepository)
        {
            blogPostRepository = _blogPostRepository;
        }

        [HttpGet("GetBlogList")]
        public async Task<IActionResult> GetBlogpostList()
        {
            var blogpost = await blogPostRepository.GetAllBlogPost();

            var response = new List<BlogPostDTO>();
            foreach (var Blogpost in blogpost)
            {
                response.Add(new BlogPostDTO
                {
                    Id = Blogpost.Id,
                    Title = Blogpost.Title,
                    ShortDescription = Blogpost.ShortDescription,
                    Content = Blogpost.Content,
                    FeaturedImageUrl = Blogpost.FeaturedImageUrl,
                    UrlHandle = Blogpost.UrlHandle,
                    PublishedDate = Blogpost.PublishedDate,
                    Author = Blogpost.Author,
                    IsVisible = Blogpost.IsVisible,
                });
            }

            return Ok(response);
        }

        [HttpGet("GetBlogPostById")]
        public async Task<IActionResult> GetBlogpostById(Guid id)
        {
            var blogpost = await blogPostRepository.GetBlogByIdAsync(id);
            if (blogpost == null)
            {
                return NotFound();
            }

            var response = new BlogPostDTO
            {
                Title = blogpost.Title,
                ShortDescription = blogpost.ShortDescription,
                Content = blogpost.Content,
                FeaturedImageUrl = blogpost.FeaturedImageUrl,
                UrlHandle = blogpost.UrlHandle,
                PublishedDate = blogpost.PublishedDate,
                Author = blogpost.Author,
                IsVisible = blogpost.IsVisible,
            };

            return Ok(blogpost);
        }


        [HttpPost("AddBlogPost")]
        public async Task<IActionResult> AddBlogPost(AddBlogPostDTO addBlogPostDTO)
        {
            var blogpost = new BlogPost
            {
                Title = addBlogPostDTO.Title,
                ShortDescription = addBlogPostDTO.ShortDescription,
                Content = addBlogPostDTO.Content,
                FeaturedImageUrl = addBlogPostDTO.FeaturedImageUrl,
                UrlHandle = addBlogPostDTO.UrlHandle,
                PublishedDate = addBlogPostDTO.PublishedDate,
                Author = addBlogPostDTO.Author,
                IsVisible = addBlogPostDTO.IsVisible,
            };

            await blogPostRepository.AddBlogAsync(blogpost);

            var addblogpost = new BlogPostDTO
            {
                Id = blogpost.Id,
                Title = blogpost.Title,
                ShortDescription = blogpost.ShortDescription,
                Content = blogpost.Content,
                FeaturedImageUrl = blogpost.FeaturedImageUrl,
                UrlHandle = blogpost.UrlHandle,
                PublishedDate = blogpost.PublishedDate,
                Author = blogpost.Author,
                IsVisible = blogpost.IsVisible,
            };

            return Ok(blogpost);
        }


        //public async Task<IActionResult> UpdateBlogpostAsync(Guid id,  BlogPost blogpost)
        //{
        //    var blogpost = await blogPostRepository.UpdateBlogByIdAsync(id, b);
        //    if (blogpost == null)
        //    {
        //        return NotFound();
        //    }

        //    var response = new BlogPostDTO
        //    {

        //    }
    }
}
