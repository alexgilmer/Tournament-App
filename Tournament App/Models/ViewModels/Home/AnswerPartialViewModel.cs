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
        private bool? DisplayDescriptionOverride { get; init; }

        public AnswerPartialViewModel(
            Answer answer,
            bool displayImage = false,
            bool displayName = false,
            bool? displayDescriptionOverride = null)
        {
            Answer = answer ?? throw new ArgumentNullException(nameof(answer));
            DisplayImage = displayImage;
            DisplayName = displayName;
            DisplayDescriptionOverride = displayDescriptionOverride;
        }

        public string Name => DisplayName
            ? (Answer.Name ?? MissingAnswerName)
            : HiddenAnswerName;
        public string Description
        {
            get
            {
                if (Answer.Description == null || Answer.Description.Length == 0)
                    return MissingAnswerDescription;

                if (DisplayDescriptionOverride == true)
                    return Answer.Description;

                if (DisplayDescriptionOverride == false)
                    return HiddenAnswerDescription;

                if (Answer.DescriptionVisible)
                    return Answer.Description;

                return HiddenAnswerDescription;
            }
        }
        public string Rarity
        {
            get
            {
                if (Answer.Rarity == AnswerRarity.RedHerring)
                    return "Red Herring";

                return Answer.Rarity.ToString();
            }
        }
        public string PointValueText
        {
            get
            {
                bool plural = Math.Abs(Answer.PointValue) != 1;

                if (plural)
                    return Answer.PointValue.ToString() + " points";

                return Answer.PointValue.ToString() + " point";
            }
        }
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
