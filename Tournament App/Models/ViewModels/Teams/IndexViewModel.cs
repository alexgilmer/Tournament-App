namespace Tournament_App.Models.ViewModels.Teams
{
    public class IndexViewModel
    {
        public IList<Group> Groups { get; set; }

        public class Group
        {
            public string Name { get; set; }
            public int Points { get; set; }
            public IList<Member> Members { get; set; }
        }

        public class Member
        {
            public string ApplicationUserId { get; set; }
            public string Name { get; set; }
        }
    }
}
