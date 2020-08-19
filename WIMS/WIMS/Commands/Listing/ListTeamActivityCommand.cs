using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models.Contracts;

namespace WIMS.Commands.Listing
{
    public class ListTeamActivityCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ListTeamActivityCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
          
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Type the name of the team whose activity you want to see");
            Console.WriteLine("List of teams" + Environment.NewLine + HelperMethods.ListTeams(engine.Teams) + Environment.NewLine + "------------------------------");
            Console.Write("Team name:");
            string teamName = Console.ReadLine();
            bool ifTeamExists = HelperMethods.IfExists(teamName, engine.Teams);
            if (ifTeamExists == false)
            {
                return "Team with such name does not exist.";
            }
            ITeam team = HelperMethods.ReturnExisting(teamName, engine.Teams);
            foreach (var item in team.History)
            {
                sb.AppendLine(item);
            }
            Console.Clear();
            return sb.ToString().Trim();
        }
    }
}
