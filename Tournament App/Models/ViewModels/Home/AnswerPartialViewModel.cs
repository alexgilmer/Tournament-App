namespace Tournament_App.Models.ViewModels.Home
{
    public class AnswerPartialViewModel
    {
        private static readonly string HiddenAnswerImg = Constants.AnswerHiddenIcon;
        private static readonly string HiddenAnswerName = Constants.AnswerHiddenName;
        private static readonly string HiddenAnswerDescription = Constants.AnswerHiddenDescription;

        private static readonly string MissingAnswerImg = Constants.AnswerMissingIcon;
        private static readonly string MissingAnswerName = Constants.AnswerMissingName;
        private static readonly string MissingAnswerDescription = Constants.AnswerMissingDescription;

        private static readonly string ImagePrefix = Constants.ImagePrefix;

        private Answer Answer { get; init; }
        private bool DisplayImage { get; init; }
        private bool DisplayName { get; init; }

        public AnswerPartialViewModel(
            Answer answer,
            bool displayImage = false,
            bool displayName = false)
        {
            Answer = answer ?? throw new ArgumentNullException(nameof(answer));
            DisplayImage = displayImage;
            DisplayName = displayName;
        }

        public string Name => DisplayName
            ? (Answer.Name ?? MissingAnswerName)
            : HiddenAnswerName;
        public string Description => Answer.DescriptionVisible
            ? (Answer.Description ?? MissingAnswerDescription)
            : HiddenAnswerDescription;
        public string Rarity => Answer.Rarity.ToString();
        public string PointValue => Answer.PointValue.ToString();
        public string ImageFileName
        {
            get
            {
                if (Answer.ImageFileName == null || Answer.ImageFileName.Length == 0)
                {
                    return ImagePrefix + MissingAnswerImg;
                }

                if (!DisplayImage)
                {
                    return ImagePrefix + HiddenAnswerImg;
                }

                return ImagePrefix + Answer.ImageFileName;
            }
        }

    }
}
