namespace Tournament_App.Models
{
    public class Team
    {
        // Self properties
        public int Id { get; set; }
        public string Name { get; set; }

        // FK properties

        // Navigation properties
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<TeamAnswer> TeamAnswers { get; set; }
    }
}
