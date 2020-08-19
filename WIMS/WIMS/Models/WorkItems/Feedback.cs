using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WIMS.Models.Enums;
using WIMS.Models.WorkItems.Abstract;
using WIMS.Models.WorkItems.Contracts;

namespace WIMS.Models.WorkItems
{
    public class Feedback : WorkItem, IFeedback
    {
        private int rating;
        [JsonConstructor]
        public Feedback()
        {

        }

        public Feedback(string title, string description, int rating, FeedbackStatus status)
            : base(title, description)
        {
            this.Rating = rating;
            this.Status = status;
        }
        public int Rating 
        { 
            get => this.rating;
            set 
            {
                this.ValidateRating(value);
                this.rating = value;
            }
            }
        public FeedbackStatus Status { get; set; }

        public void ValidateRating(int rating)
        {
            if (rating < 1 || rating > 10)
            {
                throw new ArgumentException("Rating should be a number between 1 and 10.");
            }
        }
    }
}
