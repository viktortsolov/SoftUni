namespace FootballManager.Services
{
    using FootballManager.Contracts;
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;
    using FootballManager.ViewModels.Players;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public PlayerService(
            IRepository _repo,
            IValidationService _validatonService)
        {
            repo = _repo;
            validationService = _validatonService;
        }

        public void AddPlayerToCollection(string userId, string playerId)
        {
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(x => x.UserPlayers)
                .FirstOrDefault();

            var player = repo.All<Player>()
                .FirstOrDefault(p => p.Id == playerId);

            if (user == null || player == null)
            {
                throw new ArgumentException("User or player not found!");
            }

            var userPlayer = new UserPlayer()
            {
                PlayerId = playerId,
                UserId = userId,
                Player = player,
                User = user
            };

            user.UserPlayers.Add(userPlayer);

            repo.SaveChanges();
        }

        public (bool created, string error) Create(AddPlayerViewModel model, string userId)
        {
            bool created = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            var player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description
            };

            var user = repo.All<User>()
                .Include(x => x.UserPlayers)
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            user.UserPlayers.Add(new UserPlayer()
            {
                PlayerId = player.Id,
                UserId = userId,
                Player = player,
                User = user
            });

            try
            {
                repo.Add(player);
                repo.SaveChanges();
                created = true;
            }
            catch (Exception)
            {
                error = "Could not save the product!";
            }

            return (created, error);
        }

        public void RemovePlayerFromCollection(string userId, string playerId)
        {
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(x => x.UserPlayers)
                .FirstOrDefault();

            var userPlayer = user
                .UserPlayers
                .Where(x => x.PlayerId == playerId)
                .FirstOrDefault();

            user.UserPlayers.Remove(userPlayer);

            repo.SaveChanges();
        }

        public IEnumerable<ListPlayerViewModel> ReturnCollectionOfPlayers(string userId)
        {
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(x => x.UserPlayers)
                .FirstOrDefault();

            var playersId = user
                .UserPlayers
                .Select(x => x.PlayerId);

            var players = new List<ListPlayerViewModel>();

            foreach (var player in repo.All<Player>().ToList())
            {
                if (playersId.Contains(player.Id))
                {
                    players.Add(new ListPlayerViewModel()
                    {
                        PlayerId = player.Id,
                        Description = player.Description,
                        ImageUrl = player.ImageUrl,
                        FullName = player.FullName,
                        Position = player.Position,
                        Speed = player.Speed,
                        Endurance = player.Endurance
                    });
                }
            }

            return players;
        }

        public IEnumerable<ListPlayerViewModel> ReturnPlayers()
        {
            return repo.All<Player>()
                .Select(x => new ListPlayerViewModel()
                {
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    FullName = x.FullName,
                    Position = x.Position,
                    Speed = x.Speed,
                    Endurance = x.Endurance,
                    PlayerId = x.Id

                })
                .ToList();
        }
    }
}
