using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Models;
using WIMS.Models.Contracts;
using WIMS.Models.Enums;
using WIMS.Models.WorkItems;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Core.Factories
{
    public class WIMSFactory : IWIMSFactory
    {
        private static IWIMSFactory instanceHolder = new WIMSFactory();

        private WIMSFactory()
        {

        }

        public static IWIMSFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public IBoard CreateBoard(string name)
        {
            Board defBoard = new Board(name);
            return defBoard;
        }

        public IBug CreateBug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity, BugStatus status, IMember assignee)
        {
            return new Bug(title, description, stepsToReproduce, priority, severity, status, assignee);
        }

        public IFeedback CreateFeedback(string title, string description, int rating, FeedbackStatus status)
        {
            return new Feedback(title, description, rating, status);
        }

        public IMember CreateMember(string name)
        {
            Member defMember = new Member(name);
            return defMember;
        }

        public IStory CreateStory(string title, string description, Priority priority, Size size, StoryStatus status, IMember assignee)
        {
            return new Story(title, description, priority, size, status, assignee);
        }

        public ITeam CreateTeam(string name)
        {
            Team defTeam = new Team(name);
            return defTeam;
        }
    }
}
