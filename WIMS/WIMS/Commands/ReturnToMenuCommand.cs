using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;

namespace WIMS.Commands
{
    public class ReturnToMenuCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public ReturnToMenuCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute()
        {
            Console.Clear();
            return "Returned to main menu!";
        }
        //public T CheckIfExists<T>(List<T> collection, string name)
        //{
        //    T result = default;
        //    foreach (var item in collection)
        //    {
        //        if (item.GetType().Name == name)
        //        {
        //            result = item;
        //        }
        //   }
        //   return result;
        //}

    }
}
