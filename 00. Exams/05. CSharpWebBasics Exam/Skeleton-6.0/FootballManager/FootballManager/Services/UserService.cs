namespace FootballManager.Services
{
    using FootballManager.ViewModels.Users;
    using System.Security.Cryptography;
    using System.Text;
    using FootballManager.Contracts;
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;

    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public UserService(
            IRepository _repo,
            IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public string GetUsername(string userId)
        {
            return repo.All<User>()
                .FirstOrDefault(u => u.Id == userId)?.Username;
        }

        public string Login(LoginViewModel model)
        {
            var user = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == HashPassword(model.Password))
                .SingleOrDefault();

            return user?.Id;
        }

        public (bool registered, string error) Register(RegisterViewModel model)
        {
            bool registered = false;
            string error = string.Empty;

            var userExists = repo.All<User>()
                .FirstOrDefault(x => x.Username == model.Username ||
                                   x.Email == model.Email) != null;

            if (userExists)
            {
                error = "There is a user with that username or email!";
                return (registered, error);
            }

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashPassword(model.Password)
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
                error = "Could not save user in DB!";
            }

            return (registered, error);
        }

        private string HashPassword(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }
    }
}
