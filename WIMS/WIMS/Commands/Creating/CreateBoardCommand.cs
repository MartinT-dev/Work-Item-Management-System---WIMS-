using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models;
using WIMS.Models.Contracts;

namespace WIMS.Commands.Creating
{
    public class CreateBoardCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public CreateBoardCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute()
        {
            Console.WriteLine("Please enter team for the board:");
            Console.WriteLine("List of teams:" + Environment.NewLine + HelperMethods.ListTeams(this.engine.Teams));
            string teamName = Console.ReadLine();
            bool ifTeamExists = HelperMethods.IfExists(teamName, engine.Teams);
            if (ifTeamExists == false)
            {
                return "Team with such name does not exist.";
            }
            ITeam teamToBeAssigned = HelperMethods.ReturnExisting(teamName, engine.Teams);
            Console.Clear();
            Console.WriteLine("Please enter the name of the board:");
            string name = Console.ReadLine();
            bool ifBoardExists = HelperMethods.IfExists(name, teamToBeAssigned.Boards);
            if (ifBoardExists==true)
            {
                return $"Board with name {name} already exists in team {teamToBeAssigned.Name}.";
            }
            var board = this.factory.CreateBoard(name);
            this.engine.Boards.Add(board);
            teamToBeAssigned.Boards.Add(board);
            string result = HelperMethods.TimeStamp() + board.ToString() + $" was created and added to team {teamToBeAssigned.Name}.";
            board.History.Add(result);
            teamToBeAssigned.History.Add(result);

            return result;

        }
    }
}
