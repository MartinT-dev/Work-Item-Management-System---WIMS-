using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Commands.Listing
{
    public class ListFeedbacksCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ListFeedbacksCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Type the name of the team of the board whose feedbacks you want to see");
            Console.WriteLine("List of teams:" + Environment.NewLine + HelperMethods.ListTeams(engine.Teams) + Environment.NewLine + "------------------------------");
            Console.Write("- Team name:");
            string teamName = Console.ReadLine();
            Console.Clear();
            bool ifTeamExists = HelperMethods.IfExists(teamName, engine.Teams);
            if (ifTeamExists == false)
            {
                return "Team with such name does not exist.";
            }
            ITeam team = HelperMethods.ReturnExisting(teamName, engine.Teams);
            Console.WriteLine("Type the name of the board whose feedbacks you want to check");
            Console.WriteLine("List of boards" + Environment.NewLine + HelperMethods.ListBoards(team.Boards) + Environment.NewLine + "-------------------------");
            Console.Write("-Board name:");
            string boardName = Console.ReadLine();
            bool ifBoardExist = HelperMethods.IfExists(boardName, team.Boards);
            if (ifBoardExist == false)
            {
                return $"Board with name {boardName} does not exist in team {teamName}.";
            }
            IBoard board = HelperMethods.ReturnExisting(boardName, team.Boards);
            bool feedbackExist = false;
            foreach (var item in board.WorkItems)
            {
                if (item is IFeedback)
                {
                    feedbackExist = true;
                    break;
                }
            }
            if (feedbackExist == false)
            {
                return $"There are no created feedbacks in board {board.Name}!";
            }
            StringBuilder sb = new StringBuilder();
            foreach (var feedback in board.WorkItems)
            {
                if (feedback is IFeedback)
                {
                    var iFeedback = feedback as IFeedback;
                    sb.AppendLine(Environment.NewLine + iFeedback.ToString() + Environment.NewLine +
                                $"Description of the feedback - {iFeedback.Description}{Environment.NewLine}" +
                                $"Status of the feedback - {iFeedback.Status}{Environment.NewLine}" +
                                $"Rating of the feedback - {iFeedback.Rating}{Environment.NewLine}");
                }
            }
            Console.Clear();
            Console.WriteLine($"Feedbacks in board {boardName} of team {teamName}{Environment.NewLine}--------------------------------");
            return sb.ToString().Trim();
        }
    }
}
