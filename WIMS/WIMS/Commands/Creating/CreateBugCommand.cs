using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models.Contracts;
using WIMS.Models.Enums;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Commands.Creating
{
    public class CreateBugCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public CreateBugCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute()
        {
            Console.WriteLine("Please enter title of the bug:");
            string title = Console.ReadLine();
            HelperMethods.ValidateWorkItemTitle(title);
            Console.Clear();
            Console.WriteLine("Please enter description of the bug:");
            string description = Console.ReadLine();
            HelperMethods.ValidateWorkItemDescription(description);
            Console.Clear();
            Console.WriteLine("Please enter steps to reproduce of the bug separated by space:");
            List<string> steps = Console.ReadLine().Split().ToList();
            Console.Clear();
            Console.WriteLine($"Please choose priority of the bug:{Environment.NewLine}" +
                $"Type 1 for High.{Environment.NewLine}" +
                $"Type 2 for Medium.{Environment.NewLine}" +
                $"Type 3 for Low.{Environment.NewLine}");
            string priorityUserInput = Console.ReadLine();
            Priority priority;
            switch (priorityUserInput)
            {
                case "1": priority = Priority.High; break;
                case "2": priority = Priority.Medium; break;
                case "3": priority = Priority.Low; break;
                default: throw new ArgumentException("Invalid command");
            }
            Console.Clear();
            Console.WriteLine($"Please choose severity of the bug:{Environment.NewLine}" +
                $"Type 1 for Critical.{Environment.NewLine}" +
                $"Type 2 for Major.{Environment.NewLine}" +
                $"Type 3 for Minor.{Environment.NewLine}");
            string severityUserInput = Console.ReadLine();
            Severity severity;
            switch (severityUserInput)
            {
                case "1": severity = Severity.Critical; break;
                case "2": severity = Severity.Major; break;
                case "3": severity = Severity.Minor; break;
                default: throw new ArgumentException("Invalid command");
            }
            Console.Clear();
            Console.WriteLine($"Please choose status of the bug:{Environment.NewLine}" +
                $"Type 1 for Active.{Environment.NewLine}" +
                $"Type 2 for Fixed.{Environment.NewLine}");
            string statusUserInput = Console.ReadLine();
            BugStatus status;
            switch (statusUserInput)
            {
                case "1": status = BugStatus.Active; break;
                case "2": status = BugStatus.Fixed; break;
                default: throw new ArgumentException("Invalid command");
            }
            Console.Clear();
            Console.WriteLine("Please enter the name of the team responsible for this bug:");
            Console.WriteLine("List of teams:" + Environment.NewLine + HelperMethods.ListTeams(this.engine.Teams));
            string teamName = Console.ReadLine();
            bool ifTeamExists = HelperMethods.IfExists(teamName, engine.Teams);
            if (ifTeamExists == false)
            {
                return "Team with such name does not exist.";
            }
            ITeam teamToBeAssigned = HelperMethods.ReturnExisting(teamName, engine.Teams);
            Console.Clear();
            Console.WriteLine("Please enter board where to add this bug:");
            Console.WriteLine("List of boards:" + Environment.NewLine + HelperMethods.ListBoards(teamToBeAssigned.Boards));
            string boardName = Console.ReadLine();
            bool ifBoardExists = HelperMethods.IfExists(boardName, teamToBeAssigned.Boards);
            if (ifBoardExists == false)
            {
                return $"Board with name {boardName} does not exist in team {teamToBeAssigned.Name}.";
            }
            IBoard boardToBeAssigned = HelperMethods.ReturnExisting(boardName, teamToBeAssigned.Boards);
            Console.Clear();
            Console.WriteLine("Please enter id of assigned member:");
            Console.WriteLine("List of members:" + Environment.NewLine + HelperMethods.ListMembers(teamToBeAssigned.Members));
            bool assigneeIdTry = int.TryParse(Console.ReadLine(), out int resultParse);
            int assigneeId;
            if (assigneeIdTry == false)
            {
                return "invalid command";
            }
            else
            {
                assigneeId = resultParse;
            }
            bool ifMemberExists = HelperMethods.IfExists(assigneeId, teamToBeAssigned.Members);
            if (ifMemberExists == false)
            {
                return $"Member with id {assigneeId} does not exist in team {teamToBeAssigned.Name}.";
            }
            IMember memberToBeAssigned = HelperMethods.ReturnExisting(assigneeId, teamToBeAssigned.Members);

            var bug = this.factory.CreateBug(title,description,steps,priority, severity,status,memberToBeAssigned);
            this.engine.Bugs.Add(bug);
            boardToBeAssigned.WorkItems.Add(bug);
            memberToBeAssigned.WorkItems.Add(bug);
            string result = HelperMethods.TimeStamp() + bug.ToString() + $" was created in board {boardName} and assigned to {memberToBeAssigned.Name} with ID {memberToBeAssigned.MemberID}";
            bug.History.Add(result);
            teamToBeAssigned.History.Add(result);
            boardToBeAssigned.History.Add(result);
            memberToBeAssigned.History.Add(result);
            return result;
        }
    }
}