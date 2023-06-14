using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tournament_App.Models.ViewModels.Answers
{
    public class ManageChildrenViewModel
    {
        public Answer Answer { get; set; }
        public MultiSelectList AnswerSelectList { get; set; }

        public ManageChildrenViewModel(Answer answer, IEnumerable<Answer> allAnswers, IEnumerable<Answer> selectedAnswers)
        {
            Answer = answer;
            AnswerSelectList = new(allAnswers.OrderBy(a => a.Name), "Id", "Name", selectedAnswers.Select(a => a.Id));
        }
    }
}
