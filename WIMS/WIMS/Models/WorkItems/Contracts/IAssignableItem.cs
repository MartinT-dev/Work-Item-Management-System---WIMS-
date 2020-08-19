using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Models.Contracts;

namespace WIMS.Models.WorkItems.Contracts
{
    interface IAssignableItem :IWorkItem
    {
        IMember Assignee { get; set; }
    }
}
