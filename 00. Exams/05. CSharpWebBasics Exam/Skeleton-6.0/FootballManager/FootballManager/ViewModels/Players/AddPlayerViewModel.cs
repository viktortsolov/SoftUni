namespace FootballManager.ViewModels.Players
{
    using System.ComponentModel.DataAnnotations;

    public class AddPlayerViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "{0} must be {2} to {1} characters long.")]
        public string FullName { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be {2} to {1} characters long.")]
        public string Position { get; set; }

        [Required]
        [Range(0, 20)]
        public byte Speed { get; set; }

        [Required]
        [Range(0, 10)]
        public byte Endurance { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 0, ErrorMessage = "{0} must be {2} to {1} characters long.")]
        public string Description { get; set; }
    }
}