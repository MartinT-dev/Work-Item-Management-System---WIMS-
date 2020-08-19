using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;

namespace WIMS.Core.Providers
{
    public class CommandParser : IParser
    {
        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var commandTypeInfo = this.FindCommand(commandName);
            var command = Activator.CreateInstance(commandTypeInfo, WIMSFactory.Instance, Engine.Instance) as ICommand;

            return command;
        }

        private TypeInfo FindCommand(string commandName)
        {
            Assembly currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower() == (commandName.ToLower() + "command"))
                .SingleOrDefault();
            
            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }
            

            return commandTypeInfo;
        }
    }
}
