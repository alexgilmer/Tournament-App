namespace Tournament_App.Models.ViewModels.GameData
{
    public class CreateGameDataFormModel
    {
        public string Key { get; set; }
        public string? Description { get; set; }
        public string? FileName { get; set; }
        public IFormFile? File { get; set; }
        public string Data { get; set; }
        public virtual ICollection<Guid> TeamIds { get; set; }
    }
}
