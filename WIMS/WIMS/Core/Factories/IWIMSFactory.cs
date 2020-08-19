using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Models.Contracts;
using WIMS.Models.Enums;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Core.Factories
{
    public interface IWIMSFactory
    {
        IBoard CreateBoard(string name);
        IMember CreateMember(string name);
        ITeam CreateTeam(string name);
        IBug CreateBug(string title,string description,List<string> stepsToReproduce,Priority priority,Severity severity,BugStatus status,IMember assignee);
        IStory CreateStory(string title, string description, Priority priority,Size size, StoryStatus status,IMember assigne);
        IFeedback CreateFeedback(string title, string description,int rating,FeedbackStatus status);
        


    }
}
