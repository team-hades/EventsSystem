namespace EventsSystem.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Security.Claims;
	using System.Threading.Tasks;

	using Microsoft.AspNet.Identity.EntityFramework;
	using Microsoft.AspNet.Identity;

	using Common.Constants;

	public class User : IdentityUser
	{
		// From User Microsofts Identity
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
			// Add custom user claims here
			return userIdentity;
		}
		
		private ICollection<Event> events;

		public User()
		{
			this.events = new HashSet<Event>();
		}

		public UserRole UserRole { get; set; }

		[MaxLength(ValidationConstants.MaxUserFirstName)]
		public string FirstName { get; set; }

		[MaxLength(ValidationConstants.MaxUserLastName)]
		public string LastName { get; set; }

		public string ProfilePictureUrl { get; set; }

		[MaxLength(ValidationConstants.MaxUserShortBio)]
		public string ShortBio { get; set; }

		public virtual ICollection<Event> Events
		{
			get { return this.events; }
			set { this.events = value; }
		}
	}
}
