using blog_backend.Data;
using blog_backend.Dto;
using blog_backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace blog_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IRepository<Blog> _blogRepository;

        public BlogsController(IRepository<Blog> blogRepository)
        {
            this._blogRepository = blogRepository; 
        }

        [HttpGet]
        public async Task<ActionResult> GetBlogList()
        {
            var blogs = await _blogRepository.GetAll();
            return Ok(blogs);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBlog([FromRoute] int id){
            var blog = await _blogRepository.GetById(id);
            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult> AddBlog([FromBody] BlogDto model)
        {
            var blog = new Blog()
            {
                CategoryId = model.CategoryId,
                IsFeatured = model.IsFeatured,
                Content = model.Content,
                Title = model.Content,
                Description = model.Description,
                Image = model.Image
            };
            await _blogRepository.AddAsync(blog);
            await _blogRepository.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBlog([FromRoute] int id, [FromBody] BlogDto model)
        {
            var blog = await _blogRepository.GetById(id);
            blog.Description = model.Description;
            blog.Title = model.Title;
            blog.Content = model.Content;
            blog.IsFeatured = model.IsFeatured;
            blog.Image = model.Image;
            _blogRepository.Update(blog);
            await _blogRepository.SaveChangesAsync();
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBlog([FromRoute] int id)
        {
            try
            {
                var blog = await _blogRepository.GetById(id);
                if (blog == null)
                {
                    return NotFound();
                }

                await _blogRepository.DeleteAsync(id);
                await _blogRepository.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    "An error occurred while deleting the blog."); // Return a 500 error for server issues
            }
        }
        // public async Task<ActionResult> DeleteBlog([FromRoute] int id){
        //      await _blogRepository.DeleteAsync(id);
        //     return Ok();
        // }
        
        [HttpGet("featured")]
        public async Task<ActionResult> GetBlogFeatureList()
        {
            var blogs = await _blogRepository.GetAll(x=>x.IsFeatured==true);
            return Ok(blogs);
        }
    }
}
