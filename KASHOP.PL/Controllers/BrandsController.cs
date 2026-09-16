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
        GenericRepository<Brand> repo = new GenericRepository<Brand>();

        [HttpPost("")]
        public IActionResult AddBrand(Brand brand)
        {
            repo.Create(brand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBrand(int id)
        {
            repo.Remove(id);
            return Ok();
        }

        [HttpGet("")]
        public IActionResult GetAllBrands()
        {
            var brands = repo.GetAll();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult GetBrandById(int id)
        {
            var brand = repo.GetById(id);
            return Ok(brand);
        }
    }
}
