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
    public class UpdateRatingCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public UpdateRatingCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please enter the name of the team responsible for the workitem whose rating you want to change:");
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
            if (workItem is IFeedback == false)
            {
                return $"The selected WorkItem is not of type feedback. Only feedbacks have rating.";
            }
            IFeedback feedback = workItem as IFeedback;
            Console.Clear();
            Console.WriteLine("Please enter new rating for the feedback from 1 to 10:");
            Console.WriteLine($"The current size of {feedback.Title} is: {feedback.Rating}");
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
            if (rating == feedback.Rating)
            {
                return $"The selected WorkItem is already rated with {rating}.";
            }
            string result = HelperMethods.TimeStamp() + $"WorkItem with id {feedback.ID} changed it's rating to {rating}.";
            feedback.Rating = rating;
            feedback.History.Add(result);
            board.History.Add(result);
            team.History.Add(result);

            return result;
        }
    }
}

