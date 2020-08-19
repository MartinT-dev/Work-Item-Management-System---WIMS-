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
    public class ListStoriesCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ListStoriesCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Type the name of the team of the board whose stories you want to see");
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
            Console.WriteLine("Type the name of the board whose stories you want to check");
            Console.WriteLine("List of boards" + Environment.NewLine + HelperMethods.ListBoards(team.Boards) + Environment.NewLine + "-------------------------");
            Console.Write("-Board name:");
            string boardName = Console.ReadLine();
            bool ifBoardExist = HelperMethods.IfExists(boardName, team.Boards);
            if (ifBoardExist == false)
            {
                return $"Board with name {boardName} does not exist in team {teamName}.";
            }
            IBoard board = HelperMethods.ReturnExisting(boardName, team.Boards);
            bool storiesExist = false;
            foreach (var item in board.WorkItems)
            {
                if (item is IStory)
                {
                    storiesExist = true;
                    break;
                }
            }
            if (storiesExist == false)
            {
                return $"There are no created stories in board {board.Name}!";
            }
            StringBuilder sb = new StringBuilder();
            foreach (var story in board.WorkItems)
            {
                if (story is IStory)
                {
                    var iStory = story as IStory;
                    sb.AppendLine(Environment.NewLine + iStory.ToString() + Environment.NewLine +
                                $"Description of the story - {iStory.Description}{Environment.NewLine}" +
                                $"Priority - {iStory.Priority}{Environment.NewLine}" +
                                $"Status of the story - {iStory.Status}{Environment.NewLine}" +
                                $"Size of the story - {iStory.Size}{Environment.NewLine}" +
                                $"Priority - {iStory.Priority}{Environment.NewLine}" +
                                $"Member assigned to - {iStory.Assignee.Name}{Environment.NewLine}");
                }
            }
            Console.Clear();
            Console.WriteLine($"Stories in board {boardName} of team {teamName}{Environment.NewLine}--------------------------------");
            return sb.ToString().Trim();
        }
    }
}
