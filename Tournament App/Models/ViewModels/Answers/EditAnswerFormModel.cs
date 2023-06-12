namespace Tournament_App.Models.ViewModels.Answers
{
    public class EditAnswerFormModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PointValue { get; set; }
        public int? ParentAnswerId { get; set; }
        public AnswerRarity Rarity { get; set; }
        public string FileName { get; set; } = string.Empty;
        public bool DescriptionVisible { get; set; }

    }
}
