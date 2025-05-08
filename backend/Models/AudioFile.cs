namespace backend.Models
{
    public class AudioFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public ICollection<Transcription> Transcriptions { get; set; }
    }
}