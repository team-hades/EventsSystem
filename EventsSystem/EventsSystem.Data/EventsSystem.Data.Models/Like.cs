namespace EventsSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Like
    {
		[Key]
        public int Id { get; set; }

		[Index("IX_EvenAndUserLike", 1, IsUnique = true)]
		public string UserId { get; set; }

        public virtual User User { get; set; }

		[Index("IX_EvenAndUserLike", 2, IsUnique = true)]
		public int EventId { get; set; }

        public virtual Event Event { get; set; }
	}
}
