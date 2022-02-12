using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models.Users
{
    public class RegisterViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}