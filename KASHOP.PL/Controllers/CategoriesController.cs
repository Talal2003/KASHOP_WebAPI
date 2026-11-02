using KASHOP.BLL.Services;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(CategoryRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _service.CreateAsync(request, cancellationToken);
            return result ? NoContent() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(CategoryRequest request, int id, CancellationToken cancellationToken = default)
        {
            var result = await _service.UpdateAsync(request, id, cancellationToken);
            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _service.DeleteAsync(id, cancellationToken);
            return result ? NoContent() : BadRequest();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var result = await _service.GetAllAsync(cancellationToken);
            return result is not null ? Ok(result) : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _service.GetByIdAsync(id, cancellationToken);
            return result is not null ? Ok(result) : BadRequest();
        }
    }
}
