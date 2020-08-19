
using Newtonsoft.Json;
using System.Collections.Generic;
using Wims.Models.Converters;
using WIMS.Models.Contracts;
using WIMS.Models.Enums;

namespace WIMS.Models.WorkItems.Contracts
{
    [JsonConverter(typeof(BugConverter))]
    public interface IBug : IWorkItem
    {
        IList<string> Steps { get; set; }
        Priority Priority { get; set; }
        Severity Severity { get; set; }
        BugStatus Status { get; set; }

        IMember Assignee { get; set; }
       
    }
}
