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
		private const string InitialPictureUrl = @"http://velin.wendi101.com/wp-content/uploads/2013/02/blog_image-ninja.jpg";
		private Picture InitialPicture;

		// From User Microsofts Identity
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
			// Add custom user claims here
			return userIdentity;
		}
		
		private ICollection<Event> events;
		private ICollection<Comment> comments;

		public User()
		{
			InitialPicture = new Picture { Url = InitialPictureUrl };
            this.events = new HashSet<Event>();
			this.comments = new HashSet<Comment>();
			this.Picture = InitialPicture;
		}

		public UserRole UserRole { get; set; }

		[MaxLength(ValidationConstants.MaxUserFirstName)]
		public string FirstName { get; set; }

		[MaxLength(ValidationConstants.MaxUserLastName)]
		public string LastName { get; set; }
		
		[MaxLength(ValidationConstants.MaxUserShortBio)]
		public string ShortBio { get; set; }

		public int PictureId { get; set; }

		public virtual Picture Picture { get; set; }

		public virtual ICollection<Event> Events
		{
			get { return this.events; }
			set { this.events = value; }
		}

		public virtual ICollection<Comment> Comments
		{
			get { return this.comments; }
			set { this.comments = value; }
		}
	}
}
