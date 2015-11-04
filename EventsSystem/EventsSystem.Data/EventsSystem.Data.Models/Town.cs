using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSystem.Data.Models
{
	public class Town
	{
		private ICollection<Event> events;

		public Town()
		{
			this.events = new HashSet<Event>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(2)]
		[MaxLength(50)]
		[Index(IsUnique = true)]
		public string Name { get; set; }

		public virtual ICollection<Event> Events
		{
			get { return this.events; }
			set { this.events = value; }
		}
	}
}
