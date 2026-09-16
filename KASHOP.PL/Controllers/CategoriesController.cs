using KASHOP.DAL.Models;
using KASHOP.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        [HttpPost("")]
        public IActionResult AddCategory(Category category)
        {
            repo.Create(category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCategory(int id)
        {
            repo.Remove(id);
            return Ok();
        }

        [HttpGet("")]
        public IActionResult GetAllCategories()
        {
            var categories = repo.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = repo.GetById(id);
            return Ok(category);
        }
    }
}
