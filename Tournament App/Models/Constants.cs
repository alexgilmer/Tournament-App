namespace Tournament_App.Models
{
    public class Constants
    {
        public const string AdminRole = "admin";
        
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
