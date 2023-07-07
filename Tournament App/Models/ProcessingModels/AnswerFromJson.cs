namespace Tournament_App.Models.ProcessingModels
{
    public class AnswerFromJson
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PointValue { get; set; }
        public AnswerRarity Rarity { get; set; }
        public string ImageFileName { get; set; } = string.Empty;
        public bool DescriptionVisible { get; set; }

        public string? ParentAnswerName { get; set; }
    }
}
