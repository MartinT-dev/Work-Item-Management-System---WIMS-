using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models.Contracts;

namespace WIMS.Commands.Listing
{
    public class ListBoardsCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ListBoardsCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute()
        {
            Console.WriteLine("Please type the name of the team whose boards you want to list:");
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
            StringBuilder sb = new StringBuilder();
            if (team.Boards.Count == 0)
            {
                return $"There are no existing boards in team {teamName}!";
            }
            foreach (var board in team.Boards)
            {
                sb.AppendLine(board.ToString());
            }

            Console.Clear();
            Console.WriteLine($"Boards in team {teamName}{Environment.NewLine}--------------------------------");
            return sb.ToString().Trim();
        }
    }
}
