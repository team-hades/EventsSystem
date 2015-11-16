namespace EventsSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Event
	{
		private ICollection<User> users;
		private ICollection<Picture> pictures;
		private ICollection<Comment> comments;
		private ICollection<Tag> tags;
        private ICollection<Rating> ratings;

        public Event()
        {
            this.users = new HashSet<User>();
			this.pictures = new HashSet<Picture>();
			this.comments = new HashSet<Comment>();
			this.tags = new HashSet<Tag>();
            this.ratings = new HashSet<Rating>();
        }

		[Key]
		public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxEventName)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxEventShortDescription)]
        public string ShortDescrtiption { get; set; }

        [MaxLength(ValidationConstants.MaxEventLongDescription)]
        public string LongDescrtiption { get; set; }

		public bool IsPrivate { get; set; }

		public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

		public string AuthorId { get; set; }

		public virtual User Author { get; set; }

		public int? CategoryId { get; set; }

		public virtual Category Category { get; set; }

		public int TownId { get; set; }

		public virtual Town Town { get; set; }

		public virtual ICollection<User> Users
		{
			get { return this.users; }
			set { this.users = value; }
		}

		public virtual ICollection<Picture> Pictures
		{
			get { return this.pictures; }
			set { this.pictures = value; }
		}

		public virtual ICollection<Comment> Comments
		{
			get { return this.comments; }
			set { this.comments = value; }
		}

		public virtual ICollection<Tag> Tags
		{
			get { return this.tags; }
			set { this.tags = value; }
		}

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}