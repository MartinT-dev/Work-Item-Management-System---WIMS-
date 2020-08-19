using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Models.Enums;

namespace WIMS.Models.WorkItems.Contracts
{
    interface IPriorityItem :IWorkItem
    {
        Priority Priority { get; set; }
    }
}
