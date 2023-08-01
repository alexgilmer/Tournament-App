namespace Tournament_App.Models
{
    public class Team
    {
        // Self properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ApiAlias { get; set; }
        // FK properties

        // Navigation properties
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<TeamAnswer> TeamAnswers { get; set; }
    }
}
