namespace Tournament_App.Models
{
    public class Constants
    {
        public const string AdminRole = "admin";

        public const string AnswerHiddenIcon = "autobot.png";
        public const string AnswerHiddenName = "Hidden";
        public const string AnswerHiddenDescription = "This flag's description is hidden until it's captured";

        public const string AnswerMissingIcon = "phone.png";
        public const string AnswerMissingName = "ERROR: MISSING TITLE";
        public const string AnswerMissingDescription = "ERROR: THIS FLAG IS MISSING A DESCRIPTION";

        public const string ImagePrefix = "/img/";
        public static string GetRarityColor(AnswerRarity answerRarity)
        {
            return answerRarity switch
            {
                AnswerRarity.Common => "#FFFFFF",
                AnswerRarity.Uncommon => "#1EFF00",
                AnswerRarity.Rare => "#065FB6",
                AnswerRarity.Epic => "#A335EE",
                AnswerRarity.Legendary => "#F57B01",
                AnswerRarity.RedHerring => "#FF0000",
                _ => "#FFFFFF",
            };
        }
    }
}
