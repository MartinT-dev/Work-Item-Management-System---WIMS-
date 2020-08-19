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

namespace WIMS.Commands.Listing
{
    public class ListWorkItemsFilteredCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ListWorkItemsFilteredCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please select in what how should the workitems be filtered:" + Environment.NewLine +
            $"-Type 1 for by assignee.{Environment.NewLine}" +
            $"-Type 2 for by status");
            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Please enter id of the assignee:");
                    Console.WriteLine("List of members:" + Environment.NewLine + HelperMethods.ListMembers(engine.Members));
                    int assigneeId = int.Parse(Console.ReadLine());
                    bool ifMemberExists = HelperMethods.IfExists(assigneeId, engine.Members);
                    if (ifMemberExists == false)
                    {
                        return $"Member with id {assigneeId} does not exist.";
                    }
                    IMember assignee = HelperMethods.ReturnExisting(assigneeId, engine.Members);
                    Console.Clear();
                    StringBuilder sb = new StringBuilder();
                    foreach (var bug in engine.Bugs)
                    {
                        if (bug.Assignee == assignee)
                        {
                            sb.AppendLine(bug.ToString());
                        }
                    }
                    foreach (var story in engine.Stories)
                    {
                        if (story.Assignee == assignee)
                        {
                            sb.AppendLine(story.ToString());
                        }
                    }
                    if (string.IsNullOrEmpty(sb.ToString()))
                    {
                        return $"No workitems are assigned to member {assignee.MemberID}";
                    }
                    return sb.ToString().Trim();
                case "2":
                    Console.WriteLine(($"Please choose status:{Environment.NewLine}" +
                    $"Type 1 for Story status: NotDone.{Environment.NewLine}" +
                    $"Type 2 for Story status: InProgress.{Environment.NewLine}" +
                    $"Type 3 for Story status: Done.{Environment.NewLine}" +
                    $"Type 4 for Feedback status: New.{Environment.NewLine}" +
                    $"Type 5 for Feedback status: Scheduled.{Environment.NewLine}" +
                    $"Type 6 for Feedback status: Unscheduled.{Environment.NewLine}" +
                    $"Type 7 for Feedback status: Done.{Environment.NewLine}" +
                    $"Type 8 for Bug status: Active.{Environment.NewLine}" +
                    $"Type 9 for Bug status: Fixed.{Environment.NewLine}"));
                    string input2 = Console.ReadLine();
                    StringBuilder sb2 = new StringBuilder();
                    switch (input2)
                    {
                        case "1":
                            foreach (var story in engine.Stories)
                            {
                                if (story.Status == StoryStatus.NotDone)
                                {
                                    sb2.AppendLine(story.ToString());
                                }
                            }
                            break;
                        case "2":
                            foreach (var story in engine.Stories)
                            {
                                if (story.Status == StoryStatus.InProgress)
                                {
                                    sb2.AppendLine(story.ToString());
                                }
                            }
                            break;
                        case "3":
                            foreach (var story in engine.Stories)
                            {
                                if (story.Status == StoryStatus.Done)
                                {
                                    sb2.AppendLine(story.ToString());
                                }
                            }
                            break;
                        case "4":
                            foreach (var feedback in engine.Feedbacks)
                            {
                                if (feedback.Status == FeedbackStatus.New)
                                {
                                    sb2.AppendLine(feedback.ToString());
                                }
                            }
                            break;
                        case "5":
                            foreach (var feedback in engine.Feedbacks)
                            {
                                if (feedback.Status == FeedbackStatus.Scheduled)
                                {
                                    sb2.AppendLine(feedback.ToString());
                                }
                            }
                            break;
                        case "6":
                            foreach (var feedback in engine.Feedbacks)
                            {
                                if (feedback.Status == FeedbackStatus.Unscheduled)
                                {
                                    sb2.AppendLine(feedback.ToString());
                                }
                            }
                            break;
                        case "7":
                            foreach (var feedback in engine.Feedbacks)
                            {
                                if (feedback.Status == FeedbackStatus.Done)
                                {
                                    sb2.AppendLine(feedback.ToString());
                                }
                            }
                            break;
                        case "8":
                            foreach (var bug in engine.Bugs)
                            {
                                if (bug.Status == BugStatus.Active)
                                {
                                    sb2.AppendLine(bug.ToString());
                                }
                            }
                            break;
                        case "9":
                            foreach (var bug in engine.Bugs)
                            {
                                if (bug.Status == BugStatus.Fixed)
                                {
                                    sb2.AppendLine(bug.ToString());
                                }
                            }
                            break;
                        default:
                            return "invalid command.";
                    }
                    if (string.IsNullOrEmpty(sb2.ToString()))
                    {
                        return $"No workitems are assigned with this status";
                    }
                    return sb2.ToString().Trim();
                default: return "invalid command.";
            }
        }
    }
}
