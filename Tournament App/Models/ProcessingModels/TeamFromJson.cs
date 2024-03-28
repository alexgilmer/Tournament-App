namespace Tournament_App.Models.ProcessingModels
{
    public class TeamFromJson
    {
#pragma warning disable IDE1006 // Naming Styles
        public string teamName { get; set; } = string.Empty;
        public Member[] members { get; set; } = Array.Empty<Member>();
        public string apiAlias { get; set; } = string.Empty;

        public class Member
        {
            public string username { get; set; } = string.Empty;
            public string password { get; set; } = string.Empty;
            public string contactEmail { get; set; } = string.Empty;
        }
#pragma warning restore IDE1006 // Naming Styles
    }
}
