using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Database
{
    public static class DatabaseMethods
    {
        public static void SeedBugs(IList<IBug> bugs)
        {
            if (!bugs.Any())
            {
                string json = File.ReadAllText(@"../../../Bugs.json");
                var seededBugs = JsonConvert.DeserializeObject<List<IBug>>(json);

                foreach (var bug in seededBugs)
                {
                    bugs.Add(bug);
                }
            }
        }
        public static void SeedStories(IList<IStory> stories)
        {
            if (!stories.Any())
            {
                string json = File.ReadAllText(@"../../../Stories.json");
                var seededStories = JsonConvert.DeserializeObject<List<IStory>>(json);

                foreach (var story in seededStories)
                {
                    stories.Add(story);
                }
            }
        }
        public static void SeedFeedbacks(IList<IFeedback> feedbacks)
        {
            if (!feedbacks.Any())
            {
                string json = File.ReadAllText(@"../../../Feedbacks.json");
                var seededFeedbacks = JsonConvert.DeserializeObject<List<IFeedback>>(json);

                foreach (var feedback in seededFeedbacks)
                {
                    feedbacks.Add(feedback);
                }
            }
        }
        public static void SeedTeams(IList<ITeam> teams)
        {
            if (!teams.Any())
            {
                string json = File.ReadAllText(@"../../../Teams.json");
                var seededTeams = JsonConvert.DeserializeObject<List<ITeam>>(json);

                foreach (var team in seededTeams)
                {
                    teams.Add(team);
                }
            }
        }
        public static void SeedBoards(IList<IBoard> boards)
        {
            if (!boards.Any())
            {
                string json = File.ReadAllText(@"../../../Boards.json");
                var seededBoards = JsonConvert.DeserializeObject<List<IBoard>>(json);

                foreach (var board in seededBoards)
                {
                    boards.Add(board);
                }
            }
        }
        public static void SeedMembers(IList<IMember> members)
        {
            if (!members.Any())
            {
                string json = File.ReadAllText(@"../../../Members.json");
                var seededMembers = JsonConvert.DeserializeObject<List<IMember>>(json);

                foreach (var member in seededMembers)
                {
                    members.Add(member);
                }
            }
        }
        public static void SaveBugs(IList<IBug> bugs)
        {
            var convertedJson = JsonConvert.SerializeObject(bugs, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects});
            File.WriteAllText(@"../../../Bugs.json", convertedJson);
        }
        public static void SaveStories(IList<IStory> stories)
        {
            var convertedJson = JsonConvert.SerializeObject(stories, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@"../../../Stories.json", convertedJson);
        }
        public static void SaveFeedbacks(IList<IFeedback> feedbacks)
        {
            var convertedJson = JsonConvert.SerializeObject(feedbacks, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@"../../../Feedbacks.json", convertedJson);
        }
        public static void SaveTeams(IList<ITeam> teams)
        {
            var convertedJson = JsonConvert.SerializeObject(teams, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@"../../../Teams.json", convertedJson);
        }
        public static void SaveBoards(IList<IBoard> boards)
        {
            var convertedJson = JsonConvert.SerializeObject(boards, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@"../../../Boards.json", convertedJson);
        }
        public static void SaveMembers(IList<IMember> members)
        {
            var convertedJson = JsonConvert.SerializeObject(members, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            File.WriteAllText(@"../../../Members.json", convertedJson);
        }
    }
}
