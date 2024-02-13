namespace Tournament_App.Models
{
    public class TeamGameData
    {
        // Self properties

        // FK properties
        public Guid TeamId { get; set; }
        public Guid GameDataId { get; set; }

        // Navigation properties
        public virtual Team Team { get; set; }
        public virtual GameData GameData { get; set; }
    }
}
