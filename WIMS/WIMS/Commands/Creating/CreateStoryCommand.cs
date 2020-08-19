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
    public class CreateStoryCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public CreateStoryCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute()
        {
            Console.WriteLine("Please enter title of the story:");
            string title = Console.ReadLine();
            HelperMethods.ValidateWorkItemTitle(title);
            Console.Clear();
            Console.WriteLine("Please enter description of the story:");
            string description = Console.ReadLine();
            HelperMethods.ValidateWorkItemDescription(description);
            Console.Clear();
            Console.WriteLine($"Please choose priority of the story:{Environment.NewLine}" +
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
                default: return "invalid command";
            }
            Console.Clear();
            Console.WriteLine($"Please choose size of the story:{Environment.NewLine}" +
                $"Type 1 for Large.{Environment.NewLine}" +
                $"Type 2 for Medium.{Environment.NewLine}" +
                $"Type 3 for Small.{Environment.NewLine}");
            string sizeUserInput = Console.ReadLine();
            Size size;
            switch (sizeUserInput)
            {
                case "1": size = Size.Large; break;
                case "2": size = Size.Medium; break;
                case "3": size = Size.Small; break;
                default: return "invalid command";
            }
            Console.Clear();
            Console.WriteLine($"Please choose status of the story:{Environment.NewLine}" +
                $"Type 1 for NotDone.{Environment.NewLine}" +
                $"Type 2 for InProgress.{Environment.NewLine}" +
                $"Type 3 for Done.{Environment.NewLine}");
            string statusUserInput = Console.ReadLine();
            StoryStatus status;
            switch (statusUserInput)
            {
                case "1": status = StoryStatus.NotDone; break;
                case "2": status = StoryStatus.InProgress; break;
                case "3": status = StoryStatus.Done; break;
                default: return "invalid command";
            }
            Console.Clear();
            Console.WriteLine("Please enter the name of the team responsible for this story:");
            Console.WriteLine("List of teams:" + Environment.NewLine + HelperMethods.ListTeams(this.engine.Teams));
            string teamName = Console.ReadLine();
            bool ifTeamExists = HelperMethods.IfExists(teamName, engine.Teams);
            if (ifTeamExists == false)
            {
                return "Team with such name does not exist.";
            }
            ITeam teamToBeAssigned = HelperMethods.ReturnExisting(teamName, engine.Teams);
            Console.Clear();
            Console.WriteLine("Please enter board where to add this feedback:");
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

            var story = this.factory.CreateStory(title, description, priority, size, status, memberToBeAssigned);
            this.engine.Stories.Add(story);
            boardToBeAssigned.WorkItems.Add(story);
            memberToBeAssigned.WorkItems.Add(story);
            string result = HelperMethods.TimeStamp() + story.ToString() + $" was created in board {boardName} and assigned to {memberToBeAssigned.Name} with ID {memberToBeAssigned.MemberID}";
            story.History.Add(result);
            teamToBeAssigned.History.Add(result);
            boardToBeAssigned.History.Add(result);
            memberToBeAssigned.History.Add(result);

            return result;
        }
    }
}
