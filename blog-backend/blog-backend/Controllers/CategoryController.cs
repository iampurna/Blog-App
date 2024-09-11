using blog_backend.Data;
using blog_backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repository;

        public CategoryController(IRepository<Category> repository)
        {
            _repository = repository;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult> GetAllCategory()
        {
            var categoryList = await _repository.GetAll();
            return Ok(categoryList);
        }
    }
}
