using System;
using System.Linq;

using System.Collections.Generic;

using FootballTeamGenerator.Common;
using FootballTeamGenerator.Models;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private readonly ICollection<Team> teams;
        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArg = command.Split(';');

                string cmdType = cmdArg[0];

                try
                {
                    List<string> cmdParams = cmdArg.Skip(1).ToList();
                    if (cmdType == "Team")
                    {
                        this.CreateTeam(cmdParams);
                    }
                    else if (cmdType == "Add")
                    {
                        this.AddPlayerToTeam(cmdParams);
                    }
                    else if (cmdType == "Remove")
                    {
                        this.RemovePlayerFromTeam(cmdParams);
                    }
                    else if (cmdType == "Rating")
                    {
                        this.RateTeam(cmdArg);
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private void CreateTeam(IList<string> cmdArg)
        {
            string teamName = cmdArg[0];

            Team team = new Team(teamName);
            this.teams.Add(team);
        }

        private void AddPlayerToTeam(IList<String> cmdArgs)
        {
            string teamName = cmdArgs[0];
            string playerName = cmdArgs[1];

            this.ValidateTeamExists(teamName);

            Stats stats = this.BuildStats(cmdArgs.Skip(2).ToArray());

            Player player = new Player(playerName, stats);


            Team team = this.teams.FirstOrDefault(t => t.Name == teamName);

            team.AddPlayer(player);
        }

        private void RemovePlayerFromTeam(IList<String> cmdArgs)
        {
            string teamName = cmdArgs[0];
            string playerName = cmdArgs[1];

            this.ValidateTeamExists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            team.RemovePlayer(playerName);
        }

        private void RateTeam(IList<String> cmdArgs)
        {
            string teamName = cmdArgs[1];

            this.ValidateTeamExists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team);
        }

        private Stats BuildStats(string[] stats)
        {
            int endurance = int.Parse(stats[0]);
            int sprint = int.Parse(stats[1]);
            int dribble = int.Parse(stats[2]);
            int passing = int.Parse(stats[3]);
            int shooting = int.Parse(stats[4]);

            Stats statistics = new Stats(endurance, sprint, dribble, passing, shooting);

            return statistics;
        }

        private void ValidateTeamExists(string teamName)
        {
            Team team = this.teams
                .FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.MISSING_TEAM_EXC_MSG, teamName));
            }
        }
    }
}
