using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamCount; i++)
            {
                string[] newTeam = Console.ReadLine().Split("-");
                string creatorName = newTeam[0];
                string teamName = newTeam[1];

                Team team = new Team(teamName, creatorName);

                bool isTeamNameExist = teams.Select(x => x.TeamName)
                                            .Contains(teamName);

                bool isCreatorNameExist = teams.Select(x => x.CreatorName)
                                                .Contains(creatorName);

                if (!isTeamNameExist)
                {
                    if (!isCreatorNameExist)
                    {
                        teams.Add(team);
                        Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                    }
                    else
                    {
                        Console.WriteLine($"{creatorName} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
            }

            string teamMembers = string.Empty;

            while ((teamMembers = Console.ReadLine()) != "end of assignment")
            {
                string[] cmdArg = teamMembers.Split("->").ToArray();
                string newUser = cmdArg[0];
                string teamName = cmdArg[1];

                bool isTeamExisting = teams.Select(x => x.TeamName)
                                           .Contains(teamName);
                bool isCreatorExist = teams.Select(x => x.CreatorName)
                                           .Contains(newUser);
                bool isMemberExist = teams.Select(x => x.Members)
                                          .Any(x => x.Contains(newUser));

                if (!isTeamExisting)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (isCreatorExist || isMemberExist)
                {
                    Console.WriteLine($"Member {newUser} cannot join team {teamName}!");
                }
                else
                {
                    int index = teams.FindIndex(x => x.TeamName == teamName);
                    teams[index].Members.Add(newUser);
                }
            }

            Team[] teamsToDisband = teams.OrderBy(x => x.TeamName)
                                         .Where(x => x.Members.Count == 0)
                                         .ToArray();

            Team[] fullTeam = teams.OrderByDescending(x => x.Members.Count)
                                   .ThenBy(x => x.TeamName)
                                   .Where(x => x.Members.Count > 0)
                                   .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (Team team in fullTeam)
            {
                sb.AppendLine($"{team.TeamName}");
                sb.AppendLine($"- {team.CreatorName}");

                foreach (var member in team.Members.OrderBy(x => x))
                {
                    sb.AppendLine($"-- {member}");
                }
            }

            sb.AppendLine("Teams to disband:");

            foreach (Team team in teamsToDisband)
            {
                sb.AppendLine(team.TeamName);
            }

            Console.WriteLine(sb.ToString());
        }
    }

    class Team
    {
        public Team(string teamName, string creatorName)
        {
            TeamName = teamName;
            CreatorName = creatorName;
            Members = new List<string>();
        }

        public string TeamName { get; set; }
        public string CreatorName { get; set; }
        public List<string> Members { get; set; }
    }
}
