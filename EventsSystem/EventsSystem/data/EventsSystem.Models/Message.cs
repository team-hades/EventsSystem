namespace EventsSystem.Models
{
    using System;

    public class Message
    {
        public int Id { get; set;}

        public int Content { get; set;}

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
