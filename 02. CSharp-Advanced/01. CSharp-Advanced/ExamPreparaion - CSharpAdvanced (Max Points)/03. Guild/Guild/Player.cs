using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string classOfPlayer)
        {
            this.Name = name;
            this.Class = classOfPlayer;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Player {this.Name}: {this.Class}");
            stringBuilder.AppendLine($"Rank: {this.Rank}");
            stringBuilder.AppendLine($"Description: {this.Description}");
            return stringBuilder.ToString().TrimEnd();
        }

    }
}
