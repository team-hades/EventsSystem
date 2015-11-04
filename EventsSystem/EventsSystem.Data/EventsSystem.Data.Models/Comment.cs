namespace EventsSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Comment
    {
        public int Id { get; set;}

        [Required]
        [MinLength(ValidationConstants.MinContentLenght)]
        [MaxLength(ValidationConstants.MaxContentLenght)]
        public int Content { get; set;}

        public DateTime DateCreated { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

		// TODO: is this really a Guid?! Kenov beshe pokazval che mai ne e Guid ami e string
        public Guid AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
