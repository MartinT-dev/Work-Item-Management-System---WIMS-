using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Converters;

namespace WIMS.Models.Contracts
{
    [JsonConverter(typeof(TeamConverter))]
    public interface ITeam
    {
        string Name { get; set; }
        IList<IMember> Members { get;}
        IList<IBoard> Boards { get;}
        IList<string> History { get; }

    }
}
