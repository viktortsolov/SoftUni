namespace FootballManager.Contracts
{
    using FootballManager.ViewModels.Players;

    public interface IPlayerService
    {
        (bool created, string error) Create(AddPlayerViewModel model,string userId);
        IEnumerable<ListPlayerViewModel> ReturnPlayers();
        IEnumerable<ListPlayerViewModel> ReturnCollectionOfPlayers(string userId);
        void AddPlayerToCollection(string userId, string playerId);
        void RemovePlayerFromCollection(string userId, string playerId);
    }
}
