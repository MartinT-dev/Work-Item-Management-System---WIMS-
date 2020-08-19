using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models.Contracts;

namespace WIMS.Commands.Listing
{
    public class ListMemberActivityCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ListMemberActivityCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine(" Type the name of the team of the member whose activity you want to see");
            Console.WriteLine("List of teams" + Environment.NewLine + HelperMethods.ListTeams(engine.Teams) + Environment.NewLine + "------------------------------");
            Console.Write("-Team name:");
            string teamName = Console.ReadLine();
            bool ifTeamExists = HelperMethods.IfExists(teamName, engine.Teams);
            if (ifTeamExists == false)
            {
                return "Team with such name does not exist.";
            }
            ITeam team = HelperMethods.ReturnExisting(teamName, engine.Teams);
            Console.Clear();
            Console.WriteLine($"List of members in team {teamName}" + Environment.NewLine + HelperMethods.ListMembers(team.Members) + Environment.NewLine + "------------------------------");
            Console.WriteLine(" Type the ID of the member whose activity you want to check");
            Console.Write("-Member ID:");
            int assigneeId = int.Parse(Console.ReadLine());
            bool ifMemberExists = HelperMethods.IfExists(assigneeId, team.Members);
            if (ifMemberExists == false)
            {
                return $"Member with id {assigneeId} does not exist in team {team.Name}.";
            }
            IMember member = HelperMethods.ReturnExisting(assigneeId, team.Members);
            foreach (var item in member.History)
            {
                sb.AppendLine(item);
            }
            Console.Clear();
            return sb.ToString().Trim();
        }

      
    }
}
