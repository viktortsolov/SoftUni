namespace SMS.Contracts
{
    using SMS.Models.Users;

    public interface IUserService
    {
        (bool registered, string error) Register(RegisterViewModel model);

        string Login(LoginViewModel model);

        string GetUsername(string userId);
    }
}
