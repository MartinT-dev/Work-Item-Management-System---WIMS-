using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Models
{
   public class Member : IMember
    {
        private static int memberId = 1000;
        private string name;
        private List<IWorkItem> workItems;
        private List<string> history;
        [JsonConstructor]
        public Member()
        {
            this.workItems = new List<IWorkItem>();
            this.history = new List<string>();
            this.MemberID = memberId++;
        }
        public Member(string name)
        {
            this.Name = name;
            this.workItems = new List<IWorkItem>();
            this.history = new List<string>();
            this.MemberID = memberId++;
        }

        public int MemberID { get; }

        public string Name
        {
            get => this.name;
            set 
            {
                this.ValidateName(value);
                this.name = value;
            }
        }
        public IList<IWorkItem> WorkItems { get => this.workItems; }

        public IList<string> History { get => this.history; }

        public override string ToString()
        {
            return $"Member name: {this.Name} with ID {this.MemberID}";
        }

        public void ValidateName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Title can not be null.");
            }
            if (name.Length < 5 || name.Length > 15)
            {
                throw new ArgumentException("Title should be between 5 and 15 symbols.");
            }
        }
    }
}
