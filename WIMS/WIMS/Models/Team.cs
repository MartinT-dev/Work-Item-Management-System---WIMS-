using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS.Core.Contracts;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems.Abstract;

namespace WIMS.Models
{
    public class Team : ITeam
    {
        private string name;
        private List<IMember> members;
        private List<IBoard> boards;
        private List<string> history;
        [JsonConstructor]
        public Team()
        {
            this.boards = new List<IBoard>();
            this.members = new List<IMember>();
            this.history = new List<string>();
        }

        public Team(string name)
        {
            this.Name = name;
            this.boards = new List<IBoard>();
            this.members = new List<IMember>();
            this.history = new List<string>();

        }
        public string Name
        {
            get => name;
            set
            {
                this.ValidateName(value);
                this.name = value;
            }
        }

        public IList<IBoard> Boards { get => this.boards; }
        public IList<IMember> Members { get => this.members; }

        public IList<string> History { get => this.history; }

        public override string ToString()
        {
            return $"- Team: {this.Name}";
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
