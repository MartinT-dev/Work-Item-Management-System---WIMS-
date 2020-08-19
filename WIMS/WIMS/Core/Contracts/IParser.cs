using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;

namespace WIMS.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);
        

        //IList<string> ParseParameters(string fullCommand);
    }
}
