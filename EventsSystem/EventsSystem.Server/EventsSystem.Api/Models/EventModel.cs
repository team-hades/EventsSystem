namespace EventsSystem.Api.Models
{
	using System;
	using EventsSystem.Data.Models;

	public class EventModel
	{
		public string Name { get; set; }

		public string ShortDescrtiption { get; set; }

		public bool IsPrivate { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public virtual Town Town { get; set; }
	}
}