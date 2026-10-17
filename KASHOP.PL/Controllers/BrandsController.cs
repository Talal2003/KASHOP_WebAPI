using KASHOP.DAL.Models;
using KASHOP.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IGenericRepository<Brand> _repository;
        public BrandsController(IGenericRepository<Brand> repository)
        {
            _repository = repository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBrandAsync(Brand brand, CancellationToken cancellationToken = default)
        {
            await _repository.CreateAsync(brand, cancellationToken);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrandAsync(Brand brand, int id, CancellationToken cancellationToken = default)
        {
            await _repository.UpdateAsync(brand, id, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrandAsync(int id, CancellationToken cancellationToken = default)
        {
            await _repository.RemoveAsync(id, cancellationToken);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBrandsAsync(CancellationToken cancellationToken = default)
        {
            var brands = await _repository.GetAllAsync(cancellationToken);
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var brand = await _repository.GetByIdAsync(id, cancellationToken);
            return Ok(brand);
        }
    }
}
