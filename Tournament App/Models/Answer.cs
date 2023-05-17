namespace Tournament_App.Models
{
    public class Answer
    {
        // Self properties
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointValue { get; set; }

        // FK properties

        // Navigation properties
        public virtual ICollection<TeamAnswer> TeamAnswers { get; set; }
    }
}
