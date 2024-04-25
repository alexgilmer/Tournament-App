namespace Tournament_App.Models.ViewModels.Home
{
    public class AnswerBankViewModel
    {
        public IEnumerable<IGrouping<string, AnswerPartialViewModel>> AnswerGroups { get; set; } = null!;
    }
}
