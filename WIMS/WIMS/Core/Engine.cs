using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Core.Contracts;
using WIMS.Core.Providers;
using WIMS.Models;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Core
{
    public class Engine : IEngine
    {
        private static IEngine instanceHolder;
        private const string TerminationCommand = "4";
        private const string NullProvidersExceptionMessage = "Cannot be null!";
        private Engine()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
            this.Parser = new CommandParser();

            this.Members = new List<IMember>();
            this.Boards = new List<IBoard>();
            this.Teams = new List<ITeam>();
            this.Bugs = new List<IBug>();
            this.Feedbacks = new List<IFeedback>();
            this.Stories = new List<IStory>();
            //Database.DatabaseMethods.SeedBugs(Bugs);
            //Database.DatabaseMethods.SeedStories(Stories);
            //Database.DatabaseMethods.SeedFeedbacks(Feedbacks);
            //Database.DatabaseMethods.SeedBoards(Boards);
            //Database.DatabaseMethods.SeedMembers(Members);
            //Database.DatabaseMethods.SeedTeams(Teams);
            Database.SeedSample.Seed(Bugs, Feedbacks, Stories, Teams, Members, Boards);
        }
        public static IEngine Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new Engine();
                }

                return instanceHolder;
            }
        }

       
        public IReader Reader { get; set; }

        public IWriter Writer { get; set; }

        public IParser Parser { get; set; }

        public IList<IBug> Bugs { get; private set; }

        public IList<IFeedback> Feedbacks { get; private set; }

        public IList<IStory> Stories { get; private set; }

        public IList<ITeam> Teams { get; private set; }

        public IList<IMember> Members { get; private set; }

        public IList<IBoard> Boards { get; private set; }

        public void Start()
        {
            while (true)
            {
                
                Console.WriteLine($"-----------------------------------------------{Environment.NewLine}" + 
                                  $"|Welcome to WIMS - Work Item Managment System!|{Environment.NewLine}" +
                                  $"-----------------------------------------------{Environment.NewLine}" +
                                  $"  Please enter a valid number for one of the following operations:{Environment.NewLine}" +
                                  $"-Type 1 for creation of new item.{Environment.NewLine}" +
                                  $"-Type 2 for update of existing item.{Environment.NewLine}" +
                                  $"-Type 3 for listing of existing item.{Environment.NewLine}" +
                                  $"-Type 4 for exit.");

                try
                {
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        //Database.DatabaseMethods.SaveBugs(Bugs);
                        //Database.DatabaseMethods.SaveStories(Stories);
                        //Database.DatabaseMethods.SaveFeedbacks(Feedbacks);
                        //Database.DatabaseMethods.SaveBoards(Boards);
                        //Database.DatabaseMethods.SaveMembers(Members);
                        //Database.DatabaseMethods.SaveTeams(Teams);
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                    this.Writer.WriteLine("--------------------------------");
                    Console.WriteLine("Press any key to get back to the main menu");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }
            string commandToBeParsed = "";
            switch(commandAsString)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"    Please enter a valid number for one of the following operations:{Environment.NewLine}" +
                                        $" ------------------------------------------------------{Environment.NewLine}" +
                                  $"-Type 1 for creation of new team.{Environment.NewLine}" +
                                  $"-Type 2 for creation of new member.{Environment.NewLine}" +
                                  $"-Type 3 for creation of new board.{Environment.NewLine}" +
                                  $"-Type 4 for creation of new bug.{Environment.NewLine}" +
                                  $"-Type 5 for creation of new story.{Environment.NewLine}" +
                                  $"-Type 6 for creation of new feedback.{Environment.NewLine}" +
                                  $"-Type 7 for creation of comment.{Environment.NewLine}" +
                                  $"-Type 8 for returnig back to main menu.{Environment.NewLine}");
                    string input = Console.ReadLine();
                    Console.Clear();
                    switch (input)
                    {
                        
                        case "1": commandToBeParsed = "createteam"; break;   
                        case "2": commandToBeParsed = "createmember"; break;
                        case "3": commandToBeParsed = "createboard"; break;
                        case "4": commandToBeParsed = "createbug"; break;
                        case "5": commandToBeParsed = "createstory"; break;
                        case "6": commandToBeParsed = "createfeedback"; break;
                        case "7": commandToBeParsed = "createcomment"; break;
                        case "8": commandToBeParsed = "returntomenu"; break;


                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine($"    Please enter a valid number for one of the following operations:{Environment.NewLine}" +
                                        $" ------------------------------------------------------{Environment.NewLine}" +
                                  $"-Type 1 for update of name.{Environment.NewLine}" +
                                  $"-Type 2 for update of description.{Environment.NewLine}" +
                                  $"-Type 3 for update of steps to reproduce.{Environment.NewLine}" +
                                  $"-Type 4 for update of priority.{Environment.NewLine}" +
                                  $"-Type 5 for update of size.{Environment.NewLine}" +
                                  $"-Type 6 for update of status.{Environment.NewLine}" +
                                  $"-Type 7 for update of severity.{Environment.NewLine}" +
                                  $"-Type 8 for update of rating.{Environment.NewLine}" +
                                  $"-Type 9 for update of assignee.{Environment.NewLine}" +
                                  $"-Type 10 for returnig back to main menu.{Environment.NewLine}");
                    string input2 = Console.ReadLine();
                    Console.Clear();
                    switch (input2)
                    {
                        case "1": commandToBeParsed = "updatename"; break;
                        case "2": commandToBeParsed = "updatedescription"; break;
                        case "3": commandToBeParsed = "updatestepstoreproduce"; break;
                        case "4": commandToBeParsed = "updatepriority"; break;
                        case "5": commandToBeParsed = "updatesize"; break;
                        case "6": commandToBeParsed = "updatestatus"; break;
                        case "7": commandToBeParsed = "updateseverity"; break;
                        case "8": commandToBeParsed = "updaterating"; break;
                        case "9": commandToBeParsed = "updateassignee"; break;
                        case "10": commandToBeParsed = "returntomenu"; break;
                    }
                    break;
                    
                case "3":
                    Console.Clear();
                    Console.WriteLine($"    Please enter a valid number for one of the following operations:{Environment.NewLine}" +
                                        $" ------------------------------------------------------{Environment.NewLine}" +
                                  $"-Type 1 for listing teams.{Environment.NewLine}" +
                                  $"-Type 2 for listing members.{Environment.NewLine}" +
                                  $"-Type 3 for listing team boards.{Environment.NewLine}" +
                                  $"-Type 4 for listing bugs.{Environment.NewLine}" +
                                  $"-Type 5 for listing stories.{Environment.NewLine}" +
                                  $"-Type 6 for listing feedbacks.{Environment.NewLine}" +
                                  $"-Type 7 for listing team activity.{Environment.NewLine}" +
                                  $"-Type 8 for listing member activity.{Environment.NewLine}" +
                                  $"-Type 9 for listing board activity.{Environment.NewLine}" +
                                  $"-Type 10 for listing comments to a workitem.{Environment.NewLine}" +
                                  $"-Type 11 for listing work items in a specific order.{Environment.NewLine}" +
                                  $"-Type 12 for listing filtered work items.{Environment.NewLine}" +
                                  $"-Type 13 for returnig back to main menu.{ Environment.NewLine}");
                    string input3 = Console.ReadLine();
                    Console.Clear();
                    switch (input3)
                    {

                        case "1": commandToBeParsed = "listteams"; break;
                        case "2": commandToBeParsed = "listmembers"; break;
                        case "3": commandToBeParsed = "listboards"; break;
                        case "4": commandToBeParsed = "listbugs"; break;
                        case "5": commandToBeParsed = "liststories"; break;
                        case "6": commandToBeParsed = "listfeedbacks"; break; 
                        case "7": commandToBeParsed = "listteamactivity"; break; 
                        case "8": commandToBeParsed = "listmemberactivity"; break; 
                        case "9": commandToBeParsed = "listboardactivity"; break; 
                        case "10": commandToBeParsed = "listcomments"; break;
                        case "11": commandToBeParsed = "listworkitemssorted"; break;
                        case "12": commandToBeParsed = "listworkitemsfiltered"; break;
                        case "13": commandToBeParsed = "returntomenu"; break;


                    }
                    break;

                   
                case "4":
                    Console.Clear();
                    //help menu;
                    break;
              
            }

            var command = this.Parser.ParseCommand(commandToBeParsed);

            var executionResult = command.Execute();
            this.Writer.WriteLine(executionResult);
            this.Writer.WriteLine("--------------------------------");
            Console.WriteLine("Press any key to get back to the main menu");
            Console.ReadKey();
            Console.Clear();

        }

    }
}
