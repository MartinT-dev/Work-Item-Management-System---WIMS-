using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Commands.Contracts;
using WIMS.Core.Contracts;
using WIMS.Core.Factories;
using WIMS.Models;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Commands.Update
{
    public class UpdateNameCommand : ICommand
    {
        private readonly IWIMSFactory factory;
        private readonly IEngine engine;

        public UpdateNameCommand(IWIMSFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute()
        {
            Console.WriteLine("Please select what name should be changed:" + Environment.NewLine +
            $"Type 1 for team.{Environment.NewLine}" +
            $"Type 2 for member.{Environment.NewLine}" +
            $"Type 3 for board.{Environment.NewLine}" +
            $"Type 4 for bug, story or feedback.");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Please enter the name of the team that you wish to change:");
                    Console.WriteLine("List of teams:" + Environment.NewLine + HelperMethods.ListTeams(this.engine.Teams));
                    string teamName1 = Console.ReadLine();
                    bool ifExists1 = HelperMethods.IfExists(teamName1, engine.Teams);
                    if (ifExists1 == false)
                    {
                        return $"Team with name {teamName1} does not exist.";
                    }
                    Console.Clear();
                    Console.WriteLine("Please enter the new name of the team that you wish to change:");
                    string newNameTeam = Console.ReadLine();
                    HelperMethods.ValidateTeamName(newNameTeam);
                    string result = HelperMethods.TimeStamp() + $"Team {teamName1} changed it's name to {newNameTeam}";
                    ITeam team1 = HelperMethods.ReturnExisting(teamName1, engine.Teams);
                    team1.Name = newNameTeam;
                    team1.History.Add(result);
                    return result;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Please enter the id of the member that you wish to change:");
                    Console.WriteLine("List of Members:" + Environment.NewLine + HelperMethods.ListMembers(this.engine.Members));
                    int memberId2 = int.Parse(Console.ReadLine());
                    bool ifMemberExists2 = HelperMethods.IfExists(memberId2, engine.Members);
                    if (ifMemberExists2 == false)
                    {
                        return $"Member with id {memberId2} does not exist.";
                    }
                    IMember member2 = HelperMethods.ReturnExisting(memberId2, engine.Members);
                    Console.Clear();
                    Console.WriteLine("Please enter the new name of the member that you wish to change:");
                    string newNameMember2 = Console.ReadLine();
                    HelperMethods.ValidateMemberName(newNameMember2);
                    string result2 = HelperMethods.TimeStamp() + $"Member with id {member2.MemberID} changed it's name to {newNameMember2}";
                    member2.Name = newNameMember2;
                    member2.History.Add(result2);

                    ITeam team2 = HelperMethods.GetTeam(member2, engine.Teams);
                    team2.History.Add(result2);
                    return result2;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Please enter team of the board:");
                    Console.WriteLine("List of teams:" + Environment.NewLine + HelperMethods.ListTeams(this.engine.Teams));
                    string teamName3 = Console.ReadLine();
                    bool ifTeamExists3 = HelperMethods.IfExists(teamName3, engine.Teams);
                    if (ifTeamExists3 == false)
                    {
                        return "Team with such name does not exist.";
                    }
                    ITeam teamToBeAssigned3 = HelperMethods.ReturnExisting(teamName3, engine.Teams);
                    Console.Clear();
                    Console.WriteLine("Please enter the name of the board that you wish to change:");
                    Console.WriteLine($"List of boards in team {teamToBeAssigned3.Name}:" + Environment.NewLine + HelperMethods.ListBoards(teamToBeAssigned3.Boards));
                    string boardName3 = Console.ReadLine();
                    bool ifBoardExists3 = HelperMethods.IfExists(boardName3, teamToBeAssigned3.Boards);
                    if (ifBoardExists3 == false)
                    {
                        return $"Board with name {boardName3} does not exist in team {teamToBeAssigned3.Name}.";
                    }
                    IBoard board3 = HelperMethods.ReturnExisting(boardName3, teamToBeAssigned3.Boards);
                    Console.Clear();
                    Console.WriteLine("Please enter the new name of the board that you wish to change:");
                    string boardNewName3 = Console.ReadLine();
                    HelperMethods.ValidateBoardName(boardNewName3);
                    string result3 = HelperMethods.TimeStamp() + $"Board {boardName3} in team {teamToBeAssigned3.Name} changed it's name to {boardNewName3}";
                    board3.Name = boardNewName3;
                    board3.History.Add(result3);
                    teamToBeAssigned3.History.Add(result3);
                    return result3;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Please enter the name of the team responsible for this workitem:");
                    Console.WriteLine("List of teams:" + Environment.NewLine + HelperMethods.ListTeams(this.engine.Teams));
                    string teamName4 = Console.ReadLine();
                    bool ifTeamExists4 = HelperMethods.IfExists(teamName4, engine.Teams);
                    if (ifTeamExists4 == false)
                    {
                        return "Team with such name does not exist.";
                    }
                    ITeam teamToBeAssigned4 = HelperMethods.ReturnExisting(teamName4, engine.Teams);
                    Console.Clear();
                    Console.WriteLine("Please enter board where the workitem features:");
                    Console.WriteLine("List of boards:" + Environment.NewLine + HelperMethods.ListBoards(teamToBeAssigned4.Boards));
                    string boardName4 = Console.ReadLine();
                    bool ifBoardExists4 = HelperMethods.IfExists(boardName4, teamToBeAssigned4.Boards);
                    if (ifBoardExists4 == false)
                    {
                        return $"Board with name {boardName4} does not exist in team {teamToBeAssigned4.Name}.";
                    }
                    IBoard boardToBeAssigned4 = HelperMethods.ReturnExisting(boardName4, teamToBeAssigned4.Boards);
                    Console.Clear();
                    Console.WriteLine("Please enter the id of the workitem that you wish to change:");
                    Console.WriteLine($"List of workitems in team {boardToBeAssigned4.Name}:" + Environment.NewLine + HelperMethods.ListWorkItems(boardToBeAssigned4.WorkItems));
                    int workItemName4 = int.Parse(Console.ReadLine());
                    bool ifWorkItemExists4 = HelperMethods.IfExists(workItemName4, boardToBeAssigned4.WorkItems);
                    if (ifWorkItemExists4 == false)
                    {
                        return $"WorkItem with id {workItemName4} does not exist in board {boardToBeAssigned4.Name}.";
                    }
                    IWorkItem workItem4 = HelperMethods.ReturnExisting(workItemName4, boardToBeAssigned4.WorkItems);
                    Console.Clear();
                    Console.WriteLine("Please enter the new name of the workItem that you wish to change:");
                    string workItemNewName4 = Console.ReadLine();
                    HelperMethods.ValidateWorkItemTitle(workItemNewName4);
                    string result4 = HelperMethods.TimeStamp() + $"WorkItem with id {workItemName4} changed it's name to {workItemNewName4}";
                    workItem4.Title = workItemNewName4;
                    workItem4.History.Add(result4);
                    boardToBeAssigned4.History.Add(result4);
                    teamToBeAssigned4.History.Add(result4);
                    if (workItem4 is IAssignableItem)
                    {
                        foreach (var item in teamToBeAssigned4.Members)
                        {
                            if (item.WorkItems.Contains(workItem4))
                            {
                                item.History.Add(result4);
                                break;
                            }
                        }
                    }
                    return result4;
                default: return "invalid command";         
            }
        }
    }
}
