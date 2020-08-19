using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Models;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Core.Contracts
{
   public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }

        IList<IBug> Bugs { get; }

        IList<IFeedback> Feedbacks { get; }

        IList<IStory> Stories { get; }
        IList<ITeam> Teams { get; }
        IList<IMember> Members { get; }
        IList<IBoard> Boards { get; }

    }
}
