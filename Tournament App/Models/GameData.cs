namespace Tournament_App.Models
{
    public class GameData
    {
        // Self properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }

        // FK properties

        // Navigation properties
        public virtual ICollection<TeamGameData> TeamGameData { get; set; }
    }
}
