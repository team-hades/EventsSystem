using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsSystem.Api.Models.Towns
{
	public class TownSaveModel
	{
		[Required]
		[MinLength(2)]
		[MaxLength(50)]
		public string Name { get; set; }
	}
}