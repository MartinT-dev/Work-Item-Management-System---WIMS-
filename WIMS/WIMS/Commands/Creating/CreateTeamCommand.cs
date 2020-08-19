using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;

namespace WIMS.Commands.Creating
{
    public class CreateTeamCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public CreateTeamCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute()
        {
            Console.WriteLine("Please enter the name of the team:");
            string name = Console.ReadLine();
            bool ifTeamExists = HelperMethods.IfExists(name, engine.Teams);
            if (ifTeamExists==true)
            {
            return $"Team with name {name} already exists.";
            }
            var team = this.factory.CreateTeam(name);
            string result = HelperMethods.TimeStamp()+team.ToString()+" was created.";
            team.History.Add(result);
            this.engine.Teams.Add(team);
            return result;
            
        }
    }
}
