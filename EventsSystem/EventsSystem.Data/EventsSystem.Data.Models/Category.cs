namespace EventsSystem.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using Common.Constants;

	public class Category
	{
		private ICollection<Event> events;

		public Category()
		{
			this.events = new HashSet<Event>();
		}

		public int Id { get; set; }

		[MinLength(ValidationConstants.MinCategoryNameLenght)]
		[MaxLength(ValidationConstants.MaxCategoryNameLenght)]
		public string Name { get; set; }

		public string AuthorId { get; set; }

		public virtual User Author { get; set; }

		public virtual ICollection<Event> Events
		{
			get { return this.events; }
			set { this.events = value; }
		}
	}
}
