namespace EventsSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Event
	{
		private ICollection<User> users;
		private ICollection<Picture> gallery;
		private ICollection<Comment> comments;
		private ICollection<Tag> tags;

		public Event()
        {
            this.users = new HashSet<User>();
			this.gallery = new HashSet<Picture>();
			this.comments = new HashSet<Comment>();
			this.tags = new HashSet<Tag>();
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

		public EventState State { get; set; }

		public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

		public string AuthorId { get; set; }

		public virtual User Author { get; set; }

		public int? PictureId { get; set; }

		public virtual Picture Picture { get; set; }

		public int? CategoryId { get; set; }

		public virtual Category Category { get; set; }

		public int TownId { get; set; }

		public virtual Town Town { get; set; }

		public virtual ICollection<User> Users
		{
			get { return this.users; }
			set { this.users = value; }
		}

		public virtual ICollection<Picture> Gallery
		{
			get { return this.gallery; }
			set { this.gallery = value; }
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
	}
}