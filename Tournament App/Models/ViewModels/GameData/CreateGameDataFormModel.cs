namespace Tournament_App.Models.ViewModels.GameData
{
    public class CreateGameDataFormModel
    {
        public string? Description { get; set; }
        public string? FileName { get; set; }
        public IFormFile? File { get; set; }
        public virtual ICollection<Guid> TeamIds { get; set; }
    }
}
