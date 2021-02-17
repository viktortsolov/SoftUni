using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count 
        { 
            get
            {
                return this.roster.Count;
            }
        }
        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }
        //NOT SURE FOR THIS ONE
        public bool RemovePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);

            return roster.Remove(player);
        }
        public void PromotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] players = roster.Where(x => x.Class == @class).ToArray();

            this.roster = this.roster.Where(x => x.Class != @class).ToList();
            return players;
        }
        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Players in the guild: {this.Name}");
            foreach (Player player in this.roster)
            {
                stringBuilder.AppendLine(player.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
