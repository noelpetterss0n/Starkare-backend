using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using starkare_backend.Data;
using starkare_backend.Models;

namespace starkare_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // ⛔ Requires authentication
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.ToList());
        }
    }
}