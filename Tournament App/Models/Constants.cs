namespace Tournament_App.Models
{
    public class Constants
    {
        public const string AdminRole = "admin";

        public const string AnswerHiddenIcon = "autobot.png";
        public const string AnswerHiddenName = "Hidden";
        public const string AnswerHiddenDescription = "This flag's description is hidden";

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

        public static string GetRarityTextColor(AnswerRarity answerRarity)
        {
            return answerRarity switch
            {
                AnswerRarity.Common => "#000000",
                AnswerRarity.Uncommon => "#F57B01",
                AnswerRarity.Rare => "#F57B01",
                AnswerRarity.Epic => "#F57B01",
                AnswerRarity.Legendary => "#000000",
                AnswerRarity.RedHerring => "#F57B01",
                _ => "#000000"
            };
        }
    }
}
