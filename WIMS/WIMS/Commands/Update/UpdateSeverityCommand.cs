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
    public class UpdateSeverityCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public UpdateSeverityCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please enter the name of the team responsible for the workitem whose severity you want to change:");
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
            if (workItem is IBug == false)
            {
                return $"The selected WorkItem is not of type bug. Only bugs have severity.";
            }
            IBug bug = workItem as IBug;

            Console.WriteLine($"Please choose the new severity of the bug:{Environment.NewLine}" +
                $"Type 1 for Critical.{Environment.NewLine}" +
                $"Type 2 for Major.{Environment.NewLine}" +
                $"Type 3 for Minor.{Environment.NewLine}");
            Console.WriteLine($"The current severity of {bug.Title} is: {bug.Severity}");
            string severityUserInput = Console.ReadLine();
            Severity severity;
            switch (severityUserInput)
            {
                case "1": severity = Severity.Critical; break;
                case "2": severity = Severity.Major; break;
                case "3": severity = Severity.Minor; break;
                default: return "invalid command";
            }
            if (severity == bug.Severity)
            {
                return $"The selected WorkItem is already classified with severity {severity}.";
            }
            string result = HelperMethods.TimeStamp() + $"WorkItem with id {bug.ID} changed it's severity to {severity}.";
            bug.Severity = severity;
            bug.History.Add(result);
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