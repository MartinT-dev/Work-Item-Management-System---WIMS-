using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Commands.Update
{
    public class UpdateDescriptionCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public UpdateDescriptionCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please enter the name of the team responsible for the workitem whose description you want to change:");
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
            bool workItemIDTry = int.TryParse(Console.ReadLine(), out int resultParse);
            int workItemID;
            if (workItemIDTry == false)
            {
                return "invalid command";
            }
            else
            {
                workItemID = resultParse;
            }
            bool ifWorkItemExists = HelperMethods.IfExists(workItemID, board.WorkItems);
            if (ifWorkItemExists == false)
                {
                    return $"WorkItem with id {workItemID} does not exist in board {board.Name}.";
                }
            IWorkItem workItem = HelperMethods.ReturnExisting(workItemID, board.WorkItems);
            Console.Clear();
            Console.WriteLine("Please enter the new description of the workItem that you wish to change:");
            Console.WriteLine($"The current description of {workItem.Title} is: {workItem.Description}");
            string description = Console.ReadLine();
            HelperMethods.ValidateWorkItemDescription(description);
            string result = HelperMethods.TimeStamp() + $"WorkItem with id {workItemID} changed it's description.";
            workItem.Description = description;
            workItem.History.Add(result);
            board.History.Add(result);
            team.History.Add(result);
            if (workItem is IAssignableItem)
                {
                    foreach (var item in team.Members)
                    {
                        if (item.WorkItems.Contains(workItem))
                            {
                                item.History.Add(result);
                                break;
                            }
                    }
                }
            return result;

        }
    }
}
