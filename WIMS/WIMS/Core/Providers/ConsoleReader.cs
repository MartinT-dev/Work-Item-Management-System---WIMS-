using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Core.Contracts;

namespace WIMS.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
