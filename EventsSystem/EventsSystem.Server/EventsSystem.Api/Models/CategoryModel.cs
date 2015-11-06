using EventsSystem.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsSystem.Api.Models
{
	public class CategoryModel
	{
		[Required]
		[MinLength(ValidationConstants.MinCategoryNameLenght)]
		[MaxLength(ValidationConstants.MaxCategoryNameLenght)]
		public string Name { get; set; }
	}
}