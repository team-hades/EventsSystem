namespace EventsSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    // TODO: User Microsofts Identity?
    public class User
    {
        private ICollection<Event> events;

        public User()
        {
            this.events = new HashSet<Event>();
        }

        public UserRole UserRole { get; set; }

        [MaxLength(ValidationConstants.MaxUserFirstName)]
        public string FirstName { get; set; }

        [MaxLength(ValidationConstants.MaxUserLastName)]
        public string LastName { get; set; }

        public string ProfilePictureUrl { get; set; }

        [MaxLength(ValidationConstants.MaxUserShortBio)]
        public string ShortBio { get; set; }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }
    }
}
