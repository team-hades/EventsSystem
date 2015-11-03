namespace EventsSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class Message
    {
        public int Id { get; set;}

        [Required]
        [MinLength(ValidationConstants.MinContentLenght)]
        [MaxLength(ValidationConstants.MaxContentLenght)]
        public int Content { get; set;}

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
