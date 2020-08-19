using Newtonsoft.Json;
using Wims.Models.Converters;
using WIMS.Models.Enums;

namespace WIMS.Models.WorkItems.Contracts
{
    [JsonConverter(typeof(FeedbackConverter))]
    public interface IFeedback :IWorkItem
    {
        int Rating { get; set; }
        FeedbackStatus Status { get; set; }
    }
}
