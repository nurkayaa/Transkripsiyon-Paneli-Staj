using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Transcription
    {
        public int Id { get; set; }
        public int AudioId { get; set; }
        public string Text { get; set; } // Transkripsiyon metni
        public DateTime LastEdited { get; set; }   // Son düzenleme tarihi
        public string EditedBy { get; set; }       // Son düzenlemeyi yapan kişi

        [ForeignKey("AudioId")]
        public AudioFile? AudioFile { get; set; } 

    }
}
