using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models.Contracts;

namespace WIMS.Commands.Listing
{
    public class ListBoardActivityCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ListBoardActivityCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Type the name of the team of the board whose activity you want to see");
            Console.WriteLine("List of teams:" + Environment.NewLine + HelperMethods.ListTeams(engine.Teams) + Environment.NewLine + "------------------------------");
            Console.Write("- Team name:");
            string teamName = Console.ReadLine();
            Console.Clear();
            bool ifTeamExists = HelperMethods.IfExists(teamName, engine.Teams);
            if (ifTeamExists == false)
            {
                return "Team with such name does not exist.";
            }
            ITeam team = HelperMethods.ReturnExisting(teamName, engine.Teams);
            Console.WriteLine("Type the name of the board whose activity you want to check");
            Console.WriteLine("List of boards" + Environment.NewLine + HelperMethods.ListBoards(team.Boards) + Environment.NewLine + "-------------------------");
            Console.Write("-Board name:");
            string boardName = Console.ReadLine();
            bool ifBoardExist = HelperMethods.IfExists(boardName,team.Boards);
            if (ifBoardExist == false)
            {
                return $"Board with name {boardName} does not exist in team {teamName}.";
            }
            IBoard board = HelperMethods.ReturnExisting(boardName, team.Boards);
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            foreach (var item in board.History)
            {
                sb.AppendLine(item);
            }
            return sb.ToString().Trim();
        }
    }
}
