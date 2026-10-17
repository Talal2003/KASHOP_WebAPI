using KASHOP.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        //[HttpPost("")]
        //public IActionResult AddCategory(Category category)
        //{
        //    _service.Create(category);
        //    return Ok();
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateCategory(Category category, int id)
        //{
        //    _service.Update(category, id);
        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public IActionResult RemoveCategory(int id)
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpGet("")]
        public IActionResult GetAllCategories()
        {
            var categories = _service.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _service.GetById(id);
            return Ok(category);
        }
    }
}
