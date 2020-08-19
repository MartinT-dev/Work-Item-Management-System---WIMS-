using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Models.WorkItems.Abstract
{
    public abstract class WorkItem : IWorkItem
    {
        private static int id=1;
        private string title;
        private string description;
        private Dictionary<string, string> comments;
        private List<string> history;

        public WorkItem()
        {

        }
        public WorkItem(string title, string description)
        {
            this.Title = title;
            this.Description = description;
            this.comments = new Dictionary<string, string>();
            this.history = new List<string>();
            this.ID = id++;
        }
        
        public int ID { get; }
        public string Title 
        { 
            get => this.title;
            set 
            {
                this.ValidateTitle(value);
                this.title = value;
            }
        }
        public string Description
        {
            get => this.description;
            set
            {
                this.ValidateDescription(value);
                this.description = value;
            }
        }
        public IDictionary<string, string> Comments { get => this.comments; }
        public IList<string> History { get => this.history; }

        public override string ToString()
        {
            return $"{this.GetType().Name}:{this.Title} with ID {this.ID}";        
        }

        public void ValidateTitle(string title)
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
        public void ValidateDescription(string description)
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

        
    }
}
