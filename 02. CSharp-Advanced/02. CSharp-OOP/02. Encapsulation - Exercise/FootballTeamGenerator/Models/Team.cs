using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private readonly ICollection<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.INVALID_NAME_EXC_MSG);
                }
                this.name = value;
            }
        }
        public int Rating
            => this.players.Count > 0 ? (int)Math.Round((this.players.Average(p => p.OverallSkill))) : 0;

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(player => player.Name == playerName);

            if (player == null)
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.MISSING_PLAYER_EXC_MSG, playerName, this.Name));
            }

            this.players.Remove(player);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
