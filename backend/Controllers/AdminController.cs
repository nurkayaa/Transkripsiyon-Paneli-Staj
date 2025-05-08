using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("logs")]
        public IActionResult GetLogs()
        {
            var logs = _context.UserActionLogs
                .OrderByDescending(log => log.Timestamp)
                .Take(100)
                .ToList();

            return Ok(logs);
        }
    }
}
