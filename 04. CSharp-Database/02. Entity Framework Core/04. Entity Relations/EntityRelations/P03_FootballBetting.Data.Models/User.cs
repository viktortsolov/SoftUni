namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        //Password in the DB are stored hashed
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [Required]
        [MaxLength(75)]
        public string Email { get; set; }

        [Required]
        [MaxLength(75)]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
