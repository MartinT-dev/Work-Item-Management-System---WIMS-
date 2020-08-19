using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Models.Contracts;
using WIMS.Models.WorkItems.Abstract;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Models
{
    public class Board : IBoard
    {
        private string name;
        private readonly List<IWorkItem> workItems;
        private readonly List<string> history;
        [JsonConstructor]
        public Board()
        {
            this.workItems = new List<IWorkItem>();
            this.history = new List<string>();
        }
        public Board(string name)
        {
            this.Name = name;
            this.workItems = new List<IWorkItem>();
            this.history = new List<string>();
            
        }
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
            return $"Board: {this.Name}";
        }

        public void ValidateName(string name)
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


    }
}
