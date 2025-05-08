using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin,editor")]

    public class AudioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AudioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAudioFiles()
        {
            var audioFiles = _context.AudioFiles.ToList();
            return Ok(audioFiles);
        }
        [HttpGet("{id}")]
        public IActionResult GetAudioFileById(int id)
        {
            var audioFile = _context.AudioFiles.FirstOrDefault(a => a.Id == id);
            if (audioFile == null)
            {
                return NotFound();
            }

            
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (userId != null)
            {
                var log = new UserActionLog
                {
                    UserId = int.Parse(userId),
                    ActionType = "Ses dinlendi.",
                    AudioId = audioFile.Id,
                    Timestamp = DateTime.UtcNow
                };
                _context.UserActionLogs.Add(log);
                _context.SaveChanges();
            }

            return Ok(audioFile);
        }

    }
}
