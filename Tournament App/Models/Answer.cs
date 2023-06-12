namespace Tournament_App.Models
{
    public class Answer
    {
        // Self properties
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PointValue { get; set; }
        public AnswerRarity Rarity { get; set; }
        public string ImageFileName { get; set; } = string.Empty;
        public bool DescriptionVisible { get; set; }

        // FK properties
        public int? ParentAnswerId { get; set; }

        // Navigation properties
        public virtual ICollection<TeamAnswer> TeamAnswers { get; set; } = null!;
        public virtual Answer? ParentAnswer { get; set; }
        public virtual ICollection<Answer> ChildAnswers { get; set; } = null!;
    }

    public enum AnswerRarity
    {
        RedHerring = -1,
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
}
