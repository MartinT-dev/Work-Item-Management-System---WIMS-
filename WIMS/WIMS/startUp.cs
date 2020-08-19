using System;
using WIMS.Core;

namespace WIMS
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var engine = Engine.Instance;
            engine.Start();
        }
    }
}
