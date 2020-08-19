using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models.WorkItems.Contracts;
using WIMS.Models.Contracts;

namespace WIMS.Commands.Creating
{
    class CreateCommentCommand:ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public CreateCommentCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please enter the name of the team responsible for the workitem where you want to add a comment");
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
            Console.WriteLine("Please enter the id of the workitem where you want to add a comment:");
            Console.WriteLine($"List of workitems in team {board.Name}:" + Environment.NewLine + HelperMethods.ListWorkItems(board.WorkItems));
            int workItemID = int.Parse(Console.ReadLine());
            bool ifWorkItemExists = HelperMethods.IfExists(workItemID, board.WorkItems);
            if (ifWorkItemExists == false)
            {
                return $"WorkItem with id {workItemID} does not exist in board {board.Name}.";
            }
            IWorkItem workItem = HelperMethods.ReturnExisting(workItemID, board.WorkItems);
            Console.Clear();
            Console.WriteLine("Please enter id of the member who wants to add a comment:");
            Console.WriteLine("- List of members:" + Environment.NewLine + HelperMethods.ListMembers(team.Members));
            bool tryMemberId = int.TryParse(Console.ReadLine(), out int resultParse);
            int memberId;
            if (tryMemberId == false)
            {
                return "invalid command";
            }
            else
            {
                memberId = resultParse;
            }
            bool ifMemberExists = HelperMethods.IfExists(memberId, team.Members);
            if (ifMemberExists == false)
            {
                return $"Member with id {memberId} does not exist in team {teamName}.";
            }
            IMember member = HelperMethods.ReturnExisting(memberId, team.Members);
            string author = $"{workItem.Comments.Count+1}." + HelperMethods.TimeStamp()+" " + member.Name;
            Console.Clear();
            Console.WriteLine("Please enter a comment:");
            string comment = Console.ReadLine();
            workItem.Comments.Add(author, comment);
            return "Comment was sucessfully added.";
        }
    }
}
