﻿using BlogCorner.API.Models.Domain;
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

        [HttpPut("UpdateBlogPost")]
        public async Task<IActionResult> UpdateBlogpostAsync(Guid id, UpdateBlogPostDTO updateBlogPostDTO)
        {
            var blogpost = new BlogPost
            {
                Id = id,
                Title = updateBlogPostDTO.Title,
                ShortDescription = updateBlogPostDTO.ShortDescription,
                Content = updateBlogPostDTO.Content,
                FeaturedImageUrl = updateBlogPostDTO.FeaturedImageUrl,
                UrlHandle = updateBlogPostDTO.UrlHandle,
                PublishedDate = updateBlogPostDTO.PublishedDate,
                Author = updateBlogPostDTO.Author,
                IsVisible = updateBlogPostDTO.IsVisible,
            };

            await blogPostRepository.UpdateBlogByIdAsync(id, blogpost);

            if (blogpost == null)
            {
                return NotFound();
            }

            var response = new BlogPostDTO
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

            return Ok(response);
        }

        [HttpDelete("DeleteBlogPost")]
        public async Task<IActionResult> DeleteBlogPost(Guid id)
        {
            var blogpost = await blogPostRepository.DeleteBlogByIdAsync(id);
            if (blogpost == null)
            {
                return NotFound();
            }

            var reponse = new BlogPostDTO
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

            return Ok(reponse);
        }
    }
}
