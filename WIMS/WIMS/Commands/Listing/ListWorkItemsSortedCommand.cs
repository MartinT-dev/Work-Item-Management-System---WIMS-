using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Commands.Listing
{
    public class ListWorkItemsSortedCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ListWorkItemsSortedCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please select in what order should the workitems be sorted:" + Environment.NewLine +
            $"-Type 1 to sort by title.{Environment.NewLine}" +
            $"-Type 2 to sort by priority.{Environment.NewLine}" +
            $"-Type 3 to sort by severity.{Environment.NewLine}" +
            $"-Type 4 to sort by size.{Environment.NewLine}" +
            $"-Type 5 to sort by rating");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    var allBugs = engine.Bugs.Select(b => b.Title + " with id " + b.ID);
                    var allStories = engine.Stories.Select(b => b.Title + " with id " + b.ID);
                    var allFeedbacks = engine.Feedbacks.Select(b => b.Title + " with id " + b.ID);
                    var allWorkitems = (allBugs ?? Enumerable.Empty<string>()).Concat(allStories ?? Enumerable.Empty<string>()).Concat(allFeedbacks ?? Enumerable.Empty<string>());
                    var result = allWorkitems.OrderBy(w => w);
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in result)
                    {
                        sb.AppendLine(item);
                    }
                    return sb.ToString().Trim();
                case "2":
                    var allPriorityItems = new List<IPriorityItem>();
                    foreach (var bug in engine.Bugs)
                    {
                        var iBug = bug as IPriorityItem;
                        allPriorityItems.Add(iBug);
                    }
                    foreach (var story in engine.Stories)
                    {
                        var iStory= story as IPriorityItem;
                        allPriorityItems.Add(iStory);
                    }
                    var result2 = allPriorityItems.OrderBy(p => p.Priority);
                    StringBuilder sb2 = new StringBuilder();
                    foreach (var item in result2)
                    {
                        sb2.AppendLine(item.ToString() + "with priority: " + item.Priority);
                    }
                    return sb2.ToString().Trim();
                case "3":
                    var result3 = engine.Bugs.OrderBy(b => b.Severity);
                    StringBuilder sb3 = new StringBuilder();
                    foreach (var item in result3)
                    {
                        sb3.AppendLine(item.ToString() + "with severity: " + item.Severity);
                    }
                    return sb3.ToString().Trim();
                case "4":
                    var result4 = engine.Stories.OrderBy(s => s.Size);
                    StringBuilder sb4 = new StringBuilder();
                    foreach (var item in result4)
                    {
                        sb4.AppendLine(item.ToString() + "with size: " + item.Size);
                    }
                    return sb4.ToString().Trim();
                case "5":
                    var result5 = engine.Feedbacks.OrderByDescending(b => b.Rating);
                    StringBuilder sb5 = new StringBuilder();
                    foreach (var item in result5)
                    {
                        sb5.AppendLine(item.ToString() + "with rating: " + item.Rating);
                    }
                    return sb5.ToString().Trim();
                default: return "invalid command.";
            }
        }
    }
}
