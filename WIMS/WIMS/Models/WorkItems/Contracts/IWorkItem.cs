using System;
using System.Collections.Generic;
using System.Text;

namespace WIMS.Models.WorkItems.Contracts
{
    public interface IWorkItem
    {
        int ID { get; }

        string Title { get; set; }

        string Description { get; set; }

        IDictionary<string, string> Comments { get; }

        IList<string> History { get; }

        void ValidateTitle(string title);
        void ValidateDescription(string description);
     

    }
}
