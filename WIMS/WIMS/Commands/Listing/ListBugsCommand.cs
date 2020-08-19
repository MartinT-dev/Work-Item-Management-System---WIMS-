using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Commands.Listing
{
    public class ListBugsCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ListBugsCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Type the name of the team of the board whose bugs you want to see");
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
            Console.WriteLine("Type the name of the board whose bugs you want to check");
            Console.WriteLine("List of boards" + Environment.NewLine + HelperMethods.ListBoards(team.Boards) + Environment.NewLine + "-------------------------");
            Console.Write("-Board name:");
            string boardName = Console.ReadLine();
            bool ifBoardExist = HelperMethods.IfExists(boardName, team.Boards);
            if (ifBoardExist == false)
            {
                return $"Board with name {boardName} does not exist in team {teamName}.";
            }
            IBoard board = HelperMethods.ReturnExisting(boardName, team.Boards);
            bool bugsExist = false;
            foreach (var item in board.WorkItems)
            {
                if (item is IBug)
                {
                    bugsExist = true;
                    break;
                }
            }
            if (bugsExist == false)
            {
                return $"There are no created bugs in board {board.Name}!";
            }
            StringBuilder sb = new StringBuilder();
            foreach (var bug in board.WorkItems)
            {
                if (bug is IBug)
                {
                    var iBug = bug as IBug;
                    var steps = string.Join(" ", iBug.Steps);

                    sb.AppendLine(Environment.NewLine + iBug.ToString() + Environment.NewLine +
                        $"Description of the bug - {iBug.Description}{Environment.NewLine}" +
                         $"Steps to reproduce - {steps}{Environment.NewLine}" +
                         $"Priority - {iBug.Priority}{Environment.NewLine}" +
                         $"Severity level - {iBug.Severity}{Environment.NewLine}" +
                         $"Status level - {iBug.Status}{Environment.NewLine}" +
                         $"Member assigned to - {iBug.Assignee.Name}{Environment.NewLine}");
                }
            }
            Console.Clear();
            Console.WriteLine($"Bugs in board {boardName} of team {teamName}{Environment.NewLine}--------------------------------");
            return sb.ToString().Trim();
        }
    }
}
