namespace FootballManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        public Player()
        {
            Id = Guid.NewGuid().ToString();
            UserPlayers = new List<UserPlayer>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(20)]
        public string Position { get; set; }

        [Required]
        public byte Speed { get; set; }

        [Required]
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}