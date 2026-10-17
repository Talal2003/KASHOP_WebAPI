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
        //public async Task<IActionResult> AddCategoryAsync(Category category)
        //{
        //    await _service.CreateAsync(category);
        //    return Ok();
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCategoryAsync(Category category, int id)
        //{
        //    await _service.UpdateAsync(category, id);
        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategoryAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var category = await _service.GetByIdAsync(id);
            return Ok(category);
        }
    }
}
