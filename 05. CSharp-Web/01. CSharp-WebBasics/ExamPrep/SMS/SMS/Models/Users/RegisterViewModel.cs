namespace SMS.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters!")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "{0} must be valid!")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} must be between {2} and {1} characters!")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password must be equal!")]
        public string ConfirmPassword { get; set; }
    }
}
