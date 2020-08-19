using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands;
using WIMS.Models;
using WIMS.Models.Contracts;
using WIMS.Models.Enums;
using WIMS.Models.WorkItems;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Database
{
    public static class SeedSample
    {
        public static void Seed(IList<IBug> Bugs, IList<IFeedback> Feedbacks, IList<IStory> Stories, IList<ITeam> Teams, IList<IMember> Members, IList<IBoard> Boards)
        {
            var team1 = new Team("Mandalorians");
            string team1result = HelperMethods.TimeStamp() + team1.ToString() + " was created.";
            team1.History.Add(team1result);
            Teams.Add(team1);

            var team2 = new Team("PushToMaster");
            string team2result = HelperMethods.TimeStamp() + team2.ToString() + " was created.";
            team2.History.Add(team2result);
            Teams.Add(team2);

            var team3 = new Team("ThunderDucks");
            string team3result = HelperMethods.TimeStamp() + team3.ToString() + " was created.";
            team3.History.Add(team3result);
            Teams.Add(team3);

            var member1 = new Member("Martin");
            Members.Add(member1);
            team1.Members.Add(member1);
            string member1result = HelperMethods.TimeStamp() + member1.ToString() + $" was created and added to team {team1.Name}.";
            team1.History.Add(member1result);
            member1.History.Add(member1result);

            var member2 = new Member("Boncho");
            Members.Add(member2);
            team1.Members.Add(member2);
            string member2result = HelperMethods.TimeStamp() + member2.ToString() + $" was created and added to team {team1.Name}.";
            team1.History.Add(member2result);
            member2.History.Add(member2result);

            var member3 = new Member("Greta");
            Members.Add(member3);
            team1.Members.Add(member3);
            string member3result = HelperMethods.TimeStamp() + member3.ToString() + $" was created and added to team {team1.Name}.";
            team1.History.Add(member3result);
            member3.History.Add(member3result);

            var member4 = new Member("Lachezar");
            Members.Add(member4);
            team2.Members.Add(member4);
            string member4result = HelperMethods.TimeStamp() + member4.ToString() + $" was created and added to team {team2.Name}.";
            team2.History.Add(member4result);
            member4.History.Add(member4result);

            var member5 = new Member("Dimitar");
            Members.Add(member5);
            team2.Members.Add(member5);
            string member5result = HelperMethods.TimeStamp() + member5.ToString() + $" was created and added to team {team2.Name}.";
            team2.History.Add(member5result);
            member5.History.Add(member5result);

            var member6 = new Member("Yoanna");
            Members.Add(member6);
            team2.Members.Add(member6);
            string member6result = HelperMethods.TimeStamp() + member6.ToString() + $" was created and added to team {team2.Name}.";
            team2.History.Add(member6result);
            member6.History.Add(member6result);

            var member7 = new Member("Zinaida");
            Members.Add(member7);
            team3.Members.Add(member7);
            string member7result = HelperMethods.TimeStamp() + member7.ToString() + $" was created and added to team {team3.Name}.";
            team3.History.Add(member7result);
            member7.History.Add(member7result);

            var member8 = new Member("Teodor");
            Members.Add(member8);
            team3.Members.Add(member8);
            string member8result = HelperMethods.TimeStamp() + member8.ToString() + $" was created and added to team {team3.Name}.";
            team3.History.Add(member8result);
            member8.History.Add(member8result);

            var board1 = new Board("Hackaton1");
            Boards.Add(board1);
            team1.Boards.Add(board1);
            string board1result = HelperMethods.TimeStamp() + board1.ToString() + $" was created and added to team {team1.Name}.";
            team1.History.Add(board1result);
            board1.History.Add(board1result);

            var board2 = new Board("Hackaton2");
            Boards.Add(board2);
            team1.Boards.Add(board2);
            string board2result = HelperMethods.TimeStamp() + board2.ToString() + $" was created and added to team {team1.Name}.";
            team1.History.Add(board2result);
            board2.History.Add(board2result);

            var board3 = new Board("Hackaton1");
            Boards.Add(board3);
            team2.Boards.Add(board3);
            string board3result = HelperMethods.TimeStamp() + board3.ToString() + $" was created and added to team {team2.Name}.";
            team2.History.Add(board3result);
            board3.History.Add(board3result);

            var board4 = new Board("Workshop1");
            Boards.Add(board4);
            team2.Boards.Add(board4);
            string board4result = HelperMethods.TimeStamp() + board4.ToString() + $" was created and added to team {team2.Name}.";
            team2.History.Add(board4result);
            board4.History.Add(board4result);

            var board5 = new Board("Workshop2");
            Boards.Add(board5);
            team3.Boards.Add(board5);
            string board5result = HelperMethods.TimeStamp() + board5.ToString() + $" was created and added to team {team3.Name}.";
            team3.History.Add(board5result);
            board5.History.Add(board5result);

            var board6 = new Board("Workshop3");
            Boards.Add(board6);
            team3.Boards.Add(board6);
            string board6result = HelperMethods.TimeStamp() + board6.ToString() + $" was created and added to team {team3.Name}.";
            team3.History.Add(board6result);
            board6.History.Add(board6result);

            var bug1 = new Bug("Incorrect output", "The output is different from task requirements", new List<string> { "read", "revise", "rewrite" }, Priority.High, Severity.Major, BugStatus.Active, member3);
            Bugs.Add(bug1);
            board1.WorkItems.Add(bug1);
            member3.WorkItems.Add(bug1);
            string bug1result = HelperMethods.TimeStamp() + bug1.ToString() + $" was created in board {board1.Name} and assigned to {member3.Name} with ID {member3.MemberID}";
            bug1.History.Add(bug1result);
            team1.History.Add(bug1result);
            board1.History.Add(bug1result);
            member3.History.Add(bug1result);

            var bug2 = new Bug("Most of the tests fail", "12 out of 27 tests fail", new List<string> { "read", "revise", "rewrite" }, Priority.Medium, Severity.Major, BugStatus.Active, member2);
            Bugs.Add(bug2);
            board1.WorkItems.Add(bug2);
            member2.WorkItems.Add(bug2);
            string bug2result = HelperMethods.TimeStamp() + bug2.ToString() + $" was created in board {board1.Name} and assigned to {member2.Name} with ID {member2.MemberID}";
            bug2.History.Add(bug2result);
            team1.History.Add(bug2result);
            board1.History.Add(bug2result);
            member2.History.Add(bug2result);

            var bug3 = new Bug("CreateCommand is not working", "CreateCommand return type is not as it should be", new List<string> { "read", "rewrite" }, Priority.Low, Severity.Minor, BugStatus.Fixed, member1);
            Bugs.Add(bug3);
            board1.WorkItems.Add(bug3);
            member1.WorkItems.Add(bug3);
            string bug3result = HelperMethods.TimeStamp() + bug3.ToString() + $" was created in board {board1.Name} and assigned to {member1.Name} with ID {member1.MemberID}";
            bug3.History.Add(bug3result);
            team1.History.Add(bug3result);
            board1.History.Add(bug3result);
            member1.History.Add(bug3result);

            var bug4 = new Bug("ChangeCommand is not working", "ChangeCommand is not changing the main property ", new List<string> { "read", "rewrite" }, Priority.Medium, Severity.Major, BugStatus.Active, member2);
            Bugs.Add(bug4);
            board2.WorkItems.Add(bug4);
            member2.WorkItems.Add(bug4);
            string bug4result = HelperMethods.TimeStamp() + bug4.ToString() + $" was created in board {board2.Name} and assigned to {member2.Name} with ID {member2.MemberID}";
            bug4.History.Add(bug4result);
            team1.History.Add(bug4result);
            board2.History.Add(bug4result);
            member2.History.Add(bug4result);

            var bug5 = new Bug("ListCommand is not working", "ListCommand is not listing in the right order", new List<string> { "read", "rewrite" }, Priority.High, Severity.Critical, BugStatus.Active, member3);
            Bugs.Add(bug5);
            board2.WorkItems.Add(bug5);
            member3.WorkItems.Add(bug5);
            string bug5result = HelperMethods.TimeStamp() + bug5.ToString() + $" was created in board {board2.Name} and assigned to {member3.Name} with ID {member3.MemberID}";
            bug5.History.Add(bug5result);
            team1.History.Add(bug5result);
            board2.History.Add(bug5result);
            member3.History.Add(bug5result);

            var bug6 = new Bug("Unsuccessfull overwrite", "Command does not overwrite existing file", new List<string> { "read", "rewrite" }, Priority.High, Severity.Critical, BugStatus.Active, member1);
            Bugs.Add(bug6);
            board2.WorkItems.Add(bug6);
            member1.WorkItems.Add(bug6);
            string bug6result = HelperMethods.TimeStamp() + bug6.ToString() + $" was created in board {board2.Name} and assigned to {member1.Name} with ID {member1.MemberID}";
            bug6.History.Add(bug6result);
            team1.History.Add(bug6result);
            board2.History.Add(bug6result);
            member1.History.Add(bug6result);

            var bug7 = new Bug("Unsuccessfull load of template", "Unable to download the task template", new List<string> { "discuss" }, Priority.High, Severity.Critical, BugStatus.Active, member4);
            Bugs.Add(bug7);
            board3.WorkItems.Add(bug7);
            member4.WorkItems.Add(bug7);
            string bug7result = HelperMethods.TimeStamp() + bug7.ToString() + $" was created in board {board3.Name} and assigned to {member4.Name} with ID {member4.MemberID}";
            bug7.History.Add(bug7result);
            team2.History.Add(bug7result);
            board3.History.Add(bug7result);
            member4.History.Add(bug7result);

            var bug8 = new Bug("Method AutoAttack is not working", "Not implemented", new List<string> { "implement" }, Priority.Low, Severity.Minor, BugStatus.Active, member4);
            Bugs.Add(bug8);
            board4.WorkItems.Add(bug8);
            member4.WorkItems.Add(bug8);
            string bug8result = HelperMethods.TimeStamp() + bug8.ToString() + $" was created in board {board4.Name} and assigned to {member4.Name} with ID {member4.MemberID}";
            bug8.History.Add(bug8result);
            team2.History.Add(bug8result);
            board4.History.Add(bug8result);
            member4.History.Add(bug8result);

            var bug9 = new Bug("Constructor of AutoAttack is not working", "Not implemented", new List<string> { "implement" }, Priority.Low, Severity.Minor, BugStatus.Active, member5);
            Bugs.Add(bug9);
            board3.WorkItems.Add(bug9);
            member5.WorkItems.Add(bug9);
            string bug9result = HelperMethods.TimeStamp() + bug9.ToString() + $" was created in board {board3.Name} and assigned to {member5.Name} with ID {member5.MemberID}";
            bug9.History.Add(bug9result);
            team2.History.Add(bug9result);
            board3.History.Add(bug9result);
            member5.History.Add(bug9result);

            var bug10 = new Bug("ToString method is not overriden", "Compile time error", new List<string> { "refactoring" }, Priority.Medium, Severity.Major, BugStatus.Fixed, member6);
            Bugs.Add(bug10);
            board4.WorkItems.Add(bug10);
            member6.WorkItems.Add(bug10);
            string bug10result = HelperMethods.TimeStamp() + bug10.ToString() + $" was created in board {board4.Name} and assigned to {member6.Name} with ID {member6.MemberID}";
            bug10.History.Add(bug10result);
            team2.History.Add(bug10result);
            board4.History.Add(bug10result);
            member6.History.Add(bug10result);

            var story1 = new Story("Creation of engine", "Initial of implementation engine", Priority.Medium, Size.Medium, StoryStatus.InProgress, member7);
            Stories.Add(story1);
            board5.WorkItems.Add(story1);
            member7.WorkItems.Add(story1);
            string story1result = HelperMethods.TimeStamp() + story1.ToString() + $" was created in board {board5.Name} and assigned to {member7.Name} with ID {member7.MemberID}";
            story1.History.Add(story1result);
            team3.History.Add(story1result);
            board5.History.Add(story1result);
            member7.History.Add(story1result);

            var story2 = new Story("Creation of print method", "Initial implementation of print method", Priority.Medium, Size.Medium, StoryStatus.Done, member8);
            Stories.Add(story2);
            board6.WorkItems.Add(story2);
            member8.WorkItems.Add(story2);
            string story2result = HelperMethods.TimeStamp() + story2.ToString() + $" was created in board {board6.Name} and assigned to {member8.Name} with ID {member8.MemberID}";
            story2.History.Add(story2result);
            team3.History.Add(story2result);
            board6.History.Add(story2result);
            member8.History.Add(story2result);

            var story3 = new Story("Creation of Add method", "Initial implementation of add method", Priority.Low, Size.Large, StoryStatus.InProgress, member5);
            Stories.Add(story3);
            board3.WorkItems.Add(story3);
            member5.WorkItems.Add(story3);
            string story3result = HelperMethods.TimeStamp() + story3.ToString() + $" was created in board {board3.Name} and assigned to {member5.Name} with ID {member5.MemberID}";
            story3.History.Add(story3result);
            team2.History.Add(story3result);
            board3.History.Add(story3result);
            member5.History.Add(story3result);

            var story4 = new Story("Creation of Remove method", "Initial implementation of remove method", Priority.Low, Size.Large, StoryStatus.InProgress, member4);
            Stories.Add(story4);
            board4.WorkItems.Add(story4);
            member4.WorkItems.Add(story4);
            string story4result = HelperMethods.TimeStamp() + story4.ToString() + $" was created in board {board4.Name} and assigned to {member4.Name} with ID {member4.MemberID}";
            story4.History.Add(story4result);
            team2.History.Add(story4result);
            board4.History.Add(story4result);
            member4.History.Add(story4result);

            var story5 = new Story("Creation of IndexOf method", "Initial implementation of IndexOf method", Priority.Medium, Size.Medium, StoryStatus.NotDone, member1);
            Stories.Add(story5);
            board2.WorkItems.Add(story5);
            member1.WorkItems.Add(story5);
            string story5result = HelperMethods.TimeStamp() + story5.ToString() + $" was created in board {board2.Name} and assigned to {member1.Name} with ID {member1.MemberID}";
            story5.History.Add(story5result);
            team1.History.Add(story5result);
            board2.History.Add(story5result);
            member1.History.Add(story5result);

            var story6 = new Story("Creation of RemoveAt method", "Initial implementation of RemoveAt method", Priority.High, Size.Small, StoryStatus.NotDone, member2);
            Stories.Add(story6);
            board1.WorkItems.Add(story6);
            member2.WorkItems.Add(story6);
            string story6result = HelperMethods.TimeStamp() + story6.ToString() + $" was created in board {board1.Name} and assigned to {member2.Name} with ID {member2.MemberID}";
            story6.History.Add(story6result);
            team1.History.Add(story6result);
            board1.History.Add(story6result);
            member2.History.Add(story6result);

            var feedback1 = new Feedback("Implementation of TRIMS", "Assessment of completed implementation of TRIMS", 8, FeedbackStatus.Done);
            Feedbacks.Add(feedback1);
            board1.WorkItems.Add(feedback1);
            string feedback1result = HelperMethods.TimeStamp() + feedback1.ToString() + " was created.";
            team1.History.Add(feedback1result);
            board1.History.Add(feedback1result);
            feedback1.History.Add(feedback1result);

            var feedback2 = new Feedback("Implementation of FlexCube", "Assessment of implementation of FlexCube", 5, FeedbackStatus.Unscheduled);
            Feedbacks.Add(feedback2);
            board3.WorkItems.Add(feedback2);
            string feedback2result = HelperMethods.TimeStamp() + feedback2.ToString() + " was created.";
            team2.History.Add(feedback2result);
            board3.History.Add(feedback2result);
            feedback2.History.Add(feedback2result);

            var feedback3 = new Feedback("Release of new version for BSF", "Yet to be assessed after completion", 1, FeedbackStatus.New);
            Feedbacks.Add(feedback3);
            board5.WorkItems.Add(feedback3);
            string feedback3result = HelperMethods.TimeStamp() + feedback3.ToString() + " was created.";
            team3.History.Add(feedback3result);
            board5.History.Add(feedback3result);
            feedback3.History.Add(feedback3result);
            
            bug7.Comments.Add($"1.{HelperMethods.TimeStamp()} Lachezar", "zaemam se");
            bug7.Comments.Add($"2.{HelperMethods.TimeStamp()} Dimitar", "vuiiiii maniаk");
            bug7.Comments.Add($"3.{HelperMethods.TimeStamp()} Yoanna", "machkai grishoooo");
            bug7.Comments.Add($"4.{HelperMethods.TimeStamp()} Yoanna", "are we, luchkaaa");
            bug7.Comments.Add($"5.{HelperMethods.TimeStamp()} Lachezar", "imam nujda ot oshte 2 dni");
            bug7.Comments.Add($"6.{HelperMethods.TimeStamp()} Dimitar", "po-burzo we kelesh");
                       
        }
    }
}
