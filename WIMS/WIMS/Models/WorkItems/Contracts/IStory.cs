using Newtonsoft.Json;
using Wims.Models.Converters;
using WIMS.Models.Contracts;
using WIMS.Models.Enums;

namespace WIMS.Models.WorkItems.Contracts
{
    [JsonConverter(typeof(StoryConverter))]
    public interface IStory :IWorkItem
    {
        Priority Priority { get; set; }
        Size Size { get; set; }
        StoryStatus Status { get; set; }
        IMember Assignee { get; set; }
    }
}
