namespace SMS.Services
{
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public (bool registered, string error) Register(RegisterViewModel model)
        {
            bool registered = false;
            string error = string.Empty;

            var (isValid, validationError) = ValidateRegisterModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            Cart cart = new Cart();

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashPassword(model.Password),
                Cart = cart,
                CartId = cart.Id
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

        private (bool isValid, string error) ValidateRegisterModel(RegisterViewModel model)
        {
            var context = new ValidationContext(model);
            var errorResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errorResult, true);

            if (isValid)
            {
                return (isValid, null);
            }

            string error = String.Join("; ", errorResult.Select(e => e.ErrorMessage));

            return (isValid, error);
        }

        private string HashPassword(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }

        //private (bool isValid, string error) ValidateRegisterModel(RegisterViewModel model)
        //{
        //    bool isValid = true;
        //    StringBuilder error = new StringBuilder();

        //    if (model == null)
        //    {
        //        return (false, "Register model is required!");
        //    }

        //    if (string.IsNullOrWhiteSpace(model.Username) ||
        //        model.Username.Length < 5 ||
        //        model.Username.Length > 20)
        //    {
        //        isValid = false;
        //        error.AppendLine("Username must be between 5 and 20 characters!");
        //    }

        //    if (string.IsNullOrWhiteSpace(model.Email))
        //    {
        //        isValid = false;
        //        error.AppendLine("Email must be valid!");
        //    }

        //    if (string.IsNullOrWhiteSpace(model.Password) ||
        //        model.Password.Length < 6 ||
        //        model.Password.Length > 20)
        //    {
        //        isValid = false;
        //        error.AppendLine("Password must be between 6 and 20 characters!");
        //    }

        //    if (model.Password != model.ConfirmPassword)
        //    {
        //        isValid = false;
        //        error.AppendLine("Password and Confirm Password must be equal!");
        //    }

        //    return (isValid, error.ToString().Trim());
        //}
    }
}
