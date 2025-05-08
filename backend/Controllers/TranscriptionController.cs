using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using System.Linq;
using System.Security.Claims;


namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TranscriptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TranscriptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/transcription
        [HttpGet]
        
        public IActionResult GetAllTranscriptions()
        {
            var transcriptions = _context.Transcriptions.ToList();
            if (!transcriptions.Any())
                return NotFound();

            return Ok(transcriptions);
        }

        // GET: api/transcription/5
        [HttpGet("{id}")]
        public IActionResult GetTranscription(int id)
        {
            var transcription = _context.Transcriptions.FirstOrDefault(t => t.AudioId == id);

            if (transcription == null)
                return NotFound();

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            _context.UserActionLogs.Add(new UserActionLog
            {
                UserId = userId,
                ActionType = "Transkripsiyon görüntülendi.",
                AudioId = id
            });
            _context.SaveChanges();

            return Ok(transcription);
        }

        // PUT: api/transcription/5
        [HttpPut("{id}")]
        public IActionResult UpdateTranscription(int id, [FromBody] UpdateTranscriptionDto updated)
        {
            var transcription = _context.Transcriptions.FirstOrDefault(t => t.AudioId == id);

            if (transcription == null)
                return NotFound();

            
            transcription.Text = updated.Text;
            transcription.LastEdited = DateTime.UtcNow;
            var editedBy = User.FindFirst(ClaimTypes.Name)?.Value;
            transcription.EditedBy = editedBy ?? "bilinmiyor";
 

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            _context.UserActionLogs.Add(new UserActionLog
            {
                UserId = userId,
                ActionType = "Transkripsiyon düzenlendi.",
                AudioId = id,
                Timestamp = DateTime.UtcNow
            });

            _context.SaveChanges();

            return Ok(transcription);
        }
    }
}
