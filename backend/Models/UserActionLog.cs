namespace backend.Models
{
    public class UserActionLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }              
        public string ActionType { get; set; }       
        public int? AudioId { get; set; }            
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
