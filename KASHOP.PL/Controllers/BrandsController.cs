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
        public async Task<IActionResult> AddBrandAsync(Brand brand)
        {
            await _repository.CreateAsync(brand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrandAsync(int id)
        {
            await _repository.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
            var brands = await _repository.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandByIdAsync(int id)
        {
            var brand = await _repository.GetByIdAsync(id);
            return Ok(brand);
        }
    }
}
