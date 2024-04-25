namespace Tournament_App.Models.ViewModels.Home
{
    public class AnswerBankFormModel
    {
        private string _search = string.Empty;
        public string SearchText
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value ?? string.Empty;
            }
        }
        public bool GroupByRarity { get; set; }
        public AnswerBankSortBy SortBy { get; set; }

        public enum AnswerBankSortBy
        {
            None,
            Name,
            Points,
            Rarity
        }
    }
}
