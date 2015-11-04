namespace EventsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Common.Constants;

    public class Tag
    {
        private ICollection<Event> events;

        public Tag()
        {
            this.events = new HashSet<Event>();
        }

        public int Id { get; set; }

        [MinLength(ValidationConstants.MinTagNameLenght)]
        [MaxLength(ValidationConstants.MaxTagNameLenght)]
        public string Name { get; set; }

        public virtual ICollection<Event> Events
		{
			get { return this.events; }
			set { this.events = value; }
		}
	}
}
