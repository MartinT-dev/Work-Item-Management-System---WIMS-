using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Core;
using WIMS.Core.Contracts;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Commands
{
    public static class HelperMethods
    {
        /// <summary>
        /// User friendly output of current date and time.
        /// </summary>
        /// <returns>string</returns>
        public static string TimeStamp()
        {
            return "[" + DateTime.Now.ToString("dd/MM/yyyy h:mm tt") + "]";
        }

        /// <summary>
        /// Returns whether a team with given name exists in collection of type ITeam.
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="collection">IList<ITeam></param>
        /// <returns>bool</returns>
        public static bool IfExists(string name, IList<ITeam> collection)
        {
            bool result = false;
            foreach (var item in collection)
            {
                if (name == item.Name)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns whether a board with given name exists in collection of type IBoard.
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="collection">IList<IBoard></param>
        /// <returns>bool</returns>
        public static bool IfExists(string name, IList<IBoard> collection)
        {
            bool result = false;
            foreach (var item in collection)
            {
                if (name == item.Name)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Returns whether a member with given id exists in collection of type IMember.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="collection">IList<IMember></param>
        /// <returns>bool</returns>
        public static bool IfExists(int id, IList<IMember> collection)
        {
            bool result = false;
            foreach (var item in collection)
            {
                if (id == item.MemberID)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Returns whether a workitem with given id exists in collection of type IWorkItem.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="collection">IList<IWorkItem></param>
        /// <returns>bool</returns>
        public static bool IfExists(int id, IList<IWorkItem> collection)
        {
            bool result = false;
            foreach (var item in collection)
            {
                if (id == item.ID)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Returns whether a bug with given id exists in collection of type IBug.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="collection">IList<IBug></param>
        /// <returns>bool</returns>
        public static bool IfExists(int id, IList<IBug> collection)
        {
            bool result = false;
            foreach (var item in collection)
            {
                if (id == item.ID)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns whether a story with given id exists in collection of type IStory.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="collection">IList<IStory></param>
        /// <returns>bool</returns>
        public static bool IfExists(int id, IList<IStory> collection)
        {
            bool result = false;
            foreach (var item in collection)
            {
                if (id == item.ID)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Returns whether a feedback with given id exists in collection of type IFeedback.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="collection">IList<IFeedback></param>
        /// <returns>bool</returns>
        public static bool IfExists(int id, IList<IFeedback> collection)
        {
            bool result = false;
            foreach (var item in collection)
            {
                if (id == item.ID)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Returns an ITeam by given name from a collection of type ITeam.
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="collection">IList<ITeam></param>
        /// <returns>ITeam</returns>
        public static ITeam ReturnExisting(string name, IList<ITeam> collection)
        {
            ITeam result=default;
            foreach (var item in collection)
            {
                if (name==item.Name)
                {
                    result = item;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns an IBoard by given name from a collection of type IBoard.
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="collection">IList<IBoard></param>
        /// <returns>IBoard</returns>
        public static IBoard ReturnExisting(string name, IList<IBoard> collection)
        {
            IBoard result = default;
            foreach (var item in collection)
            {
                if (name == item.Name)
                {
                    result = item;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Returns an IMember by given id from a collection of type IMember.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="collection">IList<IMember></param>
        /// <returns>IMember</returns>
        public static IMember ReturnExisting(int id, IList<IMember> collection)
        {
            IMember result = default;
            foreach (var item in collection)
            {
                if (id == item.MemberID)
                {
                    result = item;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns an IWorkItem by given id from a collection of type IWorkItem.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="collection">IList<IWorkItem></param>
        /// <returns>IWorkItem</returns>
        public static IWorkItem ReturnExisting(int id, IList<IWorkItem> collection)
        {
            IWorkItem result = default;
            foreach (var item in collection)
            {
                if (id == item.ID)
                {
                    result = item;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns an IBug by given id from a collection of type IBug.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="collection">IList<IBug></param>
        /// <returns>IBug</returns>
        public static IBug ReturnExisting(int id, IList<IBug> collection)
        {
            IBug result = default;
            foreach (var item in collection)
            {
                if (id == item.ID)
                {
                    result = item;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Returns an IStory by given id from a collection of type IStory.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="collection">IList<IStory></param>
        /// <returns>IStory</returns>
        public static IStory ReturnExisting(int id, IList<IStory> collection)
        {
            IStory result = default;
            foreach (var item in collection)
            {
                if (id == item.ID)
                {
                    result = item;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns an IFeedback by given id from a collection of type IFeedback.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="collection">IList<IFeedback></param>
        /// <returns>IFeedback</returns>
        public static IFeedback ReturnExisting(int id, IList<IFeedback> collection)
        {
            IFeedback result = default;
            foreach (var item in collection)
            {
                if (id == item.ID)
                {
                    result = item;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Return the ITeam in which an IMember belongs from a collection of ITeam.
        /// </summary>
        /// <param name="member">IMember</param>
        /// <param name="collection">IList<ITeam></param>
        /// <returns>ITeam</returns>
        public static ITeam GetTeam(IMember member, IList<ITeam> collection)
        {
            ITeam result = default;
            foreach (var item in collection)
            {
                if (item.Members.Contains(member))
                {
                    result = item;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Validation of WorkItemTitle as per task description.
        /// </summary>
        /// <param name="title">string</param>
        public static void ValidateWorkItemTitle(string title)
        {
            if (title == null)
            {
                throw new ArgumentNullException("Title can not be null.");
            }
            if (title.Length < 10 || title.Length > 50)
            {
                throw new ArgumentException("Title should be between 10 and 50 symbols.");
            }
        }
        /// <summary>
        /// Validation of TeamName as per task description.
        /// </summary>
        /// <param name="name">string</param>
        public static void ValidateTeamName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name can not be null.");
            }
            if (name.Length < 5 || name.Length > 15)
            {
                throw new ArgumentException("Name should be between 5 and 15 symbols.");
            }
        }
        /// <summary>
        /// Validation of MemberName as per task description.
        /// </summary>
        /// <param name="name">string</param>
        public static void ValidateMemberName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name can not be null.");
            }
            if (name.Length < 5 || name.Length > 15)
            {
                throw new ArgumentException("Name should be between 5 and 15 symbols.");
            }
        }
        /// <summary>
        /// Validation of BoardName as per task description.
        /// </summary>
        /// <param name="name">string</param>
        public static void ValidateBoardName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Title can not be null.");
            }
            if (name.Length < 5 || name.Length > 10)
            {
                throw new ArgumentException("Title should be between 5 and 10 symbols.");
            }
        }
        /// <summary>
        /// Validation of WorkItemDescription as per task description.
        /// </summary>
        /// <param name="description">string</param>
        public static void ValidateWorkItemDescription(string description)
        {
            if (description == null)
            {
                throw new ArgumentNullException("Description can not be null.");
            }
            if (description.Length < 10 || description.Length > 500)
            {
                throw new ArgumentException("Description should be between 10 and 500 symbols.");
            }
        }
        /// <summary>
        /// Validation of FeedbackRating as per task description.
        /// </summary>
        /// <param name="rating">int</param>
        public static void ValidateFeedbackRating(int rating)
        {
            if (rating < 1 || rating > 10)
            {
                throw new ArgumentException("Rating should be a number between 1 and 10.");
            }
        }
       /// <summary>
       /// Listing the existing teams in the collection.
       /// </summary>
       /// <param name="teams">The collection.</param>
       /// <returns>String.</returns>
        public static string ListTeams(IList<ITeam> teams)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var team in teams)
            {
                sb.Append(team.ToString() + Environment.NewLine);
            }
            return sb.ToString().Trim();
        }
        /// <summary>
        /// Listing the existing members in the collection.
        /// </summary>
        /// <param name="teams">The collection.</param>
        /// <returns>String.</returns>
        public static string ListMembers(IList<IMember> members)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var member in members)
            {
                sb.Append(member.ToString() + Environment.NewLine);
            }
            return sb.ToString().Trim();
        }
        /// <summary>
        /// Listing the existing boards in the collection.
        /// </summary>
        /// <param name="teams">The collection.</param>
        /// <returns>String.</returns>
        public static string ListBoards(IList<IBoard> boards)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var board in boards)
            {
                sb.Append(board.ToString() + Environment.NewLine);
            }
            return sb.ToString().Trim();
        }
        //Work in progress.
        /// <summary>
        /// Listing the existing workitems in the collection.
        /// </summary>
        /// <param name="teams">The collection.</param>
        /// <returns>String.</returns>
        public static string ListWorkItems(IList<IWorkItem> workItems)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var workItem in workItems)
            {
                sb.Append(workItem.ID.ToString() + Environment.NewLine);
            }
            return sb.ToString().Trim();
        }   
        public static string ListBugs(IList<IBug> bugs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var bug in bugs)
            {
                sb.Append(bug.ID.ToString() + Environment.NewLine);
            }
            return sb.ToString().Trim();
        }
        public static string ListStories(IList<IStory> stories)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var story in stories)
            {
                sb.Append(story.ID.ToString() + Environment.NewLine);
            }
            return sb.ToString().Trim();
        }  
        public static string ListFeedbacks(IList<IFeedback> feedbacks)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var feedback in feedbacks)
            {
                sb.Append(feedback.ID.ToString() + Environment.NewLine);
            }
            return sb.ToString().Trim();
        }
    }
}
