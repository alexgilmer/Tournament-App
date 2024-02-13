namespace Tournament_App.Models.ViewModels.GameData
{
    public class EditGameDataFormModel
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string? Description { get; set; }
        public string? FileName { get; set; }
        public string Data { get; set; }
        public virtual ICollection<Guid> TeamIds { get; set; }

        public EditGameDataFormModel(Models.GameData gameData)
        {
            if (gameData.TeamGameData == null)
                throw new NullReferenceException($"Initializing proprty cannot be null: {nameof(gameData.TeamGameData)}");

            Id = gameData.Id;
            Description = gameData.Description;
            Data = gameData.Data;
            TeamIds = gameData.TeamGameData.Select(x => x.TeamId).ToList();
        }
        public EditGameDataFormModel() { }
    }
}
