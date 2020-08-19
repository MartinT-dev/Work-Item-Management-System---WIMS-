using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models;
using WIMS.Models.Contracts;
using WIMS.Models.Enums;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Commands.Update
{
    public class UpdateSizeCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public UpdateSizeCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please enter the name of the team responsible for the workitem whose size you want to change:");
            Console.WriteLine("List of teams:" + Environment.NewLine + HelperMethods.ListTeams(this.engine.Teams));
            string teamName = Console.ReadLine();
            bool ifTeamExists = HelperMethods.IfExists(teamName, engine.Teams);
            if (ifTeamExists == false)
            {
                return "Team with such name does not exist.";
            }
            ITeam team = HelperMethods.ReturnExisting(teamName, engine.Teams);
            Console.Clear();
            Console.WriteLine("Please enter board where the workitem features:");
            Console.WriteLine("List of boards:" + Environment.NewLine + HelperMethods.ListBoards(team.Boards));
            string boardName = Console.ReadLine();
            bool ifBoardExists = HelperMethods.IfExists(boardName, team.Boards);
            if (ifBoardExists == false)
            {
                return $"Board with name {boardName} does not exist in team {team.Name}.";
            }
            IBoard board = HelperMethods.ReturnExisting(boardName, team.Boards);
            Console.Clear();
            Console.WriteLine("Please enter the id of the workitem that you wish to change:");
            Console.WriteLine($"List of workitems in team {board.Name}:" + Environment.NewLine + HelperMethods.ListWorkItems(board.WorkItems));
            int workItemID = int.Parse(Console.ReadLine());
            bool ifWorkItemExists = HelperMethods.IfExists(workItemID, board.WorkItems);
            if (ifWorkItemExists == false)
            {
                return $"WorkItem with id {workItemID} does not exist in board {board.Name}.";
            }
            IWorkItem workItem = HelperMethods.ReturnExisting(workItemID, board.WorkItems);
            if (workItem is IStory == false)
            {
                return $"The selected WorkItem is not of type story. Only stories have size.";
            }
            IStory story = workItem as IStory;

            Console.WriteLine($"Please choose the new size of the story:{Environment.NewLine}" +
                $"Type 1 for Large.{Environment.NewLine}" +
                $"Type 2 for Medium.{Environment.NewLine}" +
                $"Type 3 for Small.{Environment.NewLine}");
            Console.WriteLine($"The current size of {story.Title} is: {story.Size}");
            string sizeUserInput = Console.ReadLine();
            Size size;
            switch (sizeUserInput)
            {
                case "1": size = Size.Large; break;
                case "2": size = Size.Medium; break;
                case "3": size = Size.Small; break;
                default: return "invalid command";
            }
            if (size == story.Size)
            {
                return $"The selected WorkItem is already classified with size {size}.";
            }
            string result = HelperMethods.TimeStamp() + $"WorkItem with id {story.ID} changed it's size to {size}.";
            story.Size = size;
            story.History.Add(result);
            board.History.Add(result);
            team.History.Add(result);
            foreach (var item in team.Members)
            {
                if (item.WorkItems.Contains(workItem))
                {
                    item.History.Add(result);
                    break;
                }
            }
            return result;
        }
    }
}

