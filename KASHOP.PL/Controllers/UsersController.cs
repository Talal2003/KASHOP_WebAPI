using KASHOP.DAL;
using KASHOP.PL.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context) {
            _context = context;
        }
    }
}