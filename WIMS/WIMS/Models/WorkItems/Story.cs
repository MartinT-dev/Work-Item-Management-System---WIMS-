using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Models.Contracts;
using WIMS.Models.Enums;
using WIMS.Models.WorkItems.Abstract;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Models.WorkItems
{
   public class Story : WorkItem, IStory,IAssignableItem,IPriorityItem
    {
        [JsonConstructor]
        public Story()
        {

        }
        public Story(string title, string description, Priority priority, Size size, StoryStatus status, IMember assignee)
            : base(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Status = status;
            this.Assignee = assignee;
        }

        public Priority Priority { get; set; }
        public Size Size { get; set; }
        public StoryStatus Status { get; set; }
        public IMember Assignee { get; set; }
    }
}