using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models.Contracts;

namespace WIMS.Commands.Listing
{
    public class ListMembersCommand : ICommand
    {

        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ListMembersCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please enter one of the following options:" + Environment.NewLine +
                $"Type 1 for listing all members.{Environment.NewLine}" +
                $"Type 2 for listing all members in a team.{Environment.NewLine}");
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            switch (input)
            {
                case "1":
                    if (engine.Members.Count == 0)
                    {
                        return "There are no existing members!";
                    }
                    foreach (var member in engine.Members)
                    {
                        sb.AppendLine(member.ToString());
                    }
                    Console.Clear();
                    Console.WriteLine($"Members{Environment.NewLine}--------------------------------");
                    return sb.ToString().Trim();
                case "2":
                    if (engine.Members.Count == 0)
                    {
                        return "There are no existing members!";
                    }
                    Console.WriteLine("Please type the name of the team whose members you want to list:");
                    Console.WriteLine("List of teams" + Environment.NewLine + HelperMethods.ListTeams(engine.Teams) + Environment.NewLine + "--------------------------------");
                    Console.Write($"-Team name:");
                    string teamName = Console.ReadLine();
                    Console.WriteLine("--------------------------------");
                    bool ifTeamExists = HelperMethods.IfExists(teamName, engine.Teams);
                    if (ifTeamExists == false)
                    {
                        return $"Team with name {teamName} does not exist.";
                    }
                    ITeam team = HelperMethods.ReturnExisting(teamName, engine.Teams);
                    if (team.Members.Count == 0)
                    {
                        return $"There are no existing members in team {teamName}!";
                    }
                    foreach (var member in team.Members)
                    {
                        sb.AppendLine(member.ToString());
                    }
                    Console.Clear();
                    Console.WriteLine($"Members in team {teamName}:{Environment.NewLine}--------------------------------");
                    return sb.ToString().Trim();
                default: return "Invalid command.";
            }

        }
    }
}
