using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int teamsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < teamsCount; i++)
            {
                string[] teamInfo = Console.ReadLine().Split('-');
                Team currentTeamInfo = new Team(teamInfo[0], teamInfo[1]);
                if (teams.Exists(x => x.User == currentTeamInfo.User))
                {
                    foreach (var user in teams.Where(x => x.User == currentTeamInfo.User))
                    {
                        user.PrintIfCreatorAlreadyExits();
                    }
                }
                else if (teams.Exists(x => x.TeamName == currentTeamInfo.TeamName))
                {
                    foreach (var teamName in teams.Where(x => x.TeamName == currentTeamInfo.TeamName))
                    {
                        teamName.PrintIfTeamAlreadyExits();
                    }
                }
                else
                {
                    Console.WriteLine($"Team {currentTeamInfo.TeamName} has been created by {currentTeamInfo.User}!");
                    teams.Add(currentTeamInfo);
                }
            }

            string input = Console.ReadLine();
            while (input != "end of assignment")
            {
                string[] member = input.Split("->");

                if (!teams.Exists(x => x.TeamName == member[1]))
                {
                    teams[0].PrintIfMemberTryToJointInNonExistTeam(member[1]);
                }
                else if (teams.Exists(x => x.User == member[0]))
                {
                    foreach (var user in teams.Where(x => x.User == member[0]))
                    {
                        user.CheckIfMemberAlreadyInSomeTeam(user.User, member[1]);
                    }
                }
                else if (teams.Exists(x => x.Members.Contains(member[0])))
                {
                    foreach (var teamMember in teams.Where(x => x.Members.Contains(member[0])))
                    {
                        string currentMember = teamMember.Members.Find(x => x == member[0]);
                        teamMember.CheckIfMemberAlreadyInSomeTeam(currentMember, member[1]);
                    }
                }
                else
                {
                    foreach (var currentMember in teams.Where(x => x.TeamName == member[1]))
                    {
                        currentMember.Members.Add(member[0]);
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var sortByCount in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).Where(x => x.Members.Count > 0))
            {
                Console.WriteLine($"{sortByCount.TeamName}");
                Console.WriteLine($"- {sortByCount.User}");
                foreach (var sortByName in sortByCount.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {sortByName}");
                }
            }
            Console.WriteLine($"Teams to disband:");
            foreach (var item in teams.OrderBy(x => x.TeamName).Where(x => x.Members.Count == 0))
            {
                if (item.Members.Count < 1)
                {
                    Console.WriteLine($"{item.TeamName}");
                }
            }
        }
    }

    public class Team
    {
        public Team(string user, string teamName)
        {
            this.User = user;
            this.TeamName = teamName;
            this.Members = new List<string>();
        }
        public string User { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }

        public void PrintIfTeamAlreadyExits()
        {
            Console.WriteLine($"Team {TeamName} was already created!");
        }

        public void PrintIfCreatorAlreadyExits()
        {
            Console.WriteLine($"{User} cannot create another team!");
        }

        public void PrintIfMemberTryToJointInNonExistTeam(string teamName)
        {
            Console.WriteLine($"Team {teamName} does not exist!");
        }

        public void CheckIfMemberAlreadyInSomeTeam(string member, string teamName)
        {
            Console.WriteLine($"Member {member} cannot join team {teamName}!");
        }
    }
}
