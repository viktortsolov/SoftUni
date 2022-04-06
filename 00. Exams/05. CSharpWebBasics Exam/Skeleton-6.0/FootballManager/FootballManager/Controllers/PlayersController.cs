namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Contracts;
    using FootballManager.ViewModels.Players;

    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(
            Request request,
            IPlayerService _playerService)
            : base(request)
        {
            playerService = _playerService;
        }

        [Authorize]
        public Response All()
        {
            var players = playerService.ReturnPlayers();

            return View(new { players = players, IsAuthenticated = true });
        }

        [Authorize]
        public Response Add()
            => View(new { IsAuthenticated = true });

        [HttpPost]
        [Authorize]
        public Response Add(AddPlayerViewModel model)
        {
            var (created, error) = playerService.Create(model, User.Id);

            if (!created)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/");
        }

        [Authorize]
        public Response Collection()
        {
            var players = playerService.ReturnCollectionOfPlayers(User.Id); 

            return View(new { players = players, IsAuthenticated = true }); 
        }

        [Authorize]
        public Response AddToCollection(string playerId)
        {
            try
            {
                playerService.AddPlayerToCollection(User.Id, playerId);
            }
            catch (ArgumentException aex)
            {
                return View(new { ErrorMessage = aex.Message }, "/Error");
            }
            catch (Exception)
            {
                return View(new { ErrorMessage = "Player is already in the collection!" }, "/Error");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response RemoveFromCollection(string playerId)
        {
            playerService.RemovePlayerFromCollection(User.Id, playerId);

            return Redirect("/Players/Collection");
        }
    }
}
