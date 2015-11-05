using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSystem.Data.Models
{
	public class UserInfo
	{
		private ICollection<Event> events;

		public UserInfo()
		{
			this.events = new HashSet<Event>();
		}

		[Key, ForeignKey("User")]
		public string UserId { get; set; }

		public virtual ICollection<Event> Events
		{
			get { return this.events; }
			set { this.events = value; }
		}

		public virtual User User { get; set; }
	}
}
