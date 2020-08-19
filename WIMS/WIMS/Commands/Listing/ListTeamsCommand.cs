using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using System.Linq;
namespace WIMS.Commands.Listing
{
    public class ListTeamsCommand : ICommand
    {

        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ListTeamsCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute()
        {
            var teams = this.engine.Teams;
            StringBuilder sb = new StringBuilder();
            if (teams.Count == 0)
            {
                return "No teams created";
            }
            foreach (var team in teams)
            {
                sb.AppendLine(team.ToString());
            }
            Console.Clear();
            Console.WriteLine($"Teams{Environment.NewLine}--------------------------------");
            return sb.ToString().Trim();
        }
    }
}
