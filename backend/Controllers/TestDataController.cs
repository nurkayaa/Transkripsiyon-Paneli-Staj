using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ProjeStaj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestDataController : ControllerBase
    {
        private readonly string _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "test-data");

        public TestDataController()
        {
            
            var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
            _dataPath = Path.Combine(projectRoot ?? "", "test-data");
        }

        [HttpGet("audio")]
        public IActionResult GetAudio()
        {
            var filePath = Path.Combine(_dataPath, "test.mp3");
            if (!System.IO.File.Exists(filePath))
                return NotFound("Ses dosyası bulunamadı.");

            var audioBytes = System.IO.File.ReadAllBytes(filePath);
            return File(audioBytes, "audio/mpeg", "test.mp3");
        }

        [HttpGet("transcription")]
        public IActionResult GetTranscription()
        {
            var jsonPath = Path.Combine(_dataPath, "transcription.json");
            if (!System.IO.File.Exists(jsonPath))
                return NotFound("Transkripsiyon dosyası bulunamadı.");

            var jsonContent = System.IO.File.ReadAllText(jsonPath);
            return Content(jsonContent, "application/json");
        }
    }
}
