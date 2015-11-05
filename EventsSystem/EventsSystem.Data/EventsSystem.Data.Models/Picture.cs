using System.ComponentModel.DataAnnotations;

namespace EventsSystem.Data.Models
{
	public class Picture
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(5000)]
		public string Url { get; set; }

		[Required]
		[MinLength(1)]
		[MaxLength(6)]
		public string Extension { get; set; }

		[Required]
		[MinLength(1)]
		[MaxLength(100)]
		public string InitialName { get; set; }
	}
}
