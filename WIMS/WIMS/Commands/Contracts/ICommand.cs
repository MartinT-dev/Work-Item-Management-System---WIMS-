using System;
using System.Collections.Generic;
using System.Text;

namespace WIMS.Commands.Contracts
{
    public interface ICommand
    {
        string Execute();
        
    }
}
