namespace EventsSystem.Data.Models
{
    public class Like
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
