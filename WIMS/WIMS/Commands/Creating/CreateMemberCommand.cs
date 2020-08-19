using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models;
using WIMS.Models.Contracts;

namespace WIMS.Commands.Creating
{
    public class CreateMemberCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public CreateMemberCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute()
        {
            if (engine.Teams.Count==0)
            {
                return "You should create at least one team first.";
            }
            Console.WriteLine("Please enter team for the member:");
            Console.WriteLine("List of teams:" + Environment.NewLine + HelperMethods.ListTeams(this.engine.Teams));
            string teamName = Console.ReadLine();
            bool ifTeamExists = HelperMethods.IfExists(teamName, engine.Teams);
            if (ifTeamExists == false)
            {
                return "Team with such name does not exist.";
            }
            ITeam teamToBeAssigned = HelperMethods.ReturnExisting(teamName, engine.Teams);
            Console.Clear();
            Console.WriteLine("Please enter the name of the member:");
            string name = Console.ReadLine();
            var member = this.factory.CreateMember(name);
            this.engine.Members.Add(member);
            teamToBeAssigned.Members.Add(member);
            string result = HelperMethods.TimeStamp() + member.ToString() + $" was created and added to team {teamToBeAssigned.Name}.";
            member.History.Add(result);
            teamToBeAssigned.History.Add(result);

            return result;
        }
    }
}
