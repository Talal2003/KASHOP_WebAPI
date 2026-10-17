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
        //public async Task<IActionResult> AddCategoryAsync(Category category, CancellationToken cancellationToken = default)
        //{
        //    await _service.CreateAsync(category, cancellationToken);
        //    return Ok();
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCategoryAsync(Category category, int id, CancellationToken cancellationToken = default)
        //{
        //    await _service.UpdateAsync(category, id, cancellationToken);
        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategoryAsync(int id, CancellationToken cancellationToken = default)
        {
            await _service.DeleteAsync(id, cancellationToken);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _service.GetAllAsync(cancellationToken);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var category = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(category);
        }
    }
}
