using System;
using System.Collections.Generic;
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
    public class UpdatePriorityCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public UpdatePriorityCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please enter the name of the team responsible for the workitem whose priority you want to change:");
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
            if (workItem is IPriorityItem == false)
            {
                return $"The selected WorkItem is not of type which has priority. Bugs and stories have priority.";
            }
            IPriorityItem assignableWorkItem = workItem as IPriorityItem;

            Console.WriteLine($"Please choose the new priority of the workItem that you wish to change:{Environment.NewLine}" +
                $"Type 1 for High.{Environment.NewLine}" +
                $"Type 2 for Medium.{Environment.NewLine}" +
                $"Type 3 for Low.{Environment.NewLine}");
            Console.WriteLine($"The current priority of {assignableWorkItem.Title} is: {assignableWorkItem.Priority}");
            string priorityUserInput = Console.ReadLine();
            Priority priority;
            switch (priorityUserInput)
            {
                case "1": priority = Priority.High; break;
                case "2": priority = Priority.Medium; break;
                case "3": priority = Priority.Low; break;
                default: return "invalid command";
            }
            if (priority == assignableWorkItem.Priority)
            {
                return $"The selected WorkItem is already classified with priority {priority}.";
            }
            string result = HelperMethods.TimeStamp() + $"WorkItem with id {workItemID} changed it's priority to {priority}.";
            assignableWorkItem.Priority = priority;
            assignableWorkItem.History.Add(result);
            board.History.Add(result);
            team.History.Add(result);
            
            foreach (var item in team.Members)
            {
                if (item.WorkItems.Contains(assignableWorkItem))
                {
                        item.History.Add(result);
                        break;
                }
            }

            return result;

        }
    }
}

