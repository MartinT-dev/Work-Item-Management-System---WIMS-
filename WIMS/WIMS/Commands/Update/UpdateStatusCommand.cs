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
    public class UpdateStatusCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public UpdateStatusCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please enter the name of the team responsible for the workitem whose status you want to change:");
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
            string result = "";
            if (workItem is IBug)
            {
                Console.Clear();
                IBug bug = workItem as IBug;
                Console.WriteLine($"Please choose new status of the bug:{Environment.NewLine}" +
                $"Type 1 for Active.{Environment.NewLine}" +
                $"Type 2 for Fixed.{Environment.NewLine}");
                Console.WriteLine($"The current status of {bug.Title} is: {bug.Status}");
                string bugStatusUserInput = Console.ReadLine();
                BugStatus status;
                switch (bugStatusUserInput)
                {
                    case "1": status = BugStatus.Active; break;
                    case "2": status = BugStatus.Fixed; break;
                    default: return "invalid command";
                }
                if (status == bug.Status)
                {
                    return $"The selected WorkItem is already classified with status {status}.";
                }
                result = HelperMethods.TimeStamp() + $"WorkItem with id {bug.ID} changed it's status to {status}.";
                bug.Status = status;
                bug.History.Add(result);
            }

            if (workItem is IStory)
            {
                Console.Clear();
                IStory story = workItem as IStory;
                Console.WriteLine($"Please choose new status of the story:{Environment.NewLine}" +
                $"Type 1 for NotDone.{Environment.NewLine}" +
                $"Type 2 for InProgress.{Environment.NewLine}" +
                $"Type 3 for Done.{Environment.NewLine}");
                Console.WriteLine($"The current status of {story.Title} is: {story.Status}");
                string storyStatusUserInput = Console.ReadLine();
                StoryStatus status;
                switch (storyStatusUserInput)
                {
                    case "1": status = StoryStatus.NotDone; break;
                    case "2": status = StoryStatus.InProgress; break;
                    case "3": status = StoryStatus.Done; break;
                    default: return "invalid command";
                }
                if (status == story.Status)
                {
                    return $"The selected WorkItem is already classified with status {status}.";
                }
                result = HelperMethods.TimeStamp() + $"WorkItem with id {story.ID} changed it's status to {status}.";
                story.Status = status;
                story.History.Add(result);
            }

            if (workItem is IFeedback)
            {
                Console.Clear();
                IFeedback feedback = workItem as IFeedback;
                Console.WriteLine($"Please choose new status of the feedback:{Environment.NewLine}" +
                $"Type 1 for New.{Environment.NewLine}" +
                $"Type 2 for Unscheduled.{Environment.NewLine}" +
                $"Type 3 for Scheduled.{Environment.NewLine}" +
                $"Type 4 for Done.{Environment.NewLine}");
                Console.WriteLine($"The current status of {feedback.Title} is: {feedback.Status}");
                string feedbackStatusUserInput = Console.ReadLine();
                FeedbackStatus status;
                switch (feedbackStatusUserInput)
                {
                    case "1": status = FeedbackStatus.New; break;
                    case "2": status = FeedbackStatus.Unscheduled; break;
                    case "3": status = FeedbackStatus.Scheduled; break;
                    case "4": status = FeedbackStatus.Done; break;
                    default: return "invalid command";
                }
                if (status == feedback.Status)
                {
                    return $"The selected WorkItem is already classified with status {status}.";
                }
                result = HelperMethods.TimeStamp() + $"WorkItem with id {feedback.ID} changed it's status to {status}.";
                feedback.Status = status;
                feedback.History.Add(result);
            }
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
            board.History.Add(result);
            team.History.Add(result);
            return result;
        }
    }
}
