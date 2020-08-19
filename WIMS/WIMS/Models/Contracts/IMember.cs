using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Converters;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Models.Contracts
{
    [JsonConverter(typeof(MemberConverter))]
    public interface IMember
    {
        int MemberID { get;}
        string Name { get; set; }
        IList<IWorkItem> WorkItems { get; }
        IList<string> History { get; }
    }
}
