using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Core.Providers;
using WIMS.Models.Contracts;
using WIMS.Models.Enums;
using WIMS.Models.WorkItems;

namespace WIMS.Commands.Creating
{
    public class CreateFeedbackCommand : ICommand
    {
        //private readonly IWriter writer;
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public CreateFeedbackCommand(IWIMSFactory factory, IEngine engine/*, IWriter writer*/)
        {
            this.factory = factory;
            this.engine = engine;
            //this.writer = writer;
        }
        public string Execute()
        {
            Console.WriteLine("Please enter title of the feedback:");
            string title = Console.ReadLine();
            HelperMethods.ValidateWorkItemTitle(title);
            Console.Clear();
            Console.WriteLine("Please enter description of the feedback:");
            string description = Console.ReadLine();
            HelperMethods.ValidateWorkItemDescription(description);
            Console.Clear();
            /*writer*/Console.WriteLine("Please rate the feedback with number from 1 to 10:");
            bool ratingTry = int.TryParse(Console.ReadLine(), out int resultParse);
            int rating;
            if (ratingTry == false)
            {
                return "invalid command";
            }
            else
            {
                rating = resultParse;
            }
            HelperMethods.ValidateFeedbackRating(rating);
            Console.Clear();
            Console.WriteLine($"Please choose status of the feedback:{Environment.NewLine}" +
                $"Type 1 for New.{Environment.NewLine}" +
                $"Type 2 for Unscheduled.{Environment.NewLine}" +
                $"Type 3 for Scheduled.{Environment.NewLine}" +
                $"Type 4 for Done.{Environment.NewLine}");
            string statusUserInput = Console.ReadLine();
            FeedbackStatus status;
            switch (statusUserInput)
            {
                case "1": status = FeedbackStatus.New; break;
                case "2": status = FeedbackStatus.Unscheduled; break;
                case "3": status = FeedbackStatus.Scheduled; break;
                case "4": status = FeedbackStatus.Done; break;
                default: return "invalid command";
            }
            Console.Clear();
            Console.WriteLine("Please enter the name of the team responsible for this feedback:");
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

            var feedback = this.factory.CreateFeedback(title, description, rating, status);
            this.engine.Feedbacks.Add(feedback);
            boardToBeAssigned.WorkItems.Add(feedback);
            string result = HelperMethods.TimeStamp()+feedback.ToString() + " was created.";
            boardToBeAssigned.History.Add(result);
            teamToBeAssigned.History.Add(result);
            feedback.History.Add(result);
            return result;

        }
    }
}
