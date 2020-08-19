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
    public class Bug : WorkItem, IBug, IAssignableItem,IPriorityItem
    {
        [JsonConstructor]
        public Bug()
        {

        }

        public Bug(string title, string description, List<string> steps, Priority priority, Severity severity,BugStatus status, IMember assignee)
            : base(title, description)
        {
            this.Steps = steps;
            this.Severity = severity;
            this.Priority = priority;
            this.Status = status;
            this.Assignee = assignee;
        }

        public IList<string> Steps { get; set; }
        public Priority Priority { get; set; }
        public Severity Severity { get; set; }
        public BugStatus Status { get; set; }
        public IMember Assignee { get; set; }

    }
}
