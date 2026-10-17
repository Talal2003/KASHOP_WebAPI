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
        public IActionResult AddBrand(Brand brand)
        {
            _repository.Create(brand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBrand(int id)
        {
            _repository.Remove(id);
            return Ok();
        }

        [HttpGet("")]
        public IActionResult GetAllBrands()
        {
            var brands = _repository.GetAll();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult GetBrandById(int id)
        {
            var brand = _repository.GetById(id);
            return Ok(brand);
        }
    }
}
