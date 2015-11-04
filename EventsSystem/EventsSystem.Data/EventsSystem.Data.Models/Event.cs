namespace EventsSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Event
    {
        private ICollection<User> users;

        public Event()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxEventName)]
        public string Name { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxEventShortDescription)]
        public string ShortDescrtiption { get; set; }

        [MaxLength(ValidationConstants.MaxEventLongDescription)]
        public string LongDescrtiption { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public virtual ICollection<User> Users 
        { 
            get { return this.users; } 
            set { this.users = value; } 
        } 
    }
}
