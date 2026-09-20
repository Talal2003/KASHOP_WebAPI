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
        private readonly GenericRepository<Category> _repository;
        public CategoriesController(GenericRepository<Category> repo)
        {
            _repository = repo;
        }

        [HttpPost("")]
        public IActionResult AddCategory(Category category)
        {
            _repository.Create(category);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(Category category, int id)
        {
            _repository.Update(category, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCategory(int id)
        {
            _repository.Remove(id);
            return Ok();
        }

        [HttpGet("")]
        public IActionResult GetAllCategories()
        {
            var categories = _repository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _repository.GetById(id);
            return Ok(category);
        }
    }
}
