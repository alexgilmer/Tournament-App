namespace Tournament_App.Models.ViewModels.Answers
{
    public class CreateAnswerFormModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PointValue { get; set; }
        public AnswerRarity Rarity { get; set; }
        public string FileName { get; set; } = string.Empty;
        public bool DescriptionVisible { get; set; }
        public int? ParentAnswer { get; set; }

        public bool IsValid =>
            !string.IsNullOrEmpty(Name) &&
            !string.IsNullOrEmpty(Code) &&
            !string.IsNullOrEmpty(Description);
    }
}
