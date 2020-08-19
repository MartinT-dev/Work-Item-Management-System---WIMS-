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
    public class UpdateAssigneeCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public UpdateAssigneeCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please enter the name of the team responsible for the workitem whose assignee you want to change:");
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
            if (workItem is IAssignableItem == false)
            {
                return $"The selected WorkItem is not of type which has assignee. Bugs and stories have assignee.";
            }
            IAssignableItem assignableWorkItem = workItem as IAssignableItem;
            Console.Clear();
            Console.WriteLine($"Please choose new member of the {team.Name} that you wish to assign workitem with id {assignableWorkItem.ID}.");
            Console.WriteLine("List of members:" + Environment.NewLine + HelperMethods.ListMembers(team.Members));
            Console.WriteLine($"The current assignee of {assignableWorkItem.Title} is: {assignableWorkItem.Assignee.Name} with ID: {assignableWorkItem.Assignee.MemberID}");
            Console.WriteLine("Please enter id of assigned member:");
            bool assigneeIdTry = int.TryParse(Console.ReadLine(), out int resultParse2);
            int assigneeId;
            if (assigneeIdTry == false)
            {
                return "invalid command";
            }
            else
            {
                assigneeId = resultParse2;
            }
            bool ifMemberExists = HelperMethods.IfExists(assigneeId, team.Members);
            if (ifMemberExists == false)
            {
                return $"Member with id {assigneeId} does not exist in team {team.Name}.";
            }
            IMember memberToBeAssigned = HelperMethods.ReturnExisting(assigneeId, team.Members);
            if (memberToBeAssigned == assignableWorkItem.Assignee)
            {
                return $"The workitem is already assigned to {memberToBeAssigned.Name} with ID: {memberToBeAssigned.MemberID}.";
            }
            string result = HelperMethods.TimeStamp() + $"WorkItem with id {workItemID} changed it's assignee to {memberToBeAssigned.Name} with ID: {memberToBeAssigned.MemberID}.";
            team.History.Add(result);
            memberToBeAssigned.History.Add(result);
            assignableWorkItem.Assignee.History.Add(result);
            board.History.Add(result);
            assignableWorkItem.Assignee.WorkItems.Remove(assignableWorkItem);
            memberToBeAssigned.WorkItems.Add(assignableWorkItem);
            assignableWorkItem.Assignee = memberToBeAssigned;

            return result;

        }
    }
}