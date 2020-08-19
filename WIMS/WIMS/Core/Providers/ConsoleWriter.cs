using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Core.Contracts;

namespace WIMS.Core.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
