namespace Tournament_App.Models.ViewModels.Teams
{
    public class IndexViewModel
    {
        public IEnumerable<Group> Groups { get; init; }

        public class Group
        {
            public string Name { get; init; }
            public int Points { get; init; }
            public IList<Member> Members { get; init; }
        }

        public class Member
        {
            public string ApplicationUserId { get; init; }
            public string Name { get; init; }
        }
    }
}
