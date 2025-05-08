using backend.Data;
using backend.Models;
using System.Text.Json;

namespace backend.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Transcriptions.Any())
                return;

            
            var jsonPath = Path.Combine("test-data", "transcription.json");

            if (!File.Exists(jsonPath))
                return;

            var jsonString = File.ReadAllText(jsonPath);
            var transcription = JsonSerializer.Deserialize<Transcription>(jsonString);

            if (transcription != null)
            {
                transcription.EditedBy = "admin";
                transcription.LastEdited = DateTime.Now;

                context.Transcriptions.Add(transcription);
                context.SaveChanges();
            }
        }
    }
}
