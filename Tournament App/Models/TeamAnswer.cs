namespace Tournament_App.Models
{
    public class TeamAnswer
    {
        // Self properties
        
        // FK properties
        public Guid TeamId { get; set; }
        public int AnswerId { get; set; }

        // Navigation properties
        public virtual Team Team { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
